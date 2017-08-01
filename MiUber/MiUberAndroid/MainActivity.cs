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


            GetCurrentPosition();
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
         
            marcaActual = new MarkerOptions();
            GetCurrentPosition();
            marcaActual.SetPosition(latLng);
            marcaActual.SetTitle("My position");
            googleMap.AddMarker(marcaActual);
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            CameraUpdate center =
             CameraUpdateFactory.NewLatLng(latLng);
            CameraUpdate zoom = CameraUpdateFactory.ZoomIn();

            googleMap.MoveCamera(center);
            googleMap.AnimateCamera(zoom);
          
        
            googleMap.UiSettings.MyLocationButtonEnabled = true;
            googleMap.MyLocationEnabled = true;
            
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
                GetCurrentPosition();
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

