using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WinForms = System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }

    public partial class MainWindow : Window
    {

        public string folderName = "";
        string[] findFiles;
        int quantity;
        public interface IDialogService
        {
            void ShowMessage(string message);   // показ сообщения
            //string FilePath { get; set; }   // путь к выбранному файлу
            bool OpenFileDialog();  // открытие файла
            bool SaveFileDialog();  // сохранение файла
        }
        //---------------------------------------------------------Обработка пунктов меню----------------------------------------------------------------------
        private void Открыть_Клик(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog fbd = new WinForms.FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Путь к папке /PKE:";
            switch (fbd.ShowDialog())
            {
                    case WinForms.DialogResult.OK: folderName = fbd.SelectedPath;
                    try
                    {
                        findFiles = System.IO.Directory.GetFiles(@folderName, "*.pke", System.IO.SearchOption.AllDirectories);
                        quantity = findFiles.Length;
                    }
                    catch
                    {
                        quantity = 0;
                        MessageBox.Show("В папке отсутсвуют файлы .pke", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        XDocument xdoc = XDocument.Load(@"C:\Users\Александр\Desktop\1Задача Динамика\#data\card\PKE\НПП Динамика подстанция 1\27.02.2020 11.28\874553981_1582802942100.pke");
                        foreach (XElement Param_Check_PKE_Element in xdoc.Element("RM3_ПКЭ").Elements("Result_Check_PKE"))
                        {
                            XAttribute tstartAttribute = Param_Check_PKE_Element.Attribute("TimeStart");
                            XAttribute tstopAttribute = Param_Check_PKE_Element.Attribute("TimeStop");
                            XAttribute nameObjectAttribute = Param_Check_PKE_Element.Attribute("nameObject");
                            IEnumerable<XElement> de =
                            from el in xdoc.Descendants()
                            select el;
                            foreach (XElement el in de)
                            Console.WriteLine(el.Name);
                            if (tstartAttribute != null && tstopAttribute != null && nameObjectAttribute != null)
                            {
                                Console.WriteLine($"Время старта: {tstartAttribute.Value}");
                                Console.WriteLine($"Время остановки: {tstopAttribute.Value}");
                                Console.WriteLine($"Имя объекта: {nameObjectAttribute.Value}");
                            }
                            Console.WriteLine();
                        }
                    }
                    List<MyTable> result = new List<MyTable>(3);
                    for (int i = 0; i < quantity; i++)
                    {
                        var rand = new Random();
                        int[] array = new int[68];
                        for (int c = 0; c < 68; c++)
                            array[c] = rand.Next(1, 10); // [0 - 2^31)
                        result.Add(new MyTable((i+1), "НПП Динамика подстанция " + i, "25/02/20 15:01", "25/02/20 15:45", 1, array[i]));
                        //result.Add(new MyTable(i, "" + folderName[i], "25/02/20 15:01", "25/02/20 15:45", 1));
                    }
                    //result.Add(new MyTable(2, "НПП Динамика. Подстанция 2", "25/02/20 17:01", "25/02/20 19:45", 2));
                    //result.Add(new MyTable(3, "Портовая ПС", "25/02/20 16:01", "25/02/20 16:11", 2));
                    //result.Add(new MyTable(4, "Белорусская АЭС", "15/10/19 12:51", "15/10/19 13:01", 1));
                    //result.Add(new MyTable(1, "НПП Динамика. Подстанция 1", "25/02/20 15:01", "25/02/20 15:45", 1));
                    grid.ItemsSource = result;
                    break;
                case WinForms.DialogResult.Cancel: folderName = "Null"; break;
            }
         }
        private void Экспорт_Клик(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show("В данный момент функция экспорта в XML недоступна.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Выход_Клик(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBoxResult Result = MessageBox.Show("Закрыть приложение ?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (Result == MessageBoxResult.No)
            {
            }
        }
        private void О_программе_Клик(object sender, RoutedEventArgs e)
        {
            try
            {
                quantity = findFiles.Length;
            }
            catch
            {
                quantity = 0;
            }
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString() + "\nПрограмма просмотра PKE файлов " + "\nВерсия: 1.0" + "\nАвтор:" + "\nСеменов Александр Сергеевич");
        }
        //----------------------------------------------------- Тестовые пункты ----------------------------------------------------------------------------
        private void Список_Клик(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            try
            {
                string msg = string.Join(Environment.NewLine, findFiles);
                MessageBox.Show(menuItem.Header.ToString() + "\nКоличество загруженных файлов .pke = " + quantity + msg);
            }
            catch
            {
                MessageBox.Show(menuItem.Header.ToString() + "\nКоличество загруженных файлов .pke = 0");
            }
        }
        private void Переменные_Клик(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString() + "\nИмя папки" + folderName);
        }
        //-------------------------------------------------Конец обработки пунктов меню------------------------------------------------------------------------
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        //Получаем данные из таблицы
        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyTable path = grid.SelectedItem as MyTable;
            try
            {
                MessageBox.Show(" Номер: " + path.Номер + "\n Объект: " + path.Объект + "\n Время старта: " + path.Время_старта + "\n Время остановки: " + path.Время_остановки
                + "\n Схема проверки: " + path.Схема_проверки);
            }
            catch
            { }
        }
    }
    class MyTable
    {
        public MyTable(int Номер, string Объект, string Время_старта, string Время_остановки, int Схема_проверки, int Интервал_измерения)
        {
            this.Номер = Номер;
            this.Объект = Объект;
            this.Время_старта = Время_старта;
            this.Время_остановки = Время_остановки;
            this.Схема_проверки = Схема_проверки;
            this.Интервал_измерения = Интервал_измерения;
        }
        public int Номер { get; set; }
        public string Объект { get; set; }
        public string Время_старта { get; set; }
        public string Время_остановки { get; set; }
        public int Схема_проверки { get; set; }
        public int Интервал_измерения { get; set; }
    }
}
