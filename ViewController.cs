using Foundation;
using System;
using UIKit;

namespace XamarinAnimationIOS_HanoyTower_
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            _btnStart.TouchUpInside += BtnStartTouchUpInside;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void BtnStartTouchUpInside(object sender, EventArgs e)
        {
            var VC = Storyboard.InstantiateViewController("_towerView") as TowerView;
            VC.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
            VC.AmountTowers = Int32.Parse(_txtFildAmountTower.Text);                        
            this.PresentViewController(VC, true, null);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

 
    }
}