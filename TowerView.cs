using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace XamarinAnimationIOS_HanoyTower_
{
    public partial class TowerView : UIViewController
    {

        public int AmountTowers { get; set; }
        UIView viewTowers;
        UIColor color;
        int countColor;
        Tower towerStart;
        Tower towerEnd;
        Tower towerTemp;

        public TowerView(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            viewTowers = _viewForTowers;
            towerStart = new Tower(100, viewTowers.Frame.Height);
            towerEnd = new Tower(200, viewTowers.Frame.Height);
            towerTemp = new Tower(300, viewTowers.Frame.Height);
            CreateViews();
        }

        private void CreateViews()
        {
            nfloat width = 100f;
            nfloat height = viewTowers.Frame.Height / AmountTowers;
            nfloat x;
            nfloat y;

            for (int i = 0; i < AmountTowers; i++)
            {
                x = towerStart.X - (width / 2);
                y = towerStart.Y - (towerStart.views.Count * height) - height;
                var view = new UIView(new CGRect(x, y, width, height));
                view.BackgroundColor = GetBrushes();
                towerStart.views.Push(view);
                viewTowers.AddSubview(view);
                width -= 10;
            }
        }

        private UIColor GetBrushes()
        {
            if (countColor > 5)
            {
                countColor = 0;
            }
            switch (countColor)
            {
                case 0:
                    color = UIColor.Red;
                    break;
                case 1:
                    color = UIColor.Green;
                    break;
                case 2:
                    color = UIColor.Blue;
                    break;
                case 3:
                    color = UIColor.Cyan;
                    break;
                case 4:
                    color = UIColor.Brown;
                    break;
            }
            countColor++;
            return color;
        }

        //public void Start()
        //{
        //    solveTowers(totalDisks, towerStart, towerEnd, towerTemp);
        //}

        //private void solveTowers(int n, Tower startPeg, Tower endPeg, Tower tempPeg)
        //{
        //    if (n > 0)
        //    {
        //        solveTowers(n - 1, startPeg, tempPeg, endPeg);
        //        MoveDisk(startPeg, endPeg);
        //        solveTowers(n - 1, tempPeg, endPeg, startPeg);
        //    }
        //}

        //private void MoveDisk(Tower from, Tower to)
        //{
        //    Thread.Sleep(1000);
        //    this.Dispatcher.Invoke(new Action(() =>
        //    {
        //        Button button = from.buttons.Pop();
        //        int width = Convert.ToInt32(button.Width);
        //        int left = to.Left - (width / 2);
        //        Canvas.SetLeft(button, left);
        //        int top = 300 - (to.buttons.Count * 10);
        //        Canvas.SetTop(button, top);
        //        to.buttons.Push(button);
        //    }));
        //}
    }


}