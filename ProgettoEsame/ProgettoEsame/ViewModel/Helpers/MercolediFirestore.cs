using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface MercolediFirestore
    {
        bool InsertMercoledi(Evento mercoledi);
        Task<bool> DeleteMercoledi(Evento mercoledi);
        Task<bool> UpdateMercoledi(Evento mercoledi);
        Task<IList<Evento>> ReadMercoledi();
    }

    public class DatabaseMercolediHelper
    {
        private static MercolediFirestore firestore = DependencyService.Get<MercolediFirestore>();

        public static Task<bool> DeleteMercoledi(Evento mercoledi)
        {
            return firestore.DeleteMercoledi(mercoledi);
        }

        public static bool InsertMercoledi(Evento mercoledi)
        {
            return firestore.InsertMercoledi(mercoledi);
        }

        public static Task<IList<Evento>> ReadMercoledi()
        {
            return firestore.ReadMercoledi();
        }

        public static Task<bool> UpdateMercoledi(Evento mercoledi)
        {
            return firestore.UpdateMercoledi(mercoledi);
        }

    }
}