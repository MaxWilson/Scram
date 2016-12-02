module Components

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Import.PIXI
open Fable.Import.React
open Behavior

module R = Fable.Helpers.React
open R.Props

[<Pojo>]
type Stub = { stub: int }
let stub = { stub=0 }

let mutable speed = 10
type PixiBox(canvasContainer: HTMLElement) =
    let mutable animate_id = 0.
    let renderer = Globals.autoDetectRenderer(canvasContainer.clientWidth, canvasContainer.clientHeight, [RendererOptions.BackgroundColor (float 0x1099bb); Resolution 1.; Transparent true]) |> unbox<SystemRenderer>
    member this.Destroy() =
        canvasContainer.removeChild(renderer.view) |> ignore
        window.cancelAnimationFrame animate_id
    member this.Setup() =
        canvasContainer.appendChild(renderer.view) |> ignore
        let stage = Container()
        onStart stage
        stage.interactive <- true
        stage.on_click (fun e -> onClick(stage)) |> ignore
        let mutable timestamp = 0.
        let rec animate(dt:float) =
            if dt - timestamp > 10. then
                timestamp <- dt
                everySecond(stage)
            animate_id <- window.requestAnimationFrame(FrameRequestCallback animate)
            renderer.render(stage)
        animate 0. // start a pixi animation loop

let mutable box = Unchecked.defaultof<PixiBox>

// create a PIXI box with an animation loop
type DisplayBox() =
    inherit React.Component<Stub, Stub>(stub)
    let mutable canvasContainer = null
    member this.render() =
        R.div [ClassName "game-canvas-container"; Ref (fun x -> canvasContainer <- (x :?> HTMLElement))][]
    member this.componentDidMount() =
        box <- PixiBox(canvasContainer)
        box.Setup()
    member this.componentWillUnmount() =
        box.Destroy()

type App() =
    inherit Component<Stub, Stub>(stub)
    member this.render() =
        R.div [Style [Height 1000]] [
            R.com<DisplayBox,_,_>(stub)[]
            ]
