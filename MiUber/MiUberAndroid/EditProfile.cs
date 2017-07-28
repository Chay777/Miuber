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
    [Activity(Label = "EditProfile", Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat")]
    public class EditProfile : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditProfile);
            var txtNombre = FindViewById<EditText>(Resource.Id.edtEditName);
            var txtApellidos = FindViewById<EditText>(Resource.Id.edtEditLastName);
            var txtFechaNacimiento = FindViewById<EditText>(Resource.Id.edtEditBirthDay);
            var txtCorreo = FindViewById<EditText>(Resource.Id.edtEditMail);

            txtNombre.Text = "José Rosario";
            txtApellidos.Text = "Villanueva Morales";
            txtFechaNacimiento.Text = "05/07/1992";
            txtCorreo.Text = "Chayo777@msn.com";
            // Create your application here
        }
    }
}