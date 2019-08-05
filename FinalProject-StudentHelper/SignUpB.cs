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

namespace FinalProject_StudentHelper
{
    [Activity(Label = "SignUpB")]
    public class SignUpB : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Button addButton = new Button(this);
            addButton.Text = "LOLOLOL";
            
            addButton.SetWidth(100);
            addButton.SetHeight(100);
           
            LinearLayout buttonLayout = FindViewById<LinearLayout>(Resource.Id.buttonLayout);
            SetContentView(Resource.Layout.SignUpTabB);
            buttonLayout.AddView(addButton);
            // Create your application here
        }
    }
}