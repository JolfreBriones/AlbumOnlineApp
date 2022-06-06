using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AlbumOnlineApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText txtUser, txtPass;
        private Button btnEntrar;
        private TextView lblRegistrarse, lblError;

        //Establecer instancia del Web Service
        private com.somee.facultativa2022.AlbumOnlineWS ws = new com.somee.facultativa2022.AlbumOnlineWS();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

           
            //Establecer referencia con los botones del layout
            txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            txtPass = FindViewById<EditText>(Resource.Id.txtPass);
            lblError = FindViewById<TextView>(Resource.Id.lblError);


            //Botones de Accion
            btnEntrar = FindViewById<Button>(Resource.Id.btnEntrar);
            btnEntrar.Click += BtnEntrar_Click;

        }

        private void BtnEntrar_Click(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtUser.Text) && !string.IsNullOrEmpty(this.txtPass.Text))
            {
                if (ws.Login(this.txtUser.Text, this.txtPass.Text))
                {
                    lblError.Text = "Exitoso";
                    lblError.SetTextColor(Android.Graphics.Color.Green);
                    Intent i = new Intent(this, typeof(ActivityMenu));
                    StartActivity(i);
                }
                else
                    lblError.Text = "Error al Iniciar Sesion";
            }
            else
                lblError.Text = "Usuario y Contraseña son obligatorios";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}