using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectPAWBuseBianca
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());
            //Application.Run(new PaginaLogin());
           // Application.Run(new ProduseForm());
            //Application.Run(new Comenzi());
            // Application.Run(new Livrarics());
           //Application.Run(new Factura());
           // Application.Run(new Florariecs());
        }
    }

   public partial class Comenzi
    {

        public Comenzi(DateTimePicker dataLivrare, TextBox tbId, TextBox tbcCantitate, TextBox tbcCuloare, TextBox tbcPret, TextBox tbNume, TextBox tbNumar, TextBox tbCantDisp)
        {
            this.dataLivrare = dataLivrare ?? throw new ArgumentNullException(nameof(dataLivrare));
            this.tbId = tbId ?? throw new ArgumentNullException(nameof(tbId));
            this.tbcCantitate = tbcCantitate ?? throw new ArgumentNullException(nameof(tbcCantitate));
            this.tbcCuloare = tbcCuloare ?? throw new ArgumentNullException(nameof(tbcCuloare));
            this.tbcPret = tbcPret ?? throw new ArgumentNullException(nameof(tbcPret));
            this.tbNume = tbNume ?? throw new ArgumentNullException(nameof(tbNume));
            this.tbNumar = tbNumar ?? throw new ArgumentNullException(nameof(tbNumar));
            this.tbCantDisp = tbCantDisp ?? throw new ArgumentNullException(nameof(tbCantDisp));
        }
    }



    public partial class ProduseForm
    {
        public ProduseForm(TextBox tbTip, TextBox tbPret, TextBox tbCuloare, TextBox tbCantitate, DateTimePicker dateAprovizionare)
        {
            this.tbTip = tbTip ?? throw new ArgumentNullException(nameof(tbTip));
            this.tbPret = tbPret ?? throw new ArgumentNullException(nameof(tbPret));
            this.tbCuloare = tbCuloare ?? throw new ArgumentNullException(nameof(tbCuloare));
            this.tbCantitate = tbCantitate ?? throw new ArgumentNullException(nameof(tbCantitate));
            this.dateAprovizionare = dateAprovizionare ?? throw new ArgumentNullException(nameof(dateAprovizionare));
        }
    }

    public partial class Livrarics
    {
        public Livrarics(TextBox tbcAdresa, ComboBox cbStatus, ComboBox cbCurier, TextBox tbNume, TextBox tbcTelefon)
        {
            this.tbcAdresa = tbcAdresa ?? throw new ArgumentNullException(nameof(tbcAdresa));
            this.cbStatus = cbStatus ?? throw new ArgumentNullException(nameof(cbStatus));
            this.cbCurier = cbCurier ?? throw new ArgumentNullException(nameof(cbCurier));
            this.tbNume = tbNume ?? throw new ArgumentNullException(nameof(tbNume));
            this.tbcTelefon = tbcTelefon ?? throw new ArgumentNullException(nameof(tbcTelefon));
        }
    }


    public partial class Factura
    {
        public Factura(ComboBox comboBox1, TextBox tbId, TextBox tbcCantitate, TextBox tbcPret)
        {
            this.comboBox1 = comboBox1 ?? throw new ArgumentNullException(nameof(comboBox1));
            this.tbId = tbId ?? throw new ArgumentNullException(nameof(tbId));
            this.tbcCantitate = tbcCantitate ?? throw new ArgumentNullException(nameof(tbcCantitate));
            this.tbcPret = tbcPret ?? throw new ArgumentNullException(nameof(tbcPret));
        }
    }

}
