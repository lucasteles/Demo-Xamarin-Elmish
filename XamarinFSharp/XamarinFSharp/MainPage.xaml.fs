namespace XamarinFSharp

open Xamarin.Forms
open Xamarin.Forms.Xaml

open System.ComponentModel
open System

type MyViewModel () as this =
    let ev  = new Event<_,_>()
    let mutable count = 0

    let incrementCount () =
        count <- count + 1
        ev.Trigger(this, new PropertyChangedEventArgs("Count"))

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = ev.Publish

    member this.Count =
        sprintf "Count: %d" count

    member this.IncrementCommand = new Command(Action(fun p -> incrementCount ()))


type MainPage() =
    inherit ContentPage()
    do
        base.LoadFromXaml(typeof<MainPage>) |> ignore
        base.BindingContext <- new MyViewModel()

