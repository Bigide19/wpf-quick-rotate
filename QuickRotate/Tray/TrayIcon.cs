using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Tray
{
    public class TrayIcon
    {
        private Window mainWindow;
        private NotifyIcon notifyIcon;

        #region Constructor

        public TrayIcon(Window main)
        {
            mainWindow = main;
            mainWindow.Closed += (sender, e) =>
            {
                if (notifyIcon != null)
                {
                    notifyIcon.Visible = false;
                    notifyIcon.Dispose();
                }
            };

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = QuickRotate.Properties.Resources.Icon;
            notifyIcon.Visible = true;

            notifyIcon.DoubleClick += (sender, e) =>
            {
                // sender : object
                // e : EventArgs
            };

            //트레이아이콘에 추가할 콘텍스트메뉴의 메뉴 아이템 생성 / 추가, 이벤트 추가

            MenuItem menuItem = new MenuItem();
            menuItem.Text = "종료";
            menuItem.Click += (sender, e) =>
            {
                //isClose = true;
                //currentWindow.Close();
                //System.Windows.Application.Current.Shutdown();

                if (notifyIcon != null)
                {
                    notifyIcon.Visible = false;
                    notifyIcon.Dispose();
                }

                Environment.Exit(0);
            };

            ContextMenu contextMenu = new ContextMenu();
            // Initialize contextMenu1
            contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem });

            notifyIcon.ContextMenu = contextMenu;
        }

        #endregion
    }
}
