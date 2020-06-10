using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface VenerdiFirestore
    {
        bool InsertVenerdi(Evento venerdi);
        Task<bool> DeleteVenerdi(Evento venerdi);
        Task<bool> UpdateVenerdi(Evento venerdi);
        Task<IList<Evento>> ReadVenerdi();
    }

    public class DatabaseVenerdiHelper
    {
        private static VenerdiFirestore firestore = DependencyService.Get<VenerdiFirestore>();

        public static Task<bool> DeleteVenerdi(Evento venerdi)
        {
            return firestore.DeleteVenerdi(venerdi);
        }

        public static bool InsertVenerdi(Evento venerdi)
        {
            return firestore.InsertVenerdi(venerdi);
        }

        public static Task<IList<Evento>> ReadVenerdi()
        {
            return firestore.ReadVenerdi();
        }

        public static Task<bool> UpdateVenerdi(Evento venerdi)
        {
            return firestore.UpdateVenerdi(venerdi);
        }

    }
}