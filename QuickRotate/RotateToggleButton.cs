using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Controls;

namespace QuickRotate
{
    public class RotateToggleButton : ToggleButton
    {
        private static readonly double LONGPRESS_TIME = 350;

        #region IsLongPressed - Flag

        public bool IsLongPressed
        {
            get { return (bool)GetValue(IsLongPressedProperty); }
            set { SetValue(IsLongPressedProperty, value); }
        }

        public static readonly DependencyProperty IsLongPressedProperty =
            DependencyProperty.Register("IsLongPressed",
                                        typeof(bool),
                                        typeof(RotateToggleButton));

        #endregion

        #region LongPressed - Event

        public static readonly RoutedEvent LongPressedEvent =
            EventManager.RegisterRoutedEvent("LongPressed",
                                            RoutingStrategy.Bubble,
                                            typeof(RoutedEventHandler),
                                            typeof(RotateToggleButton));

        public event RoutedEventHandler LongPressed
        {
            add { AddHandler(LongPressedEvent, value); }
            remove { RemoveHandler(LongPressedEvent, value); }
        }

        void RaiseLongPressedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(RotateToggleButton.LongPressedEvent);
            RaiseEvent(newEventArgs);
        }


        #endregion

        #region ReleaseLongPressed - Event

        public static readonly RoutedEvent ReleaseLongPressedEvent =
            EventManager.RegisterRoutedEvent("ReleaseLongPressed",
                                            RoutingStrategy.Bubble,
                                            typeof(RoutedEventHandler),
                                            typeof(RotateToggleButton));

        public event RoutedEventHandler ReleaseLongPressed
        {
            add { AddHandler(ReleaseLongPressedEvent, value); }
            remove { RemoveHandler(ReleaseLongPressedEvent, value); }
        }

        void RaiseReleaseLongPressedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(RotateToggleButton.ReleaseLongPressedEvent);
            RaiseEvent(newEventArgs);
        }


        #endregion

        #region Variable
        
        private bool isClickActivate = true;

        private DispatcherTimer pressTimer;

        #endregion

        #region Constructor

        public RotateToggleButton()
        {
            this.Focusable = false;

            RoutedEventHandler loadedEventHandler = null;
            loadedEventHandler = (sender, args) =>
            {
                this.Loaded -= loadedEventHandler;

                SetTimer();
            };
            this.Loaded += loadedEventHandler;
        }

        #endregion

        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                pressTimer.Start();
                Console.WriteLine("Timer Start");
            }
            else
            {
                pressTimer.Stop();
                Console.WriteLine("Timer Stop");
            }

            base.OnIsPressedChanged(e);
        }

        protected override void OnClick()
        {
            Console.Write("OnClick : ");

            if (isClickActivate)
            {
                IsLongPressed = false;
                base.OnClick();

                Console.WriteLine("Enable");
            }
            else
            {
                Console.WriteLine("Disable");
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            isClickActivate = true;
            IsLongPressed = false;
            
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IsLongPressed == false)
            {
                //isClickActivate = false;
                pressTimer.Stop();
                return;
            }

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Application.Current.MainWindow.DragMove();
            }
            else if (e.LeftButton == MouseButtonState.Released)
            {
                RaiseReleaseLongPressedEvent();
            }

            base.OnMouseMove(e);
        }
        
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            isClickActivate = false;

            base.OnMouseLeave(e);
        }

        private void SetTimer()
        {
            pressTimer = new DispatcherTimer();
            pressTimer.Tick += (sender, e) =>
            {
                Console.WriteLine("Timer DoWork");

                IsLongPressed = true;
                isClickActivate = false;

                RaiseLongPressedEvent();

                pressTimer.Stop();
                Console.WriteLine("Timer Stop");
            };
            pressTimer.Interval = TimeSpan.FromMilliseconds(LONGPRESS_TIME);
        }
    }
}