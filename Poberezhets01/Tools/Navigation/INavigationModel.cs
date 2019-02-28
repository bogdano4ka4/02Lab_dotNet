using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poberezhets01.Models;

namespace Poberezhets01.Tools.Navigation
{
    internal enum ViewType
    {
        InputInfo,//Input info
        OutputInfo,//Output info
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
