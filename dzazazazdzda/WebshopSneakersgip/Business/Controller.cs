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

        public List<Product> LoadData()
        {
            return _pers.LoadData();
        }
        
        public void UpdateVoorraad(int pid, int _a, int _v)
        {
            _pers.UpdateVoorraad(pid, _a, _v);
        }

        public void UploadToWinkelmand(int kid, int pid, int aant)
        {
            Winkelmand w = new Winkelmand();
            w.KlantID = kid; w.ProductID = pid; w.Aantal = aant;
            _pers.UploadToWinkelmand(w);
        }

        public List<ProductenInWinkelmand> LoadFromProductenInWinkelmand(int KlantID)
        {
            return _pers.LoadFromProductenInWinkelmand(KlantID);
        }
    }
}