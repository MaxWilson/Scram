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
        robots |> List.iter (fun r -> r.PlaceOnMap stage)
        stage.interactive <- true
        stage.on_click (fun e -> onClick(stage, e)) |> ignore
        stage.on_tap (fun e -> onClick(stage, e)) |> ignore
        let mutable timestamp = 0.
        let rec animate(dt:float) =
            robots |> List.iter (fun r -> r.Update())
            if dt - timestamp > 1000. then
                timestamp <- dt
                everySecond(stage)
                robots |> List.iter (fun r -> r.Think())
            animate_id <- window.requestAnimationFrame(FrameRequestCallback animate)
            renderer.render(stage)
        animate 0. // start a pixi animation loop

[<Pojo>]
type DisplayBoxState = { box: PixiBox }

// create a PIXI box with an animation loop
type DisplayBox() =
    inherit React.Component<Stub, DisplayBoxState>(stub)
    let mutable canvasContainer = null
    member this.render() =
        R.div [ClassName "game-canvas-container"; Ref (fun x -> canvasContainer <- (x :?> HTMLElement))][]
    member this.componentDidMount() =
        let box = PixiBox(canvasContainer)
        this.setState({box=box})
        box.Setup()
    member this.componentWillUnmount() =
        this.state.box.Destroy()

let RobotApp() = R.div [Style [Height 1000]] [
                    R.com<DisplayBox,_,_>(stub)[]
                    ]
