using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml.Linq;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Object.xaml
    /// </summary>
    public partial class Object : Window
    {
        public string NameObject = MainWindow.name;
        public static int schema = 0;
        //public static int active_schema = MainWindow.schema;
        //public int number = MainWindow.number;
        //public string[] current_object = MainWindow.current_object; //Получение массива из другого класса
        //public static string[] findFiles = MainWindow.findFiles;
        //public static string[] findFiles1;
        //public static int lenm; //количество файлов в текущем каталоге
        public static string[] current_object;

        //public static int active_schema = ;
        //Переменные для схемы проверки 1
        public string ua;
        public double ia; // используется для двух схем
        public double pa;
        public double qa;
        public double sa;
        public string freq; // используется для двух схем
        public string sigmaUy; // используется для двух схем
        //Переменные для схемы проверки 2
        public string uab;
        public string ubc;
        public string uca;
        public string iab;
        public string ibc;
        public string ica;
        public double ib;
        public double ic;
        public double po;
        public double pp;
        public double qo;
        public double qp;
        public double so;
        public double sp;
        public string uo;
        public string up;
        public double io;
        public double ip;
        public string ko;
        public string sigmaUyab;
        public string sigmaUybc;
        public string sigmaUyca;
        public long TimeTek;
        public Object()
        {
            int active_schema = MainWindow.schema;
            int lenm;
            int number = MainWindow.number;
            string[] findFiles = MainWindow.findFiles;
            NameObject = MainWindow.name;
            InitializeComponent();
            Closing += Window_Closing;
            this.Title = NameObject + " (Отображаются файлы для схемы " + active_schema + ")";
            string current_path = MainWindow.current_path;
            string[] findFiles1 = { "" };
            //---------------------------------------------------------------------------------------------------------------------------------
            //int d = 0;
            try
            {
                findFiles1 = System.IO.Directory.GetFiles(@current_path, "*.pke", System.IO.SearchOption.TopDirectoryOnly);
                lenm = findFiles1.Length;
            }
            catch
            {
                lenm = 0;
                MessageBox.Show("В папке отсутсвуют файлы .pke", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            List<Schema_1> result_1 = new List<Schema_1>(3);
            List<Schema_2> result_2 = new List<Schema_2>(3);
            List<Schema_3> result_3 = new List<Schema_3>(3);
            XDocument ndoc = XDocument.Load(findFiles[number - 1]);
            {
                foreach (XElement Param_Check_PKE_Element in ndoc.Element("RM3_ПКЭ").Elements("Param_Check_PKE"))
                {
                    XAttribute active_schema_Attribute = Param_Check_PKE_Element.Attribute("active_cxema");
                    if (active_schema_Attribute != null)
                    {
                        schema = int.Parse(active_schema_Attribute.Value);
                    }
                }
            }
            for (int k = 0; k < lenm; k++)
            {
                XDocument xdoc = XDocument.Load(findFiles1[k]);
                if ((schema == 1) && (schema == active_schema))
                {
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
                            ua = UAAttribute.Value;
                            ia = double.Parse(IAAttribute.Value);
                            pa = double.Parse(PAAttribute.Value);
                            qa = double.Parse(QAAttribute.Value);
                            sa = double.Parse(SAAttribute.Value);
                            freq = FreqAttribute.Value;
                            sigmaUy = sigmaUyAttribute.Value;
                            //Обработка TimeTek
                            TimeSpan time_start = TimeSpan.FromMilliseconds(TimeTek);
                            DateTime tstart_t = new DateTime(time_start.Ticks);
                            tstart_t.Add(time_start);
                            TimeSpan duration = new TimeSpan(719528, 0, 0, 0);
                            DateTime answer = tstart_t.Add(duration);
                            string TimeTek_s = answer.ToString("dd MMMM yyyy hh:mm:ss tt");
                            result_1.Add(new Schema_1(TimeTek_s, ua, ia, pa, qa, sa, freq, sigmaUy));
                        }
                    }
                }
                if ((schema == 2) && (schema == active_schema))
                {
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
                            uab = UABAttribute.Value;
                            ubc = UBCAttribute.Value;
                            uca = UCAAttribute.Value;
                            iab = IABAttribute.Value;
                            ibc = IBCAttribute.Value;
                            ica = ICAAttribute.Value;
                            ia = double.Parse(IAAttribute.Value);
                            ib = double.Parse(IBAttribute.Value);
                            ic = double.Parse(ICCAttribute.Value);
                            po = double.Parse(POAttribute.Value);
                            pp = double.Parse(PPAttribute.Value);
                            qo = double.Parse(QOAttribute.Value);
                            qp = double.Parse(QPAttribute.Value);
                            so = double.Parse(SOAttribute.Value);
                            sp = double.Parse(SPAttribute.Value);
                            uo = UOAttribute.Value;
                            up = UPAttribute.Value;
                            io = double.Parse(IOAttribute.Value);
                            ip = double.Parse(IPAttribute.Value);
                            ko = KOAttribute.Value;
                            freq = FreqAttribute.Value;
                            sigmaUy = sigmaUyAttribute.Value;
                            sigmaUyab = sigmaUyABAttribute.Value;
                            sigmaUybc = sigmaUyBCAAttribute.Value;
                            sigmaUyca = sigmaUyCAAttribute.Value;
                            TimeTek = long.Parse(timetekAttribute.Value);
                            TimeSpan time_start = TimeSpan.FromMilliseconds(TimeTek);
                            DateTime tstart_t = new DateTime(time_start.Ticks);
                            tstart_t.Add(time_start);
                            TimeSpan duration = new TimeSpan(719528, 0, 0, 0);
                            DateTime answer = tstart_t.Add(duration);
                            string TimeTek_s = answer.ToString("dd MMMM yyyy hh:mm:ss tt");
                            result_2.Add(new Schema_2(TimeTek_s, uab, ubc, uca, iab, ibc, ica, ia, ib, ic, po, pp, qo, qp, so, sp, uo, up, io, ip, ko, freq, sigmaUy, sigmaUyab, sigmaUybc, sigmaUyca));
                        }
                    }
                }
                if ((schema == 3) && (schema == active_schema))
                {
                    foreach (XElement Result_Check_PKE_Element in xdoc.Element("RM3_ПКЭ").Elements("Result_Check_PKE"))
                    {
                        XAttribute timetekAttribute = Result_Check_PKE_Element.Attribute("TimeTek");
                        XAttribute UABAttribute = Result_Check_PKE_Element.Attribute("UAB");
                        XAttribute UBCAttribute = Result_Check_PKE_Element.Attribute("UBC");
                        XAttribute UCAAttribute = Result_Check_PKE_Element.Attribute("UCA");
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
                        XAttribute sigmaUyABAttribute = Result_Check_PKE_Element.Attribute("sigmaUyA");
                        XAttribute sigmaUyBCAAttribute = Result_Check_PKE_Element.Attribute("sigmaUyB");
                        XAttribute sigmaUyCAAttribute = Result_Check_PKE_Element.Attribute("sigmaUyC");
                        if (timetekAttribute != null && UABAttribute != null && UBCAttribute != null && UCAAttribute != null && IAAttribute != null &&
                            IBAttribute != null && ICCAttribute != null && POAttribute != null && PPAttribute != null && QOAttribute != null && QPAttribute != null &&
                            SOAttribute != null && SPAttribute != null && UOAttribute != null && UPAttribute != null && IOAttribute != null && IPAttribute != null &&
                            KOAttribute != null && FreqAttribute != null && sigmaUyAttribute != null && sigmaUyABAttribute != null && sigmaUyBCAAttribute != null && sigmaUyCAAttribute != null)
                        {
                            uab = UABAttribute.Value;
                            ubc = UBCAttribute.Value;
                            uca = UCAAttribute.Value;
                            ia = double.Parse(IAAttribute.Value);
                            ib = double.Parse(IBAttribute.Value);
                            ic = double.Parse(ICCAttribute.Value);
                            po = double.Parse(POAttribute.Value);
                            pp = double.Parse(PPAttribute.Value);
                            qo = double.Parse(QOAttribute.Value);
                            qp = double.Parse(QPAttribute.Value);
                            so = double.Parse(SOAttribute.Value);
                            sp = double.Parse(SPAttribute.Value);
                            uo = UOAttribute.Value;
                            up = UPAttribute.Value;
                            io = double.Parse(IOAttribute.Value);
                            ip = double.Parse(IPAttribute.Value);
                            ko = KOAttribute.Value;
                            freq = FreqAttribute.Value;
                            sigmaUy = sigmaUyAttribute.Value;
                            sigmaUyab = sigmaUyABAttribute.Value;
                            sigmaUybc = sigmaUyBCAAttribute.Value;
                            sigmaUyca = sigmaUyCAAttribute.Value;
                            TimeTek = long.Parse(timetekAttribute.Value);
                            TimeSpan time_start = TimeSpan.FromMilliseconds(TimeTek);
                            DateTime tstart_t = new DateTime(time_start.Ticks);
                            tstart_t.Add(time_start);
                            TimeSpan duration = new TimeSpan(719528, 0, 0, 0);
                            DateTime answer = tstart_t.Add(duration);
                            string TimeTek_s = answer.ToString("dd MMMM yyyy hh:mm:ss tt");
                            result_3.Add(new Schema_3(TimeTek_s, uab, ubc, uca, ia, ib, ic, po, pp, qo, qp, so, sp, uo, up, io, ip, ko, freq, sigmaUy, sigmaUyab, sigmaUybc, sigmaUyca));
                        }
                    }
                }
                if (active_schema == 1)
                {
                    grid.ItemsSource = result_1;
                }
                if (active_schema == 2)
                {
                    grid.ItemsSource = result_2;
                }
                if (active_schema == 3)
                {
                    grid.ItemsSource = result_3;
                }
            }

        }
        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int active_schema = MainWindow.schema;
            if (active_schema == 1)
            {
                Schema_1 path = grid.SelectedItem as Schema_1;
                try
                {
                    MessageBox.Show("U(A) = " + path.Ua + ", " + "I(A) = " + path.Ia + ", " + "P(A) = " + path.Pa + ", " + "Q(A) = " + path.Qa + ", " + "S(A) = " + path.Sa + ", "
                        + "" + "Sigma(Uy) = " + path.sigmaUy + ". ", NameObject + " - " + path.Дата);
                }
                catch
                {
                }
            }
            if (active_schema == 2)
            {
                Schema_2 path = grid.SelectedItem as Schema_2;
                try
                {
                    MessageBox.Show("I(A) = " + path.IA + ", " + "I(AB) = " + path.IAB + ", " + "I(B) = " + path.IB + ", " + "I(BC) = " + path.IBC + ", " + "I(C) = " + path.IC + ", "
                    + "I(CA) = " + path.ICA + ", " + "I(O) = " + path.IO + ", " + "I(P) = " + path.IP + ", " + "I(KO) = " + path.KO + ", " + "I(PO) = " + path.PO + ", "
                    + "I(PP) = " + path.PP + ", " + "I(QO) = " + path.QO + ", " + "I(QP) = " + path.QP + ", " + "Sigma Uy = " + path.sigmaUy + ", " + "Sigma Uy(AB) = " + path.sigmaUyAB + ", "
                    + "Sigma Uy(BC) = " + path.sigmaUyBC + ", " + "Sigma Uy(CA) = " + path.sigmaUyCA + ", " + "I(SO) = " + path.SO + ". ", NameObject + " - " + path.Дата);
                }
                catch
                {
                }
            }
            if (active_schema == 3)
            {
                Schema_3 path = grid.SelectedItem as Schema_3;
                try
                {
                    MessageBox.Show("I(A) = " + path.IA + ", " + "I(B) = " + path.IB + ", " + "I(C) = " + path.IC + ", " + "I(O) = " + path.IO + ", " + "I(P) = " + path.IP + ", "
                    + "KO = " + path.KO + ", " + "PO = " + path.PO + ", " + "PP = " + path.PP + ", " + "QO = " + path.QO + ", " + "QP = " + path.QP + ", "
                    + "Sigma Uy = " + path.sigmaUy + ", " + "Sigma Uy(AB) = " + path.sigmaUyAB + ", " + "Sigma Uy(BC) = " + path.sigmaUyBC + ", " + "Sigma Uy(CA) = " + path.sigmaUyCA + ", "
                    + "SO = " + path.SO + ", " + "SP = " + path.SP + ", " + "U(AB) = " + path.UAB + ", " + "U(BC) = " + path.UBC + ", " + "U(CA) = " + path.UCA + ", "
                    + "U(O) = " + path.UO + ", " + "U(P) = " + path.UP + ", ", NameObject + " - " + path.Дата);
                }
                catch
                {
                }

            }
        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
        private void grid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }
    }
    class Schema_1
    {
        public Schema_1(string Дата, string Ua, double Ia, double Pa, double Qa, double Sa, string Freq, string sigmaUy)
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
        public string Ua { get; set; }
        public double Ia { get; set; }
        public double Pa { get; set; }
        public double Qa { get; set; }
        public double Sa { get; set; }
        public string Freq { get; set; }
        public string sigmaUy { get; set; }
    }
    class Schema_2
    {
        public Schema_2(string Дата, string UAB, string UBC, string UCA, string IAB, string IBC, string ICA, double IA,
                        double IB, double IC, double PO, double PP, double QO, double QP, double SO, double SP,
                        string UO, string UP, double IO, double IP, string KO, string Freq, string sigmaUy, string sigmaUyAB,
                        string sigmaUyBC, string sigmaUyCA)
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
        public string UAB { get; set; }
        public string UBC { get; set; }
        public string UCA { get; set; }
        public string IAB { get; set; }
        public string IBC { get; set; }
        public string ICA { get; set; }
        public double IA { get; set; }
        public double IB { get; set; }
        public double IC { get; set; }
        public double PO { get; set; }
        public double PP { get; set; }
        public double QO { get; set; }
        public double QP { get; set; }
        public double SO { get; set; }
        public double SP { get; set; }
        public string UO { get; set; }
        public string UP { get; set; }
        public double IO { get; set; }
        public double IP { get; set; }
        public string KO { get; set; }
        public string Freq { get; set; }
        public string sigmaUy { get; set; }
        public string sigmaUyAB { get; set; }
        public string sigmaUyBC { get; set; }
        public string sigmaUyCA { get; set; }
    }

    class Schema_3
    {
        public Schema_3(string Дата, string UAB, string UBC, string UCA, double IA,
                        double IB, double IC, double PO, double PP, double QO, double QP, double SO, double SP,
                        string UO, string UP, double IO, double IP, string KO, string Freq, string sigmaUy, string sigmaUyAB,
                        string sigmaUyBC, string sigmaUyCA)
        {
            this.Дата = Дата;
            this.UAB = UAB;
            this.UBC = UBC;
            this.UCA = UCA;
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
        public string UAB { get; set; }
        public string UBC { get; set; }
        public string UCA { get; set; }
        public double IA { get; set; }
        public double IB { get; set; }
        public double IC { get; set; }
        public double PO { get; set; }
        public double PP { get; set; }
        public double QO { get; set; }
        public double QP { get; set; }
        public double SO { get; set; }
        public double SP { get; set; }
        public string UO { get; set; }
        public string UP { get; set; }
        public double IO { get; set; }
        public double IP { get; set; }
        public string KO { get; set; }
        public string Freq { get; set; }
        public string sigmaUy { get; set; }
        public string sigmaUyAB { get; set; }
        public string sigmaUyBC { get; set; }
        public string sigmaUyCA { get; set; }
    }
}