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
        private TimeSpan celkovaDobaProvozu;
        private DateTime okamzikZapnuti;
        private bool jeVProvozu;
        public string Kod
        {
            get
            {
                return kod;
            }
            set
            {
                string s = value;
                for (int i = 0; i < s.Length; ++i)
                {
                    if (!char.IsLetter(s[i]) && !char.IsNumber(s[i]) && s[i] != '-')
                    { s = s.Remove(i, 1) + s.Substring(i + 1); }
                    else if (char.IsLetter(s[i]))
                    {
                        if (char.IsLower(s[i]))
                        {
                            s = char.ToUpper(s[i]) + s.Substring(i + 1);
                        }
                    }
                }
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
            double spotreba = 0;
            if (JeVProvozu)
            {
                spotreba = double.Parse((DateTime.Now - okamzikZapnuti).TotalHours.ToString()) * prikon;
            }
            else
            {
                spotreba = double.Parse(celkovaDobaProvozu.TotalHours.ToString()) * prikon;
            }
            return spotreba;
        }
        public override string ToString()
        {
            string s = "\nKód spotřebiče je: " + Kod + "\nCelková doba provozu je: " + celkovaDobaProvozu.TotalHours + " hodin\n" + "Celková spotřeba je: " + CelkovaSpotreba() + "Wh";
            return base.ToString() + s;
        }

    }
}
