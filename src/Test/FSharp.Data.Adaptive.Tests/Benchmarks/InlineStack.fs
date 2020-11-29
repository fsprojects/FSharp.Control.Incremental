﻿namespace Benchmarks

open FSharp.Data.Adaptive
open System
open System.Collections
open System.Collections.Generic
open BenchmarkDotNet.Attributes
open Microsoft.FSharp.NativeInterop
open System.Runtime.InteropServices



module private InlineStackUtilities =
    
    let inline get (ref : byref<'T>) =
        let v = ref
        ref <- Unchecked.defaultof<'T>
        v


[<NoComparison; NoEquality>]
type InlineStack16<'T> =
    struct
        [<DefaultValue(false)>]
        val mutable public Rest : list<'T>
        [<DefaultValue(false)>]
        val mutable public E0 : 'T
        [<DefaultValue(false)>]
        val mutable public E1 : 'T
        [<DefaultValue(false)>]
        val mutable public E2 : 'T
        [<DefaultValue(false)>]
        val mutable public E3 : 'T
        [<DefaultValue(false)>]
        val mutable public E4 : 'T
        [<DefaultValue(false)>]
        val mutable public E5 : 'T
        [<DefaultValue(false)>]
        val mutable public E6 : 'T
        [<DefaultValue(false)>]
        val mutable public E7 : 'T
        [<DefaultValue(false)>]
        val mutable public E8 : 'T
        [<DefaultValue(false)>]
        val mutable public E9 : 'T
        [<DefaultValue(false)>]
        val mutable public E10 : 'T
        [<DefaultValue(false)>]
        val mutable public E11 : 'T
        [<DefaultValue(false)>]
        val mutable public E12 : 'T
        [<DefaultValue(false)>]
        val mutable public E13 : 'T
        [<DefaultValue(false)>]
        val mutable public E14 : 'T
        [<DefaultValue(false)>]
        val mutable public E15 : 'T
        [<DefaultValue(false)>]
        val mutable public Count : int

        member inline x.Push(value : 'T) =
            match x.Count with
            | 0 -> x.E0 <- value
            | 1 -> x.E1 <- value
            | 2 -> x.E2 <- value
            | 3 -> x.E3 <- value
            | 4 -> x.E4 <- value
            | 5 -> x.E5 <- value
            | 6 -> x.E6 <- value
            | 7 -> x.E7 <- value
            | 8 -> x.E8 <- value
            | 9 -> x.E9 <- value
            | 10 -> x.E10 <- value
            | 11 -> x.E11 <- value
            | 12 -> x.E12 <- value
            | 13 -> x.E13 <- value
            | 14 -> x.E14 <- value
            | 15 -> x.E15 <- value
            | _ -> 
                if isNull (x.Rest :> obj) then x.Rest <- [value]
                else x.Rest <- value :: x.Rest

            x.Count <- x.Count + 1

        member inline x.Pop() =
            let c = x.Count
            if c <= 0 then raise <| System.IndexOutOfRangeException()
            x.Count <- c - 1

            match c with
            | 1 -> InlineStackUtilities.get &x.E0
            | 2 -> InlineStackUtilities.get &x.E1
            | 3 -> InlineStackUtilities.get &x.E2
            | 4 -> InlineStackUtilities.get &x.E3
            | 5 -> InlineStackUtilities.get &x.E4
            | 6 -> InlineStackUtilities.get &x.E5
            | 7 -> InlineStackUtilities.get &x.E6
            | 8 -> InlineStackUtilities.get &x.E7
            | 9 -> InlineStackUtilities.get &x.E8
            | 10 -> InlineStackUtilities.get &x.E9
            | 11 -> InlineStackUtilities.get &x.E10
            | 12 -> InlineStackUtilities.get &x.E11
            | 13 -> InlineStackUtilities.get &x.E12
            | 14 -> InlineStackUtilities.get &x.E13
            | 15 -> InlineStackUtilities.get &x.E14
            | 16 -> InlineStackUtilities.get &x.E15
            | _ ->
                if isNull (x.Rest :> obj) then failwith "invalid state"
                let h = List.head x.Rest
                x.Rest <- List.tail x.Rest
                h
    end

[<NoComparison; NoEquality>]
type InlineStack12<'T> =
    struct
        [<DefaultValue(false)>]
        val mutable public Rest : list<'T>
        [<DefaultValue(false)>]
        val mutable public E0 : 'T
        [<DefaultValue(false)>]
        val mutable public E1 : 'T
        [<DefaultValue(false)>]
        val mutable public E2 : 'T
        [<DefaultValue(false)>]
        val mutable public E3 : 'T
        [<DefaultValue(false)>]
        val mutable public E4 : 'T
        [<DefaultValue(false)>]
        val mutable public E5 : 'T
        [<DefaultValue(false)>]
        val mutable public E6 : 'T
        [<DefaultValue(false)>]
        val mutable public E7 : 'T
        [<DefaultValue(false)>]
        val mutable public E8 : 'T
        [<DefaultValue(false)>]
        val mutable public E9 : 'T
        [<DefaultValue(false)>]
        val mutable public E10 : 'T
        [<DefaultValue(false)>]
        val mutable public E11 : 'T
        [<DefaultValue(false)>]
        val mutable public Count : int

        member inline x.Push(value : 'T) =
            match x.Count with
            | 0 -> x.E0 <- value
            | 1 -> x.E1 <- value
            | 2 -> x.E2 <- value
            | 3 -> x.E3 <- value
            | 4 -> x.E4 <- value
            | 5 -> x.E5 <- value
            | 6 -> x.E6 <- value
            | 7 -> x.E7 <- value
            | 8 -> x.E8 <- value
            | 9 -> x.E9 <- value
            | 10 -> x.E10 <- value
            | 11 -> x.E11 <- value
            | _ -> 
                if isNull (x.Rest :> obj) then x.Rest <- [value]
                else x.Rest <- value :: x.Rest
            x.Count <- x.Count + 1

        member inline x.Pop() =
            let c = x.Count
            if c <= 0 then raise <| System.IndexOutOfRangeException()
            x.Count <- c - 1
            match c with
            | 1 -> InlineStackUtilities.get &x.E0
            | 2 -> InlineStackUtilities.get &x.E1
            | 3 -> InlineStackUtilities.get &x.E2
            | 4 -> InlineStackUtilities.get &x.E3
            | 5 -> InlineStackUtilities.get &x.E4
            | 6 -> InlineStackUtilities.get &x.E5
            | 7 -> InlineStackUtilities.get &x.E6
            | 8 -> InlineStackUtilities.get &x.E7
            | 9 -> InlineStackUtilities.get &x.E8
            | 10 -> InlineStackUtilities.get &x.E9
            | 11 -> InlineStackUtilities.get &x.E10
            | 12 -> InlineStackUtilities.get &x.E11
            | _ ->
                if isNull (x.Rest :> obj) then failwith "invalid state"
                let h = List.head x.Rest
                x.Rest <- List.tail x.Rest
                h
    end


[<NoComparison; NoEquality>]
type InlineStack8<'T> =
    struct
        [<DefaultValue(false)>]
        val mutable public Rest : list<'T>
        [<DefaultValue(false)>]
        val mutable public E0 : 'T
        [<DefaultValue(false)>]
        val mutable public E1 : 'T
        [<DefaultValue(false)>]
        val mutable public E2 : 'T
        [<DefaultValue(false)>]
        val mutable public E3 : 'T
        [<DefaultValue(false)>]
        val mutable public E4 : 'T
        [<DefaultValue(false)>]
        val mutable public E5 : 'T
        [<DefaultValue(false)>]
        val mutable public E6 : 'T
        [<DefaultValue(false)>]
        val mutable public E7 : 'T
        [<DefaultValue(false)>]
        val mutable public Count : int

        member inline x.Push(value : 'T) =
            match x.Count with
            | 0 -> x.E0 <- value
            | 1 -> x.E1 <- value
            | 2 -> x.E2 <- value
            | 3 -> x.E3 <- value
            | 4 -> x.E4 <- value
            | 5 -> x.E5 <- value
            | 6 -> x.E6 <- value
            | 7 -> x.E7 <- value
            | _ -> 
                if isNull (x.Rest :> obj) then x.Rest <- [value]
                else x.Rest <- value :: x.Rest
            x.Count <- x.Count + 1

        member inline x.Pop() =
            let c = x.Count
            if c <= 0 then raise <| System.IndexOutOfRangeException()
            x.Count <- c - 1
            match c with
            | 1 -> InlineStackUtilities.get &x.E0
            | 2 -> InlineStackUtilities.get &x.E1
            | 3 -> InlineStackUtilities.get &x.E2
            | 4 -> InlineStackUtilities.get &x.E3
            | 5 -> InlineStackUtilities.get &x.E4
            | 6 -> InlineStackUtilities.get &x.E5
            | 7 -> InlineStackUtilities.get &x.E6
            | 8 -> InlineStackUtilities.get &x.E7
            | _ ->
                if isNull (x.Rest :> obj) then failwith "invalid state"
                let h = List.head x.Rest
                x.Rest <- List.tail x.Rest
                h
    end
    
[<NoComparison; NoEquality>]
type InlineStack4<'T> =
    struct
        [<DefaultValue(false)>]
        val mutable public Rest : list<'T>
        [<DefaultValue(false)>]
        val mutable public E0 : 'T
        [<DefaultValue(false)>]
        val mutable public E1 : 'T
        [<DefaultValue(false)>]
        val mutable public E2 : 'T
        [<DefaultValue(false)>]
        val mutable public E3 : 'T
        [<DefaultValue(false)>]
        val mutable public Count : int

        member inline x.Push(value : 'T) =
            match x.Count with
            | 0 -> x.E0 <- value
            | 1 -> x.E1 <- value
            | 2 -> x.E2 <- value
            | 3 -> x.E3 <- value
            | _ -> 
                if isNull (x.Rest :> obj) then x.Rest <- [value]
                else x.Rest <- value :: x.Rest
            x.Count <- x.Count + 1

        member inline x.Pop() =
            let c = x.Count
            if c <= 0 then raise <| System.IndexOutOfRangeException()
            x.Count <- c - 1
            match c with
            | 1 -> InlineStackUtilities.get &x.E0
            | 2 -> InlineStackUtilities.get &x.E1
            | 3 -> InlineStackUtilities.get &x.E2
            | 4 -> InlineStackUtilities.get &x.E3
            | _ ->
                if isNull (x.Rest :> obj) then failwith "invalid state"
                let h = List.head x.Rest
                x.Rest <- List.tail x.Rest
                h
    end
    
[<NoComparison; NoEquality>]
type InlineStack2<'T> =
    struct
        [<DefaultValue(false)>]
        val mutable public Rest : list<'T>
        [<DefaultValue(false)>]
        val mutable public E0 : 'T
        [<DefaultValue(false)>]
        val mutable public E1 : 'T
        [<DefaultValue(false)>]
        val mutable public Count : int

        member inline x.Push(value : 'T) =
            match x.Count with
            | 0 -> x.E0 <- value
            | 1 -> x.E1 <- value
            | _ -> 
                if isNull (x.Rest :> obj) then x.Rest <- [value]
                else x.Rest <- value :: x.Rest
            x.Count <- x.Count + 1

        member inline x.Pop() =
            let c = x.Count
            if c <= 0 then raise <| System.IndexOutOfRangeException()
            x.Count <- c - 1
            match c with
            | 1 -> InlineStackUtilities.get &x.E0
            | 2 -> InlineStackUtilities.get &x.E1
            | _ ->
                if isNull (x.Rest :> obj) then failwith "invalid state"
                let h = List.head x.Rest
                x.Rest <- List.tail x.Rest
                h
    end



type internal MapExtEnumerator0<'Key, 'Value when 'Key : comparison> =
    struct
        val mutable public _Stack : list<MapExtImplementation.MapTree<'Key, 'Value>>
        val mutable public _Root : MapExtImplementation.MapTree<'Key, 'Value>
        val mutable public _Current : KeyValuePair<'Key, 'Value>


        member x.MoveNext() =
            match x._Stack with
            | MapExtImplementation.MapEmpty :: _ ->
                failwith "invalid state"

            | MapExtImplementation.MapOne(k, v) :: rest ->
                x._Stack <- rest
                x._Current <- KeyValuePair(k, v)
                true
            | MapExtImplementation.MapNode(k, v, l, r, _, _) :: rest ->
                x._Stack <- rest
                match l with
                | MapExtImplementation.MapEmpty ->
                    x._Current <- KeyValuePair(k,v)
                    match r with
                    | MapExtImplementation.MapEmpty -> ()
                    | _ -> x._Stack <- r :: x._Stack
                    true
                | MapExtImplementation.MapOne(lk, lv) ->
                    x._Current <- KeyValuePair(lk, lv)
                    match r with
                    | MapExtImplementation.MapEmpty -> ()
                    | _ -> x._Stack <- r :: x._Stack
                    x._Stack <- MapExtImplementation.MapOne(k, v) :: x._Stack
                    true
                | l ->
                    match r with
                    | MapExtImplementation.MapEmpty -> ()
                    | _ -> x._Stack <- r :: x._Stack
                    x._Stack <- MapExtImplementation.MapOne(k, v) :: x._Stack
                    x._Stack <- l :: x._Stack
                    x.MoveNext()
            | [] ->
                false

        member x.Current = x._Current

        member x.Reset() = 
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- []
            match x._Root with
            | MapExtImplementation.MapEmpty -> ()
            | r -> x._Stack <- r :: x._Stack

        member x.Dispose() =
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- []
            x._Root <- MapExtImplementation.MapEmpty
            
        interface IEnumerator with
            member x.MoveNext() = x.MoveNext()
            member x.Reset() = x.Reset()
            member x.Current = x.Current :> obj

        interface IEnumerator<KeyValuePair<'Key, 'Value>> with
            member x.Current = x.Current
            member x.Dispose() = x.Dispose()

        new(map : MapExt<'Key, 'Value>) =
            {
                _Current = Unchecked.defaultof<_>
                _Stack = (match map.Tree with | MapExtImplementation.MapEmpty -> [] | _ -> [map.Tree])
                _Root = map.Tree
            }


    end


type internal MapExtEnumerator2<'Key, 'Value when 'Key : comparison> =
    struct
        val mutable public _Stack : InlineStack2<MapExtImplementation.MapTree<'Key, 'Value>>
        val mutable public _Root : MapExtImplementation.MapTree<'Key, 'Value>
        val mutable public _Current : KeyValuePair<'Key, 'Value>


        member x.MoveNext() =
            if x._Stack.Count > 0 then
                match x._Stack.Pop() with
                | MapExtImplementation.MapEmpty ->
                    failwith "invalid state"
                | MapExtImplementation.MapOne(k, v) ->
                    x._Current <- KeyValuePair(k, v)
                    true
                | MapExtImplementation.MapNode(k, v, l, r, _, _) ->
                    match l with
                    | MapExtImplementation.MapEmpty ->
                        x._Current <- KeyValuePair(k,v)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        true
                    | MapExtImplementation.MapOne(lk, lv) ->
                        x._Current <- KeyValuePair(lk, lv)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        true
                    | l ->
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        x._Stack.Push l
                        x.MoveNext()
            else
                false

        member x.Current = x._Current

        member x.Reset() = 
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack2()
            match x._Root with
            | MapExtImplementation.MapEmpty -> ()
            | r -> x._Stack.Push r

        member x.Dispose() =
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack2()
            x._Root <- MapExtImplementation.MapEmpty
            
        interface IEnumerator with
            member x.MoveNext() = x.MoveNext()
            member x.Reset() = x.Reset()
            member x.Current = x.Current :> obj

        interface IEnumerator<KeyValuePair<'Key, 'Value>> with
            member x.Current = x.Current
            member x.Dispose() = x.Dispose()

        new(map : MapExt<'Key, 'Value>) =
            let mutable stack = Unchecked.defaultof<InlineStack2<_>>
            match map.Tree with
            | MapExtImplementation.MapEmpty -> ()
            | r -> stack.Push r
            {
                _Current = Unchecked.defaultof<_>
                _Stack = stack
                _Root = map.Tree
            }


    end

    
type internal MapExtEnumerator4<'Key, 'Value when 'Key : comparison> =
    struct
        val mutable public _Stack : InlineStack4<MapExtImplementation.MapTree<'Key, 'Value>>
        val mutable public _Root : MapExtImplementation.MapTree<'Key, 'Value>
        val mutable public _Current : KeyValuePair<'Key, 'Value>


        member x.MoveNext() =
            if x._Stack.Count > 0 then
                match x._Stack.Pop() with
                | MapExtImplementation.MapEmpty ->
                    failwith "invalid state"
                | MapExtImplementation.MapOne(k, v) ->
                    x._Current <- KeyValuePair(k, v)
                    true
                | MapExtImplementation.MapNode(k, v, l, r, _, _) ->
                    match l with
                    | MapExtImplementation.MapEmpty ->
                        x._Current <- KeyValuePair(k,v)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        true
                    | MapExtImplementation.MapOne(lk, lv) ->
                        x._Current <- KeyValuePair(lk, lv)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        true
                    | l ->
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        x._Stack.Push l
                        x.MoveNext()
            else
                false

        member x.Current = x._Current

        member x.Reset() = 
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack4()
            match x._Root with
            | MapExtImplementation.MapEmpty -> ()
            | r -> x._Stack.Push r

        member x.Dispose() =
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack4()
            x._Root <- MapExtImplementation.MapEmpty
            
        interface IEnumerator with
            member x.MoveNext() = x.MoveNext()
            member x.Reset() = x.Reset()
            member x.Current = x.Current :> obj

        interface IEnumerator<KeyValuePair<'Key, 'Value>> with
            member x.Current = x.Current
            member x.Dispose() = x.Dispose()

        new(map : MapExt<'Key, 'Value>) =
            let mutable stack = Unchecked.defaultof<InlineStack4<_>>
            match map.Tree with
            | MapExtImplementation.MapEmpty -> ()
            | r -> stack.Push r
            {
                _Current = Unchecked.defaultof<_>
                _Stack = stack
                _Root = map.Tree
            }

    end
    
    
type internal MapExtEnumerator8<'Key, 'Value when 'Key : comparison> =
    struct
        val mutable public _Stack : InlineStack8<MapExtImplementation.MapTree<'Key, 'Value>>
        val mutable public _Root : MapExtImplementation.MapTree<'Key, 'Value>
        val mutable public _Current : KeyValuePair<'Key, 'Value>


        member x.MoveNext() =
            if x._Stack.Count > 0 then
                match x._Stack.Pop() with
                | MapExtImplementation.MapEmpty ->
                    failwith "invalid state"
                | MapExtImplementation.MapOne(k, v) ->
                    x._Current <- KeyValuePair(k, v)
                    true
                | MapExtImplementation.MapNode(k, v, l, r, _, _) ->
                    match l with
                    | MapExtImplementation.MapEmpty ->
                        x._Current <- KeyValuePair(k,v)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        true
                    | MapExtImplementation.MapOne(lk, lv) ->
                        x._Current <- KeyValuePair(lk, lv)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        true
                    | l ->
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        x._Stack.Push l
                        x.MoveNext()
            else
                false

        member x.Current = x._Current

        member x.Reset() = 
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack8()
            match x._Root with
            | MapExtImplementation.MapEmpty -> ()
            | r -> x._Stack.Push r

        member x.Dispose() =
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack8()
            x._Root <- MapExtImplementation.MapEmpty
            
        interface IEnumerator with
            member x.MoveNext() = x.MoveNext()
            member x.Reset() = x.Reset()
            member x.Current = x.Current :> obj

        interface IEnumerator<KeyValuePair<'Key, 'Value>> with
            member x.Current = x.Current
            member x.Dispose() = x.Dispose()

        new(map : MapExt<'Key, 'Value>) =
            let mutable stack = Unchecked.defaultof<InlineStack8<_>>
            match map.Tree with
            | MapExtImplementation.MapEmpty -> ()
            | r -> stack.Push r
            {
                _Current = Unchecked.defaultof<_>
                _Stack = stack
                _Root = map.Tree
            }

    end
    
    
    
type internal MapExtEnumerator12<'Key, 'Value when 'Key : comparison> =
    struct
        val mutable public _Stack : InlineStack12<MapExtImplementation.MapTree<'Key, 'Value>>
        val mutable public _Root : MapExtImplementation.MapTree<'Key, 'Value>
        val mutable public _Current : KeyValuePair<'Key, 'Value>


        member x.MoveNext() =
            if x._Stack.Count > 0 then
                match x._Stack.Pop() with
                | MapExtImplementation.MapEmpty ->
                    failwith "invalid state"
                | MapExtImplementation.MapOne(k, v) ->
                    x._Current <- KeyValuePair(k, v)
                    true
                | MapExtImplementation.MapNode(k, v, l, r, _, _) ->
                    match l with
                    | MapExtImplementation.MapEmpty ->
                        x._Current <- KeyValuePair(k,v)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        true
                    | MapExtImplementation.MapOne(lk, lv) ->
                        x._Current <- KeyValuePair(lk, lv)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        true
                    | l ->
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        x._Stack.Push l
                        x.MoveNext()
            else
                false

        member x.Current = x._Current

        member x.Reset() = 
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack12()
            match x._Root with
            | MapExtImplementation.MapEmpty -> ()
            | r -> x._Stack.Push r

        member x.Dispose() =
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack12()
            x._Root <- MapExtImplementation.MapEmpty
            
        interface IEnumerator with
            member x.MoveNext() = x.MoveNext()
            member x.Reset() = x.Reset()
            member x.Current = x.Current :> obj

        interface IEnumerator<KeyValuePair<'Key, 'Value>> with
            member x.Current = x.Current
            member x.Dispose() = x.Dispose()

        new(map : MapExt<'Key, 'Value>) =
            let mutable stack = Unchecked.defaultof<InlineStack12<_>>
            match map.Tree with
            | MapExtImplementation.MapEmpty -> ()
            | r -> stack.Push r
            {
                _Current = Unchecked.defaultof<_>
                _Stack = stack
                _Root = map.Tree
            }

    end
        
    
type internal MapExtEnumerator16<'Key, 'Value when 'Key : comparison> =
    struct
        val mutable public _Stack : InlineStack16<MapExtImplementation.MapTree<'Key, 'Value>>
        val mutable public _Root : MapExtImplementation.MapTree<'Key, 'Value>
        val mutable public _Current : KeyValuePair<'Key, 'Value>


        member x.MoveNext() =
            if x._Stack.Count > 0 then
                match x._Stack.Pop() with
                | MapExtImplementation.MapEmpty ->
                    failwith "invalid state"
                | MapExtImplementation.MapOne(k, v) ->
                    x._Current <- KeyValuePair(k, v)
                    true
                | MapExtImplementation.MapNode(k, v, l, r, _, _) ->
                    match l with
                    | MapExtImplementation.MapEmpty ->
                        x._Current <- KeyValuePair(k,v)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        true
                    | MapExtImplementation.MapOne(lk, lv) ->
                        x._Current <- KeyValuePair(lk, lv)
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        true
                    | l ->
                        match r with
                        | MapExtImplementation.MapEmpty -> ()
                        | _ -> x._Stack.Push r
                        x._Stack.Push(MapExtImplementation.MapOne(k, v))
                        x._Stack.Push l
                        x.MoveNext()
            else
                false

        member x.Current = x._Current

        member x.Reset() = 
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack16()
            match x._Root with
            | MapExtImplementation.MapEmpty -> ()
            | r -> x._Stack.Push r

        member x.Dispose() =
            x._Current <- Unchecked.defaultof<_>
            x._Stack <- InlineStack16()
            x._Root <- MapExtImplementation.MapEmpty
            
        interface IEnumerator with
            member x.MoveNext() = x.MoveNext()
            member x.Reset() = x.Reset()
            member x.Current = x.Current :> obj

        interface IEnumerator<KeyValuePair<'Key, 'Value>> with
            member x.Current = x.Current
            member x.Dispose() = x.Dispose()

        new(map : MapExt<'Key, 'Value>) =
            let mutable stack = Unchecked.defaultof<InlineStack16<_>>
            match map.Tree with
            | MapExtImplementation.MapEmpty -> ()
            | r -> stack.Push r
            {
                _Current = Unchecked.defaultof<_>
                _Stack = stack
                _Root = map.Tree
            }

    end



[<PlainExporter; MemoryDiagnoser>]
type InlineStackBenchmark() =

    let mutable map : MapExt<int, int> = MapExt.empty
    let mutable operations : array<int> = [||]
    let mutable operationsd : array<double> = [||]
    let mutable operationsq : array<decimal> = [||]
    
    [<DefaultValue; Params(5)>]
    val mutable public Count : int



    member x.Check () =
        let m = List.init 100 (fun i -> i, i) |> MapExt.ofList

        let res = System.Collections.Generic.List<_>()
        let mutable e = new MapExtEnumerator0<_,_>(m)
        while e.MoveNext() do res.Add e.Current
        if Seq.toList res <> Seq.toList m then failwith "MapExtEnumerator0 bad"

        let res = System.Collections.Generic.List<_>()
        let mutable e = new MapExtEnumerator2<_,_>(m)
        while e.MoveNext() do res.Add e.Current
        if Seq.toList res <> Seq.toList m then failwith "MapExtEnumerator2 bad"
    
        let res = System.Collections.Generic.List<_>()
        let mutable e = new MapExtEnumerator4<_,_>(m)
        while e.MoveNext() do res.Add e.Current
        if Seq.toList res <> Seq.toList m then failwith "MapExtEnumerator4 bad"
    
        let res = System.Collections.Generic.List<_>()
        let mutable e = new MapExtEnumerator8<_,_>(m)
        while e.MoveNext() do res.Add e.Current
        if Seq.toList res <> Seq.toList m then failwith "MapExtEnumerator8 bad"
    
        let res = System.Collections.Generic.List<_>()
        let mutable e = new MapExtEnumerator12<_,_>(m)
        while e.MoveNext() do res.Add e.Current
        if Seq.toList res <> Seq.toList m then failwith "MapExtEnumerator12 bad"
    
        let res = System.Collections.Generic.List<_>()
        let mutable e = new MapExtEnumerator16<_,_>(m)
        while e.MoveNext() do res.Add e.Current
        if Seq.toList res <> Seq.toList m then failwith "MapExtEnumerator16 bad"

    [<GlobalSetup>]
    member x.Setup() =
        x.Check()

        let m = MapExt.ofList ([1.. x.Count] |> List.map (fun v -> v,v))

        map <- m

        let ops = System.Collections.Generic.List<int>()

        let rec flatten (n : MapExtImplementation.MapTree<int, int>) =
            match n with
            | MapExtImplementation.MapEmpty ->
                ()
            | MapExtImplementation.MapNode(k,_,l,r,e,f) ->
                ops.Add -1
                match l with
                | MapExtImplementation.MapEmpty -> ()
                | MapExtImplementation.MapOne(k,_) -> ops.Add k
                | MapExtImplementation.MapNode(k,_,_,_,_,_) -> ops.Add k
                match r with
                | MapExtImplementation.MapEmpty -> ()
                | MapExtImplementation.MapOne(k,_) -> ops.Add k
                | MapExtImplementation.MapNode(k,_,_,_,_,_) -> ops.Add k
                flatten l
                flatten r
            | MapExtImplementation.MapOne(k,v) ->
                ops.Add -1

        match m.Tree with
        | MapExtImplementation.MapEmpty -> ()
        | MapExtImplementation.MapOne(k,_) -> ops.Add k
        | MapExtImplementation.MapNode(k,_,_,_,_,_) -> ops.Add k
        flatten m.Tree
        operations <- Seq.toArray ops
        operationsd <- Array.map float operations
        operationsq <- Array.map decimal operations

        
    [<Benchmark>]
    member x.MapExtEnumerator0() =
        let mutable sum = 0
        let mutable e = new MapExtEnumerator0<_,_>(map)
        try
            while e.MoveNext() do 
                sum <- sum + e.Current.Value
        finally
            e.Dispose()
        sum

    [<Benchmark>]
    member x.MapExtEnumerator2() =
        let mutable sum = 0
        let mutable e = new MapExtEnumerator2<_,_>(map)
        try
            while e.MoveNext() do 
                sum <- sum + e.Current.Value
        finally
            e.Dispose()
        sum
        
    [<Benchmark>]
    member x.MapExtEnumerator4() =
        let mutable sum = 0
        let mutable e = new MapExtEnumerator4<_,_>(map)
        try
            while e.MoveNext() do 
                sum <- sum + e.Current.Value
        finally
            e.Dispose()
        sum
        
    [<Benchmark>]
    member x.MapExtEnumerator8() =
        let mutable sum = 0
        let mutable e = new MapExtEnumerator8<_,_>(map)
        try
            while e.MoveNext() do 
                sum <- sum + e.Current.Value
        finally
            e.Dispose()
        sum
        
    [<Benchmark>]
    member x.MapExtEnumerator12() =
        let mutable sum = 0
        let mutable e = new MapExtEnumerator12<_,_>(map)
        try
            while e.MoveNext() do 
                sum <- sum + e.Current.Value
        finally
            e.Dispose()
        sum
        
    [<Benchmark>]
    member x.MapExtEnumerator16() =
        let mutable sum = 0
        let mutable e = new MapExtEnumerator16<_,_>(map)
        try
            while e.MoveNext() do 
                sum <- sum + e.Current.Value
        finally
            e.Dispose()
        sum

    //[<Benchmark>]
    //member x.InlineStack2_DWORD() =
    //    let mutable s = InlineStack2<int>()
    //    for o in operations do
    //        if o < 0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack4_DWORD() =
    //    let mutable s = InlineStack4<int>()
    //    for o in operations do
    //        if o < 0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
                
    //[<Benchmark>]
    //member x.InlineStack8_DWORD() =
    //    let mutable s = InlineStack8<int>()
    //    for o in operations do
    //        if o < 0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack12_DWORD() =
    //    let mutable s = InlineStack12<int>()
    //    for o in operations do
    //        if o < 0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack16_DWORD() =
    //    let mutable s = InlineStack16<int>()
    //    for o in operations do
    //        if o < 0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o


    //[<Benchmark>]
    //member x.InlineStack2_QWORD() =
    //    let mutable s = InlineStack2<float>()
    //    for o in operationsd do
    //        if o < 0.0 then 
    //            if s.Count <= 0 then s.Push -o
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack4_QWORD() =
    //    let mutable s = InlineStack4()
    //    for o in operationsd do
    //        if o < 0.0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
                
    //[<Benchmark>]
    //member x.InlineStack8_QWORD() =
    //    let mutable s = InlineStack8()
    //    for o in operationsd do
    //        if o < 0.0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack12_QWORD() =
    //    let mutable s = InlineStack12()
    //    for o in operationsd do
    //        if o < 0.0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack16_QWORD() =
    //    let mutable s = InlineStack16()
    //    for o in operationsd do
    //        if o < 0.0 then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o

                
    //[<Benchmark>]
    //member x.InlineStack2_OWORD() =
    //    let mutable s = InlineStack2()
    //    for o in operationsq do
    //        if o < 0.0m then 
    //            if s.Count <= 0 then s.Push -o
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack4_OWORD() =
    //    let mutable s = InlineStack4()
    //    for o in operationsq do
    //        if o < 0.0m then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
                
    //[<Benchmark>]
    //member x.InlineStack8_OWORD() =
    //    let mutable s = InlineStack8()
    //    for o in operationsq do
    //        if o < 0.0m then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack12_OWORD() =
    //    let mutable s = InlineStack12()
    //    for o in operationsq do
    //        if o < 0.0m then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
                
    //[<Benchmark>]
    //member x.InlineStack16_OWORD() =
    //    let mutable s = InlineStack16()
    //    for o in operationsq do
    //        if o < 0.0m then 
    //            if s.Count <= 0 then s.Push (-o)
    //            else s.Pop() |> ignore
    //        else
    //            s.Push o
