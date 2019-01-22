using Display;
using MVVMHelper;
using System.Windows;
using System.Windows.Input;

namespace QuickRotate
{
    public class RotateViewModel : BaseViewModel
    {
        private bool _IsEnabled = true;
        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        #region Constructor

        public RotateViewModel()
        {

        }

        #endregion

        #region Commands

        public ICommand LoadedCommand { get { return new DelegateCommand(OnLoaded); } }

        public ICommand ClickCommand { get { return new DelegateCommand(OnClick); } }
        public ICommand LongPressedCommand { get { return new DelegateCommand(OnLongPressed); } }
        public ICommand LongPressedReleaseCommand { get { return new DelegateCommand(OnLongPressedRelease); } }

        #endregion

        #region Command Handlers

        private void OnLoaded(object param)
        {

        }

        private void OnClick(object param)
        {
            //DisplayManager.RotateScreen(false);
            DisplayManager.ReverseScreen();
        }

        private void OnLongPressed(object param)
        {
            IsEnabled = false;
        }

        private void OnLongPressedRelease(object param)
        {
            IsEnabled = true;
        }

        #endregion

    }
}