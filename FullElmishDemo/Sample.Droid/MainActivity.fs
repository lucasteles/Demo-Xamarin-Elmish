namespace Sample.Droid

open System

open Android.App
open Android.Content.PM
open Android.Runtime
open Android.OS
open Xamarin.Forms.Platform.Android

type Resources = Sample.Droid.Resource

[<Activity (Label = "Sample.Doid",  MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity () =
    inherit FormsAppCompatActivity()
    override this.OnCreate (bundle: Bundle) =
        FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar


        base.OnCreate (bundle)

        Xamarin.Essentials.Platform.Init(this, bundle)

        Xamarin.Forms.Forms.Init (this, bundle)

        let appcore  = new Sample.App()
        this.LoadApplication (appcore)

    override this.OnRequestPermissionsResult(requestCode: int, permissions: string[], [<GeneratedEnum>] grantResults: Android.Content.PM.Permission[]) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)

        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
