using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP03
{
    class Spotrebic
    {
        private string kod;
        private double prikon;
        private double spotreba = 0;
        private TimeSpan celkovaDobaProvozu = new TimeSpan(0);
        private DateTime okamzikZapnuti;
        private bool jeVProvozu = false;
        public string Kod
        {
            get
            {
                return kod;
            }
            set
            {
                string s = value;
                s = value.ToUpper();
                int i = 0;
                while (i < s.Length)
                {
                    if (!char.IsLetterOrDigit(s[i]) && !(s[i] == '-'))
                    {
                        s = s.Remove(i, 1);
                    }
                    else ++i;
                }

                //for (int i = 0; i < s.Length; ++i)   SPATNE a SLOZITE
                //{
                //    if (!char.IsLetter(s[i]) && !char.IsNumber(s[i]) && s[i] != '-')
                //    { s = s.Remove(i, 1) + s.Substring(i + 1); }
                //    else if (char.IsLetter(s[i]))
                //    {
                //        if (char.IsLower(s[i]))
                //        {
                //            s = char.ToUpper(s[i]) + s.Substring(i + 1);
                //        }
                //    }
                //}

                kod = s;
            }
        }
        public bool JeVProvozu
        {
            get
            {
                return jeVProvozu;
            }
        }
        public Spotrebic(string kod, double prikon)
        {
            Kod = kod;
            this.prikon = prikon;
        }
        public void Zapni()
        {
            jeVProvozu = true;
            okamzikZapnuti = DateTime.Now;
            System.Windows.Forms.MessageBox.Show("Zapnuto");
        }
        public void Vypni()
        {
            jeVProvozu = false;
            celkovaDobaProvozu += DateTime.Now - okamzikZapnuti;
            System.Windows.Forms.MessageBox.Show("Vypnuto");
        }
        public double CelkovaSpotreba()
        {
            spotreba = celkovaDobaProvozu.TotalSeconds * prikon;
            if (JeVProvozu)
            {
                spotreba += (DateTime.Now - okamzikZapnuti).TotalSeconds * prikon;
            }

            return spotreba;
        }
        public override string ToString()
        {
            string s = "\nKód spotřebiče je: " + Kod + "\nCelková doba provozu je: " + celkovaDobaProvozu.TotalSeconds + " sekund\n" + "Celková spotřeba je: " + CelkovaSpotreba() + "Ws";
            return base.ToString() + s;
        }

    }
}
