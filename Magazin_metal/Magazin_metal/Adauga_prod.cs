using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Magazin_metal
{
    public partial class Adauga_prod : Form
    {
        string t;
        MySqlConnection conn = new MySqlConnection("DataSource=localhost;UserID = root; database=metalmag");
        public Adauga_prod(string tip)
        {
            t = tip;
            conn.Open();
            InitializeComponent();

            if (t == "t")
            {
                pret.Text = "Pret/m2";
                l2.Hide();
                l5.Hide();
                H.Hide();
                Diam.Hide();
                poza.Image = Image.FromFile("poze\\t.png");
            }

            if (t == "tc")
            {
                pret.Text = "Pret/m";
                l1.Hide();
                l2.Hide();
                Lat.Hide();
                H.Hide();
                poza.Image = Image.FromFile("poze\\tc.png");
            }

            if (t == "tr")
            {
                pret.Text = "Pret/m";
                l5.Hide();
                Diam.Hide();
                poza.Image = Image.FromFile("poze\\tr.png");
            }

            if (t == "bc")
            {
                pret.Text = "Pret/m";
                l1.Hide();
                l2.Hide();
                l4.Hide();
                Lat.Hide();
                H.Hide();
                g.Hide();
                poza.Image = Image.FromFile("poze\\bc.png");
            }

            if (t == "br")
            {
                pret.Text = "Pret/m";
                l4.Hide();
                l5.Hide();
                Diam.Hide();
                g.Hide();
                poza.Image = Image.FromFile("poze\\br.png");
            }
            Completez_Combo_Materiale();
        }

        void Completez_Combo_Materiale()
        {
            MySqlCommand comMateriale = new MySqlCommand("SELECT * FROM materiale", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter(comMateriale);
            DataTable lista_materiale = new DataTable();
            adapt.Fill(lista_materiale);
            mat.Items.Clear();
            mat.DataSource = lista_materiale;
            // DataTable din care sunt preluate datele pentru ComboBox categorie
            mat.ValueMember = "id_material";
            // Valoarea din coloana id_acteg nu se afiseaza in comboBox, o vom folosi pentru adaugarea id_categ in tabela produse
            mat.DisplayMember = "nume";
            // Elementele afisate in ComboBox, preluate din coloana denumire din DataTable
        }

        //Functie pentru adaugarea unui produs de tip tabla
        void Adaug_Tabla()
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO produse(nume, pret, descriere, l, g, lung, id_cat, id_mat) VALUES(@nume_prod, @pret, @descriere, @latime, @grosime, @lungime, 1, @id_mat); ", conn);
            try
            {
                // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                if (prod.Text.Length > 0 && cost.Text.Length > 0 && Lat.Text.Length > 0 && g.Text.Length > 0 && Lung.Text.Length > 0 && mat.Items.Count > 0)
                {
                    cmd.Parameters.AddWithValue("@nume_prod", prod.Text);
                    cmd.Parameters.AddWithValue("@pret", cost.Text);
                    cmd.Parameters.AddWithValue("@descriere", desc.Text);
                    cmd.Parameters.AddWithValue("@latime", Lat.Text);
                    cmd.Parameters.AddWithValue("@grosime", g.Text);
                    cmd.Parameters.AddWithValue("@lungime", Lung.Text);
                    cmd.Parameters.AddWithValue("@id_mat", mat.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else throw new Exception("Completati toate informatiile");
                MessageBox.Show("Produsul " + prod.Text + " a fost adaugat");
                prod.Text = "";
                cost.Text = "";
                desc.Text = "";
                Lat.Text = "";
                Diam.Text = "";
                g.Text = "";
                Lung.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            //Functie pentru adaugarea unui produs de tip teava circulara
            void Adaug_Teava_Circulara()
        {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO produse(nume, pret, descriere, diam, g, lung, id_cat, id_mat) VALUES(@nume_prod, @pret, @descriere, @diametru, @grosime, @lungime, 2, @id_mat); ", conn);
                try
                {
                    // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                    if (prod.Text.Length > 0 && cost.Text.Length > 0 && Diam.Text.Length > 0 && g.Text.Length > 0 && Lung.Text.Length > 0 && mat.Items.Count > 0)
                    {
                        cmd.Parameters.AddWithValue("@nume_prod", prod.Text);
                        cmd.Parameters.AddWithValue("@pret", cost.Text);
                        cmd.Parameters.AddWithValue("@descriere", desc.Text);
                        cmd.Parameters.AddWithValue("@diametru", Diam.Text);
                        cmd.Parameters.AddWithValue("@grosime", g.Text);
                        cmd.Parameters.AddWithValue("@lungime", Lung.Text);
                        cmd.Parameters.AddWithValue("@id_mat", mat.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }
                    else throw new Exception("Completati toate informatiile");
                    MessageBox.Show("Produsul " + prod.Text + " a fost adaugat");
                    prod.Text = "";
                    cost.Text = "";
                    desc.Text = "";
                    Lat.Text = "";
                    g.Text = "";
                    Lung.Text = "";
                    Diam.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        //Functie pentru adaugarea unui produs de tip teava rectangulara
        void Adaug_Teava_Rectangulara()
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO produse(nume, pret, descriere, l, h, g, lung, id_cat, id_mat) VALUES(@nume_prod, @pret, @descriere, @latime, @inaltime, @grosime, @lungime, 3, @id_mat); ", conn);
            try
            {
                // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                if (prod.Text.Length > 0 && cost.Text.Length > 0 && Lat.Text.Length > 0 && H.Text.Length > 0 && g.Text.Length > 0 && Lung.Text.Length > 0 && mat.Items.Count > 0)
                {
                    cmd.Parameters.AddWithValue("@nume_prod", prod.Text);
                    cmd.Parameters.AddWithValue("@pret", cost.Text);
                    cmd.Parameters.AddWithValue("@descriere", desc.Text);
                    cmd.Parameters.AddWithValue("@latime", Lat.Text);
                    cmd.Parameters.AddWithValue("@inaltime", H.Text);
                    cmd.Parameters.AddWithValue("@grosime", g.Text);
                    cmd.Parameters.AddWithValue("@lungime", Lung.Text);
                    cmd.Parameters.AddWithValue("@id_mat", mat.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else throw new Exception("Completati toate informatiile");
                MessageBox.Show("Produsul " + prod.Text + " a fost adaugat");
                prod.Text = "";
                cost.Text = "";
                desc.Text = "";
                Lat.Text = "";
                H.Text = "";
                g.Text = "";
                Lung.Text = "";
                Diam.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Functie pentru adaugarea unui produs de tip bara circulara
        void Adaug_Bara_Circulara()
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO produse(nume, pret, descriere, diam, lung, id_cat, id_mat) VALUES(@nume_prod, @pret, @descriere, @diametru, @lungime, 4, @id_mat); ", conn);
            try
            {
                // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                if (prod.Text.Length > 0 && cost.Text.Length > 0 && Diam.Text.Length > 0 && Lung.Text.Length > 0 && mat.Items.Count > 0)
                {
                    cmd.Parameters.AddWithValue("@nume_prod", prod.Text);
                    cmd.Parameters.AddWithValue("@pret", cost.Text);
                    cmd.Parameters.AddWithValue("@descriere", desc.Text);
                    cmd.Parameters.AddWithValue("@diametru", Diam.Text);
                    cmd.Parameters.AddWithValue("@lungime", Lung.Text);
                    cmd.Parameters.AddWithValue("@id_mat", mat.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else throw new Exception("Completati toate informatiile");
                MessageBox.Show("Produsul " + prod.Text + " a fost adaugat");
                prod.Text = "";
                cost.Text = "";
                desc.Text = "";
                Lat.Text = "";
                g.Text = "";
                Lung.Text = "";
                Diam.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Functie pentru adaugarea unui produs de tip bara rectangulara
        void Adaug_Bara_Rectangulara()
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO produse(nume, pret, descriere, l, h, lung, id_cat, id_mat) VALUES(@nume_prod, @pret, @descriere, @latime, @inaltime, @lungime, 5, @id_mat); ", conn);
            try
            {
                // Tratarea exceptiei pentru situatia in care exista o eroare in executarea comenzii
                if (prod.Text.Length > 0 && cost.Text.Length > 0 && Lat.Text.Length > 0 && H.Text.Length > 0 && Lung.Text.Length > 0 && mat.Items.Count > 0)
                {
                    cmd.Parameters.AddWithValue("@nume_prod", prod.Text);
                    cmd.Parameters.AddWithValue("@pret", cost.Text);
                    cmd.Parameters.AddWithValue("@descriere", desc.Text);
                    cmd.Parameters.AddWithValue("@latime", Lat.Text);
                    cmd.Parameters.AddWithValue("@inaltime", H.Text);
                    cmd.Parameters.AddWithValue("@lungime", Lung.Text);
                    cmd.Parameters.AddWithValue("@id_mat", mat.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else throw new Exception("Completati toate informatiile");
                MessageBox.Show("Produsul " + prod.Text + " a fost adaugat");
                prod.Text = "";
                cost.Text = "";
                desc.Text = "";
                Lat.Text = "";
                g.Text = "";
                Lung.Text = "";
                Diam.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t == "t") Adaug_Tabla();
            if (t == "tc") Adaug_Teava_Circulara();
            if (t == "tr") Adaug_Teava_Rectangulara();
            if (t == "bc") Adaug_Bara_Circulara();
            if (t == "br") Adaug_Bara_Rectangulara();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close(); // inchidem conexiunea cu serverul BD
            this.Close(); //inchidem fereastra
        }
    }
}
