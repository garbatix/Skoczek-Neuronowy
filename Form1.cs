using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Skoczek_Neuronowy
{

    public struct Pole
    {
        public int x, y;
        public Pole(int a, int b)
        {
            x = a;
            y = b;
        }
    }

    public struct Neuron
    {
        public Pole wierzch1, wierzch2;
        public int stan, impuls;
        public Neuron(Pole n1, Pole n2, int s, int i)
        {
            wierzch1 = n1;
            wierzch2 = n2;
            stan = s;
            impuls = i;
        }
    }


    public partial class Okienko : Form
    {
        public static int BokSzachownicy = 8; // Długość boku szachownicy
        public bool zatrzymaj = false;
        public bool pauza = false;
        public static int IloscNeuronow = 10 * (BokSzachownicy - 2) + (BokSzachownicy - 4) * (4 * (BokSzachownicy - 2) + 2) + 4;
        public static Neuron[] SiecNeuronowa = new Neuron[IloscNeuronow]; // Deklarowanie pustej tablicy sieci neuronowej
        public static Neuron[] BufSieci = new Neuron[IloscNeuronow]; // Deklarowanie bufora sieci neuronowej

        public Okienko()
        {
            InitializeComponent();
        }

        public static Neuron[] ZbudujSiec()
        {
            Neuron[] Siec = new Neuron[IloscNeuronow];
            Random imp = new Random();
            int n = 0;
            for (int i = 0; i < (BokSzachownicy - 1); i++)
                for (int j = 0; j < (BokSzachownicy); j++)
                {
                    if (((i + 1) <= BokSzachownicy - 1) && ((j - 2) >= 0))
                    {
                        Siec[n].wierzch1.x = i;
                        Siec[n].wierzch1.y = j;
                        Siec[n].wierzch2.x = i + 1;
                        Siec[n].wierzch2.y = j - 2;
                        Siec[n].stan = imp.Next(4);
                        Siec[n].impuls = 0;
                        n++;

                    }
                    if (((i + 2) <= BokSzachownicy - 1) && ((j - 1) >= 0))
                    {
                        Siec[n].wierzch1.x = i;
                        Siec[n].wierzch1.y = j;
                        Siec[n].wierzch2.x = i + 2;
                        Siec[n].wierzch2.y = j - 1;
                        Siec[n].stan = imp.Next(4);
                        Siec[n].impuls = 0;
                        n++;
                    }
                    if (((i + 2) <= BokSzachownicy - 1) && ((j + 1) <= BokSzachownicy - 1) && ((j + 1) >= 0))
                    {
                        Siec[n].wierzch1.x = i;
                        Siec[n].wierzch1.y = j;
                        Siec[n].wierzch2.x = i + 2;
                        Siec[n].wierzch2.y = j + 1;
                        Siec[n].stan = imp.Next(4);
                        Siec[n].impuls = 0;
                        n++;
                    }
                    if (((i + 1) <= BokSzachownicy - 1) && ((j + 2) <= BokSzachownicy - 1) && ((j + 2) >= 0))
                    {
                        Siec[n].wierzch1.x = i;
                        Siec[n].wierzch1.y = j;
                        Siec[n].wierzch2.x = i + 1;
                        Siec[n].wierzch2.y = j + 2;
                        Siec[n].stan = imp.Next(4);
                        Siec[n].impuls = 0;
                        n++;
                    }
                }
            return Siec;
        }

        public static Neuron[] KopiujSiec(Neuron[] si)
        {
            Neuron[] siec = new Neuron[IloscNeuronow];
            for (int i = 0; i < IloscNeuronow; i++)
            {
                siec[i].impuls = si[i].impuls;
                siec[i].stan = si[i].stan;
                siec[i].wierzch1 = si[i].wierzch1;
                siec[i].wierzch2 = si[i].wierzch2;

            }
            return siec;
        }

        private static int ImpulsySasiadow(Pole w, ref Neuron[] Siec) // oblicza sumę impulsów pochodzących od neuronów stykających się w danym polu
        {
            int suma = 0;
            for (int j = 0; j < IloscNeuronow; j++)
            {
                if (((Siec[j].wierzch1.x) == w.x) && ((Siec[j].wierzch1.y) == w.y)) suma = suma + Siec[j].impuls;
                if (((Siec[j].wierzch2.x) == w.x) && ((Siec[j].wierzch2.y) == w.y)) suma = suma + Siec[j].impuls;
            }

            return suma;
        }

        public static bool ZmienStan(Neuron[] Siec, ref Neuron[] Buf)  // zmienia stan neuronu w zależności od impulsów sąsiadów
        {
            bool zmiana = false;
            for (int i = 0; i < IloscNeuronow; i++)
            {
                Buf[i].stan = Siec[i].stan + 3 - ImpulsySasiadow(Siec[i].wierzch1, ref Siec) - ImpulsySasiadow(Siec[i].wierzch2, ref Siec) + (1 * Siec[i].impuls); // to ostatnie to impulsy własne
                if (Buf[i].stan > 10) Buf[i].stan = 10;
                if (Buf[i].stan < -10) Buf[i].stan = -10;
                if (Siec[i].stan != Buf[i].stan) zmiana = true;
            }
            return zmiana;

        }

        public static void ZmienImpulsy(Neuron[] Siec, ref Neuron[] Buf)  // zmienia impuls neuronu w zależności od jego stanu
        {
            
            for (int i = 0; i < IloscNeuronow; i++)
            {
                if (Siec[i].stan > 2) Buf[i].impuls = 1;
                if (Siec[i].stan < 0) Buf[i].impuls = 0;
                
                
            }
            
        }

        public bool SprawdzSiec(Neuron[] Siec)  // sprawdza, czy udało się zamknąć sieć ruchów
        {
            bool Wszystkie = false;
            bool Wierzcholki = true;
            int n = 0;
            for (int i = 0; i < IloscNeuronow; i++)
            {
                n = n + Siec[i].impuls; // sprawdzamy ilość aktywnych neuronów
                if (Siec[i].impuls == 1) // sprawdzamy czy nie ma trzech neuronów połączonych w jednym wierzchołku
                {
                    
                    if ((ImpulsySasiadow(Siec[i].wierzch1, ref Siec) + ImpulsySasiadow(Siec[i].wierzch2, ref Siec) - 2 * Siec[i].impuls) > 2) Wierzcholki = false;
                }
            }
            if ((n >= BokSzachownicy * BokSzachownicy - 1)&&(Wierzcholki)) Wszystkie = true;
            return Wszystkie;
        }

        public int SprawdzSciezkeH(Neuron[] Siec)  // sprawdza, czy udało się zamknąć sieć ruchów
        {
            bool jest;
            int start = 0;
            Pole p = new Pole();
            Pole ps = new Pole();
            Pole pb = new Pole();
            int n = 0;
            int liczba = 1;
            
            // szukamy pustej końcówki
            for (int i = 0; i < IloscNeuronow; i++)
            {
                if (Siec[i].impuls == 1) // znajdujemy pierwszy neuron z jednej strony nie podłączony
                    if ((ImpulsySasiadow(Siec[i].wierzch1, ref Siec) == 1)||(ImpulsySasiadow(Siec[i].wierzch2, ref Siec) == 1))
                    {
                        start = i;
                        if (ImpulsySasiadow(Siec[i].wierzch1, ref Siec) == 1) p = Siec[i].wierzch2;
                        else p = Siec[i].wierzch1;
                        break;
                    }
            }
            if (start == -1) { n = 0; p.x = 0; p.y = 0; }
            n = start;
            ps = p;
            // this.textBox1.AppendText("Pierwszy neuron: " + p.x + "," + p.y + "\n");
            
            do
            {
                jest = false;
                for (int i = 0; i < IloscNeuronow; i++)
                {
                if ((Siec[i].impuls == 1)&& (i != start) && (i != n) &&(((Siec[i].wierzch1.x==p.x)&&(Siec[i].wierzch1.y==p.y))||((Siec[i].wierzch2.x==p.x)&&(Siec[i].wierzch2.y==p.y))))
                {
                    if ((Siec[i].wierzch1.x==p.x)&&(Siec[i].wierzch1.x==p.x))
                    {
                        pb.x=Siec[i].wierzch2.x;
                        pb.y=Siec[i].wierzch2.y;
                    }
                    else
                    {
                        pb.x=Siec[i].wierzch1.x;
                        pb.y=Siec[i].wierzch1.y;
                    }
                    jest = true;
                    p.x = pb.x;
                    p.y = pb.y;
                    n = i;
                    liczba++;
                    break;
                }
            }
            
            // do  // pauza po każdym kroku
            // {
            //    Thread.Sleep(Convert.ToInt16(kontrPauza.Value));
            //    Application.DoEvents();
            //}
            // while (!pauza);
            // pauza = true;
            // if (jest) this.textBox1.AppendText("Kolejny neuron: " + p.x + "," + p.y + "\n");
            }
            while (jest == true);
       
            return liczba;
        }


        public void PokazSiec(Neuron[] SiecNeuronowa)  // rysuje sieć
        {
            Graphics obraz = this.panel.CreateGraphics();
            for (int i = 0; i < IloscNeuronow; i++)
            {
                if (this.checkStany.Checked == true) this.textBox1.AppendText((i + ": " + SiecNeuronowa[i].wierzch1.x + "," + SiecNeuronowa[i].wierzch1.y + "-" + SiecNeuronowa[i].wierzch2.x + "," + SiecNeuronowa[i].wierzch2.y + "  " + SiecNeuronowa[i].impuls + "/" + SiecNeuronowa[i].stan + "\n"));
                int pWidth = panel.ClientRectangle.Width;
                int pHeight = panel.ClientRectangle.Height;
                if (SiecNeuronowa[i].impuls == 1) obraz.DrawLine(Pens.Red, SiecNeuronowa[i].wierzch1.x * (pWidth / BokSzachownicy) + (pWidth / BokSzachownicy / 2), SiecNeuronowa[i].wierzch1.y * (pHeight / BokSzachownicy) + (pHeight / BokSzachownicy / 2), SiecNeuronowa[i].wierzch2.x * (pWidth / BokSzachownicy) + (pWidth / BokSzachownicy / 2), SiecNeuronowa[i].wierzch2.y * (pHeight / BokSzachownicy) + (pHeight / BokSzachownicy / 2));
                else obraz.DrawLine(Pens.White, SiecNeuronowa[i].wierzch1.x * (pWidth / BokSzachownicy) + (pWidth / BokSzachownicy / 2), SiecNeuronowa[i].wierzch1.y * (pHeight / BokSzachownicy) + (pHeight / BokSzachownicy / 2), SiecNeuronowa[i].wierzch2.x * (pWidth / BokSzachownicy) + (pWidth / BokSzachownicy / 2), SiecNeuronowa[i].wierzch2.y * (pHeight / BokSzachownicy) + (pHeight / BokSzachownicy / 2));
                
            }
            

        }

        

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            StatusBarText1.Text = "Obliczam...";
            StatusBarTextCzas.Text = ("");
            DateTime Czas = DateTime.Now;
            DateTime Czas2;
            button1.Visible = false;
            butStop.Enabled = true;
            butStop.Visible = true;
            kontrBok.Enabled = false;
            int Prob = 0;
            Neuron[] SiecNeuronowa = new Neuron[IloscNeuronow]; // Deklarowanie pustej tablicy sieci neuronowej
            Neuron[] BufSieci = new Neuron[IloscNeuronow]; // Deklarowanie bufora sieci neuronowej
            Neuron[] BufSieci2 = new Neuron[IloscNeuronow]; // Deklarowanie 2. bufora sieci neuronowej
            
            Graphics obraz = this.panel.CreateGraphics();
            int pWidth = panel.ClientRectangle.Width;
            int pHeight = panel.ClientRectangle.Height;
            int RoznGodz, RoznMin, RoznSek;
            obraz.Clear(Color.White);
            obraz.DrawRectangle(Pens.Black, 0, 0, pWidth-1, pHeight-1); // rysuje obwódkę
            for (int i = 1; i < BokSzachownicy; i++)               // rysuje nową szachownicę
            {
                obraz.DrawLine(Pens.DimGray, pWidth / BokSzachownicy * i, 0, pWidth / BokSzachownicy * i, pHeight);
                obraz.DrawLine(Pens.DimGray, 0, pWidth / BokSzachownicy * i, pHeight, pWidth / BokSzachownicy * i);
            }

            do
            {

                do
                {
                    SiecNeuronowa = ZbudujSiec();
                    BufSieci = KopiujSiec(SiecNeuronowa);
                    BufSieci2 = KopiujSiec(SiecNeuronowa);
                    PokazSiec(SiecNeuronowa); // stan początkowy
                    Thread.Sleep(Convert.ToInt16(kontrPauza.Value));
                    Application.DoEvents();
                    int t = 0;
                    bool zmi = false;
                    zatrzymaj = false;
                    pauza = true;
                    do
                    {
                        do  // pauza po każdym kroku
                        {
                            Thread.Sleep(Convert.ToInt16(kontrPauza.Value));
                            Application.DoEvents();
                        }
                        while ((pauza) && (!zatrzymaj) && (checkKlik.Checked == true));
                        zmi = ZmienStan(SiecNeuronowa, ref BufSieci);
                        SiecNeuronowa = KopiujSiec(BufSieci);
                        ZmienImpulsy(SiecNeuronowa, ref BufSieci);
                        SiecNeuronowa = KopiujSiec(BufSieci);
                        if (this.checkRuchy.Checked == true) PokazSiec(SiecNeuronowa);
                        // textBox1.AppendText ("Próba" + t + "\n");                    
                        pauza = true;
                        t++;
                    }
                    while ((zmi) && (!zatrzymaj) && (t < 100));
                    Prob++;    
                }
                while ((!SprawdzSiec(SiecNeuronowa)) && (!zatrzymaj));
                Czas2 = DateTime.Now;
                RoznGodz = (Czas2.Hour - Czas.Hour);
                RoznMin = (Czas2.Minute - Czas.Minute);
                RoznSek = (Czas2.Second - Czas.Second);
                StatusBarTextCzas.Text = ("Czas obliczeń: " + RoznGodz + ":" + RoznMin + ":" + RoznSek);
                this.textBox1.AppendText("Sieć neuronowa ustabilizowana po " + Prob + " próbach.\n");
            }
            while ((!zatrzymaj)&&(((this.checkCyklH.Checked == false)&&(this.checkSciezkaH.Checked == true) && (SprawdzSciezkeH(SiecNeuronowa) < (BokSzachownicy * BokSzachownicy) - 1))||((this.checkCyklH.Checked == true) && (SprawdzSciezkeH(SiecNeuronowa) < (BokSzachownicy * BokSzachownicy)))));
            if (SprawdzSciezkeH(SiecNeuronowa) >= (BokSzachownicy * BokSzachownicy) - 1)
            {
                this.textBox1.AppendText("Uzyskano ścieżkę Hamiltona\n");
                if (SprawdzSciezkeH(SiecNeuronowa) == (BokSzachownicy * BokSzachownicy)) this.textBox1.AppendText("Uzyskano zamknięty cykl Hamiltona\n");
            }
            else this.textBox1.AppendText("Nie uzyskano ścieżki Hamiltona\n");
            

            
            PokazSiec(SiecNeuronowa); // stan końcowy

            Czas2 = DateTime.Now;
            RoznGodz = (Czas2.Hour - Czas.Hour);
            RoznMin = (Czas2.Minute - Czas.Minute);
            RoznSek = (Czas2.Second - Czas.Second);
            StatusBarTextCzas.Text = ("Czas obliczeń: " + RoznGodz + ":" + RoznMin + ":" + RoznSek);
            this.textBox1.AppendText("Czas obliczeń: " + RoznGodz + ":" + RoznMin + ":" + RoznSek + "\n");
            button1.Enabled = true;
            button1.Visible = true;
            butStop.Enabled = false;
            butStop.Visible = false;
            kontrBok.Enabled = true;
            StatusBarText1.Text = "Gotowy";
            
        }


        private void kontrBok_ValueChanged(object sender, EventArgs e)
        {
            BokSzachownicy = Convert.ToInt16(kontrBok.Value);
            IloscNeuronow = 10 * (BokSzachownicy - 2) + (BokSzachownicy - 4) * (4 * (BokSzachownicy - 2) + 2) + 4;
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            zatrzymaj = true;
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            pauza = false;
        }

        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Okienko());

        }

        
     
    }
}