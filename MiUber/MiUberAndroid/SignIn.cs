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
using Android.Support.V7.App;

namespace MiUberAndroid
{
    [Activity(Label = "@string/ApplicationName",Icon = "@drawable/icon", Theme = "@style/Base.Theme.DesignDemo")]
    public class SignIn : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignIn);
            // Create your application here
        }
    }
}