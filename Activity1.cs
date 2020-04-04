using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace access_controle
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /*Button envoie = FindViewById<Button>(Resource.Id.button1);
            TextView texte = FindViewById<TextView>(Resource.Id.textView1);
            string url = "http://192.168.1.50/auth.php?rfid=0123456789";
            envoie.Click += req;

            void req(object sender, EventArgs e)
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                //request.Method = "GET";
                //request.Headers.Add("rfid", "0123456789");
                HttpWebResponse Httpresponse = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = Httpresponse.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                texte.Text = readStream.ReadToEnd();
            };*/
        }
    }
}