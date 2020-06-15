using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Google.Type;
using Java.Util;
using ProgettoEsame.Model;
using ProgettoEsame.ViewModel.Helpers;
using Xamarin.Forms;
using Firebase.Firestore;
using Android.Gms.Tasks;
using Android.Service.VR;
using Org.W3c.Dom;
[assembly: Dependency(typeof(ProgettoEsame.Droid.Dependencies.FirestoreVenerdi))]
namespace ProgettoEsame.Droid.Dependencies
{
    class FirestoreVenerdi : Java.Lang.Object, ViewModel.Helpers.VenerdiFirestore, IOnCompleteListener
    {

        List<Evento> venerdiList;
        bool hasReadVenerdi = false;

        public FirestoreVenerdi()
        {
            venerdiList = new List<Evento>();
        }



        public async Task<bool> DeleteVenerdi(Evento venerdi)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Venerdi");
                collection.Document(venerdi.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertVenerdi(Evento venerdi)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Venerdi");
                var venerdiDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"nome", venerdi.Name },
                    {"luogo", venerdi.Luogo },
                    {"ora inizio", venerdi.OraI },
                    {"ora fine", venerdi.OraF }

                };
                collection.Add(venerdiDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IList<Evento>> ReadVenerdi()
        {
            hasReadVenerdi = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Venerdi");
            collection.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadVenerdi)
                    break;
            }

            return venerdiList;

        }

        public async Task<bool> UpdateVenerdi(Evento venerdi)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Venerdi");
                collection.Document(venerdi.Id).Update("nome", venerdi.Name, "luogo", venerdi.Luogo, "ora inizio", venerdi.OraI, "ora fine", venerdi.OraF);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void OnComplete(Android.Gms.Tasks.Task task)  //qui otteniani il risultato della query
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;

                venerdiList.Clear();
                foreach (var doc in documents.Documents)
                {
                    string luogo, oraI, oraF;
                    if (doc.Get("luogo") == null)
                    {
                        luogo = "";
                    }
                    else
                    {
                        luogo = doc.Get("luogo").ToString();
                    }
                    if (doc.Get("ora inizio") == null)
                    {
                        oraI = "";
                    }
                    else
                    {
                        oraI = doc.Get("ora inizio").ToString();
                    }
                    if (doc.Get("ora fine") == null)
                    {
                        oraF = "";
                    }
                    else
                    {
                        oraF = doc.Get("ora fine").ToString();
                    }
                    Evento venerdi = new Evento
                    {
                        Name = doc.Get("nome").ToString(),
                        Luogo = luogo,
                        OraI = oraI,
                        OraF = oraF,

                        Id = doc.Id
                    };

                    venerdiList.Add(venerdi);

                }
            }
            else
            {
                venerdiList.Clear();

            }
            hasReadVenerdi = true;
        }
    }
}