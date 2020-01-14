using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Threading;
using UIKit;

namespace XamarinAnimationIOS_HanoyTower_
{
    public partial class TowerView : UIViewController
    {
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
            viewTowers = _viewForTowers;
            towerStart = new Tower(viewTowers.Frame.Width/5, viewTowers.Frame.Height*0.9f);
            towerEnd = new Tower(viewTowers.Frame.Width/3, viewTowers.Frame.Height * 0.9f);
            towerTemp = new Tower(4 *viewTowers.Frame.Width / 5, viewTowers.Frame.Height * 0.9f);
            CreateViews();
           
            //Start();


        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            UIView temp = towerStart.views.Pop();
            UIView.Animate(10f, () =>
            {
                temp.Frame = new CGRect
                (
                    temp.Frame.X + towerEnd.X,
                    temp.Frame.Y + View.Frame.Height - 290,
                    temp.Frame.Width,
                    temp.Frame.Height
                ); ;
            });

        }

        private void CreateViews()
        {
            nfloat widthRect = 100f;
            nfloat hightRect = viewTowers.Frame.Height / AmountTowers*0.8f;
            nfloat x;
            nfloat y;

            for (int i = 0; i < AmountTowers; i++)
            {
                x = towerStart.X - (widthRect / 2);
                y = towerStart.Y - (towerStart.views.Count * hightRect) - hightRect;

               var view = new UIView(new CGRect(x, y, widthRect, hightRect));
              
                view.BackgroundColor = GetBrushes();
                towerStart.views.Push(view);
                viewTowers.AddSubview(view);
               

                widthRect += widthRect*(0.95f -2)/ AmountTowers;
            }

          //  UIView temp = towerStart.views.Pop();


            //Thread.Sleep(1000);
            //UIView.Animate(10f, () =>
            //    {
            //        temp.Frame = new CGRect
            //        (
            //            temp.Frame.X + 100,
            //            temp.Frame.Y,
            //            temp.Frame.Width,
            //            temp.Frame.Height
            //        );
            //    });
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
            solveTowers(totalDisks, towerStart, towerEnd, towerTemp);
        }

        private void solveTowers(int n, Tower startPeg, Tower endPeg, Tower tempPeg)
        {
            if (n > 0)
            {
                solveTowers(n - 1, startPeg, tempPeg, endPeg);
                MoveDisk(startPeg, endPeg);
                solveTowers(n - 1, tempPeg, endPeg, startPeg);
            }
        }

        private void MoveDisk(Tower from, Tower to)
        {
            Thread.Sleep(1000);


            UIView oneView = from.views.Pop();
            nfloat width = oneView.Frame.Width;
            nfloat left = to.X - (width / 2);
            //  Canvas.SetLeft(oneView, left);
            int top = 300 - (to.views.Count * 10);
            //  Canvas.SetTop(oneView, top);
            to.views.Push(oneView);





            //Thread.Sleep(1000);
            //this.Dispatcher.Invoke(new Action(() =>
            //{
            //    UIView button = from.UIView.Pop();
            //    int width = Convert.ToInt32(button.Width);
            //    int left = to.Left - (width / 2);
            //    Canvas.SetLeft(button, left);
            //    int top = 300 - (to.buttons.Count * 10);
            //    Canvas.SetTop(button, top);
            //    to.buttons.Push(button);
            //}));
        }
    }


}