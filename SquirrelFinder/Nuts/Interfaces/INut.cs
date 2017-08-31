using System;
using System.Net;
using static SquirrelFinder.Nuts.Nut;

namespace SquirrelFinder.Nuts
{
    public interface INut
    {
        Uri Url { get; set; }
        NutState State { get; set; }
        bool HasShownMessage { get; set; }

        HttpStatusCode Peek(int timeout = 5000);

        string GetBalloonTipInfo();
        string GetBalloonTipTitle();
    }
}