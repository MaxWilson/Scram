module Map

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Import.PIXI
open Data
open Utils

let tilesize = 64.
let top,left = 20., 20.
let bottom,right = 20.+(tilesize*10.),20.+(tilesize*10.)

type MoveableSprite() =
    inherit Sprite()
    member val xdest = (0.) with get, set
    member val ydest = (0.) with get, set

let makeAnimation(url, size: int, spritecoords: (int * int) list) =
    let texture = Texture.fromImage(url)
    let frames = spritecoords |> List.map (fun (x,y) -> Texture(texture, Rectangle(float x, float y, float size, float size))) |> ResizeArray
    let movie = PIXI.extras.MovieClip(frames)
    movie.gotoAndPlay(unbox (random frames.Count - 1))
    movie

let lava (stage: Container) (x, y) =
    let lava = makeAnimation("Lava.png", 128, [2,114;132,114;262,114;392,114;522,114;652,114;782,114;2,244;132,244;262,244;392,244])
    lava.position <- Point(x, y)
    lava.scale <- Point(0.5, 0.5)
    lava.animationSpeed <- 0.2
    stage.addChild(lava) |> ignore

let ground (stage: Container) (x, y) =
    let g = Graphics(position=Point(x, y))
    // brown square
    g.beginFill(float 0x8B4513).drawRect(0., 0., tilesize, tilesize).endFill() |> ignore
    stage.addChild(g)
    |> ignore

let spikes (stage: Container) (x, y) =
    ground stage (x, y)
    let s = Sprite.fromImage (sprintf "spike%d.png" (random 4))
    s.position <- Point(x,y)
    stage.addChild(s)
    |> ignore

let mutable currentLevel : TerrainMap = Unchecked.defaultof<TerrainMap>

let renderLevel (stage: Container) (level : TerrainMap) =
    let gr = Graphics()
    gr.beginFill(float 0xFFFFFF).lineStyle(3., float 0x000000)
        .drawRect(top, left, bottom-top, right-left)
        .endFill()
        |> ignore
    stage.addChild(gr) |> ignore
    for m in 0..level.Length - 1 do
        let row = level.[m]
        for n in 0..row.Length - 1 do
            // convert x, y to pixels
            let coords = top + (float n * tilesize), left + (float m * tilesize)
            match row.[n] with
            | TerrainType.Lava ->
                lava stage coords
            | TerrainType.Spikes ->
                spikes stage coords
            | _ ->
                ground stage coords

type Robot(image: string, map: TerrainMap) =
    let legalStarts = mapIndexes map Start |> List.ofSeq
    let mutable m = -1
    let mutable n = -1
    let sp = Sprite.fromImage(image) |> unbox<MoveableSprite>
    let updateDest() =
        sp.ydest <- top + (float n * tilesize) + 32.
        sp.xdest <- left + (float m * tilesize) + 32.
    let place() =
        if m < 0 && n < 0 then
            let m', n' = randomPick legalStarts
            m <- m'
            n <- n'
            updateDest()
    let destinations = [
        200., 200.
        500., 200.
        300., 300.
    ]
    let mutable destIndex = 0
    do
        sp.anchor <- Point(0.5, 0.5)
    member this.Coords = m, n
    member this.IsDead =
        match map.[m].[n] with
        | TerrainType.Spikes -> true
        | TerrainType.Lava -> true
        | _ -> false
    member this.PlaceOnMap(c: Container) =
        place()
        c.addChild(sp) |> ignore
    member this.Update() =
        if sp.xdest = sp.position.x && sp.ydest = sp.position.y then
            let (x, y) = destinations.[destIndex]
            sp.xdest <- x
            sp.ydest <- y
            destIndex <- (destIndex + 1) % 3
        else
            let distx = sp.xdest - sp.position.x
            let disty = sp.ydest - sp.position.y
            let scale n =
                if n > 10. then 10.
                elif n < -10. then -10.
                else n
            sp.position.x <- sp.position.x + scale distx
            sp.position.y <- sp.position.y + scale disty
