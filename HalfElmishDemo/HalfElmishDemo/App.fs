namespace HalfElmishDemo

open Elmish.XamarinForms
open Elmish.XamarinForms.StaticViews
open Xamarin.Forms

type App() =
    inherit Application()

    do
        let page = Program.mkSimple MainPage.init MainPage.update MainPage.view
                    |> Program.withConsoleTrace
                    |> Program.runWithStaticView

        base.MainPage <- page.InitialMainPage
