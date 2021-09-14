using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml.Linq;

//using MathNet.Numerics.LinearAlgebra;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Object.xaml
    /// </summary>
    public partial class Object : Window
    {
        public string NameObject = MainWindow.name;
        public int schema = MainWindow.schema;
        public int number = MainWindow.number;
        public string[] current_object = MainWindow.current_object; //Получение массива из другого класса
        //Переменные для схемы проверки 1
        public double ua;
        public double ia; // используется для двух схем
        public double pa;
        public double qa;
        public double sa;
        public double freq; // используется для двух схем
        public double sigmaUy; // используется для двух схем
        //Переменные для схемы проверки 2
        public double uab;
        public double ubc;
        public double uca;
        public double iab;
        public double ibc;
        public double ica;
        public double ib;
        public double ic;
        public double po;
        public double pp;
        public double qo;
        public double qp;
        public double so;
        public double sp;
        public double uo;
        public double up;
        public double io;
        public double ip;
        public double ko;
        public double sigmaUyab;
        public double sigmaUybc;
        public double sigmaUyca;
        public long TimeTek;
        public Object()
        {
            NameObject = MainWindow.name;
            InitializeComponent();
            this.Title = NameObject;
            for (int i = 0; i <= current_object.Length; i++)
            {
                Console.WriteLine("Текущий путь = " + current_object[i]);
                XDocument xdoc = XDocument.Load(current_object[i]);
                if ((schema != 1) || (schema == 2) || (schema == 3))
                {
                }
                else
                {
                    if (schema == 1)
                    {
                        List<Schema_1> result = new List<Schema_1>(3);
                        foreach (XElement Result_Check_PKE_Element in xdoc.Element("RM3_ПКЭ").Elements("Result_Check_PKE"))
                        {

                            XAttribute timetekAttribute = Result_Check_PKE_Element.Attribute("TimeTek");
                            XAttribute UAAttribute = Result_Check_PKE_Element.Attribute("UA");
                            XAttribute IAAttribute = Result_Check_PKE_Element.Attribute("IA");
                            XAttribute PAAttribute = Result_Check_PKE_Element.Attribute("PA");
                            XAttribute QAAttribute = Result_Check_PKE_Element.Attribute("QA");
                            XAttribute SAAttribute = Result_Check_PKE_Element.Attribute("SA");
                            XAttribute FreqAttribute = Result_Check_PKE_Element.Attribute("Freq");
                            XAttribute sigmaUyAttribute = Result_Check_PKE_Element.Attribute("sigmaUy");
                            if (timetekAttribute != null && UAAttribute != null && IAAttribute != null && PAAttribute != null && QAAttribute != null && SAAttribute != null && FreqAttribute != null && sigmaUyAttribute != null)
                            {
                                TimeTek = long.Parse(timetekAttribute.Value);
                                ua = double.Parse(UAAttribute.Value);
                                ia = double.Parse(IAAttribute.Value);
                                pa = double.Parse(PAAttribute.Value);
                                qa = double.Parse(QAAttribute.Value);
                                sa = double.Parse(SAAttribute.Value);
                                freq = double.Parse(FreqAttribute.Value);
                                sigmaUy = double.Parse(sigmaUyAttribute.Value);
                                //Обработка TimeTek
                                TimeSpan time_start = TimeSpan.FromMilliseconds(TimeTek);
                                DateTime tstart_t = new DateTime(time_start.Ticks);
                                tstart_t.Add(time_start);
                                TimeSpan duration = new TimeSpan(719528, 0, 0, 0);
                                DateTime answer = tstart_t.Add(duration);
                                string TimeTek_s = answer.ToString("dd MMMM yyyy hh:mm:ss tt");
                                //string ua_s = 
                                result.Add(new Schema_1(TimeTek_s, ua, ia, pa, qa, sa, freq, sigmaUy));
                            }

                        }
                    }
                    if ((schema == 2) || (schema == 3))
                    {
                        List<Schema_2> result = new List<Schema_2>(3);
                        foreach (XElement Result_Check_PKE_Element in xdoc.Element("RM3_ПКЭ").Elements("Result_Check_PKE"))
                        {

                            XAttribute timetekAttribute = Result_Check_PKE_Element.Attribute("TimeTek");
                            XAttribute UABAttribute = Result_Check_PKE_Element.Attribute("UAB");
                            XAttribute UBCAttribute = Result_Check_PKE_Element.Attribute("UBC");
                            XAttribute UCAAttribute = Result_Check_PKE_Element.Attribute("UCA");
                            XAttribute IABAttribute = Result_Check_PKE_Element.Attribute("IAB");
                            XAttribute IBCAttribute = Result_Check_PKE_Element.Attribute("IBC");
                            XAttribute ICAAttribute = Result_Check_PKE_Element.Attribute("ICA");
                            XAttribute IAAttribute = Result_Check_PKE_Element.Attribute("IA");
                            XAttribute IBAttribute = Result_Check_PKE_Element.Attribute("IB");
                            XAttribute ICCAttribute = Result_Check_PKE_Element.Attribute("IC");
                            XAttribute POAttribute = Result_Check_PKE_Element.Attribute("PO");
                            XAttribute PPAttribute = Result_Check_PKE_Element.Attribute("PP");
                            XAttribute QOAttribute = Result_Check_PKE_Element.Attribute("QO");
                            XAttribute QPAttribute = Result_Check_PKE_Element.Attribute("QP");
                            XAttribute SOAttribute = Result_Check_PKE_Element.Attribute("SO");
                            XAttribute SPAttribute = Result_Check_PKE_Element.Attribute("SP");
                            XAttribute UOAttribute = Result_Check_PKE_Element.Attribute("UO");
                            XAttribute UPAttribute = Result_Check_PKE_Element.Attribute("UP");
                            XAttribute IOAttribute = Result_Check_PKE_Element.Attribute("IO");
                            XAttribute IPAttribute = Result_Check_PKE_Element.Attribute("IP");
                            XAttribute KOAttribute = Result_Check_PKE_Element.Attribute("KO");
                            XAttribute FreqAttribute = Result_Check_PKE_Element.Attribute("Freq");
                            XAttribute sigmaUyAttribute = Result_Check_PKE_Element.Attribute("sigmaUy");
                            XAttribute sigmaUyABAttribute = Result_Check_PKE_Element.Attribute("sigmaUyAB");
                            XAttribute sigmaUyBCAAttribute = Result_Check_PKE_Element.Attribute("sigmaUyBC");
                            XAttribute sigmaUyCAAttribute = Result_Check_PKE_Element.Attribute("sigmaUyCA");
                            if (timetekAttribute != null && UABAttribute != null && UBCAttribute != null && UCAAttribute != null && IABAttribute != null && IBCAttribute != null && ICAAttribute != null && IAAttribute != null &&
                                IBAttribute != null && ICCAttribute != null && POAttribute != null && PPAttribute != null && QOAttribute != null && QPAttribute != null && SOAttribute != null && SPAttribute != null &&
                                UOAttribute != null && UPAttribute != null && IOAttribute != null && IPAttribute != null && KOAttribute != null && FreqAttribute != null && sigmaUyAttribute != null && sigmaUyABAttribute != null && sigmaUyBCAAttribute != null && sigmaUyCAAttribute != null)
                            {
                                uab = double.Parse(UABAttribute.Value);
                                ubc = double.Parse(UBCAttribute.Value);
                                uca = double.Parse(UCAAttribute.Value);
                                iab = double.Parse(IABAttribute.Value);
                                ibc = double.Parse(IBCAttribute.Value);
                                ica = double.Parse(ICAAttribute.Value);
                                ia = double.Parse(IAAttribute.Value);
                                ib = double.Parse(IBAttribute.Value);
                                ic = double.Parse(ICCAttribute.Value);
                                po = double.Parse(POAttribute.Value);
                                pp = double.Parse(PPAttribute.Value);
                                qo = double.Parse(QOAttribute.Value);
                                qp = double.Parse(QPAttribute.Value);
                                so = double.Parse(SOAttribute.Value);
                                sp = double.Parse(SPAttribute.Value);
                                uo = double.Parse(UOAttribute.Value);
                                up = double.Parse(UPAttribute.Value);
                                io = double.Parse(IOAttribute.Value);
                                ip = double.Parse(IPAttribute.Value);
                                ko = double.Parse(KOAttribute.Value);
                                freq = double.Parse(FreqAttribute.Value);
                                sigmaUy = double.Parse(sigmaUyAttribute.Value);
                                sigmaUyab = double.Parse(sigmaUyABAttribute.Value);
                                sigmaUybc = double.Parse(sigmaUyBCAAttribute.Value);
                                sigmaUyca = double.Parse(sigmaUyCAAttribute.Value);
                                TimeTek = long.Parse(timetekAttribute.Value);
                            }
                        }
                    }
                    
                }
            }
        }
        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (schema == 1)
            {
                Schema_1 path1 = grid.SelectedItem as Schema_1;
            }
            else
            {
                if (schema == 2)
                {
                    Schema_2 path1 = grid.SelectedItem as Schema_2;
                }
                else
                {
                }
            }
            try
            {
                NameObject = MainWindow.name;
                MessageBox.Show(" Имя: " + NameObject);
                Console.WriteLine("Имя объекта: " + NameObject);
            }
            catch
            { 
            }
        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (schema == 1)
            {
                //Schema_1 path1 = grid.SelectedItem as Schema_1; result add бла бла
            }
            else
            {
                if ((schema == 2)||(schema == 3))
                {
                    //Schema_2 path1 = grid.SelectedItem as Schema_2; result add бла бла
                }
                else
                {
                }
            }
        }
    }
    class Schema_1
    {
        public Schema_1(string Дата, double Ua, double Ia, double Pa, double Qa, double Sa, double Freq, double sigmaUy)
        {
            this.Дата = Дата;
            this.Ua = Ua;
            this.Ia = Ia;
            this.Pa = Pa;
            this.Qa = Qa;
            this.Sa = Sa;
            this.Freq = Freq;
            this.sigmaUy = sigmaUy;
        }
        public string Дата { get; set; }
        public double Ua { get; set; }
        public double Ia { get; set; }
        public double Pa { get; set; }
        public double Qa { get; set; }
        public double Sa { get; set; }
        public double Freq { get; set; }
        public double sigmaUy { get; set; }
    }
    class Schema_2
    {
        public Schema_2(string Дата, double UAB, double UBC, double UCA, double IAB, double IBC, double ICA, double IA,
                        double IB, double IC, double PO, double PP, double QO, double QP, double SO, double SP,
                        double UO, double UP, double IO, double IP, double KO, double Freq, double sigmaUy, double sigmaUyAB,
                        double sigmaUyBC, double sigmaUyCA)
        {
            this.Дата = Дата;
            this.UAB = UAB;
            this.UBC = UBC;
            this.UCA = UCA;
            this.IAB = IAB;
            this.IBC = IBC;
            this.ICA = ICA;
            this.IA = IA;
            this.IB = IB;
            this.IC = IC;
            this.PO = PO;
            this.PP = PP;
            this.QO = QO;
            this.QP = QP;
            this.SO = SO;
            this.SP = SP;
            this.UO = UO;
            this.UP = UP;
            this.IO = IO;
            this.IP = IP;
            this.KO = KO;
            this.Freq = Freq;
            this.sigmaUy = sigmaUy;
            this.sigmaUyAB = sigmaUyAB;
            this.sigmaUyBC = sigmaUyBC;
            this.sigmaUyCA = sigmaUyCA;
        }
        public string Дата { get; set; }
        public double UAB { get; set; }
        public double UBC { get; set; }
        public double UCA { get; set; }
        public double IAB { get; set; }
        public double IBC { get; set; }
        public double ICA { get; set; }
        public double IA { get; set; }
        public double IB{ get; set; }
        public double IC{ get; set; }
        public double PO{ get; set; }
        public double PP { get; set; }
        public double QO { get; set; }
        public double QP { get; set; }
        public double SO { get; set; }
        public double SP { get; set; }
        public double UO     { get; set; }
        public double UP    { get; set; }
        public double IO    { get; set; }
        public double IP    { get; set; }
        public double KO    { get; set; }
        public double Freq { get; set; }
        public double sigmaUy { get; set; }
        public double sigmaUyAB { get; set; }
        public double sigmaUyBC { get; set; }
        public double sigmaUyCA { get; set; }
}
}