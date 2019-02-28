using System;
using Poberezhets01.Views;

namespace Poberezhets01.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }
        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.InputInfo:
                    if (!ViewsDictionary.ContainsKey(viewType))
                        ViewsDictionary.Add(viewType, new InputInfoView());
                    break;
                case ViewType.OutputInfo:
                    ViewsDictionary.Add(viewType, new OutputInfoView());;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
