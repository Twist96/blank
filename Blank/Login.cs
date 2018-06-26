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
using Java.Interop;

namespace Blank
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        TextView emailText, passwordText;
        EditText email, password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
            SetContentView(Resource.Layout.login);

            // Create your application here
            email = FindViewById<EditText>(Resource.Id.email);
            emailText = FindViewById<TextView>(Resource.Id.emailText);
            password = FindViewById<EditText>(Resource.Id.password);
            passwordText = FindViewById<TextView>(Resource.Id.passwordText);

            //email.FocusChange += (object sender, View.FocusChangeEventArgs e){

            //}


        }

        public void SetLogin(View view)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("name", "martins");
            StartActivity(intent);
        }

        [Export("emailClicked")]
        public void emailClicked(View view)
        {
            emailText.Visibility = ViewStates.Visible;
            passwordText.Visibility = ViewStates.Gone;
        }

        [Export("passwordClicked")]
        public void passwordClicked(View view)
        {
            emailText.Visibility = ViewStates.Gone;
            passwordText.Visibility = ViewStates.Visible;
        }

        [Export("loginClicked")]
        public void loginClicked(View view)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}