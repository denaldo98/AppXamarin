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
        bool InsertLunedi(Lunedi lunedi);
        Task<bool> DeleteLunedi(Lunedi lunedi);
        Task<bool> UpdateLunedi(Lunedi lunedi);
        Task<IList<Lunedi>> ReadLunedi();
    }

    public class DatabaseLunediHelper
    {
        private static LunediFirestore firestore = DependencyService.Get<LunediFirestore>();

        public static Task<bool> DeleteLunedi(Lunedi lunedi)
        {
            return firestore.DeleteLunedi(lunedi);
        }

        public static bool InsertLunedi(Lunedi lunedi)
        {
            return firestore.InsertLunedi(lunedi);
        }

        public static Task<IList<Lunedi>> ReadLunedi()
        {
            return firestore.ReadLunedi();
        }

        public static Task<bool> UpdateLunedi(Lunedi lunedi)
        {
            return firestore.UpdateLunedi(lunedi);
        }

    }
}
