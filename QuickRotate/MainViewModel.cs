using MVVMHelper;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tray;

namespace QuickRotate
{
    public class MainViewModel
    {
        private bool isClose = false;
        private Window currentWindow;

        #region Constructor

        public MainViewModel()
        {   
        }

        #endregion

        #region Commands

        public ICommand LoadedCommand { get { return new DelegateCommand(OnLoaded); } }
        public ICommand ClosingCommand { get { return new DelegateCommand(OnClosing); } }

        #endregion

        #region Command Handlers

        private void OnLoaded(object param)
        {
            if ((param is Window) == false) return;

            if (currentWindow == null)
            {
                currentWindow = param as Window;
            }

            Console.WriteLine(DateTime.Now.Year);
            Console.WriteLine(DateTime.Now.Month);
            if (DateTime.Now.Year > 2019)
            {
                System.Windows.MessageBox.Show("bigide19@gmail.com");
                Environment.Exit(0);
            }
            if (DateTime.Now.Month > 6)
            {
                System.Windows.MessageBox.Show("bigide19@gmail.com");
                Environment.Exit(0);
            }

            CreateTrayIcon();
        }

        private void OnClosing(object param)
        {
            if ((param is CancelEventArgs) == false) return;

            CancelEventArgs args = param as CancelEventArgs;

            if (isClose)
            {
                args.Cancel = false;
            }
            else
            {
                args.Cancel = true;
            }
        }

        #endregion

        private void CreateTrayIcon()
        {
            TrayIcon trayIcon = new TrayIcon(currentWindow);
        }
    }
}