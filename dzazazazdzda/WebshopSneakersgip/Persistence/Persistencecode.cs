using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip.Persistence
{
    public class Persistencecode
    {
        string connstr = "server=localhost; user id=root; password=Test123; database=dbsneakers";

        //Persistence code om een product met bijhorende informatie op te halen.
        public List<Product> LoadProductenData()
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr); 
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT * FROM tblproducten";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //Lijst aanmaken en doorsturen naar de Business laag.
            List<Product> lijst = new List<Product>();
            while (dtr.Read())
            {
                Product product = new Product();
                product.ProductID = Convert.ToInt32(dtr["ProductID"]);
                product.Naam = dtr["Naam"].ToString();
                product.Voorraad = Convert.ToInt32(dtr["Voorraad"]);
                product.Prijs = Convert.ToDouble(dtr["Prijs"]);
                product.Foto = dtr["Foto"].ToString();

                lijst.Add(product);
            }
            conn.Close();
            return lijst;
        }

        public bool CheckInWinkelmand(int ProductID)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string qry = "SELECT * FROM tblWinkelmand WHERE ProductID = " + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            if (dtr.HasRows)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                return true;
            }
        }

        public void UpdateVoorraadMin(int ProductID, int _aantal, int _voorraad)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            int newvoorraad = _voorraad - _aantal;
            string qry = "UPDATE tblproducten SET Voorraad=" + newvoorraad + " WHERE ProductID=" + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool CheckWinkelmand()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();          
            string qry = "SELECT * FROM tblWinkelmand";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            if (dtr.HasRows)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }           
        }

        public void UploadToWinkelmand(Winkelmand w)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();         
            string qry = "INSERT into tblwinkelmand (KlantID, ProductID, Aantal) values (" + w.KlantID + ", " + w.ProductID + ", " + w.Aantal + ")";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteFromWinkelmand(int ProductID, int KlantID)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string qry = "DELETE from tblwinkelmand where KlantID = " + KlantID + " AND ProductID = " + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateVoorraadPlus(int ProductID, int _aantal, int _voorraad)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            int newvoorraad = _voorraad + _aantal;
            string qry = "UPDATE tblproducten SET Voorraad=" + newvoorraad + " WHERE ProductID=" + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public string[] LoadKlantData(int KlantID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT * FROM tblKlanten WHERE KlantID=" + KlantID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //array aanmaken en doorsturen naar de Business laag.           
            string[] array = new string[4];
            while (dtr.Read())
            {
                array[0] = dtr["Voornaam"].ToString() + " " + dtr["Naam"].ToString();
                array[1] = dtr["Adres"].ToString();
                array[2] = dtr["Postcode"].ToString();
                array[3] = dtr["Gemeente"].ToString();
            }
       
            conn.Close();
            return array;
        }

        public List<ProductenInWinkelmand> LoadFromProductenInWinkelmand(int KlantID)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string qry = "SELECT tblproducten.ProductID, Foto, Naam, Aantal, Prijs FROM tblProducten INNER JOIN tblWinkelmand ON tblProducten.ProductID = tblWinkelmand.ProductID WHERE KlantID=" + KlantID; 
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<ProductenInWinkelmand> Lijst = new List<ProductenInWinkelmand>();

            while (dtr.Read())
            {
                ProductenInWinkelmand Piw = new ProductenInWinkelmand();
                Piw.Foto = dtr["Foto"].ToString();
                Piw.ProductID = Convert.ToInt32(dtr["ProductID"]);
                Piw.Naam = dtr["Naam"].ToString();
                Piw.Aantal = Convert.ToInt32(dtr["Aantal"]);
                Piw.Prijs = Convert.ToDouble(dtr["Prijs"]);
                Piw.Totaal = Convert.ToDouble(dtr["Prijs"]) * Convert.ToDouble(dtr["Aantal"]);

                Lijst.Add(Piw);
            }
            conn.Close();
            return Lijst;
        }

        public double[] BerekenTotalen()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string qry = "select sum(Aantal * Prijs) as totaalExclBTW, 0.21 * sum(Aantal * Prijs) as BTW, sum(Aantal * Prijs) + 0.21 * sum(Aantal * Prijs) as totaalInclBTW" + "" +
                         "from tblwinkelmand inner join tblproducten on tblWinkelmand.ProductID = tblProducten.ProductID";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            double[] array = new double[3];
            while (dtr.Read())
            {
                Totalen tot = new Totalen();
                array[0] = Convert.ToDouble(dtr["totaalExclBTW"]);
                array[1] = Convert.ToDouble(dtr["BTW"]);
                array[2] = Convert.ToDouble(dtr["totaalInclBTW"]);             
            }
            conn.Close();
            return array;
        }

    }
}