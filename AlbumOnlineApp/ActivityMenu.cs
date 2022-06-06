using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlbumOnlineApp
{
    [Activity(Label = "ActivityMenu")]
    public class ActivityMenu : Activity
    {
        private Button btnTomarFoto, btnGaleria;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);
            // Create your application here

            btnTomarFoto = FindViewById<Button>(Resource.Id.btnTomarFoto);
            btnTomarFoto.Click += BtnTomarFoto_Click;
            btnGaleria = FindViewById<Button>(Resource.Id.btnGaleria);
            btnGaleria.Click += BtnGaleria_Click;
        }

        private void BtnGaleria_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityGaleria));
            StartActivity(i);
        }

        private void BtnTomarFoto_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityCamara));
            StartActivity(i);
        }
    }
}