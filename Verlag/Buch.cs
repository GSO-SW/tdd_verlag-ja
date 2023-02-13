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
        private string iSBN10;
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
                    this.iSBN10 = iSBN10Pruefziffer(value);
                }
                else if (value.Length == 12)
                {
                    this.iSBN13 = iSBN13Pruefziffer(value);
                    this.iSBN10 = iSBN10Pruefziffer(value);
                }
                else
                {
                    throw new Exception("ISBN nicht vollständig.");
                }
            }
        }

        public string ISBN10
        {
            get { return this.iSBN10; }
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

        private string iSBN13Pruefziffer(string value)
        {
            int geradeZ;
            int ungeradeZ;
            int pZ;
            geradeZ = (value[0] - '0') + (value[2] - '0') + (value[4] - '0') + (value[6] - '0') + (value[8] - '0') + (value[10] - '0');
            ungeradeZ = 3 * ((value[1] - '0') + (value[3] - '0') + (value[5] - '0') + (value[7] - '0') + (value[9] - '0') + (value[11] - '0'));

            pZ = 10 - ((geradeZ + ungeradeZ) % 10);

            return $"{value}{pZ}";
        }

        private string iSBN10Pruefziffer(string value)
        {
            int behaelter = 0;
            string iSBN10 = "";
            for (int i = 3; i < 12; i++)
            {
                behaelter += (value[i] - '0') * (i - 2);
                iSBN10 += $"{(value[i] - '0')}";
            }
            return iSBN10 + $"{behaelter % 11}";

        }
    }
}
