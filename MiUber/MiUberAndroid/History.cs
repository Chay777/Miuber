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
using PCLCode.Entities;
using Android.Support.V7.App;

namespace MiUberAndroid
{
    [Activity(Label = "History", Theme = "@style/Base.Theme.DesignDemo")]
    public class History : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.History);
            ViajeEjemplo viaje1 = new ViajeEjemplo();
            viaje1.fechaInicio = "12/01/2017 13:00";
            viaje1.id = 1;
            viaje1.costo = "$30.00";
            viaje1.modeloAuto = "Jetta Vento";
            ViajeEjemplo viaje2 = new ViajeEjemplo();
            viaje2.fechaInicio = "13/01/2017 13:00";
            viaje2.id = 2;
            viaje2.costo = "$20.00";
            viaje2.modeloAuto = "Mazda 3";
            ViajeEjemplo viaje3 = new ViajeEjemplo();
            viaje3.fechaInicio = "19/01/2017 13:00";
            viaje3.id = 3;
            viaje3.costo = "$70.00";
            viaje3.modeloAuto = "Mercedes Benz";

            var listViajes = FindViewById<ListView>(Resource.Id.listViajes);

            List<ViajeEjemplo> viajes = new List<ViajeEjemplo>
            {
                viaje1,
                viaje2,
                viaje3
            };
            listViajes.Adapter = new HistoryAdapter(
                    this, viajes, Resource.Layout.ViajeItem, Resource.Id.txtFechaInicio, Resource.Id.txtModeloAuto,Resource.Id.txtCosto
                    );

            // Create your application here
        }
    }
}