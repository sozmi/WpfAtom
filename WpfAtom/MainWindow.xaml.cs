using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfAtom.Resource.Controls;

namespace WpfAtom
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string wavelenght_txt;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Обработка события Click
        /// <summary>
        /// Открыть форму поиска длины волн для примеси
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchWavelenght_Click(object sender, RoutedEventArgs e)
        {
            ChangeControl(new Wavelenght_UC(), (Button)sender, "ПОИСК ДЛИН ВОЛН ПРИМЕСИ", Visibility.Visible);
        }
        /// <summary>
        /// Открыть форму определения примеси
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeterminateElem_Click(object sender, RoutedEventArgs e)
        {
            ChangeControl(new Admixture_UC(), (Button)sender, "ОПРЕДЕЛЕНИЕ ПРИМЕСИ", Visibility.Visible);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ChangeControl(null, null, "ГЛАВНОЕ МЕНЮ", Visibility.Collapsed);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Directory_Click(object sender, RoutedEventArgs e)
        {
            ChangeControl(new Directory(), (Button)sender, "СПРАВКА", Visibility.Visible);
        }
        #endregion
        private static Button currentButton;
        private static readonly SolidColorBrush colorButton = new SolidColorBrush(Color.FromArgb(100, 0, 128, 128));
        /// <summary>
        /// функция для изменения цвета кнопок при их выборе
        /// </summary>
        /// <param name="button"></param>
        private void ChangeColorButton(Button button)
        {
            if (currentButton == null)
            {
                currentButton = button;
                currentButton.Background = colorButton;
                return;
            }
            else
            {    
                if (button == null)
                {
                    currentButton.Background = null;
                    currentButton = button;           
                    return;
                }
                if (currentButton != button)
                {
                    currentButton.Background = null;
                    currentButton = button;
                    currentButton.Background = colorButton;
                }
            }
        }

        /// <summary>
        /// Изменение содержимого основного ContentControl
        /// </summary>
        /// <param name="control">ContentControl</param>
        /// <param name="button">Нажатая кнопка</param>
        /// <param name="title">Заголовок открываемой страницы</param>
        /// <param name="visibility">Видимость кнопки возврата на главную страницу</param>
        private void ChangeControl(UserControl control, Button button, string title, Visibility visibility)
        {
            BtnCancel.Visibility = visibility;
            content_panel.Content = control;
            ChangeColorButton(button);
            formName_txt.Text = title;
        }


    }
}
