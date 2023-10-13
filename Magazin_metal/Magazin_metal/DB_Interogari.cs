using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;


namespace Magazin_metal
{
    class DB_Interogari
    {
        static MySqlConnection conn = new MySqlConnection("DataSource=localhost; UserID=root; database=metalmag");

        public static DataTable Descarc_Categorii()
        {
            MySqlCommand comCateg = new MySqlCommand("SELECT id_categ,nume FROM categorii", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter(comCateg);
            DataTable CategT = new DataTable();
            adapt.Fill(CategT);
            return CategT;
        }

        public static DataTable Descarc_Materiale()
        {
            MySqlCommand comMateriale = new MySqlCommand("SELECT id_material,densitate,descriere,nume FROM materiale", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter(comMateriale);
            DataTable MaterialT = new DataTable();
            adapt.Fill(MaterialT);
            return MaterialT;
        }

        public static DataTable Descarc_Produse()
        {
            MySqlCommand comProduse = new MySqlCommand("SELECT id_produs,id_mat,id_cat,nume,l,h,diam,lung,pret,descriere,g FROM materiale", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter(comProduse);
            DataTable ProdusT = new DataTable();
            adapt.Fill(ProdusT);
            return ProdusT;
        }

        public static DataTable Descarc_ProdCom() //Returneaza id-urile produselor care se afla in comenzi
        {
            MySqlCommand comProdCom = new MySqlCommand("SELECT id_p FROM detalii_comanda", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter(comProdCom);
            DataTable ProdComT = new DataTable();
            adapt.Fill(ProdComT);
            return ProdComT;
        }

    }
}
