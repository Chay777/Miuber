using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Support.V4.Content;
using Android;
using Android.Locations;
using Plugin.Geolocator;
using System;
using Android.Runtime;
using Android.Graphics;
using Android.Widget;

namespace MiUberAndroid
{
    [Activity(Label = "MiUberAndroid", Theme = "@style/Base.Theme.DesignDemo")]

    public class MainActivity : AppCompatActivity, IOnMapReadyCallback, ILocationListener
    {
        DrawerLayout drawerLayout;
        Android.Support.Design.Widget.NavigationView navigationView;
        MarkerOptions marcaActual;
        GoogleMap _googleMap;
        LatLng latLng;
        protected override void OnCreate(Bundle bundle)
        {


            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // Create ActionBarDrawerToggle button and add it to the toolbar  
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            // drawerToggle.addDrawerListener(drawerToggle);

            //drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.InflateHeaderView(Resource.Layout.NavigationHeader);
            setupDrawerContent(navigationView); //Calling Function
            var bottomSheet = FindViewById<LinearLayout>(Resource.Id.layoutTravelData);
            BottomSheetBehavior sheet = BottomSheetBehavior.From(bottomSheet);
            sheet.Hideable = true;
            sheet.State = BottomSheetBehavior.StateHidden;
            var txtSearch = FindViewById<EditText>(Resource.Id.edtSearchDestination);
            var txvCancelar = FindViewById<TextView>(Resource.Id.txvCancelar);
            txtSearch.FocusChange += (sender, evt) =>
            {
                sheet.State=BottomSheetBehavior.StateExpanded;

            };

            txvCancelar.Click += (NotificationPrioritySenders, evt) =>
            {
                sheet.State = BottomSheetBehavior.StateHidden;
            };
            
            // GetCurrentPosition();
            MapFragment map = (MapFragment)FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
            map.GetMapAsync(this);

            
        }

        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId) {
                    case Resource.Id.nav_Profile:
                        var intent = new Android.Content.Intent(this, typeof(EditProfile));
                        StartActivity(intent);
                        break;

                    case Resource.Id.nav_history:
                        var intentHistory = new Android.Content.Intent(this, typeof(History));
                        StartActivity(intentHistory);
                        break;

                }

                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {

            navigationView.InflateMenu(Resource.Menu.NavigationMenu);
            return true;

        }

        public void OnMapReady(GoogleMap googleMap)
        {

            _googleMap = googleMap;
            // GetCurrentPosition();
            setPosicionActual(_googleMap);
            setConductoresActivos(_googleMap);


            CameraUpdate center =
             CameraUpdateFactory.NewLatLng(new LatLng(20.5279612, -100.8112885));
            // CameraUpdate zoom = CameraUpdateFactory.ZoomIn();
            CameraUpdate zoom = CameraUpdateFactory.NewLatLngZoom(new LatLng(20.5279612, -100.8112885), 16);
            _googleMap.MoveCamera(center);
            _googleMap.AnimateCamera(zoom);
          
        
          //  _googleMap.UiSettings.MyLocationButtonEnabled = true;
           // _googleMap.MyLocationEnabled = true;

            pintarRuta(googleMap);
            mostrarMensaje("Bienvenido");
        }
        public void setPosicionActual(GoogleMap map)
        {
           MarkerOptions usuarioMarca = new MarkerOptions();
            usuarioMarca.SetPosition(new LatLng(20.5279612, -100.8112885));
            usuarioMarca.SetTitle("Mi posicion");
            usuarioMarca.Draggable(true);
            usuarioMarca.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue));
            map.UiSettings.ZoomControlsEnabled = true;
            map.UiSettings.CompassEnabled = true;
          
             map.AddMarker(usuarioMarca);
        }
        public void pintarRuta(GoogleMap map)
        {
            Polyline line = map.AddPolyline(new PolylineOptions()
             .Add(new LatLng(20.5279612, -100.8112885), new LatLng(20.5466882, -100.8384814)));
            line.Width = 3;
            line.Color = Color.ParseColor("#303f9f");


        }

        public void mostrarMensaje(String mensaje)
        {
            var layout = FindViewById<LinearLayout>(Resource.Id.lytToolBar);

            Snackbar
          .Make(layout, mensaje, Snackbar.LengthLong)
          .SetAction("Ok", (view) => { /*Undo message sending here.*/ })
          .Show(); // Don’t forget to show!
        }

        public void setConductoresActivos(GoogleMap map)
        {
            
            for (int i=0; i<10; i++)
            {
                LatLng lat;
                if (i % 2 == 0)
                {
                    Random random = new Random();
                    Double randomNumber = random.Next(0, i);
                    lat = new LatLng(20.5279612 + randomNumber*.01, -100.811288 + randomNumber*.01);
                }
                else
                {
                    Random random = new Random();
                    Double randomNumber = random.Next(0, i);
                    lat = new LatLng(20.5279612 - randomNumber*.02, -100.811288 - randomNumber*.02);
                }
                marcaActual = new MarkerOptions();
                marcaActual.SetPosition(lat);
                marcaActual.SetTitle("Conductor "+i+1);
              
                map.UiSettings.ZoomControlsEnabled = true;
                map.UiSettings.CompassEnabled = true;
                marcaActual.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.car));
                map.AddMarker(marcaActual);
            }
            

        }

        public async void  GetCurrentPosition()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            latLng = new LatLng(position.Latitude, position.Longitude);
        }

        public void OnLocationChanged(Location location)
        {
            var locator = CrossGeolocator.Current;
            locator.PositionChanged += (sender, e) => {
                var position = e.Position;


                marcaActual = new MarkerOptions();
               // GetCurrentPosition();
                marcaActual.SetPosition(new LatLng(position.Latitude, position.Longitude));
                marcaActual.SetTitle("My position");
                _googleMap.AddMarker(marcaActual);
                _googleMap.AnimateCamera(CameraUpdateFactory.ZoomTo(15));
            };
            throw new NotImplementedException();
        }


        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
    }
}

