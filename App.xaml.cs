﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WinForms = System.Windows.Forms;
using System.Xml.Linq;

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
        //Элементы XML файла========
        public long tstart;
        public long tstop;
        public string nameobject;
        public static string name;
        public static int number;
        public static int schema;
        public static string[,] current = new string[3, 3];
        public static string[] current_object = { "" };
        public static string[] objects = { "", "" };
        public static List<int> qList = new List<int>();
        public static double ver = 0.7;
        //public static int[] qelements = { 0, 0, 0, 0, 0 };
        public string intervalt;
        public long interval;
        //public int l = 0;
        //public int schema;
        public string ed;
        //==========================
        public string folderName = "";
        public static string[] findFiles;
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
                    }
                    List<MyTable> result = new List<MyTable>(3);
                    //int l = 0;
                    for (int i = 0; i < quantity; i++)
                    {
                        XDocument xdoc = XDocument.Load(findFiles[i]);
                        foreach (XElement Param_Check_PKE_Element in xdoc.Element("RM3_ПКЭ").Elements("Param_Check_PKE"))
                        {
                            XAttribute tstartAttribute = Param_Check_PKE_Element.Attribute("TimeStart");
                            XAttribute tstopAttribute = Param_Check_PKE_Element.Attribute("TimeStop");
                            XAttribute nameObjectAttribute = Param_Check_PKE_Element.Attribute("nameObject");
                            XAttribute averaging_interval_timeAttribute = Param_Check_PKE_Element.Attribute("averaging_interval_time");
                            XAttribute averaging_interval_Attribute = Param_Check_PKE_Element.Attribute("averaging_interval");
                            XAttribute active_schema_Attribute = Param_Check_PKE_Element.Attribute("active_cxema");
                            if (tstartAttribute != null && tstopAttribute != null && nameObjectAttribute != null && averaging_interval_timeAttribute != null && averaging_interval_Attribute != null && active_schema_Attribute != null)
                            {
                                tstart = long.Parse(tstartAttribute.Value);
                                tstop = long.Parse(tstopAttribute.Value);
                                nameobject = nameObjectAttribute.Value;
                                int intervalt_i = int.Parse(averaging_interval_timeAttribute.Value) / 1000;
                                interval = long.Parse(averaging_interval_Attribute.Value);
                                schema = int.Parse(active_schema_Attribute.Value);
                                if (intervalt_i < 60)
                                {
                                    intervalt = intervalt_i.ToString() + " сек";
                                }
                                else
                                {
                                    int sec;
                                    int min;
                                    if (intervalt_i == 60)
                                    {
                                        intervalt = "1 мин";
                                    }
                                    else
                                    {
                                        do
                                        {
                                            min = intervalt_i / 60;
                                            sec = intervalt_i % 60;
                                            if (sec == 0)
                                            {
                                                intervalt = min.ToString() + " мин";
                                            }
                                            else
                                            {
                                                string res_s = sec.ToString();
                                                intervalt = min.ToString() + " мин " + res_s + " сек";
                                            }
                                        }
                                        while (sec > 60);
                                    }
                                }
                            }
                        }
                        //Обработка Time start
                        TimeSpan time_start = TimeSpan.FromMilliseconds(tstart);
                        DateTime tstart_t = new DateTime(time_start.Ticks);
                        tstart_t.Add(time_start);
                        //Добавление 1970 лет к полученной дате
                        TimeSpan duration = new TimeSpan(719528, 0, 0, 0);
                        DateTime answer = tstart_t.Add(duration);
                        string tstart_s = answer.ToString("dd MMMM yyyy hh:mm:ss tt");
                        //Обработка Time stop
                        TimeSpan time_stop = TimeSpan.FromMilliseconds(tstop);
                        DateTime tstop_t = new DateTime(time_stop.Ticks);
                        tstop_t.Add(time_stop);
                        //Добавление 1970 лет к полученной дате
                        DateTime answer1 = tstop_t.Add(duration);
                        string tstop_s = answer1.ToString("dd MMMM yyyy hh:mm:ss tt");
                        int l = 0;
                        try
                        {
                            for (int t = 1; t <= objects.Length; t++)
                            {
                                if (objects[t] != nameobject)
                                {
                                    l += 1;
                                    // Добавление элемента в коллекцию 
                                    qList.Add(0);
                                    // Подсчёт количества файлов с одинаковым именем объекта
                                    qList[l] += 1;
                                    objects[t] = nameobject;
                                    // Добавление результата в таблицу
                                    result.Add(new MyTable(qList.Count - 1, nameobject, tstart_s, tstop_s, schema, intervalt));
                                }
                                else
                                {
                                    qList[l] += 1;
                                }
                                
                            }
                        }
                        catch
                        {
                        }
                    }
                    grid.ItemsSource = result;
                    break;
                case WinForms.DialogResult.Cancel: folderName = "Null"; break;
            }
        }
        private void Экспорт_Клик(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show("В данный момент функция экспорта в Excel недоступна.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
            String version = "Версия: " + ver;
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show("Программа просмотра PKE файлов " + "\n" + version + "\nАвтор:" + "\nСеменов Александр Сергеевич", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
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
            //Переменная pnumber - номер объекта в массиве путей файлов
            //Переменная pquantity - количество файлов проверок объекта
            int pnumber = 0;
            int pquantity = 0;
            MyTable path = grid.SelectedItem as MyTable;
            try
            {
                name = path.Объект;
                number = path.Номер;
                int rank = current.Rank;
                for (int i = 1; i <= number; i++)
                {
                    // Подсчёт индекса массива для обращения в массив findFiles[] и заполнения путей файлам текущего объекта
                    pnumber += qList[i];
                }
                pquantity = qList[number];
                // Если количество элементов не равно 0, заполняется массив current_object
                if (pnumber !=0)
                {
                    int d = pnumber;
                    //
                    for (int i = 1; i<= pquantity; i++)
                    {
                        current_object[i] = findFiles[d];
                        Console.WriteLine("Текущий " + findFiles[d]);
                        d++;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                //Условия для открытия окна "Object"
                if (name!=null)
                {
                    new Object().ShowDialog();
                }
            }
        }
    }
        class MyTable
        {
            public MyTable(int Номер, string Объект, string Время_старта, string Время_остановки, int Схема_проверки, string Интервал_измерения)
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
            public string Интервал_измерения { get; set; }
        }
}
