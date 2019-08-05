using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FinalProject_StudentHelper
{
       public class SignUpFragmentA : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.SignUpTabA, container, false);
            Button nextFrag = myView.FindViewById<Button>(Resource.Id.register);
            nextFrag.Click += delegate
            {
        //        Android.App.ActionBar.TabEventArgs tabEventArgs;
       //         Fragment frag = new SignUpFragmentB();
         //       _ = tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
           //     View mV = inflater.Inflate(Resource.Layout.SignUpTabB, container, false);
                
            };
           
            return myView;
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

    }
}
/*
        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
 * */
