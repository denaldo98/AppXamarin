using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface GiovediFirestore
    {
        bool InsertGiovedi(Evento giovedi);
        Task<bool> DeleteGiovedi(Evento giovedi);
        Task<bool> UpdateGiovedi(Evento giovedi);
        Task<IList<Evento>> ReadGiovedi();
    }

    public class DatabaseGiovediHelper
    {
        private static GiovediFirestore firestore = DependencyService.Get<GiovediFirestore>();

        public static Task<bool> DeleteGiovedi(Evento giovedi)
        {
            return firestore.DeleteGiovedi(giovedi);
        }

        public static bool InsertGiovedi(Evento giovedi)
        {
            return firestore.InsertGiovedi(giovedi);
        }

        public static Task<IList<Evento>> ReadGiovedi()
        {
            return firestore.ReadGiovedi();
        }

        public static Task<bool> UpdateGiovedi(Evento giovedi)
        {
            return firestore.UpdateGiovedi(giovedi);
        }

    }
}