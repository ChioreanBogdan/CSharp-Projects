using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cabinet_medical
{
    public partial class Ad_pres2 : Form
    {
        public static int verif_med=0; //verifica daca a fost adaugat cel putin un medicament in prescriptie inainte de a finaliza comanda
        public Ad_pres2()
        {
            InitializeComponent();
            Completez_Combo_UM();
            Completez_Combo_Med();
        }

        void Completez_Combo_UM()
        {
            DataTable lista_UM = DB_Interogari.Descarc_UM();
            um.Items.Clear();
            um.DataSource = lista_UM;
            // DataTable din care sunt preluate datele pentru ComboBox de unitati masura
            um.ValueMember = "id_um";
            um.DisplayMember = "nume";
            // Elementele afisate in ComboBox, preluate din coloana nume din DataTable
        }

        void Completez_Combo_Med()
        {
            DataTable lista_Med = DB_Interogari.Descarc_Med();
            med.Items.Clear();
            med.DataSource = lista_Med;
            // DataTable din care sunt preluate datele pentru ComboBox de medicamente
            med.ValueMember = "id_medicament";
            med.DisplayMember = "nume";
            // Elementele afisate in ComboBox, preluate din coloana nume din DataTable
        }

        //Verific ca ce introduc in Textbox-ul "Cantitate" sa poata fi doar double
        private void cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //Verific ca ce introduc in Textbox-ul "Cantitate" sa poata fi doar integer
        private void zi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e) //Butonul "Medicament nou" pentru a adauga un medicament nou
        {
            Ad_med Admed = new Ad_med();
            Admed.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) //Butonul "Adauga medicament" folosit pt a adauga un alt id de medicament in prescriptie
        {
            int okp;
            int id_med = Convert.ToInt32(med.SelectedValue);
            int id_um = Convert.ToInt32(um.SelectedValue);

            try
            {
                if (cant.Text=="") throw new Exception("Completati cantitatea!");
                if (zi.Text == "") throw new Exception("Completati numarul de zile!");
                double can = Convert.ToDouble(cant.Text);
                int z = Convert.ToInt32(zi.Text);
                okp = DB_Adaugare.Adaug_prescriptie(Ad_pres1.memidp,id_med,id_um,can,z,Ad_pres1.memdat);
                if (okp == 0)
                {
                    string num_med = this.med.GetItemText(this.med.SelectedItem);
                    MessageBox.Show("Medicamentul " + num_med + " a fost adaugat \n cu succes in prescriptie");
                    cant.Text = "";
                    zi.Text = "";
                    verif_med = 1; //Daca va fost adaugat cel putin un medicament se poate finaliza prescriptia
                }
                else
                {
                    MessageBox.Show("A aparut o eroare la adaugarea medicamentului in prescriptie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Butonul "Finalizeaza prescriptie"
        {
            if (verif_med != 1) MessageBox.Show("Trebuie sa adaugati cel putin \n un medicament in prescriptie");
            else
            {
                try
                {
                    Confirmare c = new Confirmare("fin");
                    DialogResult dr = c.ShowDialog();
                    if (dr == DialogResult.Yes)
                    {
                        MessageBox.Show("Prescriptia pacientului " + Ad_pres1.mempac + " \n a fost adaugata cu succes!");
                        this.Close();
                    }
                    if (dr == DialogResult.No)
                    {
                        MessageBox.Show("Prescriptia nu a fost finalizata");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //Butonul "Renunta"
        {
            //Inchide formularul si sterge toate medicamentele pe baza id-ului pacient si a datei introduse in formularul Ad_pres1
            try
            {
                Confirmare c = new Confirmare("ren");
                DialogResult dr = c.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    DB_Sterge.Sterg_Prescriptia(Ad_pres1.memidp, Ad_pres1.memdat);
                    MessageBox.Show("Prescriptia pacientului " + Ad_pres1.mempac + " \n din data "+Ad_pres1.memdat+"\n a fost stearsa cu succes!");
                    this.Close();
                }
                if (dr == DialogResult.No)
                {
                    MessageBox.Show("Prescriptia nu a fost stearsa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
