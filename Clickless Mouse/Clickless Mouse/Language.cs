using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Clickless_Mouse
{
    public partial class MainWindow : Window
    {
        string error_title, about_title, about_content, contentLscreen_resolution,
            argb_error, screen_size_error1, screen_size_error2, time_to_start_mouse_movement_error,
            cursor_time_in_square_error, min_square_size_too_low_error, min_square_size_too_high_error,
            square_size_error, square_border_error, cursor_idle_time_error,
            hold_release_delay_after_stop_error, loading_error_msg,
            about_latest_version, about_installed_version, about_homepage, about_changelog, about_eula;

        enum language
        {
            en,
            pl,
            zh
        }

        void change_language(language lang)
        {
            set_instructions(lang);

            if (lang == language.en)
            {
                MIfile.Header = "File";
                MIexit.Header = "Exit";
                MIrestore.Header = "Restore";
                MIdefault_colors.Header = "Default Square Colors";
                MIdefault_settings.Header = "All Default Settings";
                MIlanguage.Header = "Language";
                MIenglish.Header = "English";
                MIpolish.Header = "Polish";
                MIchinese.Header = "Chinese";
                MIhelp.Header = "Help";
                MImanual.Header = "User Guide";
                MIabout.Header = "About";
                GBmain_settings.Header = "Main Settings";
                CHBLMB.Content = "LMB click";
                CHBRMB.Content = "RMB click";
                CHBdoubleLMB.Content = "LMB double click";
                CHBholdLMB.Content = "LMB holding";
                CHBholdRMB.Content = "RMB holding";
                CHBscreen_panning.Content = "Screen panning";
                Lcursor_idle_before_squares_appear.Text = "Cursor idle time before squares appear [ms]:";
                Ltime_to_start_mouse.Text = "Time to start mouse movement after squares appear [ms]:";
                Lcursor_time_in_square.Text = "Cursor time in square to register click [ms]:";
                GBother_settings.Header = "Other Settings";
                CHBrun_at_startup.Content = "Run when computer starts";
                CHBstart_minimized.Content = "Start minimized";
                CHBminimize_to_tray.Content = "Minimize to system tray";
                CHBcheck_for_updates.Content = "Check for updates automatically";
                SetWrappedContent(CHBlmb_hold_release_after_stop, "Release LMB hold after stopping for a moment");
                SetWrappedContent(CHBrmb_hold_release_after_stop, "Release RMB hold after stopping for a moment");
                Lhold_release_delay_after_stop.Text = "Hold release delay after stop [ms]:";
                GBsquare_settings.Header = "Squares Settings";
                Lsquare_size.Content = "Size [px]:";
                Lsquare_border.Content = "Border width [px]:";
                Lsquare_color1.Content = "Color 1:";
                Lsquare_color2.Content = "Color 2:";
                Lmin_square_size.Content = "Minimum size [%]:";
                GBrecommended_square_size.Header = "Recommended Square Size";
                Lscreen_size.Content = "Diagonal screen size [in]:";
                contentLscreen_resolution = "Screen resolution: ";
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                Lscreen_resolution.Content = contentLscreen_resolution + x + "x" + y;
                Bset_recommended_square.Content = "Set recommended square size";

                error_title = "Error";
                about_title = "About";
                about_content = "Version: " + prog_version + "\nAuthor: Mikołaj Magowski";
                about_latest_version = "Latest version: ";
                about_installed_version = "Installed version: ";
                about_homepage = "Homepage: ";
                about_changelog = "Changelog";
                about_eula = "EULA";
                argb_error = "ARGB color value must be lower than 0";
                screen_size_error1 = "Diagonal screen size must be higher than 0";
                screen_size_error2 = "Diagonal screen size can't be empty";
                cursor_idle_time_error = "Cursor idle time before squares appear cannot be lower than ";
                hold_release_delay_after_stop_error = "Hold release delay after stop cannot be lower than ";
                time_to_start_mouse_movement_error = "Time to start mouse movement cannot be lower than ";
                cursor_time_in_square_error = "Cursor time in square to register click cannot be "
                    + "lower than ";
                square_size_error = "Square size cannot be lower than ";
                square_border_error = "Square border width cannot be lower than ";
                min_square_size_too_low_error = "Minimum square size cannot be lower than ";
                min_square_size_too_high_error = "Minimum square size cannot be higher than ";
                loading_error_msg = " Settings loading error - values that weren't loaded will be " +
                    "restored to default and saved.";
            }
            else if(lang == language.pl)
            {
                MIfile.Header = "Plik";
                MIexit.Header = "Zakończ";
                MIrestore.Header = "Przywróć";
                MIdefault_colors.Header = "Domyślne kolory kwadratu";
                MIdefault_settings.Header = "Wszystkie ustawienia domyślne";
                MIlanguage.Header = "Język";
                MIenglish.Header = "Angielski";
                MIpolish.Header = "Polski";
                MIchinese.Header = "Chiński";
                MIhelp.Header = "Pomoc";
                MImanual.Header = "Instrukcja obsługi";
                MIabout.Header = "O programie";
                GBmain_settings.Header = "Ustawienia główne";
                CHBLMB.Content = "Klik LPM";
                CHBRMB.Content = "Klik PPM";
                CHBdoubleLMB.Content = "Dwuklik LPM";
                CHBholdLMB.Content = "Przytrzymanie LPM";
                CHBholdRMB.Content = "Przytrzymanie PPM";
                CHBscreen_panning.Content = "Przesuwanie ekranu";
                Lcursor_idle_before_squares_appear.Text = "Czas bezczynności kursora zanim pojawią" +
                    " się kwadraty [ms]:";
                Ltime_to_start_mouse.Text = "Czas na rozpoczęcie ruchu myszą po pojawieniu się "
                    + "kwadratów [ms]:";
                Lcursor_time_in_square.Text = "Czas kursora w kwadracie do zarejestrowania kliknięcia [ms]:";                    
                GBother_settings.Header = "Pozostałe ustawienia";
                CHBrun_at_startup.Content = "Uruchom przy starcie komputera";
                CHBstart_minimized.Content = "Uruchom zminimalizowany";
                CHBminimize_to_tray.Content = "Minimalizuj do zasobnika systemowego";
                CHBcheck_for_updates.Content = "Automatycznie sprawdzaj aktualizacje";
                SetWrappedContent(CHBlmb_hold_release_after_stop, "Zwolnij przytrzymanie LPM po krótkim zatrzymaniu");
                SetWrappedContent(CHBrmb_hold_release_after_stop, "Zwolnij przytrzymanie PPM po krótkim zatrzymaniu");
                Lhold_release_delay_after_stop.Text = "Opóźnienie zwolnienia przytrzymania po zatrzymaniu [ms]:";
                GBsquare_settings.Header = "Ustawienia kwadratów";
                Lsquare_size.Content = "Rozmiar [px]:";
                Lsquare_border.Content = "Szerokość krawędzi [px]:";
                Lsquare_color1.Content = "Kolor 1:";
                Lsquare_color2.Content = "Kolor 2:";
                Lmin_square_size.Content = "Minimalny rozmiar [%]:";
                GBrecommended_square_size.Header = "Zalecany rozmiar kwadratu";
                Lscreen_size.Content = "Przekątna ekranu [cale]:";
                contentLscreen_resolution = "Rozdzielczość ekranu: ";
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                Lscreen_resolution.Content = contentLscreen_resolution + x + "x" + y;
                Bset_recommended_square.Content = "Ustaw zalecaną wielkość kwadratu";

                error_title = "Błąd";
                about_title = "O programie";
                about_content = "Wersja: " + prog_version + "\nAutor: Mikołaj Magowski";
                about_latest_version = "Najnowsza wersja: ";
                about_installed_version = "Zainstalowana wersja: ";
                about_homepage = "Strona internetowa: ";
                about_changelog = "Lista zmian";
                about_eula = "Umowa licencyjna";
                argb_error = "Wartość ARGB koloru musi być mniejsza od 0";
                screen_size_error1 = "Przekątna ekranu musi być większa od 0";
                screen_size_error2 = "Przekątna ekranu nie może być pusta";
                cursor_idle_time_error = "Czas bezczynności kursora zanim pojawią się kwadraty nie może" +
                    " być niższy niż ";
                hold_release_delay_after_stop_error = "Opóźnienie zwolnienia przytrzymania po zatrzymaniu nie może być niższe niż ";
                time_to_start_mouse_movement_error = "Czas na rozpoczęcie ruchu myszą nie może być "
                    + "niższy niż ";
                cursor_time_in_square_error = "Czas kursora w kwadracie do zarejestrowania kliknięcia"
                    + " nie może byc niższy niż ";
                square_size_error = "Rozmiar kwadratu nie może być niższy niż ";
                square_border_error = "Rozmiar krawędzi kwadratu nie może być niższy niż ";
                min_square_size_too_low_error = "Minimalny rozmiar kwadratu nie może być niższy niż ";
                min_square_size_too_high_error = "Minimalny rozmiar kwadratu nie może być wyższy niż ";
                loading_error_msg = " Błąd odczytu ustawień - wartości, które nie zostały wczytane " +
                    "zostaną przywrócone do domyślnych i zapisane.";
            }
            else if (lang == language.zh)
            {
                MIfile.Header = "文件";
                MIexit.Header = "退出";
                MIrestore.Header = "恢复";
                MIdefault_colors.Header = "恢复默认方块颜色";
                MIdefault_settings.Header = "恢复全部默认设置";
                MIlanguage.Header = "语言";
                MIenglish.Header = "英语";
                MIpolish.Header = "波兰语";
                MIchinese.Header = "中文";
                MIhelp.Header = "帮助";
                MImanual.Header = "使用说明";
                MIabout.Header = "关于";
                GBmain_settings.Header = "主要设置";
                CHBLMB.Content = "左键单击";
                CHBRMB.Content = "右键单击";
                CHBdoubleLMB.Content = "左键双击";
                CHBholdLMB.Content = "左键按住";
                CHBholdRMB.Content = "右键按住";
                CHBscreen_panning.Content = "屏幕平移";
                Lcursor_idle_before_squares_appear.Text = "光标静止多久后显示方块 [毫秒]:";
                Ltime_to_start_mouse.Text = "方块出现后开始移动鼠标的时间 [毫秒]:";
                Lcursor_time_in_square.Text = "光标停留在方块内触发点击的时间 [毫秒]:";
                GBother_settings.Header = "其他设置";
                CHBrun_at_startup.Content = "开机时运行";
                CHBstart_minimized.Content = "启动时最小化";
                CHBminimize_to_tray.Content = "最小化到系统托盘";
                CHBcheck_for_updates.Content = "自动检查更新";
                SetWrappedContent(CHBlmb_hold_release_after_stop, "短暂停顿后释放左键按住");
                SetWrappedContent(CHBrmb_hold_release_after_stop, "短暂停顿后释放右键按住");
                Lhold_release_delay_after_stop.Text = "停止后释放按住的延迟 [毫秒]:";
                GBsquare_settings.Header = "方块设置";
                Lsquare_size.Content = "大小 [像素]:";
                Lsquare_border.Content = "边框宽度 [像素]:";
                Lsquare_color1.Content = "颜色 1:";
                Lsquare_color2.Content = "颜色 2:";
                Lmin_square_size.Content = "最小大小 [%]:";
                GBrecommended_square_size.Header = "推荐方块大小";
                Lscreen_size.Content = "屏幕对角线尺寸 [英寸]:";
                contentLscreen_resolution = "屏幕分辨率: ";
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                Lscreen_resolution.Content = contentLscreen_resolution + x + "x" + y;
                Bset_recommended_square.Content = "设置推荐方块大小";

                error_title = "错误";
                about_title = "关于";
                about_content = "版本: " + prog_version + "\n作者: Mikołaj Magowski";
                about_latest_version = "最新版本: ";
                about_installed_version = "已安装版本: ";
                about_homepage = "主页: ";
                about_changelog = "更新日志";
                about_eula = "最终用户许可协议";
                argb_error = "颜色 ARGB 值必须小于 0";
                screen_size_error1 = "屏幕对角线尺寸必须大于 0";
                screen_size_error2 = "屏幕对角线尺寸不能为空";
                cursor_idle_time_error = "光标静止多久后显示方块不能小于 ";
                hold_release_delay_after_stop_error = "停止后释放按住的延迟不能小于 ";
                time_to_start_mouse_movement_error = "开始移动鼠标的时间不能小于 ";
                cursor_time_in_square_error = "光标停留在方块内触发点击的时间不能小于 ";
                square_size_error = "方块大小不能小于 ";
                square_border_error = "方块边框宽度不能小于 ";
                min_square_size_too_low_error = "最小方块大小不能小于 ";
                min_square_size_too_high_error = "最小方块大小不能大于 ";
                loading_error_msg = " 设置读取错误 - 未能读取的值将恢复为默认值并重新保存。";
            }
        }

        void set_instructions(language lang)
        {
            if(lang == language.en)
            {
                wm.Title = "User Guide";

                FlowDocument fd = new FlowDocument();
                Paragraph p1 = new Paragraph();
                p1.Inlines.Add(new Run("Clickless Mouse makes using a computer easier for people with"
                    + " repetitive strain injury, carpal tunnel syndrome, some motor disabilities and"
                    + " other health problems."
                    + "\n\nThis application allows using a mouse without clicking - by moving it only."
                    + "\nBy reacting to user mouse movements this program simulates left/right mouse button"
                    + " click, double left mouse button click and left/right mouse button holding."
                    + "\n\nClickless Mouse can be used with a virtual keyboard to type by moving mouse" +
                    " (e.g. Free Virtual Keyboard: "));

                Hyperlink link = new Hyperlink();
                link.IsEnabled = true;
                link.Inlines.Add("https://freevirtualkeyboard.com/");
                link.NavigateUri = new Uri("https://freevirtualkeyboard.com/");
                link.RequestNavigate += (sender, args) => System.Diagnostics.Process.Start(args.Uri.ToString());
                p1.Inlines.Add(link);

                p1.Inlines.Add(new Run(").\n\nBy using Clickless Mouse with a virtual keyboard " +
                    "a user can fully control a computer by moving a mouse."
                    + "\n\nWhen you want to click/hold a mouse button: stop moving the mouse"
                    + ", wait for the squares to appear and move the mouse cursor to the chosen square:"));

                List a = new List();
                a.MarkerStyle = TextMarkerStyle.Disc;
                a.Padding = new Thickness(25, 0, 0, 0);
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Top center square = double left mouse button click"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Top left square = left mouse button click"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Top right square = right mouse button click"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Left square = left mouse button holding on/off"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Right square = right mouse button holding on/off"))));

                BitmapImage bitmap = new BitmapImage(new Uri(
                    "pack://application:,,,/Clickless Mouse;component/1en.jpg"));
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = bitmap;
                image.Width = 442;
                Paragraph p2 = new Paragraph();
                p2.Inlines.Add(image);

                p2.Inlines.Add(new Run("\nWhen the mouse cursor is located inside a square long enough"
                    + " (depending on cursor time in square to register click setting), " +
                    "it automatically moves"
                    + " back to the previous position to simulate an action based on the square that" +
                    " was previously entered."
                    + "\n\nIf the mouse cursor is too close to the top edge of the screen, squares for" +
                    " LMB click, RMB click and LMB double click are shown below the mouse cursor."
                    + "\n\nIf the mouse cursor is too close to the left/right edge of the screen all" +
                    " squares"
                    + " size decrease so at least 25% of a square is visible. By default decreased " +
                    "square size cannot be lower than 60% of the normal size."
                    + "\nSquares size don't decrease if the mouse cursor is so close to the edge" +
                    " of the screen that smallest size isn't enough to show a square."
                    + "\n\nThe squares that aren't needed can be disabled."
                    + "\n\nScreen panning - when this mode is on, moving the mouse cursor to the " +
                    "edges of" +
                    " the screen presses keys: up at top edge, down at bottom edge, " +
                    "left at left edge, " +
                    "right at right edge. While screen panning is enabled the squares don't show " +
                    "when the mouse cursor is located at the screen edge."
                    + "\n\nClickless Mouse works only in programs and games that are run in "
                    + "borderless or windowed mode (fullscreen mode is not supported)."));

                Paragraph p3 = new Paragraph();
                Bold b = new Bold();
                b.Inlines.Add(new Run("First steps:"));
                p3.Inlines.Add(b);

                List a2 = new List();
                a2.MarkerStyle = TextMarkerStyle.Decimal;
                a2.Padding = new Thickness(25, 0, 0, 0);
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Type your diagonal screen size and press 'Set recommended square size button'."))));
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Decide which mouse functionality you need. Most users need 'LMB Click', " +
                    "'RMB click, 'LMB click', 'LMB double click' and 'LMB holding'."))));
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "If you have a motor disability consider increasing cursor idle time before" +
                    " squares appear, time to start mouse movement after squares appear and" +
                    " square size."))));

                Paragraph p4 = new Paragraph();
                b = new Bold();
                b.Inlines.Add(new Run("Lowest possible values (the program ignores lower values and" +
                    " uses following values instead):"));
                p4.Inlines.Add(b);

                List a3 = new List();
                a3.MarkerStyle = TextMarkerStyle.Disc;
                a3.Padding = new Thickness(25, 0, 0, 0);
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Cursor idle time before squares appear [ms]: "
                    + lowest_cursor_idle_time_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Time to start mouse movement after squares appear [ms]: "
                    + lowest_time_to_start_mouse_movement_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Cursor time in square to register click [ms]: " 
                    + lowest_cursor_time_in_square_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Size [px]: " + lowest_size))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Border width [px]: " + lowest_border_width))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Minimum size [%]: " + lowest_min_square_size_percents))));

                fd.Blocks.Add(p1);
                fd.Blocks.Add(a);
                fd.Blocks.Add(p2);
                fd.Blocks.Add(p3);
                fd.Blocks.Add(a2);
                fd.Blocks.Add(p4);
                fd.Blocks.Add(a3);
                wm.RTBinstructions.Document = fd;
            }
            else if(lang == language.pl)
            {
                wm.Title = "Instrukcja obsługi";

                FlowDocument fd = new FlowDocument();
                Paragraph p1 = new Paragraph();
                Paragraph p2 = new Paragraph();
                p1.Inlines.Add(new Run("Clickless Mouse ułatwia użytkowanie komputera osobą z RSI " +
                    "(repetitive strain injury),"
                    + " zespołem cieśni nadgarstka, niektórymi niepełnosprawnościami ruchowymi oraz"
                    + " innymi problemami zdrowotnymi."
                    + "\n\nTa aplikacja umożliwia używanie myszki bez klikania - jedynie poprzez"
                    + " jej przesuwanie."
                    + "\n\nPoprzez reagowanie na poruszanie myszą przez użytkownika program symuluje"
                    + " lewy/prawy przycisk myszy, podwójne kliknięcie lewym przyciskiem myszy "
                    + "oraz przytrzymywanie lewego/prawego przycisku myszy."
                    + "\n\nClickless Mouse można używać z klawiaturą wirtualną do pisania poprzez " +
                    "poruszanie myszką (np. Free Virtual Keyboard: "));

                Hyperlink link = new Hyperlink();
                link.IsEnabled = true;
                link.Inlines.Add("https://freevirtualkeyboard.com/");
                link.NavigateUri = new Uri("https://freevirtualkeyboard.com/");
                link.RequestNavigate += (sender, args) => System.Diagnostics.Process.Start(args.Uri.ToString());
                p1.Inlines.Add(link);

                p1.Inlines.Add(new Run(").\n\nUżywając Clickless Mouse wraz z wirtualną klawiaturą"
                    + " użytkownik może w pełni kontrolować komputer poprzez poruszanie myszką."
                    + "\n\nKiedy chcesz kliknąć/przytrzymać przycisk myszy:"
                    + " zatrzymaj myszkę, poczekaj aż pojawią się kwadraty, a następnie przesuń"
                    + " kursor do wybranego kwadratu:"));

                List a = new List();
                a.MarkerStyle = TextMarkerStyle.Disc;
                a.Padding = new Thickness(25, 0, 0, 0);
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Górny środkowy kwadrat = podwójne kliknięcie lewym przyciskiem myszy"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Górny lewy kwadrat = kliknięcie lewym przyciskiem myszy"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Górny prawy kwadrat = kliknięcie prawym przyciskiem myszy"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Lewy kwadrat = włącz/wyłącz przytrzymanie lewego przycisku myszy"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Prawy kwadrat = włącz/wyłącz przytrzymanie prawego przycisku myszy"))));

                BitmapImage bitmap = new BitmapImage(new Uri(
                    "pack://application:,,,/Clickless Mouse;component/1pl.jpg"));
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = bitmap;
                image.Width = 521;
                p2.Inlines.Add(image);

                p2.Inlines.Add(new Run("\nKiedy kursor myszy znajduje się wystarczająco długo"
                    + " w kwadracie (w zależności od ustawienia czasu kursora w kwadracie do rejestracji"
                    + " kliknięcia)"
                    + ", przesunie się automatycznie do poprzedniej pozycji, aby zasymulować"
                    + " akcję na podstawie ostatnio odwiedzonego kwadratu."
                    + "\n\nJeśli kursor myszy jest zbyt blisko górnej krawędzi ekranu, kwadraty"
                    + " dla kliknięcia LPM, kliknięcia PPM i dwukliknięcia LPM są pokazywane"
                    + " poniżej kursora myszy."
                    + "\n\nGdy kursor myszy jest zbyt blisko lewej lub prawej krawędzi ekranu"
                    + " rozmiar wszystkich kwadratów zostaje zmniejszony tak aby przynajmniej 25%"
                    + " kwadratu było widoczne. Maksymalne domyślne zmniejszenie rozmiaru kwadratu to"
                    + " 60% oryginalnej wielkości."
                    + "\nWielkość kwadratów nie zmniejsza się, jeśli kursor jest na tyle blisko"
                    + " krawędzi ekranu, że najmniejszy rozmiar nie wystarczy do pokazania kwadratu."
                    + "\n\nIstnieje możliwość wyłączenia niepotrzebnych kwadratów."
                    + "\n\nPrzesuwanie ekranu - gdy tryb ten jest włączony, przesunięcie kursora do" +
                    " krawędzi ekranu powoduje naciśnięcie klawiszy: góra dla górnej krawędzi, dół" +
                    " dla dolnej krawędzi, lewo dla lewej krawędzi i prawo dla prawej krawędzi." +
                    " Gdy przesuwanie ekranu jest aktywne, kwadraty nie są pokazywane kiedy kursor" +
                    " myszy znajduje się na krawędzi ekranu."
                    + "\n\nClickless Mouse działa tylko w programach i grach, które zostały"
                    + " uruchomione w trybie bezramkowym lub okienkowym (tryb pełnoekranowy"
                    + " nie jest wspierany)."));

                Paragraph p3 = new Paragraph();
                Bold b = new Bold();
                b.Inlines.Add(new Run("Pierwsze kroki:"));
                p3.Inlines.Add(b);

                List a2 = new List();
                a2.MarkerStyle = TextMarkerStyle.Decimal;
                a2.Padding = new Thickness(25, 0, 0, 0);
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Podaj przekątną ekranu, a następnie naciśnij przycisk 'Ustaw zalecaną wielkość " +
                    "kwadratu'."))));
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Zdecyduj z jakich funkcji myszki chcesz skorzystać. Większość użytkowników wybiera"
                    + " 'Klik LPM', 'Klik PPM', 'Dwuklik LPM' oraz 'Przytrzymywanie LPM'."))));
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Jeśli posiadasz niepełnosprawność ruchową rozważ zwiększenie czasu bezczynności" +
                    " kursora zanim pojawią się kwadraty, czasu na rozpoczęcie " +
                    "ruchu myszą po pojawieniu się kwadratów oraz rozmiaru kwadratów."))));

                Paragraph p4 = new Paragraph();
                b = new Bold();
                b.Inlines.Add(new Run("Najniższe możliwe wartości (program ignoruje niższe wartości"
                    + " i używa poniższe zamiast nich):"));
                p4.Inlines.Add(b);

                List a3 = new List();
                a3.MarkerStyle = TextMarkerStyle.Disc;
                a3.Padding = new Thickness(25, 0, 0, 0);
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Czas bezczynności kursora zanim pojawią się kwadraty [ms]: "
                    + lowest_cursor_idle_time_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Czas na rozpoczęcie ruchu myszą po pojawieniu się kwadratów [ms]: "
                    + lowest_time_to_start_mouse_movement_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Czas kursora w kwadracie do zarejestrowania kliknięcia [ms]: "
                    + lowest_cursor_time_in_square_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Rozmiar [px]: " + lowest_size))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Szerokość krawędzi [px]: " + lowest_border_width))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "Minimalny rozmiar [%]: " + lowest_min_square_size_percents))));

                fd.Blocks.Add(p1);
                fd.Blocks.Add(a);
                fd.Blocks.Add(p2);
                fd.Blocks.Add(p3);
                fd.Blocks.Add(a2);
                fd.Blocks.Add(p4);
                fd.Blocks.Add(a3);
                wm.RTBinstructions.Document = fd;
            }
            else if (lang == language.zh)
            {
                wm.Title = "使用说明";

                FlowDocument fd = new FlowDocument();
                Paragraph p1 = new Paragraph();
                p1.Inlines.Add(new Run("Clickless Mouse 可帮助患有重复性劳损（RSI）、腕管综合征、"
                    + "部分运动障碍以及其他健康问题的用户更轻松地使用电脑。"
                    + "\n\n这个程序允许你只通过移动鼠标来操作，而不需要实际点击。"
                    + "\n程序会根据用户的鼠标移动来模拟左键/右键单击、左键双击以及左键/右键按住。"
                    + "\n\nClickless Mouse 可以与虚拟键盘配合使用，通过移动鼠标输入文字"
                    + "（例如 Free Virtual Keyboard: "));

                Hyperlink link = new Hyperlink();
                link.IsEnabled = true;
                link.Inlines.Add("https://freevirtualkeyboard.com/");
                link.NavigateUri = new Uri("https://freevirtualkeyboard.com/");
                link.RequestNavigate += (sender, args) => System.Diagnostics.Process.Start(args.Uri.ToString());
                p1.Inlines.Add(link);

                p1.Inlines.Add(new Run("）。\n\n将 Clickless Mouse 与虚拟键盘配合使用时，"
                    + "用户仅通过移动鼠标就可以完整控制电脑。"
                    + "\n\n当你想点击或按住鼠标按键时：停止移动鼠标，等待方块出现，"
                    + "然后将光标移动到目标方块："));

                List a = new List();
                a.MarkerStyle = TextMarkerStyle.Disc;
                a.Padding = new Thickness(25, 0, 0, 0);
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "上方中间方块 = 左键双击"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "左上方块 = 左键单击"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "右上方块 = 右键单击"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "左侧方块 = 左键按住开/关"))));
                a.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "右侧方块 = 右键按住开/关"))));

                BitmapImage bitmap = new BitmapImage(new Uri(
                    "pack://application:,,,/Clickless Mouse;component/1en.jpg"));
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = bitmap;
                image.Width = 442;
                Paragraph p2 = new Paragraph();
                p2.Inlines.Add(image);

                p2.Inlines.Add(new Run("\n当鼠标光标在某个方块中停留足够长时间后"
                    + "（取决于“光标停留在方块内触发点击的时间”设置），"
                    + "它会自动回到之前的位置，并根据刚进入的方块执行相应操作。"
                    + "\n\n如果鼠标光标过于接近屏幕上边缘，左键单击、右键单击和左键双击方块"
                    + "会显示在光标下方。"
                    + "\n\n如果鼠标光标过于接近屏幕左右边缘，所有方块会缩小，确保至少有 25%"
                    + " 的方块可见。默认情况下，缩小后的方块大小不会低于正常大小的 60%。"
                    + "\n如果光标离边缘太近，即使最小尺寸也不足以显示方块，则不会继续缩小。"
                    + "\n\n不需要的方块可以禁用。"
                    + "\n\n屏幕平移：启用该模式后，将鼠标移动到屏幕边缘会按下对应方向键："
                    + "上边缘为上、下边缘为下、左边缘为左、右边缘为右。启用屏幕平移时，"
                    + "当光标位于屏幕边缘时不会显示方块。"
                    + "\n\nClickless Mouse 仅适用于以无边框或窗口模式运行的程序和游戏"
                    + "（不支持全屏模式）。"));

                Paragraph p3 = new Paragraph();
                Bold b = new Bold();
                b.Inlines.Add(new Run("开始使用:"));
                p3.Inlines.Add(b);

                List a2 = new List();
                a2.MarkerStyle = TextMarkerStyle.Decimal;
                a2.Padding = new Thickness(25, 0, 0, 0);
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "输入屏幕对角线尺寸，然后点击“设置推荐方块大小”。"))));
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "决定你需要哪些鼠标功能。大多数用户会用到“左键单击”、“右键单击”、"
                    + "“左键双击”和“左键按住”。"))));
                a2.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "如果你有运动障碍，可以考虑增加“光标静止多久后显示方块”、"
                    + "“方块出现后开始移动鼠标的时间”和“方块大小”。"))));

                Paragraph p4 = new Paragraph();
                b = new Bold();
                b.Inlines.Add(new Run("最低可用值（程序会忽略更低的值，并改用以下数值）:"));
                p4.Inlines.Add(b);

                List a3 = new List();
                a3.MarkerStyle = TextMarkerStyle.Disc;
                a3.Padding = new Thickness(25, 0, 0, 0);
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "光标静止多久后显示方块 [毫秒]: " + lowest_cursor_idle_time_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "方块出现后开始移动鼠标的时间 [毫秒]: " + lowest_time_to_start_mouse_movement_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "光标停留在方块内触发点击的时间 [毫秒]: " + lowest_cursor_time_in_square_ms))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "大小 [像素]: " + lowest_size))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "边框宽度 [像素]: " + lowest_border_width))));
                a3.ListItems.Add(new ListItem(new Paragraph(new Run(
                    "最小大小 [%]: " + lowest_min_square_size_percents))));

                fd.Blocks.Add(p1);
                fd.Blocks.Add(a);
                fd.Blocks.Add(p2);
                fd.Blocks.Add(p3);
                fd.Blocks.Add(a2);
                fd.Blocks.Add(p4);
                fd.Blocks.Add(a3);
                wm.RTBinstructions.Document = fd;
            }
        }

        private void SetWrappedContent(System.Windows.Controls.CheckBox checkBox, string text)
        {
            System.Windows.Controls.TextBlock textBlock = checkBox.Content as System.Windows.Controls.TextBlock;
            if (textBlock != null)
            {
                textBlock.Text = text;
            }
            else
            {
                checkBox.Content = new System.Windows.Controls.TextBlock
                {
                    Text = text,
                    TextWrapping = System.Windows.TextWrapping.Wrap
                };
            }
        }
    }
}
