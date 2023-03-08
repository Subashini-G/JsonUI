using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MonoTouch.Dialog;
using UIKit;

namespace syncfusionApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        UIWindow _window;
        UINavigationController _nav;
        DialogViewController _rootVC;
        RootElement _rootElement;

        private int n;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfButtonRenderer.Init();

            _window = new UIWindow(UIScreen.MainScreen.Bounds);
            _rootElement = new RootElement("Products") { new Section() };
            _rootVC = new DialogViewController(_rootElement);
            _nav = new UINavigationController(_rootVC);

            _window.RootViewController = _nav;
            _window.MakeKeyAndVisible();

            n++;
            var product = new Product { Name = "product " + n };
            var productElement = JsonElement.FromFile("product.json");
            productElement.Caption = product.Name;
            var q1 = productElement["question1"] as EntryElement;
            var q2 = productElement["question2"] as BooleanElement;

            _rootElement.Add(productElement);

            return true;
            return base.FinishedLaunching(app, options);
        }
    }

}

