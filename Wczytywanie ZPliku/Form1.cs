using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wczytywanie_ZPliku
{
    public partial class Form1 : Form
    {
        /*                  METRYKI                 */

        
        public delegate double Metryka(int[] obiektX, int[] obiektY);

        // EUKLIDESOWA
        public static double euklidesowa(int[] obiektX, int[] obiektY)
        {
            double wynik = 0;
            for (int i = 0; i < obiektX.Length - 1; i++)
            {
                wynik += Math.Pow(obiektX[i] - obiektY[i], 2);
            }
            return Math.Sqrt(wynik);
        }

        //  MANHATTAN
        static double Manhattan(int[] obiektX, int[] obiektY)
        {
            double temp = 0;
            for (int i = 0; i < obiektX.Count() - 1; i++)
            {
                temp = temp + Math.Abs(obiektX[i] - obiektY[i]);
            }
            return temp;
        }


        //CANBERRA
        static double Canberra(int[] obiektX, int[] obiektY)
        {
            double temp = 0;
            for (int i = 0; i < obiektX.Count() - 1; i++)
            {
                temp = temp + Math.Abs(((double)obiektX[i] - (double)obiektY[i]) / ((double)obiektX[i] + (double)obiektY[i]));
            }
            return temp;
        }


        //CZYBYSZEWA
        static double Czybeszewa(int[] obiektX, int[] obiektY)
        {
            double temp = 0;
            double temp2 = 0;
            for (int i = 0; i < obiektX.Count() - 1; i++)
            {
                temp = Math.Abs(obiektX[i] - obiektY[i]);
                if (temp > temp2) temp2 = temp;
            }
            return temp;
        }


        /* PEARSONA */
        public static double Pearson(int[] obiektX, int[] obiektY)
        {

            double wynik = 0;
            int iloscAtrybutow = obiektX.Length - 1;
            double sred_x, sred_y, odch_stand_x, odch_stand_y;
            sred_x = 0;
            sred_y = 0;
            odch_stand_x = 0;
            odch_stand_y = 0;

            for (int i = 0; i < iloscAtrybutow; i++)
            {
                sred_x += obiektX[i];
                sred_y += obiektY[i];

            }
            sred_x /= iloscAtrybutow;
            sred_y /= iloscAtrybutow;
            for (int i = 0; i < iloscAtrybutow; i++)
            {
                odch_stand_x += Math.Pow(obiektX[i] - sred_x, 2);
                odch_stand_y += Math.Pow(obiektY[i] - sred_y, 2);
            }
            for (int i = 0; i < iloscAtrybutow; i++)
            {
                wynik += (obiektX[i] - sred_x) * (obiektY[i] - sred_y);
            }
            wynik /= Math.Sqrt(odch_stand_x) * Math.Sqrt(odch_stand_y);
            wynik = 1 - Math.Abs(wynik);

            return wynik;
        }
        /* PEARSONA */


        /*              FUNKCJE                 */

        int[][] daneZPliku, daneZPliku2;

        public static int? klasyfikujObiekt(int[] obiekt, int[][] TRN, int k, Metryka metryka)
        {
            List<tst> wyniki = new List<tst>();
            List<tst> posortowana = new List<tst>();

            // OBLICZAMY WARTOŚCI DLA KONKRETNYCH WIERSZY X
            for (int i = 0; i < TRN.Length; i++)
            {
                wyniki.Add(new tst(TRN[i].Last(), metryka(obiekt, TRN[i])));
            }

            List<double> listaDecyzji = new List<double>();
            Dictionary<double, double> sumaOdleglosci = new Dictionary<double, double>();
            posortowana = wyniki.OrderBy(tst => tst.odleglosc).ToList();

            // TWORZYMY LISTE MOZLIWYCH DECYZJI
            foreach (var _decyzjaObiektu in posortowana) // tutaj sobie zrobie k
            {
                if (!(listaDecyzji.Contains(_decyzjaObiektu.decyzja)))
                {
                    listaDecyzji.Add(_decyzjaObiektu.decyzja);
                }
            }


            //SUMUJEMY W POSORTOWANEJ JUZ LISCIE OD NAJMNIEJSZEJ DO NAJWIEKSZEJ WARTOSCI, DLUGOSC SUMY TO K
            foreach (var klasa in listaDecyzji) // sumowanie odleglosci według K
            {
                int licznikK = 0;
                double suma = 0;
                foreach (var odleglosci in posortowana)
                {
                    if (klasa == odleglosci.decyzja && licznikK < k)
                    {
                        suma += odleglosci.odleglosc;
                        licznikK += 1;
                    }
                }
                sumaOdleglosci.Add(klasa, suma);
            }

            //WYSZUKUJEMY NAJMNIEJSZEJ MOZLIWEJ WARTOSCI
            var min = sumaOdleglosci.Aggregate((l, r) => l.Value < r.Value ? l : r).Key; // klucz najmniejszej wartosc

            double wartosc = 0;
            sumaOdleglosci.TryGetValue(min, out wartosc); // najmniejsza wartosc
            foreach (var minOdlglosc in sumaOdleglosci)
            {  
                //JESLI NAJMNIEJSZA MOZLIWA WARTOSC JEST ROWNA WARTOSCI Z INNEJ KLASY 
                    if (wartosc == minOdlglosc.Value && min != minOdlglosc.Key)
                    {
                    //WTEDY NIE KLASYFIKUJEMY DECYZJI
                        return null;
                    }
            }
            
            return Convert.ToInt32(min); //zwracam klucz i konwertuje

        }

        /*              END FUNKCJE             */


        public Form1()
        {
            InitializeComponent();
        }


        int policzMozliweK(int[][] systemTestowy, int[][] systemTreningowy)
        {
            Dictionary<int, int> liczbaMozliwychK = new Dictionary<int, int>();
            List<int> liczbaDecyzji = new List<int>();

            foreach (var item in systemTestowy)
            {
                if (!(liczbaDecyzji.Contains(item.Last())))
                {
                    liczbaDecyzji.Add(item.Last());
                }
            }

            foreach (var klasa in liczbaDecyzji)
            {
                foreach (var obiekt in systemTestowy)
                {
                    if (obiekt.Last() == klasa)
                    {
                        if (!(liczbaMozliwychK.ContainsKey(klasa))) liczbaMozliwychK.Add(klasa, 1);
                        else liczbaMozliwychK[klasa] += 1;
                    }
                }
            }

            return liczbaMozliwychK.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
        }

        // SYSTEM TESTOWY FILE
        private void btnWybierz_Click(object sender, EventArgs e)
        {
            var wynik = ofd.ShowDialog();
            if (wynik != DialogResult.OK)
                return;


            if (wynik == DialogResult.OK)
            {
                tbScieszka.Text = ofd.FileName;
                string trescPliku = System.IO.File.ReadAllText(ofd.FileName);

                string[] poziomy = trescPliku.Split('\n');

                daneZPliku = new int[poziomy.Length][];

                for (int i = 0; i < poziomy.Length; i++)
                {
                    string poziom = poziomy[i].Trim();
                    string[] miejscaParkingowe = poziom.Split(' ');
                    daneZPliku[i] = new int[miejscaParkingowe.Length];
                    for (int j = 0; j < miejscaParkingowe.Length; j++)
                    {
                        daneZPliku[i][j] = int.Parse(miejscaParkingowe[j]);
                    }
                }
                if (daneZPliku2 != null && daneZPliku != null)
                {
                    var ilosc = policzMozliweK(daneZPliku, daneZPliku2);
                    dodajDoComboBoxaK(ilosc);
                }
            }

        }


        // SYSTEM TRENINGOWY FILE
        private void btnWybierz2_Click(object sender, EventArgs e)
        {
            var wynik = ofd.ShowDialog();
            if (wynik != DialogResult.OK)
                return;

            if (wynik == DialogResult.OK)
            {
                tbScieszka2.Text = ofd.FileName;
                string trescPliku = System.IO.File.ReadAllText(ofd.FileName);

                string[] poziomy = trescPliku.Split('\n');

                daneZPliku2 = new int[poziomy.Length][];

                for (int i = 0; i < poziomy.Length; i++)
                {
                    string poziom = poziomy[i].Trim();
                    string[] miejscaParkingowe = poziom.Split(' ');
                    daneZPliku2[i] = new int[miejscaParkingowe.Length];
                    for (int j = 0; j < miejscaParkingowe.Length; j++)
                    {
                        daneZPliku2[i][j] = int.Parse(miejscaParkingowe[j]);

                    }
                }
                if (daneZPliku2 != null && daneZPliku != null)
                {
                    var ilosc = policzMozliweK(daneZPliku, daneZPliku2);
                    dodajDoComboBoxaK(ilosc);
                }
            }
        }

        public void dodajDoComboBoxaK(int ilosc)
        {
            comboBoxK.Items.Clear();
            for (int i = 0; i < ilosc; i++)
            {
                comboBoxK.Items.Add(i + 1);
            }
        }


        //GENERUJ WYNIKI
        private void buttonGeneruj_Click(object sender, EventArgs e)
        {
            List<int?> decyzjeTestowy = new List<int?>();
            List<int> decyzjeTreningowy = new List<int>();

            Metryka wybranaMetryka;

            int wyborMetryki = cBMetryki.SelectedIndex;

            switch (wyborMetryki)
            {
                case 0:
                    wybranaMetryka = euklidesowa;
                    break;
                case 1:
                    wybranaMetryka = Manhattan;
                    break;
                case 2:
                    wybranaMetryka = Canberra;
                    break;
                case 3:
                    wybranaMetryka = Czybeszewa;
                    break;
                default:
                    wybranaMetryka = euklidesowa;
                    break;
            }
           
            if (comboBoxK.Items.Count == 0)
            {
                MessageBox.Show("widocznie nie wczytałeś któregoś z plików, włącz program ponownie wiec podamy domyślnie 1");
                comboBoxK.Items.Add(1);
            }
            


            foreach (var item in daneZPliku)
            {
                // tutaj zwraca decyzje i zapisuje w liscie
                decyzjeTestowy.Add(klasyfikujObiekt(item, daneZPliku2, Convert.ToInt32(comboBoxK.SelectedItem), wybranaMetryka));
            }


            //dodajemy liste decyzji z systemu testowego
            foreach (var element in daneZPliku)
            {
                decyzjeTreningowy.Add(element.Last());
            }
            
            List<int> listaDecyzji = new List<int>();

            // dodajemy liste decyzji z systemu Treningowego
            foreach (var element in daneZPliku2)
            {
                if (!(listaDecyzji.Contains(element.Last())))
                {
                    listaDecyzji.Add(element.Last());
                }
            }

            int[] decyzjeDobrze = new int[listaDecyzji.Count()];            
            List<List<int?>> decyzjeZle2 = new List<List<int?>>();

            for (int i = 0; i < listaDecyzji.Count(); i++) // ile bylo dobrych decyzji dla mozliwych klas
            {
                decyzjeZle2.Add(new List<int?>());
                // sprawdzamy obliczone klasyfikacje z z systemem testowym (czy sie weryfikuja)
                for (int j = 0; j < decyzjeTestowy.Count(); j++) //
                {
                    //jesli obliczona klasyfikacja zgadza sie z decyzja z systemu testowego (wystepuje w tym samym obiekcie ta sama decyzja to dodaj do decyzji dobrze sklasyfikowanych)
                    if (decyzjeTreningowy[j] == listaDecyzji[i]) //jesli sprawdzany obiekt ma odpowiednia decyzje ktora jest sprawdzana to dalej
                    {
                        if (decyzjeTestowy[j] == decyzjeTreningowy[j]) decyzjeDobrze[i] += 1; //jesli decyzje sie zgadzaja to dodaj do dobrych
                        else
                        {
                            //jesli nie 
                            decyzjeZle2[i].Add(decyzjeTestowy[j]);
                        }
                    }

                }
            }

            lbMacierz.Text = "";

            for (int i = 0; i < listaDecyzji.Count(); i++)
            {
                double tempCov = CovFunc((double)decyzjeDobrze[i],(double)decyzjeZle2[i].Count(),(double)liczNull(decyzjeZle2[i]));
                double tempAcc = AccFunc((double)decyzjeDobrze[i],(double)decyzjeZle2[i].Count(),(double)liczNull(decyzjeZle2[i]));
                lbMacierz.Text += "Decyzja: " + listaDecyzji[i] + "; Przypisanych poprawnie: " + decyzjeDobrze[i] + "; Przypisane niepoprawnie: " + (decyzjeZle2[i].Count() - liczNull(decyzjeZle2[i]))
                    + ";Niezchwytane: " + liczNull(decyzjeZle2[i]) + "; Accuracy: " + tempAcc + "; Coverage: " + tempCov;
                lbMacierz.Text += "\n\n";
            }


        }

        double CovFunc(double _decyzjaDobrze, double _ileDecyzjaZle, double ileNulli)
        {
            return (_decyzjaDobrze + _ileDecyzjaZle - ileNulli) / (_decyzjaDobrze + _ileDecyzjaZle);
        }

        double AccFunc(double _decyzjaDobrze, double _ileDecyzjaZle, double ileNulli)
        {
            return _decyzjaDobrze / (_ileDecyzjaZle - ileNulli + _decyzjaDobrze);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd.Filter = "Text Filrd (.txt) |*.txt";
        }

        private int liczNull(List<int?> lista)
        {
            int temp = 0;
            foreach (var element in lista)
            {
                if (element == null) temp++;
            }
            return temp;
        }

    }
}
