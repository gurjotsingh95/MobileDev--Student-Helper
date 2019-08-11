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
    

    public class SignInFragment : Fragment
    {
/*      public String myName;
        public SignInFragment(string name)
        {
            myName = name;
        }*/
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            DBHelper sqlfunctions = new DBHelper(Context);

            View myView = inflater.Inflate(Resource.Layout.SignIn, container, false);
            //          myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;
            Button login = myView.FindViewById<Button>(Resource.Id.loginBtnID);
            login.Click += delegate
            {
                RadioGroup loginTypeRG = myView.FindViewById<RadioGroup>(Resource.Id.loginType);
                //table 
                var loginTo = myView.FindViewById<RadioButton>(loginTypeRG.CheckedRadioButtonId).Text;
                var eMailEntered = (myView.FindViewById<EditText>(Resource.Id.userNameID)).Text;
                var passWordEntered = (myView.FindViewById<EditText>(Resource.Id.passwordID)).Text;
                Boolean loginVerified = sqlfunctions.LoginValidation(eMailEntered, passWordEntered, loginTo);
                if(loginVerified)
                {
                    Intent teacherProfile = new Intent();
                }
                else
                {
                    Intent studentProfile = new Intent();
                }
            };

            return myView;
        }
    }
}