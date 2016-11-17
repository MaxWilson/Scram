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
