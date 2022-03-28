using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ONIT_Kursov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Encryption Encryption;
        public MainWindow()
        {
            InitializeComponent();
            aesCheck.Checked += AesCheck_Checked; desCheck.Checked += DesCheck_Checked;
        }

        private void DesCheck_Checked(object sender, RoutedEventArgs e)
        {
            aesCheck.IsChecked = false;
        }

        private void AesCheck_Checked(object sender, RoutedEventArgs e)
        {
            desCheck.IsChecked = false;
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData("FileDrop");
            long sumByte = 0;
            try
            {
                foreach (var item in paths)
                {
                    Encryption = new Encryption(item, "0");
                    using (var stream = File.OpenRead(item))
                    {
                        sumByte += stream.Length;
                        WriteLog("Файл " + item + $" загружен ({stream.Length} byte)");
                    }
                }
                WriteLog("Всего файлов: " + paths.Length + $"({sumByte} byte)");
                UpdQuery();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, Brushes.Red);
            }
        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileManager = new OpenFileDialog();
            fileManager.ShowDialog();
            var item = fileManager.FileName;
            if (item != "")
            {
                Encryption = new Encryption(item, "0");
                using (var stream = File.OpenRead(item))
                {
                    WriteLog("Файл " + item + $" загружен ({stream.Length} byte)");
                }
                UpdQuery();
            }
        }

        private void WriteLog(string message, System.Windows.Media.SolidColorBrush color = null)
        {
            if (color == null)
                color = System.Windows.Media.Brushes.Black;
            var text = new TextBlock() { Text = message, Foreground = color };
            Log.Items.Add(text);
            Log.ScrollIntoView(text);
            Log.SelectedItem = text;
        }

        private void UpdQuery()
        {
            int i = 0;
            Query.Items.Clear();
            TextBlock text;
            if (i == 0)
            {
                text = new TextBlock() { Text = Encryption.SourceFilePath, Foreground = System.Windows.Media.Brushes.DarkGreen };
            }
            else
            {
                text = new TextBlock() { Text = Encryption.SourceFilePath, Foreground = System.Windows.Media.Brushes.Black };
            }
            Query.Items.Add(text);
            i++;
        }

        private void EncryptClick(object sender, RoutedEventArgs e)
        {
            if(Key.Password == "" || RKey.Password == "")
            {
                MessageBox.Show("Введите пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Encryption == null || Encryption.SourceFilePath == "")
            {
                MessageBox.Show("Добавьте Файл", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!CheckKeyRepeat())
            {
                MessageBox.Show("Пароли не совпадают", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var encFile = Encryption;
                SaveFileDialog fileManager = new SaveFileDialog();
                fileManager.Filter = "Файлы enc|*.enc";
                fileManager.FileName = encFile.GetNameFileWithoutFormat() + '.' + encFile.FormatFile + ".enc";
                fileManager.FileOk += FileManager_EncryptGo;
                fileManager.ShowDialog();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, Brushes.DarkRed);
            }
        }

        private void DecryptClick(object sender, RoutedEventArgs e)
        {
            if (Key.Password == "" || RKey.Password == "")
            {
                MessageBox.Show("Введите пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Encryption.SourceFilePath == null)
            {
                MessageBox.Show("Добавьте Файл", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!CheckKeyRepeat())
            {
                MessageBox.Show("Пароли не совпадают", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var encFile = Encryption;
                SaveFileDialog fileManager = new SaveFileDialog();
                fileManager.FileName = encFile.GetNameFileWithoutFormat();
                fileManager.FileOk += FileManager_DecryptGo;
                fileManager.ShowDialog();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, Brushes.DarkRed);
            }
        }

        private async void FileManager_DecryptGo(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var encFile = Encryption;
            var item = ((SaveFileDialog)sender).FileName;
            try
            {
                if (item != "")
                {
                    encFile.Key = Key.Password;
                    encFile.UseDES = desCheck.IsChecked.Value;
                    //encFile.DeleteSource = deleteCheck.IsChecked.Value;
                    await encFile.DecryptInFileAsync(item);
                }
                WriteLog("Файл " + item + " успешно сохранен", Brushes.DarkBlue);
                UpdQuery();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, Brushes.DarkRed);
            }
        }

        private async void FileManager_EncryptGo(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var encFile = Encryption;
            var item = ((SaveFileDialog)sender).FileName;
            try
            {
                if (item != "")
                {
                    encFile.Key = Key.Password;
                    encFile.UseDES = desCheck.IsChecked.Value;
                    //encFile.DeleteSource = deleteCheck.IsChecked.Value;
                    await encFile.EncryptInFileAsync(item);               
                }
                WriteLog("Файл " + item + " успешно сохранен", Brushes.DarkBlue);
                UpdQuery();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, Brushes.DarkRed);
            }
        }

        private bool CheckKeyRepeat()
        {
            if (Key.Password == RKey.Password)
                return true;
            return false;
        }

        private void ClearQuery(object sender, RoutedEventArgs e)
        {
            Encryption = new Encryption("","", false);
            UpdQuery();
        }
    }
}
