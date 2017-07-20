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

namespace MiUberAndroid
{

    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class Login : Activity
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
            txtSignIn.Click += (sender, evt) =>
            {
                var intent = new Android.Content.Intent(this, typeof(ValidateNumberPhone));
                StartActivity(intent);
            };



        }
    }
}