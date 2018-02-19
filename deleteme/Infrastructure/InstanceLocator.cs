
//sive para encoontrar la main view model
namespace deleteme.Infrastructure
{
    using ViewModels;
    public class InstanceLocator
    {
        #region properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion


        #region constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion

    }
}
