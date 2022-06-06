using Android.App;
using Android.Content;
using Android.Graphics;
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
    internal class AdapterImage : BaseAdapter
    {
        private Activity context;
        private List<SWPhoto> vLista;

        public AdapterImage(Activity context, List<SWPhoto> vLista)
        {
            this.context = context;
            this.vLista = vLista;
        }

        public override int Count => vLista.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = vLista[position];
            Bitmap bitmap = BitmapFactory.DecodeByteArray(item.Img, 0,
            item.Img.Length);
            View view = convertView; // re-use an existing view, if one is available

            if (view == null) // otherwise create a new one
                view =context.LayoutInflater.Inflate(Resource.Layout.ItemGaleria, null);
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageBitmap(bitmap);
            view.FindViewById<TextView>(Resource.Id.lblUser).Text = item.User;
            view.FindViewById<TextView>(Resource.Id.lblTipo).Text = item.TipoId.ToString();
            view.FindViewById<TextView>(Resource.Id.lblStatus).Text = item.Status;
            return view;
        }
    }
}