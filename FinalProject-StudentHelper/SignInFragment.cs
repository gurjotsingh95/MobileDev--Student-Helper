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
                RadioButton loginToRB = myView.FindViewById<RadioButton>(loginTypeRG.CheckedRadioButtonId);
                var loginTo = "";
                if (loginToRB != null)
                {
                    Toast.MakeText(Context, "Please Choose you login Type", ToastLength.Short).Show();
                    loginTo = loginToRB.Text;
                    var eMailEntered = (myView.FindViewById<EditText>(Resource.Id.userNameID)).Text;
                    var passWordEntered = (myView.FindViewById<EditText>(Resource.Id.passwordID)).Text;
                    Boolean loginVerified = sqlfunctions.LoginValidation(eMailEntered, passWordEntered, loginTo);
                    Console.WriteLine("Below checkin login condition");
                    if (loginVerified && (loginTo == "Teacher"))
                    {
                        Console.WriteLine("After checking login condition");
                        Intent teacherProfile = new Intent(Context, typeof(teachProfile));
                        teacherProfile.PutExtra("userEmail", eMailEntered);
                        teacherProfile.PutExtra("password", passWordEntered);
                        teacherProfile.PutExtra("loginAs", loginTo);
                        StartActivity(teacherProfile);
                    }
                    else if (loginVerified && (loginTo == "Student"))
                    {
                        Intent studentProfile = new Intent(Context, typeof(studentProfile));
                        studentProfile.PutExtra("userEmail", eMailEntered);
                        studentProfile.PutExtra("password", passWordEntered);
                        studentProfile.PutExtra("loginAs", loginTo);
                        StartActivity(studentProfile);
                    }
                    else
                    {
                        Toast.MakeText(Context, "Incorrect Username/Password combination", ToastLength.Short).Show();
                    }
                }
            };

            return myView;
        }
    }
}