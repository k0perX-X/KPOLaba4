using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenExplorer(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            // combine the arguments together
            // it doesn't matter if there is a space after ','
            string argument = "/select, \"" + filePath + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml1.LinqXml1.Main(SelectFileControl1_1.FilePath, SelectFileControl1_2.FilePath);
                OpenExplorer(SelectFileControl1_2.FilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBlock11.Text = "[" + string.Join(", ", LinqXml11.LinqXml11.LinqMethod(SelectFileControl11.FilePath).Select(x => x.Key + " - " + x.Count.ToString())) + "]";
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml21.LinqXml21.Main(SelectFileControl21_1.FilePath, SelectFileControl21_2.FilePath, textBox21.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml31.LinqXml31.Main(SelectFileControl31_1.FilePath,
                    SelectFileControl31_2.FilePath, textBox31_1.Text, textBox31_2.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml41.LinqXml41.Main(SelectFileControl41_1.FilePath,
                    SelectFileControl41_2.FilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml51.LinqXml51.Main(SelectFileControl51_1.FilePath,
                    SelectFileControl51_2.FilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml61.LinqXml61.Main(SelectFileControl61_1.FilePath,
                    SelectFileControl61_2.FilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml71.LinqXml71.Main(SelectFileControl71_1.FilePath,
                    SelectFileControl71_2.FilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                LinqXml81.LinqXml81.Main(SelectFileControl81_1.FilePath, 
                    SelectFileControl81_2.FilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
