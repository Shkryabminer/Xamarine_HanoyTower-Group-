﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace XamarinAnimationIOS_HanoyTower_
{
    public class Tower
    {
        private nfloat _x;
        public nfloat X
        {
            get
            {
                return _x;
            }
        }

        private nfloat _y;
        public nfloat Y
        {
            get
            {
                return _y;
            }
        }

        public Stack<UIView> views;

        public Tower(nfloat x, nfloat y)
        {
            _x = x;
            _y = y;
            views = new Stack<UIView>();
        }
    }
}