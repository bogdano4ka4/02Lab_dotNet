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
