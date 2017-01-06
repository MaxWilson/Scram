#if INTERACTIVE
#r "bin\\Debug\\Fable.Core.dll"
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Import.PIXI
#load "Fable.Import.Pixi.v4.fs"
#load "Utils.fs"
#else
module Behavior
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Import.PIXI
#endif
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

module RobotImpl =
    type Direction = | Left | Right | Up | Down
    let TurnLeft = function Left -> Down | Down -> Right | Right -> Up | Up -> Left
    let TurnRight = function Right -> Down | Down -> Left | Left -> Up | Up -> Right
    let RotationAngle = function Right -> 90. | Down -> 180. | Left -> 270. | Up -> 0.

type Robot(image: string, map: TerrainMap, computeInstructions: unit -> Behavior list) =
    let legalStarts = mapIndexes map Start |> List.ofSeq
    let mutable m = -1
    let mutable n = -1
    let mutable Direction = RobotImpl.Direction.Up
    let mutable Instructions = []
    let sp = Sprite.fromImage(image) |> unbox<MoveableSprite>
    let updateDest() =
        sp.xdest <- top + (float n * tilesize) + 32.
        sp.ydest <- left + (float m * tilesize) + 32.
    let place() =
        if m < 0 && n < 0 then
            let m', n' = randomPick legalStarts
            m <- m'
            n <- n'
            updateDest()
    do
        sp.anchor <- Point(0.5, 0.5)
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
    member this.Think() =
        // when at rest and no instructions, get new instructions
        if sp.xdest = sp.position.x && sp.ydest = sp.position.y then
            match Instructions with
            | [] -> Instructions <- computeInstructions()
            | _ -> ()
    member this.Update() =
        if sp.xdest = sp.position.x && sp.ydest = sp.position.y then
            match Instructions with
            | [] -> ()
            | currentInstruction :: rest ->
                Instructions <- rest
                match currentInstruction with
                | Behavior.Left ->
                    Direction <- RobotImpl.TurnLeft Direction
                    sp.rotation <- RobotImpl.RotationAngle Direction
                | Behavior.Right ->
                    Direction <- RobotImpl.TurnRight Direction
                    sp.rotation <- RobotImpl.RotationAngle Direction
                | Forward ->
                    let bound n = if n < 0 then 0 elif n > 9 then 9 else n
                    match Direction with
                    | RobotImpl.Left ->
                        n <- bound(n - 1)
                    | RobotImpl.Right ->
                        n <- bound(n + 1)
                    | RobotImpl.Up ->
                        m <- bound(m - 1)
                    | RobotImpl.Down ->
                        m <- bound(m + 1)
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

let alienBrain() =
    [Forward;Left]
let unicornBrain() =
    if Keys.pressed.Contains(Keys.Left) then [Left; Forward]
    elif Keys.pressed.Contains(Keys.Right) then [Right; Forward]
    elif Keys.pressed.Contains(Keys.Up) then [Forward]
    else [Left; Forward; Right; Forward;Forward;Forward;Forward;Left]

let robots = [
                Robot("aliancorn.png", Data.level1, alienBrain);
                Robot("Unicorn.png", Data.level1, unicornBrain)
                ]

let onStart (stage: Container) =
    Scram.Map.renderLevel stage Data.level1
    addText stage "Level 1" "blue" "red"
    ()

let everySecond stage =
    //addText stage "Attack!"
    ()

let onClick (stage, e: InteractionEvent) =
    //r.SetDest(e)
    //addText stage "Scream, Run, Hide!" "blue" "black"
    //addAliancorn stage
    ()



