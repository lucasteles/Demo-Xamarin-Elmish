namespace Sample

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms

module App =
    type Model =
      { Count : int }

    type Msg =
        | Increment

    let initModel = { Count = 0 }

    let init () = initModel, Cmd.none

    let update msg model =
         if (msg = Increment) then
            { model with Count = model.Count + 1 }, Cmd.none
         else 
            model, Cmd.none

    let view (model: Model) dispatch =
        View.ContentPage(
          content = View.StackLayout(padding = 20.0, verticalOptions = LayoutOptions.Center,
            children = [
                View.Label(text = sprintf "%d" model.Count, horizontalOptions = LayoutOptions.Center, widthRequest=200.0, horizontalTextAlignment=TextAlignment.Center)
                View.Button(text = "Increment", command = (fun () -> dispatch Increment), horizontalOptions = LayoutOptions.Center)
            ]))

    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkProgram init update view

type App () as app =
    inherit Application ()
    do App.program
        |> Program.withConsoleTrace
        |> Program.runWithDynamicView app
        |> ignore



