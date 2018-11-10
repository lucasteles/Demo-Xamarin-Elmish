namespace HalfElmishDemo

open Elmish.XamarinForms.StaticViews
open Xamarin.Forms
open Xamarin.Forms.Xaml

type MainPage() =
    inherit ContentPage()
    do base.LoadFromXaml(typeof<MainPage>) |> ignore

module MainPage =

    type Model =
        {
            Count : int
        }

    type Msg =
        | Increment

    let init() =
        { Count = 0 }

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count+1 }

    let view () =
        MainPage(),
        [
            "Message" |> Binding.oneWay (fun m -> sprintf "Clicked = %d" m.Count)
            "Increment" |> Binding.msg Increment
        ]

