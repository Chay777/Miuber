using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;

namespace MiUberAndroid
{  
    [Activity(Label = "MiUberAndroid", Theme = "@style/Theme.AppCompat.NoActionBar")]
  
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        DrawerLayout drawerLayout;
        Android.Support.Design.Widget.NavigationView navigationView;
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

            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

        }

        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
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

            MarkerOptions makerOptions = new MarkerOptions();
            makerOptions.SetPosition(new LatLng(16.03, 108));
            makerOptions.SetTitle("My position");
            googleMap.AddMarker(makerOptions);
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
        }
    }
}

