using ClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAtom.Resource.Controls
{
    /// <summary>
    /// Логика взаимодействия для Admixture_UC.xaml
    /// </summary>
    public partial class Admixture_UC : UserControl
    {
        public Admixture_UC()
        {
            InitializeComponent();
            txtValue.Text = MainWindow.wavelenght_txt;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgResult.ItemsSource = DeterminateElement.GetResult(txtValue.Text);       
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }
    }
}
