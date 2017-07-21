using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

	
using AlertDialog = Android.Support.V7.App.AlertDialog;
namespace MiUberAndroid
{

    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat")]



    public class Login : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            var txtForgotPassword = FindViewById<TextView>(Resource.Id.txtPasswordForgot);
            var txtSignIn = FindViewById<TextView>(Resource.Id.txtSignIn);

           

            txtForgotPassword.Click += (sender, evt) =>
            {
                var intent = new Android.Content.Intent(this, typeof(ForgotPassword));
                  StartActivity(intent);
            };
            // cambiar de actividad al dar clic sobre el boton.
            txtSignIn.Click += (sender, evt) =>
            {
                var intent = new Android.Content.Intent(this, typeof(ValidateNumberPhone));
                StartActivity(intent);
            };



        }
    }
}