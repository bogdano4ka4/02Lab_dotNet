using System;
using Poberezhets01.Models;
namespace Poberezhets01.Tools.Managers
{
    internal class StationManager

    {
        internal static Person CurrentUser { get; set; }

        internal static void CloseApp()
        {
            Environment.Exit(0);
        }
    }
}
