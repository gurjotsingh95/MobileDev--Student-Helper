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

                EditText user = myView.FindViewById<EditText>(Resource.Id.userName2);
                EditText passWord = myView.FindViewById<EditText>(Resource.Id.pwdID);
                EditText eMail = myView.FindViewById<EditText>(Resource.Id.emailID);
                EditText age = myView.FindViewById<EditText>(Resource.Id.ageID);
                EditText gender = myView.FindViewById<EditText>(Resource.Id.genderID);
                EditText contact = myView.FindViewById<EditText>(Resource.Id.contactID);

                RadioGroup registerTypeRG = myView.FindViewById<RadioGroup>(Resource.Id.studentTeacherRadioId);
                RadioButton registerTypeRB = myView.FindViewById<RadioButton>(registerTypeRG.CheckedRadioButtonId);
                var registerTypeChoice = "No";
                if ((registerTypeRB.Text) == "Regiister as Teacher")
                {
                    registerTypeChoice = "Yes";
                }

                string userNameText = user.Text;
                var passWordText = passWord.Text;
                var eMailText = eMail.Text;
                var ageText = age.Text;
                var genderText = gender.Text;
                var contactText = contact.Text;

                Intent signUpB = new Intent(Context, typeof(SignUpB));
                signUpB.PutExtra("userName", userNameText);
                signUpB.PutExtra("passWord", passWordText);
                signUpB.PutExtra("eMail", eMailText);
                signUpB.PutExtra("age", ageText);
                signUpB.PutExtra("gender", genderText);
                signUpB.PutExtra("contact", contactText);
                signUpB.PutExtra("registerType", registerTypeChoice);
                StartActivity(signUpB);

            };
           
            return myView;
         }

    }
}