using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android;
using System;

namespace FinalProject_StudentHelper
{
    [Obsolete]
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Fragment[] _fragmentsArray;
  //      string name = "Welcome To my App";



        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            Button nextFrag = FindViewById<Button>(Resource.Id.register);

            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);


            _fragmentsArray = new Fragment[]
            {
            new SignInFragment(""),
            new SignUpFragmentA(),
            };


            AddTabToActionBar("Sign In"); //First Tab
            AddTabToActionBar("Sign Up"); //First Tab


        }

        [Obsolete]
        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }



        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }



    }
}