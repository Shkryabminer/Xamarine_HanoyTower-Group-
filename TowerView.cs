using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Threading;
using UIKit;
using System.Threading.Tasks;

namespace XamarinAnimationIOS_HanoyTower_
{
    public partial class TowerView : UIViewController
    {
        int count = 0;
        int totalDisks = 0;
        public int AmountTowers { get; set; }
        UIView viewTowers;
        UIColor color;
        int countColor;
        Tower towerStart;
        Tower towerEnd;
        Tower towerTemp;
        public delegate void Action();

        public TowerView(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();




            //  _lable.Text = "end";
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            viewTowers = _viewForTowers;
            towerStart = new Tower(viewTowers.Frame.Width / 5, viewTowers.Frame.Height * 0.9f);
            towerEnd = new Tower(viewTowers.Frame.Width / 2, viewTowers.Frame.Height * 0.9f);
            towerTemp = new Tower(4 * viewTowers.Frame.Width / 5, viewTowers.Frame.Height * 0.9f);
            CreateViews();
            Start();
        }

        private void BtnCont_TouchUpInside(object sender, EventArgs e)
        {

        }

        private void CreateViews()
        {
            nfloat widthRect = View.Frame.Width / 8f;
            nfloat hightRect = viewTowers.Frame.Height / AmountTowers * 0.8f;
            nfloat x;
            nfloat y;

            for (int i = 0; i < AmountTowers; i++)
            {
                x = towerStart.X - (widthRect / 2);
                y = towerStart.Y - hightRect; //-(towerStart.views.Count * hightRect)

                var view = new UIView(new CGRect(x, y, widthRect, hightRect));

                view.BackgroundColor = GetBrushes();
                towerStart.views.Push(view);
                viewTowers.AddSubview(view);
                towerStart.Y -= view.Frame.Height;
                widthRect += widthRect * (0.95f - 2) / AmountTowers;
            }
        }


        private UIColor GetBrushes()
        {

            int red = new Random().Next(255);
            int green = new Random().Next(255);
            int blue = new Random().Next(255);

            UIColor color = UIColor.FromRGB(red, green, blue);

            return color;
        }

        public void Start()
        {
            solveTowers(AmountTowers, towerStart, towerEnd, towerTemp);
        }

        private async Task solveTowers(int n, Tower startPeg, Tower endPeg, Tower tempPeg)
        {
            if (n > 0)
            {
                await solveTowers(n - 1, startPeg, tempPeg, endPeg);
                await Task.Delay(2000);
                MoveDiskAsync(startPeg, endPeg);
                await solveTowers(n - 1, tempPeg, endPeg, startPeg);
            }
        }

        private void MoveDiskAsync(Tower start, Tower end)
        {
            UIView oneView = start.views.Pop();
            UIView.Animate(2f, () =>
            {
                oneView.Frame = new CGRect(end.X - oneView.Frame.Width / 2, end.Y - oneView.Frame.Height, oneView.Frame.Width, oneView.Frame.Height);
            });
            end.views.Push(oneView);
            start.Y += oneView.Frame.Height;
            end.Y -= oneView.Frame.Height;


        }

        //void NextAnimation(UIView to, UIView source)
        //{
        //    UIView.Animate(2f, () =>
        //    {
        //        source.Frame = new CGRect
        //        (
        //            to.Frame.X + to.Frame.Width / 2f - source.Frame.Width * 0.5f,
        //            to.Frame.Y - source.Frame.Height,
        //            source.Frame.Width,
        //            source.Frame.Height
        //        );
        //    },
        //    () =>
        //    {

        //        if (towerStart.views.Count == 0)
        //        {
        //            return;
        //        }

        //        UIView temp1 = towerStart.views.Pop();
        //        NextAnimation(source, temp1);
        //    });

    }

}