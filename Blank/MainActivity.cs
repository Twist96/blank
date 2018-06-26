using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Preferences;
using Android.Support.Design.Widget;
using System;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Java.Interop;

namespace Blank
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           SetContentView(Resource.Layout.activity_main);

            ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            string email = sharedPreferences.GetString("email", null);
            
            if(email == null || email == "null")
            {
                Intent intent = new Intent(this, typeof(Login));
                StartActivity(intent);
            }

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            // create button to add tool bar

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_open);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += OnNavigaationItemSelected;
        }

        private void OnNavigaationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            e.MenuItem.SetChecked(true);
            drawerLayout.CloseDrawers();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            try
            {
                navigationView.InflateMenu(Resource.Menu.nav_menu);
            }catch (InflateException e)
            {

            }
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Type typeID = item.GetType();
            int id = item.ItemId;

            switch(id){
                case Resource.Id.nav_home:
                    FragmentManager.BeginTransaction().Replace(Resource.Id.trans, new Resources.layout.Home()).Commit();
                    break;
                case Resource.Id.nav_location:
                    FragmentManager.BeginTransaction().Replace(Resource.Id.trans, new Resources.layout.Home()).Commit();
                    break;
                case Resource.Id.nav_preference:
                    FragmentManager.BeginTransaction().Replace(Resource.Id.trans, new Resources.layout.Home()).Commit();
                    break;
                case Resource.Id.nav_history:
                    FragmentManager.BeginTransaction().Replace(Resource.Id.trans, new Resources.layout.Home()).Commit();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

    }

    

}

