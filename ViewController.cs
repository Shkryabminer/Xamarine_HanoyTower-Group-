using CoreGraphics;
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
          
        }

        private void BtnStartTouchUpInside(object sender, EventArgs e)
        {
            var VC = Storyboard.InstantiateViewController("_towerView") as TowerView;
            VC.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
            VC.AmountTowers = Int32.Parse(_txtFildAmountTower.Text);
            this.PresentViewController(VC, true, null);
            
            //nfloat widthView = View.Bounds.Width;
            //nfloat heightView = View.Bounds.Height;
            //var height = 20;
            //var width = 150;
            //var tempHeight = 0.75f;
            //for (int i = 0; i < 5; i++)
            //{
            //    //UIView uIView = new UIView();
            //    //uIView.Frame.Height = 100f;

            //    //button.Width = width;
            //    //button.Height = 10;
            //    //button.Background = GetBrushes();
            //    //left = towerStart.Left - (width / 2);
            //    //Canvas.SetLeft(button, left);
            //    //top = 300 - (towerStart.buttons.Count * 10);
            //    //Canvas.SetTop(button, top);
            //    //towerStart.buttons.Push(button);
            //    //this.canvas.Children.Add(button);
            //    //width -= 10;

            //    //float width = View.Bounds.Width;

            //    var barrier = new UIView(new CGRect(300, 400, width, height));
            //    barrier.BackgroundColor = UIColor.Green;
            //    tempHeight -= 0.07f;
            //    VC.View.AddSubviews(barrier);

            //}
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

 
    }
}