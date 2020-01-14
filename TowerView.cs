using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UIKit;

namespace XamarinAnimationIOS_HanoyTower_
{
    public partial class TowerView : UIViewController
    {
        public int AmountTowers { get; set; }
        UIView viewTowers;       
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
            towerStart = new Tower(viewTowers.Frame.Width / 5, viewTowers.Frame.Height * 0.9f);
            towerEnd = new Tower(viewTowers.Frame.Width / 3, viewTowers.Frame.Height * 0.9f);
            towerTemp = new Tower(4 * viewTowers.Frame.Width / 5, viewTowers.Frame.Height * 0.9f);

            CreateViews();

            //Start();


        }

        public override void ViewDidAppear(bool animated)
        {

            base.ViewDidAppear(animated);
                     
            AnimatedTower();       
         }

        public void AnimatedTower()
        {
            UIView temp = towerStart.views.Pop();

            UIView.Animate(2f, () =>
            {
                temp.Frame = new CGRect
                (
                    temp.Frame.X + towerEnd.X - temp.Frame.Width * 0.5f,
                    View.Frame.Height - temp.Frame.Height - View.Frame.Height * 0.1f,
                    temp.Frame.Width,
                    temp.Frame.Height
                );
            },
            () =>
            {

                UIView temp1 = towerStart.views.Pop();
                NextAnimation(temp, temp1);
            });
        }

        void NextAnimation(UIView to, UIView source)
        {
            UIView.Animate(2f, () =>
            {
                source.Frame = new CGRect
                (
                    to.Frame.X + to.Frame.Width / 2f - source.Frame.Width * 0.5f,                   
                    to.Frame.Y - source.Frame.Height,
                    source.Frame.Width,
                    source.Frame.Height
                );
            },
            () =>
            {

                if (towerStart.views.Count == 0)
                {
                    return;
                }

                UIView temp1 = towerStart.views.Pop();
                NextAnimation(source, temp1);
            });
        }

       
        private void CreateViews()
        {
            nfloat widthRect = 100f;
            nfloat hightRect = viewTowers.Frame.Height / AmountTowers * 0.8f;
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

            SolveTowers(AmountTowers, towerStart, towerEnd, towerTemp);
        }

        private void SolveTowers(int count, Tower startPeg, Tower endPeg, Tower tempPeg)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("towerStart - " + towerStart.views.Count);
            Console.WriteLine("towerEnd - " + towerEnd.views.Count);
            Console.WriteLine("towerTemp - " + towerTemp.views.Count);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");

            if (count > 0)
            {
                MoveDisk(startPeg, endPeg, () =>
                {
                    SolveTowers(count - 1, startPeg, tempPeg, endPeg);
                    SolveTowers(count - 1, tempPeg, endPeg, startPeg);
                });
            }
        }

        private void MoveDisk(Tower towerStart, Tower towerEnd, Action nextAnim)
        {

            nfloat x = 0;
            nfloat y = 0;
            UIView source = towerStart.views.Pop();
            if (towerEnd.views.Count == 0)
            {
                x = towerStart.X + towerEnd.X - source.Frame.Width * 0.5f;
                y = View.Frame.Height - source.Frame.Height - View.Frame.Height * 0.1f;
            }
            else
            {
                x = towerStart.X + towerEnd.X - source.Frame.Width * 0.5f;
                y = towerEnd.views.Peek().Frame.Y - source.Frame.Height;
            }

            towerEnd.views.Push(source);

            UIView.Animate(2f, () =>
            {
                source.Frame = new CGRect
                (
                    x,
                    //View.Frame.Height - temp1.Frame.Height - View.Frame.Height * 0.1f,
                    y,
                    source.Frame.Width,
                    source.Frame.Height
                );
            }, () => nextAnim());


            
        }
      


    }
}