﻿using System;
using System.Net;
using static SquirrelFinder.Nuts.Nut;

namespace SquirrelFinder.Nuts
{
    public interface INut
    {
        string Type { get; set; }
        void OnNutChanged(NutEventArgs e);
        event EventHandler<NutEventArgs> NutChanged;
        
        string Title { get; set; }
        Uri Url { get; set; }
        NutState State { get; set; }
        bool HasShownMessage { get; set; }

        void Peek(int timeout = 5000);

        string GetBalloonTipInfo();
        string GetBalloonTipTitle();
    }
}