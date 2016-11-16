#if DEBUG
module Behavior
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Import.PIXI
#else
#r "bin\\Debug\\Fable.Core.dll"
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Import.PIXI
#load "Fable.Import.Pixi.v4.fs"
#load "Utils.fs"
#endif
open Utils

let x = random 10

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

let makeAnimation(url, size: int, spritecoords: (int * int) list) =
    let texture = Texture.fromImage(url)
    let frames = spritecoords |> List.map (fun (x,y) -> Texture(texture, Rectangle(float x, float y, float size, float size))) |> ResizeArray
    let movie = PIXI.extras.MovieClip(frames)
    movie.gotoAndPlay(unbox (random frames.Count - 1))
    movie

let lava (stage: Container) x y =
    let lava = makeAnimation("Lava.png", 128, [2,114;132,114;262,114;392,114;522,114;652,114;782,114;2,244;132,244;262,244;392,244])
    lava.position <- Point(x, y)
    lava.scale <- Point(0.5, 0.5)
    lava.animationSpeed <- 0.2
    stage.addChild(lava) |> ignore

let onStart stage =
    addText stage "Hello" "blue" "red"
    addText stage "World" "orange" "purple"
    lava stage 330. 220.
    lava stage (330.+64.) 220.
    ()

let everySecond stage =
    //addText stage "Hello again!"
    ()

let onClick stage =
    //addText stage "Goodbye!"
    //addUnicorn stage
    ()