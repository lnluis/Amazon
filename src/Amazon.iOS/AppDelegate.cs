using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookUI;
using CoreAnimation;
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
            _window.BackgroundColor = UIColor.Brown;
            return true;
        }
    }

    public class MainRootViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            this.View = new MainView(UIScreen.MainScreen.Bounds);
        }
    }

    public sealed class MainView : UIView
    {
        public MainView(CGRect bounds) : base(bounds)
        {
            BackgroundColor = UIColor.White;
        }

        public override void Draw(CGRect rect)
        {
            var signUpButton = CreateSignUpButton();
            AddSubview(signUpButton);
            
            var amazonLogoPlaceholder = CreateAmazonLogo(signUpButton);
            AddSubview(amazonLogoPlaceholder);





            var signupForm = new UIView();
            var topBorder = new CALayer();

            var uilabel = new UILabel() { Text = "Hello", TextColor = UIColor.Red };
            uilabel.Font = UIFont.SystemFontOfSize((nfloat) 32.3);
            signupForm.ClipsToBounds = true;
            uilabel.SizeToFit();

            topBorder.BorderColor = UIColor.LightGray.CGColor;
            topBorder.BorderWidth = 1.0f;
            var toplayerFrameCopy = uilabel.Layer.Frame;
            toplayerFrameCopy.Y -= uilabel.Layer.Frame.Height - 0.5f;
            topBorder.Frame = toplayerFrameCopy;

            var bottomBorder = new CALayer();
            bottomBorder.BorderColor = UIColor.LightGray.CGColor;
            bottomBorder.BorderWidth = 1.0f;

            var bottomBorderFrameCopy = uilabel.Layer.Frame;
            bottomBorderFrameCopy.Y += uilabel.Layer.Frame.Height - 0.5f;
            bottomBorder.Frame = bottomBorderFrameCopy;


            signupForm.Layer.AddSublayer(topBorder);
            signupForm.Layer.AddSublayer(bottomBorder);
            var currentFrame = uilabel.Frame;
            currentFrame.X = 20;
            currentFrame.Y = amazonLogoPlaceholder.Frame.Height;
            signupForm.Frame = currentFrame;
            signupForm.AddSubview(uilabel);
            AddSubview(signupForm);
        
        }

        private static UIButton CreateSignUpButton()
        {
            var signUpButton = new UIButton();
            signUpButton.SizeToFit();
            var signUpLabel = new UILabel() {Text = "Sign up", TextColor = UIColor.Orange};
            signUpLabel.Font = UIFont.SystemFontOfSize(11);
            signUpLabel.SizeToFit();
            signUpLabel.Frame = new CGRect(signUpLabel.Frame.X - 5, signUpLabel.Frame.Y + 5,
                UIScreen.MainScreen.ApplicationFrame.Width, signUpLabel.Frame.Height);
            signUpLabel.TextAlignment = UITextAlignment.Right;
            signUpButton.AddSubview(signUpLabel);
            return signUpButton;
        }

        private static UIImageView CreateAmazonLogo(UIButton signUpButton)
        {
            var amazonLogo = UIImage.FromFile("Images/amazonlogo.jpg");
            var amazonLogoPlaceholder = new UIImageView(amazonLogo);
            amazonLogoPlaceholder.ContentMode = UIViewContentMode.ScaleAspectFit;
            var maxImageViewSize = new CGSize(UIScreen.MainScreen.ApplicationFrame.Width,
                UIScreen.MainScreen.ApplicationFrame.Height/4);
            var imageSize = amazonLogo.Size;
            var aspectRatio = imageSize.Width/imageSize.Height;
            var x = amazonLogoPlaceholder.Frame.X;
            nfloat width;
            nfloat height;

            if (maxImageViewSize.Width/aspectRatio <= maxImageViewSize.Height)
            {
                width = maxImageViewSize.Width;
                height = amazonLogoPlaceholder.Frame.Size.Width/aspectRatio;
            }
            else
            {
                height = maxImageViewSize.Height;
                width = amazonLogoPlaceholder.Frame.Size.Height/aspectRatio;
            }

            amazonLogoPlaceholder.Frame = new CGRect(x, signUpButton.Frame.Height, width, height);
            return amazonLogoPlaceholder;
        }
    }
}
