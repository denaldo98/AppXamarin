using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface AppelliFirestore
    {
        bool InsertAppello(Appello appello);
        Task<bool> DeleteAppello(Appello appello);
        Task<bool> UpdateAppello(Appello appello);
        Task<IList<Appello>> ReadAppelli();
    }

    public class DatabaseAppelliHelper
    {
        private static AppelliFirestore firestore = DependencyService.Get<AppelliFirestore>();

        public static Task<bool> DeleteAppello(Appello appello)
        {
            return firestore.DeleteAppello(appello);
        }

        public static bool InsertAppello(Appello appello)
        {
            return firestore.InsertAppello(appello);
        }

        public static Task<IList<Appello>> ReadAppelli()
        {
            return firestore.ReadAppelli();
        }

        public static Task<bool> UpdateAppello(Appello appello)
        {
            return firestore.UpdateAppello(appello);
        }

    }
}
