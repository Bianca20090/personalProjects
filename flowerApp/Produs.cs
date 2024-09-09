using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectPAWBuseBianca
{
    class Produs
    {
        string Denumire;
        float Pret;
        string culoare;
        int cantitate;
        DateTime data;
        internal string tbDenumire;
        internal float tbPret;
        internal string tbCuloare;
        internal int tbCant;

        public Produs(string denumire,  string culoare, float pret, int cantitate, DateTime data)
        {
            Denumire = denumire;
            Pret = pret;
            this.culoare = culoare;
            this.cantitate = cantitate;
            this.data = data;
        }

        public Produs()
        {

        }


    }
   
}
