using System;
using System.Collections.Generic;
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
    /// Interaction logic for SelectFileControl.xaml
    /// </summary>
    public partial class SelectFileControl : UserControl
    {
        public SelectFileControl()
        {
            InitializeComponent();
            DefaultExt = ".xml";
            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            CheckFileExists = true;
            this.DataContext = this;
        }

        public string Title { get; set; }
        

        public string DefaultExt
        {
            get;
            set;
        }

        public string Filter
        {
            get;
            set;
        }

        public delegate void ButtonClick(object sender, RoutedEventArgs e);

        public event ButtonClick? OnButtonClick;
        public string FilePath => _filePath;
        private string _filePath = "";
        public bool CheckFileExists { get; set; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OnButtonClick?.Invoke(sender, e);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                // Set filter for file extension and default file extension 
                DefaultExt = DefaultExt,
                Filter = Filter,
                CheckFileExists = CheckFileExists
            };


            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                button.Content = dlg.SafeFileName;
                _filePath = dlg.FileName;
            }
        }
    }
}
