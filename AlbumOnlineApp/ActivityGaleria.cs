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
    [Activity(Label = "ActivityGaleria")]
    public class ActivityGaleria : Activity
    {
        private ListView listFotos;

        //Establecer instancia del Web Service
        private com.somee.facultativa2022.AlbumOnlineWS ws = new com.somee.facultativa2022.AlbumOnlineWS();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Galeria);
            // Create your application here

            listFotos = FindViewById<ListView>(Resource.Id.listFotos);

            var list = ws.get_photos("Admin");
            List<SWPhoto> list2 = list.Select(x => new SWPhoto() {
                Img = x.Img,
                Fecha = x.Fecha,
                Status = x.Status,
                TipoId = x.TipoId,
                User = x.User
            }).ToList();

            listFotos.Adapter = new AdapterImage(this, list2);
        }
    }

    public class SWPhoto
    {
        public byte[] Img { get; set; }
        public string User { get; set; }
        public string Fecha { get; set; }
        public string Status { get; set; }
        public int TipoId { get; set; }
    }
}