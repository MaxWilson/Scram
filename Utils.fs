module Utils
open Fable.Core
open System

/// Returns a number between 1 and n
[<Emit("Math.floor(Math.random() * $0) + 1")>]
let random(n:int) =
    let r = new Random();
    r.Next(n) + 1

// Returns a number between 0 and n
[<Emit("Math.random() * $0")>]
let randomRational(n:float) =
    let r = new Random();
    r.NextDouble() * n

let randomPick (vals: 't list) =
    vals.[(random vals.Length) - 1]

module Keys =
    let mutable pressed = System.Collections.Generic.List<_>()
    Fable.Import.Browser.document.addEventListener_keydown(fun ke -> pressed.Add(ke.keyCode |> int); unbox ())
    Fable.Import.Browser.document.addEventListener_keyup(fun ke -> (if (pressed.Contains (ke.keyCode |> int)) then pressed.Remove(ke.keyCode |> int) |> ignore); unbox ())
    let Left = 37
    let Right = 39
    let Up = 38
    let Down = 40
    let Enter = 13
