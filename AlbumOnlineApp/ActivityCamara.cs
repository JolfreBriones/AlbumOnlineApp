using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlbumOnlineApp
{
    [Activity(Label = "ActivityCamara")]
    public class ActivityCamara : Activity
    {
        private Button btnAbrirCamara, btnSubirFoto;
        private ImageView imgVista;
        private Byte[] bitmapData;
        private TextView lblMensaje;
        private com.somee.facultativa2022.AlbumOnlineWS db = new com.somee.facultativa2022.AlbumOnlineWS();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Camara);
            // Create your application here

            btnAbrirCamara = FindViewById<Button>(Resource.Id.btnAbrirCamara);
            btnAbrirCamara.Click += BtnAbrirCamara_Click;
            btnSubirFoto = FindViewById<Button>(Resource.Id.btnSubirFoto);
            btnSubirFoto.Click += BtnSubirFoto_Click;

            imgVista = FindViewById<ImageView>(Resource.Id.imgVista);
            lblMensaje = FindViewById<TextView>(Resource.Id.lblMensaje);
        }

        private void BtnSubirFoto_Click(object sender, EventArgs e)
        {
            if (db.AddImg(bitmapData, 1, "Admin"))
            {
                lblMensaje.Text = "Se guardo la imagen";
                lblMensaje.SetTextColor(Android.Graphics.Color.Green);
            }
            else
            {
                lblMensaje.Text = "Error al guardar la imagen";
                lblMensaje.SetTextColor(Android.Graphics.Color.Red);
            }

            /*Intent i = new Intent();
            i.SetType("image/*");
            i.SetAction(Intent.ActionGetContent);
            StartActivityForResult(i, 0);*/
        }

        private void BtnAbrirCamara_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            Intent i = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(i, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum]Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            imgVista.SetImageBitmap(bitmap);
            //Bitmap to Byte
            //convertimos a Byte para luego almacenarlo en el servidor
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
        }


    }
}