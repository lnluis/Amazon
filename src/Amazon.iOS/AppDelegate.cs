using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookUI;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Amazon.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        private UIWindow _window;
        private UINavigationController _mainController;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //global::Xamarin.Forms.Forms.Init();
            //LoadApplication(new App());
            _window = new UIWindow();
            _window.RootViewController = new MainRootViewController();
            _window.MakeKeyAndVisible();

            return true;
        }
    }

    public class MainRootViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            this.View = new MainView();
        }
    }

    public class MainView : UIView
    {
        public override void Draw(CGRect rect)
        {
            var uiLabel = new UILabel() { Text="Hello", TextColor = UIColor.Red};
            uiLabel.SizeToFit();
            this.AddSubview(uiLabel);
        }
    }
}
