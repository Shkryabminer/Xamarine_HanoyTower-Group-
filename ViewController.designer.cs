﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinAnimationIOS_HanoyTower_
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _btnStart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _txtFildAmountTower { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_btnStart != null) {
                _btnStart.Dispose ();
                _btnStart = null;
            }

            if (_txtFildAmountTower != null) {
                _txtFildAmountTower.Dispose ();
                _txtFildAmountTower = null;
            }
        }
    }
}