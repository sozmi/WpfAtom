using ClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAtom.Resource.Controls
{
    /// <summary>
    /// Логика взаимодействия для Wavelenght_UC.xaml
    /// </summary>
    public partial class Wavelenght_UC : UserControl
    {
        public Wavelenght_UC()
        {
            InitializeComponent();
        }

        private void BtnStart_Clic(object sender, RoutedEventArgs e)
        {
            try
            {
                panel_result.Visibility = Visibility.Collapsed;
                txtResult.Text = Admixture.GetWavelenght(txtValue.Text);
                if (txtResult.Text != "Не удаётся найти длины волн примеси.")
                {
                    MainWindow.wavelenght_txt = txtResult.Text;
                }
                else
                {
                    MainWindow.wavelenght_txt = null;
                }
                    
                panel_result.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }
    }
}
