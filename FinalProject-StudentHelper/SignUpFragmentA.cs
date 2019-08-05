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
    [Obsolete]
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
                Intent signUpB = new Intent(Context, typeof(SignUpB));
                 StartActivity(signUpB);

            };
           
            return myView;
         }

    }
}