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
using System.IO;
using Microsoft.Win32;

namespace fileUploadTuts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filePath = string.Empty;
        private string fileServerLocation = string.Empty;
        private string fileName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void fileBrowseBtn_Click(object sender, RoutedEventArgs e)
        {

            string[] temp = new string[] { };
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt | (*.txt)";
            ofd.DefaultExt= "txt";
            ofd.InitialDirectory = " ";
            ofd.Title = "Uploading File";

            if ((bool)ofd.ShowDialog() != true) 
            {
                return;
            }

            temp = ofd.FileName.Split('\\');
            fileName = temp[temp.Length];
            filePath = ofd.FileName;
            fileNameLbl.Content = filePath;
        }

        private void submitFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filePath.Length < 1) 
            {
                MessageBox.Show("No file has been browsed!");
                return;
            }

            fileServerLocation = "C:\\Users\\julet\\Documents\\";

            Directory.CreateDirectory(fileServerLocation);

            try
            {
                File.Copy(filePath, fileServerLocation + "\\" + fileName);
            }
            catch (IOException ioe) 
            {
                MessageBox.Show(ioe.Message);
            }

        }
    }
}
