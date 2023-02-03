using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage = 1;
        private string iSBN13;
        private double preis;

        public Buch(string autor, string titel, double preis, int auflage) : this(autor, titel, preis)
        {
            this.Auflage = auflage;
        }

        public Buch(string autor, string titel, double preis)
        {
            this.Autor = autor;
            this.titel = titel;
            this.Preis = preis;
        }

        public string Autor
        {
            get { return this.autor; }
            set 
            {
                List<char> unerlaubteZeichen = new List<char>();
                unerlaubteZeichen.Add('#');
                unerlaubteZeichen.Add(';');
                unerlaubteZeichen.Add('§');
                unerlaubteZeichen.Add('%');

                foreach (char c in unerlaubteZeichen)
                {
                    if (value.Contains(c) || value == "" || value is null)
                    {
                        throw new ArgumentException("Unerlaubte Eingabe bei Autor.");
                    }
                }
                this.autor = value;
            }
        }

        public string Titel
        {
            get { return this.titel; }
        }

        public int Auflage
        {
            get { return this.auflage; }
            set 
            { 
                if(value > 0)
                {
                    this.auflage = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Auflage muss größer als 0 sein.");
                }
            }
        }

        public string ISBN13
        {
            get { return this.iSBN13;}
            set
            {
                if (value.Length == 13)
                {
                    this.iSBN13 = value;
                }
                else if (value.Length == 12)
                {
                    int geradeZ;
                    int ungeradeZ;
                    int pZ;
                    geradeZ = value[0] + value[2] + value[4] + value[6] + value[8] + value[10];
                    ungeradeZ = 3 * (value[1] + value[3] + value[5] + value[7] + value[9] + value[11]);

                    pZ = 10 - ((geradeZ + ungeradeZ) % 10);

                    this.iSBN13 = value + pZ;
                }
            }
        }

        public double Preis
        {
            get { return this.preis; }
            set
            {
                if (value >= 0)
                {
                    this.preis = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Kein negativer Preis.");
                }
            }
        }
    }
}
