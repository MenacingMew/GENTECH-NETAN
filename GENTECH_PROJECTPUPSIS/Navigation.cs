using System;
using System.Windows.Forms;

namespace StudentEnrollmentDraft
{
    public class NavigationRequestedEventArgs : EventArgs
    {
        public Type TargetViewType { get; }

        public NavigationRequestedEventArgs(Type targetViewType)
        {
            TargetViewType = targetViewType;
        }
    }

    public interface INavigationSource
    {
        event EventHandler<NavigationRequestedEventArgs> NavigationRequested;
    }
}
