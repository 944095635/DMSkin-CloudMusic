using DMSkin.Core.Common;
using System.Windows;

namespace DMSkin.CloudMusic
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Execute.InitializeWithDispatcher();
        }
    }
}
