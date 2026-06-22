using System.Windows;
using WindowsInput.Native;

namespace Clickless_Mouse
{
    public partial class MainWindow : Window
    {
        bool app_left_hold_active = false;
        bool app_left_hold_waiting_for_release_after_move = false;
        bool should_release_lmb_hold_after_next_stop = true;
        bool app_right_hold_active = false;
        bool app_right_hold_waiting_for_release_after_move = false;
        bool should_release_rmb_hold_after_next_stop = true;
        bool show_left_hold_indicator = false;
        bool show_right_hold_indicator = false;

        void left_down()
        {
            sim.Mouse.LeftButtonDown();
            app_left_hold_active = true;
        }

        void left_up()
        {
            sim.Mouse.LeftButtonUp();
            app_left_hold_active = false;
            app_left_hold_waiting_for_release_after_move = false;
            show_left_hold_indicator = false;
            sync_hold_indicator_visibility();
        }

        void right_down()
        {
            sim.Mouse.RightButtonDown();
            app_right_hold_active = true;
        }

        void right_up()
        {
            sim.Mouse.RightButtonUp();
            app_right_hold_active = false;
            app_right_hold_waiting_for_release_after_move = false;
            show_right_hold_indicator = false;
            sync_hold_indicator_visibility();
        }

        public void LMBClick(int X, int Y, int time)
        {
            ///user may forget that right button is pressed or press it by mistake without noticing
            //(holding RMB prevents LMB clicking)
            if (sim.InputDeviceState.IsKeyDown(VirtualKeyCode.RBUTTON))
            {
                right_up();
            }
            freeze_mouse(X, Y, 50);
            left_down();
            freeze_mouse(X, Y, time);
            left_up();
            freeze_mouse(X, Y, 10);
        }

        public void RMBClick(int X, int Y, int time)
        {
            freeze_mouse(X, Y, 50);
            right_down();
            freeze_mouse(X, Y, time);
            right_up();
            freeze_mouse(X, Y, 10);
        }

        public void DLMBClick(int X, int Y, int time)
        {
            //user may forget that right button is pressed or press it by mistake without noticing
            //(holding RMB prevents LMB clicking)
            if (sim.InputDeviceState.IsKeyDown(VirtualKeyCode.RBUTTON))
            {
                right_up();
            }
            LMBClick(X, Y, 100);
            LMBClick(X, Y, 100);
        }

        public void LMBHold(int X, int Y, int time)
        {
            freeze_mouse(X, Y, 50);
            if (should_release_lmb_hold_after_next_stop)
            {
                if (app_left_hold_active == false)
                {
                    left_down();
                    app_left_hold_waiting_for_release_after_move = false;
                    show_left_hold_indicator = true;
                    sync_hold_indicator_visibility();
                }
            }
            else if (app_left_hold_active == false)
            {
                left_down();
                show_left_hold_indicator = true;
                sync_hold_indicator_visibility();
            }
            else
            {
                left_up();
            }
            freeze_mouse(X, Y, time);
        }

        public void RMBHold(int X, int Y, int time)
        {
            freeze_mouse(X, Y, 50);
            if (should_release_rmb_hold_after_next_stop)
            {
                if (app_right_hold_active == false)
                {
                    right_down();
                    app_right_hold_waiting_for_release_after_move = false;
                    show_right_hold_indicator = true;
                    sync_hold_indicator_visibility();
                }
            }
            else if (app_right_hold_active == false)
            {
                right_down();
                show_right_hold_indicator = true;
                sync_hold_indicator_visibility();
            }
            else
            {
                right_up();
            }
            freeze_mouse(X, Y, time);
        }
    }
}
