module Robot

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Import.PIXI
open Utils
open Data
open Scram.Map

let rec addUnicorn (container: Container) =
    let p = Sprite.fromImage "https://www.ethereum.org/images/unicorn.png"
    p.anchor.x <- 0.5
    p.anchor.y <- 0.5
    let scale = JS.Math.random() + 0.25
    p.position.x <- randomRational 400.
    p.position.y <- randomRational 400.
    p.scale <- Point(scale, scale)
    p?velocity <- scale
    let onclick() =
        addUnicorn(container)
        p?velocity <- (p?velocity |> unbox<float>) * -1. + (JS.Math.random() * 0.20 - 0.10)
        p.scale.x <- p.scale.x * -1. // flip pic but not text
    p.on_click (fun e -> onclick()) |> ignore
    p.on_tap(fun e -> onclick()) |> ignore
    p.interactive <- true
    container.addChild(p) |> ignore

let addText (stage: Container) msg color1 color2 =
    let text =
        Fable.Import.PIXI.Text(
            msg,
            [
            TextStyle.Font "bold italic 24px Arial"
            TextStyle.Fill (U2.Case1 color1)
            TextStyle.Align "center"
            TextStyle.Stroke (U2.Case1 color2)
            TextStyle.StrokeThickness 7.
            ], position=Point(randomRational 500., randomRational 500.))
    stage.addChild(text)
    |> ignore

let RotationAngle = function Direction.Right -> 0. | Direction.Down -> Math.PI/2. | Direction.Left -> Math.PI | Direction.Up -> -Math.PI/2.

type Robot(image: string, map: TerrainMap, computeInstructions: Robot -> Behavior list) =
    let legalStarts = mapIndexes map Start |> List.ofSeq
    let mutable m = -1
    let mutable n = -1
    let mutable direction = Direction.Up
    let mutable Instructions = []
    let mutable isDead = false
    let mutable isWinner = false
    let scream = Audio.Create("Scream.mp3")
    let sp = Sprite.fromImage(image) |> unbox<MoveableSprite>
    let updateDest() =
        sp.xdest <- top + (float n * tilesize) + 32.
        sp.ydest <- left + (float m * tilesize) + 32.
    let place() =
        let m', n' = randomPick legalStarts
        m <- m'
        n <- n'
        updateDest() // set destination to legalStart
        // should be at rest on its destination
        sp.x <- sp.xdest
        sp.y <- sp.ydest
        // reset rotation
        direction <- Direction.Up
        sp.rotation <- RotationAngle direction
        isDead <- false
        isWinner <- false
        sp.scale <- Point(1., 1.)
    do
        sp.anchor <- Point(0.5, 0.5)
    member this.IsWinner = isWinner
    member this.SetDest(e : InteractionEvent) =
        let d = e.data |> unbox<interaction.InteractionData>
        let pos = d.``global``
        sp.xdest <- pos.x
        sp.ydest <- pos.y
        ()
    member this.Coords = m, n
    member this.IsDead =
        match map.[m].[n] with
        | TerrainType.Spikes -> true
        | TerrainType.Lava -> true
        | _ -> false
    member this.PlaceOnMap(c: Container) =
        place()
        c.addChild(sp) |> ignore
    member this.EverySecond() =
        // come back to life if necessary
        if isDead then
            place()

        // when at rest and no instructions, get new instructions
        if sp.xdest = sp.position.x && sp.ydest = sp.position.y then
            if List.isEmpty Instructions then
                Instructions <- computeInstructions this
    member this.Peek(location:Location) =
        Data.peek(map, (m,n), direction, location)
    member this.Update() =
        if isDead then
            () // do nothing
        elif sp.xdest = sp.position.x && sp.ydest = sp.position.y then
            // if at rest on a deadly spot, then die
            if Scram.Map.isDeadly m n then
                scream.play()
                isDead <- true
                sp.scale <- Point(1.5, 1.5)
            elif Scram.Map.isTreasure m n then
                isWinner <- true
                sp.scale <- Point(1.5, 1.5)
            else
                match Instructions with
                | [] -> ()
                | currentInstruction :: rest ->
                    Instructions <- rest
                    match currentInstruction with
                    | Behavior.Left ->
                        direction <- Direction.TurnLeft direction
                        sp.rotation <- RotationAngle direction
                    | Behavior.Right ->
                        direction <- Direction.TurnRight direction
                        sp.rotation <- RotationAngle direction
                    | Forward ->
                        let bound max n = if n < 0 then 0 elif n > max then max else n
                        match direction with
                        | Direction.Left ->
                            n <- bound (map.[m].Length) (n - 1)
                        | Direction.Right ->
                            n <- bound (map.[m].Length) (n + 1)
                        | Direction.Up ->
                            m <- bound (map.Length) (m - 1)
                        | Direction.Down ->
                            m <- bound (map.Length) (m + 1)
                        updateDest()
                    | _ -> ()
        else
            let distx = sp.xdest - sp.position.x
            let disty = sp.ydest - sp.position.y
            let scale a b =
                let c = sqrt(a*a + b*b)
                if c < 10. then
                    a
                else
                    10. * a / c
            sp.position.x <- sp.position.x + scale distx disty
            sp.position.y <- sp.position.y + scale disty distx

let KLeft = 37
let KRight = 39
let KUp = 38
let KDown = 40
let KEnter = 13

let alienBrain (robot:Robot) =
    // Go right if you can UNLESS that leaves empty space on your right (because we don't want U-turns), otherwise go forward, or turn left
    match robot.Peek(Rightof(Me)) with
    | Some(TerrainType.Treasure) | Some(TerrainType.Ground) when (match robot.Peek(Backof(Rightof(Me))) with Some(TerrainType.Treasure) | Some(TerrainType.Ground) -> false | _ -> true) ->
        [Right; Forward]
    | _ ->
        match robot.Peek(Frontof(Me)) with
        | Some(TerrainType.Treasure) | Some(TerrainType.Ground) -> [Forward]
        | _ -> [Left]

let unicornBrain (robot: Robot) =
    let k = Keys.pressed
    if k.Contains KLeft then [Left]
    elif k.Contains KRight then [Right]
    elif k.Contains KUp then [Forward]
    elif k.Contains KDown then [Right; Right; Forward]
    else []


let mutable robots = []
let mutable levelCount = 0
let setupNewLevel (stage : Container) =
    stage.removeChildren() |> ignore
    levelCount <- levelCount + 1
    Scram.Map.nextLevel()
    let lvl = Scram.Map.currentLevel
    robots <- [
                Robot("aliancorn.png", lvl, alienBrain);
                Robot("Unicorn.png", lvl, unicornBrain)
                ]
    Scram.Map.renderLevel stage lvl
    addText stage (sprintf "Level %d" levelCount) "blue" "red"
    robots |> List.iter (fun r -> r.PlaceOnMap stage)


let onStart (stage: Container) =
    setupNewLevel stage

let onClick (stage, e: InteractionEvent) =
    ()



