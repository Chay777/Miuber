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
    [Activity(Label = "ValidateNumberPhone", Theme = "@style/Base.Theme.DesignDemo")]
    public class ValidateNumberPhone : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ValidateNumberPhone);

            var btnSendCode = FindViewById<Button>(Resource.Id.btnSendCode);
            var btnNext = FindViewById<Button>(Resource.Id.btnNext);

            btnSendCode.Click += (sender, evd) =>
            {
                btnNext.Enabled = true;
            };

            btnNext.Click += (sender, evt) => 
            {
                var intent = new Android.Content.Intent(this, typeof(SignIn));
                StartActivity(intent);
            };
            

            // Create your application here
        }
    }
}