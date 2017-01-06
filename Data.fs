module Data

open System.Collections.Generic

type TerrainType = Lava | Spikes | Ground | Start | Treasure
type TerrainMap = TerrainType[][]
let parseMap (input: string) : TerrainType[][] =
    let rows = input.Trim().Split() |> Array.filter (fun x -> x.Length > 0)
    let rows = rows |> Array.map(fun str -> seq { for x in str.Trim() do yield (match x with '^' -> Spikes | '-' -> Lava | 'X' -> Treasure | 'S' -> Start | _ -> Ground) } |> Array.ofSeq)
    rows

let levels =
    [
    """
    ...^..^X..
    ......-...
    .--.....^^
    .-...-..^.
    ...^..^...
    -..---^^^.
    .......-..
    ..-....-.^
    ......--..
    .S.....S..
    """
    """
    ...^..^...
    ......-...
    .--.....^^
    .--..-..^.
    ...^^^^X..
    -..---^^^.
    .......-..
    ..-....-.^
    ......--..
    ...-...^S.
    """
    """
    ...^..^^S.
    ......-...
    .--.....^^
    X-...-..^.
    -..^..^S..
    -..---^^^.
    ....-..-..
    ..-.-S.-.^
    ....-.--..
    ..........
    """
    ] |> List.map parseMap


let mapIndexes (map: TerrainMap) (t: TerrainType) =
    seq {
        for x in 0..map.Length - 1 do
            let row = map.[x]
            for y in 0..map.Length - 1 do
                if row.[y] = t then
                    yield (x,y)
    }

type Event = Button1 | Button2

type Direction = | Left | Right | Up | Down
    with
    static member TurnLeft = function Direction.Left -> Direction.Down | Direction.Down -> Direction.Right | Direction.Right -> Direction.Up | Direction.Up -> Direction.Left
    static member TurnRight = function Direction.Right -> Direction.Down | Direction.Down -> Direction.Left | Direction.Left -> Direction.Up | Direction.Up -> Direction.Right
type Location = Frontof of Location | Leftof of Location | Rightof of Location | Backof of Location | Me
type TileVal = On of Location | In of Location | To of Location | Lava | Spikes | Clear
type Predicate = Is of TileVal * TileVal | When of Event
type Behavior =
    | Left
    | Right
    | Smash
    | Forward
    | Hop of int
    | Time of int * Behavior
    | Seek
    | If of Predicate * Behavior * Behavior
    | Say of string
    | Do of Behavior list
type BehaviorState = Succeeded | Failed | Active
type Execution = { Proceed: SpawnFunc -> BehaviorState; Print: unit -> string }
    and SpawnFunc = (Behavior -> Execution)
type Scope() =
    let vals = Dictionary<string, obj>()
    member this.Get(key: string) =
        match vals.TryGetValue(key) with
        | true, v -> v :?> 't |> Some
        | _ -> None
    member this.Set(key: string, value: 't) = vals.[key] <- value
    // convenience helper for ubiquitous operation
    member this.GetChild() = this.Get<Execution>("child")
    // convenience helper for ubiquitous operation
    member this.SetChild v = this.Set<Execution>("child", v)
    member this.Init(key, defaultVal: unit -> 't) =
        match this.Get(key) with
        | Some(v) -> ()
        | None -> this.Set(key, defaultVal())

let defer x = fun() -> x

let rec spawner bhv =
    let scope = Scope()
    { Proceed = execute scope bhv; Print = fun() -> print scope bhv }
and execute (scope: Scope) behavior (spawn: SpawnFunc) =
    match behavior with
    | Say(msg) ->
        printfn "%s" msg
        Succeeded
    | Time(time, bhv) ->
        let endTime = "endTime"
        let createChild() =
            let child = spawn bhv
            match child.Proceed(spawner) with
            | Succeeded -> Succeeded
            | Failed -> Failed
            | Active ->
                scope.SetChild(child)
                Active
        scope.Init(endTime, defer (System.DateTime.Now.AddMilliseconds (float time)))
        if System.DateTime.Now < scope.Get(endTime).Value then
            let rec executeChild() =
                let child =
                    match scope.GetChild() with
                    | None ->
                        let child = spawn bhv
                        scope.SetChild(child)
                        child
                    | Some(child) -> child
                match child.Proceed(spawner) with
                | Active -> Active
                | Succeeded ->
                    executeChild() // loop until time is up
                | Failed -> Failed
            executeChild()
        else
            Succeeded
    | Do(bhvs) ->
        let key = "index";
        scope.Init(key, defer 0)
        let rec nextChild() =
            let currentIndex = scope.Get(key).Value
            if currentIndex = bhvs.Length then
                Succeeded
            else
                let child = spawn bhvs.[currentIndex]
                scope.Set(key, currentIndex + 1)
                match child.Proceed(spawner) with
                | Active ->
                    scope.SetChild(child)
                    Active
                | Failed -> Failed
                | Succeeded -> nextChild()
        let executeChild() =
            match scope.GetChild() with
            | None -> nextChild()
            | Some(child) ->
                match child.Proceed(spawner) with
                | Active -> Active
                | Failed -> Failed
                | Succeeded ->
                    nextChild()
        executeChild()
    | _ -> failwith "not implemented"
and print (scope: Scope) behavior =
    match behavior with
    | Time(time, bhv) ->
        let childprint =
            match scope.GetChild() with
            | None -> sprintf "%A" bhv
            | Some(v) -> v.Print()
        sprintf "TIME(%d, %s)" time childprint
    | Say(msg) ->
        sprintf "SAY(%s)" msg
    | Do(bhvs) ->
        match scope.Get("index") with
        | None -> sprintf "%A" behavior
        | Some(index) ->
            let behaviors = bhvs |> List.mapi (fun i bhv -> if i = index then scope.GetChild().Value.Print() else sprintf "%A" bhv)
            sprintf "DO [%s\t]" (System.String.Join("\n", behaviors))
    | _ -> failwith "not implemented"

let count = ref 0
let rec loopToCompletion execution =
    incr count
    match execution.Proceed(spawner) with
    | Succeeded | Failed as st -> ()
    | _ as st ->
        printfn "%d %s" (!count) (execution.Print())
        loopToCompletion execution

let peek(map : TerrainType[][], mn:int*int, (currentFacing: Direction), (loc: Location)) =
    let move (m, n) = function
    | Direction.Up -> m-1, n
    | Direction.Left -> m, n-1
    | Direction.Right -> m, n+1
    | Direction.Down -> m+1, n
    let left = (function
        | Direction.Up -> Direction.Left
        | Direction.Left -> Direction.Down
        | Direction.Down -> Direction.Right
        | Direction.Right -> Direction.Up)
    let right = (function
        | Direction.Up -> Direction.Right
        | Direction.Right -> Direction.Down
        | Direction.Down -> Direction.Left
        | Direction.Left-> Direction.Up)

    let rec findCoords c =
        function
        | Me -> c
        | Frontof(rest) ->
            move (findCoords c rest) (currentFacing)
        | Backof(rest) ->
            move (findCoords c rest) (left (left currentFacing))
        | Leftof(rest) ->
            move (findCoords c rest) (left currentFacing)
        | Rightof(rest) ->
            move (findCoords c rest) (right currentFacing)

    let m',n' = findCoords mn loc
    let bounded upper x = 0 <= x && x < upper
    if map <> null && bounded map.Length m' && bounded map.[m'].Length n' then
        // start states count as ground
        match map.[m'].[n'] with
        | TerrainType.Start -> TerrainType.Ground
        | x -> x
        |> Some
    else
        None

