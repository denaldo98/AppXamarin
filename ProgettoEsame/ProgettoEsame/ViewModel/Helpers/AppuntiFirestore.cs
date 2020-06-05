using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface AppuntiFirestore
    {
        bool InsertAppunto(Appunto appunto);
        Task<bool> DeleteAppunto(Appunto appunto);
        Task<bool> UpdateAppunto(Appunto appunto);
        Task<IList<Appunto>> ReadAppunti(Corso corso);
    }

    public class DatabaseAppuntiHelper
    {
        private static AppuntiFirestore firestore = DependencyService.Get<AppuntiFirestore>();

        public static Task<bool> DeleteAppunto(Appunto appunto)
        {
            return firestore.DeleteAppunto(appunto);
        }

        public static bool InsertAppunto(Appunto appunto)
        {
            return firestore.InsertAppunto(appunto);
        }

        public static Task<IList<Appunto>> ReadAppunti(Corso corso)
        {
            return firestore.ReadAppunti(corso);
        }

        public static Task<bool> UpdateAppunto(Appunto appunto)
        {
            return firestore.UpdateAppunto(appunto);
        }

    }
}
