namespace Sample

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms

module App =
    type Model =
      { Count : int
        Step : int
      }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | SetStep of int

    let initModel = { Count = 0; Step = 1 }

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + model.Step }, Cmd.none
        | Decrement -> { model with Count = model.Count - model.Step }, Cmd.none
        | Reset -> init ()
        | SetStep n -> { model with Step = n }, Cmd.none

    let view (model: Model) dispatch =
        View.ContentPage(
          content = View.StackLayout(padding = 20.0, verticalOptions = LayoutOptions.Center,
            children = [
                View.Label(text = sprintf "%d" model.Count, horizontalOptions = LayoutOptions.Center, widthRequest=200.0, horizontalTextAlignment=TextAlignment.Center)
                View.Button(text = "Increment", command = (fun () -> dispatch Increment), horizontalOptions = LayoutOptions.Center)
                View.Button(text = "Decrement", command = (fun () -> dispatch Decrement), horizontalOptions = LayoutOptions.Center)
                View.Slider(minimum = 0.0, maximum = 10.0, value = double model.Step, valueChanged = (fun args -> dispatch (SetStep (int (args.NewValue + 0.5)))), horizontalOptions = LayoutOptions.FillAndExpand)
                View.Label(text = sprintf "Step size: %d" model.Step, horizontalOptions = LayoutOptions.Center)
                View.Button(text = "Reset", horizontalOptions = LayoutOptions.Center, command = (fun () -> dispatch Reset), canExecute = (model <> initModel))
            ]))

    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkProgram init update view

type App () as app =
    inherit Application ()
    do App.program
        |> Program.withConsoleTrace
        |> Program.runWithDynamicView app
        |> ignore



