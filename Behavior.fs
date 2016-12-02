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

let r = Map.Robot("aliancorn.png", Data.level1)
let onStart (stage: Container) =
    Map.renderLevel stage Data.level1
    addText stage "Invade" "blue" "red"
    addText stage "Planet" "orange" "purple"
    addText stage "Earth" "red" "green"
    r.PlaceOnMap(stage)
    ()

let everySecond stage =
    //addText stage "Attack!"
    r.Update()
    ()

let onClick (stage, e: InteractionEvent) =
    r.SetDest(e)
    //addText stage "Scream, Run, Hide!" "blue" "black"
    //addAliancorn stage
    ()