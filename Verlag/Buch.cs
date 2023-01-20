using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    internal class Buch
    {
        private string autor;
        private string titel;
        private int auflage = 1;

        public Buch(string autor, string titel, int auflage) : this(autor, titel)
        {
            this.Auflage = auflage;
        }

        public Buch(string autor, string titel)
        {
            this.autor = autor;
            this.titel = titel;
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
                        throw new ArgumentException("Unerlaubte Zeichen bei Autor.");
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
    }
}
