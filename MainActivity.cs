using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace access_controle
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
            EditText identifient;
            EditText pass;
            EditText adresse;
            EditText nom;
            EditText prenom;
            EditText rfid;
            EditText minheure;
            EditText maxheure;
            EditText supuser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            this.identifient = FindViewById<EditText>(Resource.Id.identifiant);
            this.pass = FindViewById<EditText>(Resource.Id.pass);
            this.adresse = FindViewById<EditText>(Resource.Id.adresse);
            this.nom = FindViewById<EditText>(Resource.Id.nom);
            this.prenom = FindViewById<EditText>(Resource.Id.prenom);
            this.minheure = FindViewById<EditText>(Resource.Id.minheure);
            this.maxheure = FindViewById<EditText>(Resource.Id.maxheure);
            this.rfid = FindViewById<EditText>(Resource.Id.rfid);
            this.supuser = FindViewById<EditText>(Resource.Id.supuser);

            Button btnajt = FindViewById<Button>(Resource.Id.btnAjt);
            Button btnsupuser = FindViewById<Button>(Resource.Id.btnsupuser);

            btnajt.Click += this.ajtuser;
            btnsupuser.Click += this.suprimer;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private string envoyer(string req)
        {
            var request = WebRequest.Create(req) as HttpWebRequest;
            HttpWebResponse Httpresponse = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = Httpresponse.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            return readStream.ReadToEnd();
        }
        public void ajtuser(object sender ,EventArgs e)
        {
            if(int.Parse(this.minheure.Text)>24)
            {
                this.minheure.Text = 24.ToString();
            }
            if (int.Parse(this.maxheure.Text) > 24)
            {
                this.maxheure.Text = 24.ToString();
            }
            try
            {
                string req = "http://" + this.adresse.Text + "/mobile.php?type=ajtuser&nom=" + this.nom.Text + "&prenom=" + this.prenom.Text + "&rfid=" + this.rfid.Text + "&minheure=" + this.minheure.Text + "&maxheure=" + this.maxheure.Text + "&identifient=" + this.identifient.Text + "&pass=" + this.pass.Text;
                System.Diagnostics.Debug.WriteLine(req);
                this.envoyer(req);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("erreur d'ajout d'utilisateur");
            }
        }
        public void suprimer(object sender, EventArgs e)
        {
            try
            {
                string req = "http://" + this.adresse.Text + "/mobile.php?type=supuser&prenom="+this.supuser.Text+"&identifient="+this.identifient.Text+"&pass="+this.pass.Text ;
                System.Diagnostics.Debug.WriteLine(req);
                this.envoyer(req);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("erreur d'ajout d'utilisateur");
            }
        }
        public void test(object sender, EventArgs e)
        {
            string req = "http://" + this.adresse + "/auth.php?rfid=" + this.rfid.Text;
            System.Diagnostics.Debug.WriteLine(req);
            this.envoyer(req);
        }
    }
}

