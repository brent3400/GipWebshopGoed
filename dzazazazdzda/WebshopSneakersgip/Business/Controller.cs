using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopSneakersgip.Persistence;

namespace WebshopSneakersgip.Business
{
    public class Controller
    {
        Persistencecode _pers = new Persistencecode();

        public List<Product> LoadProductenData()
        {
            return _pers.LoadProductenData();
        }
        
        public bool CheckInWinkelmand(int ProductID)
        {
            return _pers.CheckInWinkelmand(ProductID);
        }

        public void UpdateVoorraadMin(int pid, int _a, int _v)
        {
            _pers.UpdateVoorraadMin(pid, _a, _v);
        }

        public bool CheckWinkelmand()
        {
            return _pers.CheckWinkelmand();
        }

        public void UploadToWinkelmand(int kid, int pid, int aant)
        {
            Winkelmand w = new Winkelmand();
            w.KlantID = kid; w.ProductID = pid; w.Aantal = aant;
            _pers.UploadToWinkelmand(w);
        }

        public void DeleteFromWinkelmand(int pid, int kid)
        {
            _pers.DeleteFromWinkelmand(pid, kid);
        }

        public void UpdateVoorraadPlus(int pid, int _a, int _v)
        {
            _pers.UpdateVoorraadPlus(pid, _a, _v);
        }

        public List<ProductenInWinkelmand> LoadFromProductenInWinkelmand(int KlantID)
        {
            return _pers.LoadFromProductenInWinkelmand(KlantID);
        }

        public string[] LoadFromKlanten(int KlantID)
        {
            return _pers.LoadKlantData(KlantID);
        }

        public double[] BerekenTotalen()
        {
            return _pers.BerekenTotalen();
        }
    }
}