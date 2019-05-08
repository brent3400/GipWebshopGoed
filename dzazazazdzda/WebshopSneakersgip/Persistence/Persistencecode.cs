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
        public List<Product> LoadData()
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

        public void UpdateVoorraad(int ProductID, int _aantal, int _voorraad)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            int newvoorraad = _voorraad - _aantal;
            string qry = "UPDATE tblproducten SET Voorraad=" + newvoorraad + " WHERE ProductID=" + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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

        public void DeleteFromWinkelmand(int ProductID)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string qry = "DELETE from tblwinkelmand where ProductID = " + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<ProductenInWinkelmand> LoadFromProductenInWinkelmand(int KlantID)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Close();
            string qry = "SELECT Foto, ProductID, Naam, Aantal, Prijs from tblProducten INNER JOIN tblWinkelmand ON tblProducten.ProductID = tblWinkelmand.ProductID where KlantID=" + KlantID; 
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
    }
}