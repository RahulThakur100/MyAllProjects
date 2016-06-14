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
using System.Drawing;
using Microsoft.Win32;

using System.Windows.Navigation;
using System.Windows.Shapes;




namespace WpfNotepad
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var win2 = new About();
            win2.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TextRange txtRange = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
            txtRange.Text = "";
            Title = "Utility.txt";
            status.Content = "";      
          }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            TextRange txtRange = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
            try
            {
                File.WriteAllText(Title, txtRange.Text);
                status.Content = Title + " is saved";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                TextRange txtRange = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Text Files (*.txt)|*.txt";
                fd.ShowDialog();
                txtRange.Text = File.ReadAllText(fd.FileName);

                Title = System.IO.Path.GetFileName(fd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            TextRange txtRange = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
            try
            {
                File.Delete(Title);
                status.Content = Title + " is deleted";
                txtRange.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            TextRange txtRange = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd);
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog1.Title = "Save a Text File";
                ////saveFileDialog1.ShowDialog();
                saveFileDialog1.RestoreDirectory = true;
                //saveFileDialog1.ShowDialog();
               
               
                    if (saveFileDialog1.ShowDialog() == true)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, txtRange.Text);
                    status.Content = System.IO.Path.GetFileName(saveFileDialog1.FileName) + " is saved";
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

       

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            ScrollViewer viewer = new ScrollViewer();
            viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        }

        private void ff_Click(object sender, RoutedEventArgs e)
        {
            
        }
       
       
    }
}
