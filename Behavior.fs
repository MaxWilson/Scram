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

let addText (stage: Container) msg =
    let text =
        Fable.Import.PIXI.Text(
            msg,
            [
            TextStyle.Font "bold italic 24px Arial"
            TextStyle.Fill (U2.Case1 "orange")
            TextStyle.Align "center"
            TextStyle.Stroke (U2.Case1 "blue")
            TextStyle.StrokeThickness 7.
            ], position=Point(randomRational 500., randomRational 500.))
    stage.addChild(text)
    |> ignore

let addSmallText (stage: Container) msg =
    let colors = ["red";"yellow";"blue";"black"]
    let text =
        Fable.Import.PIXI.Text(
            msg,
            [
            TextStyle.Font "bold italic 12px"
            TextStyle.Fill (U2.Case1 colors.[(random colors.Length)-1])
            TextStyle.Align "center"
            TextStyle.Stroke (U2.Case1 colors.[(random colors.Length)-1])
            TextStyle.StrokeThickness 7.
            ], position=Point(randomRational 500., randomRational 500.))
    stage.addChild(text)
    |> ignore


let onStart stage =
    addText stage "Hello"
    ()

let everySecond stage =
    addSmallText stage "I'm a fish"
    ()

let onClick stage =
    //addText stage "Goodbye!"
    //addUnicorn stage
    ()