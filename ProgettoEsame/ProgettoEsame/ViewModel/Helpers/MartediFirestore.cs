using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface MartediFirestore
    {
        bool InsertMartedi(Evento martedi);
        Task<bool> DeleteMartedi(Evento martedi);
        Task<bool> UpdateMartedi(Evento martedi);
        Task<IList<Evento>> ReadMartedi();
    }

    public class DatabaseMartediHelper
    {
        private static MartediFirestore firestore = DependencyService.Get<MartediFirestore>();

        public static Task<bool> DeleteMartedi(Evento martedi)
        {
            return firestore.DeleteMartedi(martedi);
        }

        public static bool InsertMartedi(Evento martedi)
        {
            return firestore.InsertMartedi(martedi);
        }

        public static Task<IList<Evento>> ReadMartedi()
        {
            return firestore.ReadMartedi();
        }

        public static Task<bool> UpdateMartedi(Evento martedi)
        {
            return firestore.UpdateMartedi(martedi);
        }

    }
}