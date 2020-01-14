using Foundation;
using System;
using UIKit;

namespace XamarinAnimationIOS_HanoyTower_
{
    public partial class TowerView : UIViewController
    {
        public int AmountTowers { get; set; }

        public TowerView (IntPtr handle) : base (handle)
        {
        }
    }
}