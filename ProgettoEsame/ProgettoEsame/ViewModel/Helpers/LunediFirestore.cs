using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface LunediFirestore
    {
        bool InsertLunedi(Evento lunedi);
        Task<bool> DeleteLunedi(Evento lunedi);
        Task<bool> UpdateLunedi(Evento lunedi);
        Task<IList<Evento>> ReadLunedi();
    }

    public class DatabaseLunediHelper
    {
        private static LunediFirestore firestore = DependencyService.Get<LunediFirestore>();

        public static Task<bool> DeleteLunedi(Evento lunedi)
        {
            return firestore.DeleteLunedi(lunedi);
        }

        public static bool InsertLunedi(Evento lunedi)
        {
            return firestore.InsertLunedi(lunedi);
        }

        public static Task<IList<Evento>> ReadLunedi()
        {
            return firestore.ReadLunedi();
        }

        public static Task<bool> UpdateLunedi(Evento lunedi)
        {
            return firestore.UpdateLunedi(lunedi);
        }

    }
}
