using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FinalProject_StudentHelper
{
    [Activity(Label = "studentProfile")]
    public class studentProfile : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProfileStudent);


            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            var studentEmail = Intent.GetStringExtra("userEmail");
            var studentPass = Intent.GetStringExtra("password");
            var profileType = Intent.GetStringExtra("loginAs");


            EditText nameET = FindViewById<EditText>(Resource.Id.Sname);
            EditText collET = FindViewById<EditText>(Resource.Id.Sschool);
            EditText emailET = FindViewById<EditText>(Resource.Id.SEmailID);
            EditText passET = FindViewById<EditText>(Resource.Id.SPasswordID);
            EditText ageET = FindViewById<EditText>(Resource.Id.SAgeID);
            EditText contactET = FindViewById<EditText>(Resource.Id.SContactID);
            EditText genderET = FindViewById<EditText>(Resource.Id.SGenderID);
            EditText fieldET = FindViewById<EditText>(Resource.Id.SFieldID);
            EditText yearET = FindViewById<EditText>(Resource.Id.SYearID);

            Button editButton = FindViewById<Button>(Resource.Id.SEdit);
            Button saveButton = FindViewById<Button>(Resource.Id.SSave);
            Button logOut = FindViewById<Button>(Resource.Id.logOut);

            DBHelper sqlFunctions = new DBHelper(this);
            ICursor details = sqlFunctions.getUserDetails(studentEmail, studentPass, profileType);

            while (details.MoveToNext())
            {
                Console.WriteLine(" Value  Of Name  FROM DB  --> " + details.GetString(details.GetColumnIndexOrThrow("Name")));

                nameET.Text = details.GetString(details.GetColumnIndexOrThrow("Name"));
                collET.Text = details.GetString(details.GetColumnIndexOrThrow("College"));
                emailET.Text = studentEmail;
                passET.Text = studentPass;
                ageET.Text = details.GetString(details.GetColumnIndexOrThrow("Age"));
                contactET.Text = details.GetString(details.GetColumnIndexOrThrow("Contact"));
                genderET.Text = details.GetString(details.GetColumnIndexOrThrow("gender"));
                fieldET.Text = details.GetString(details.GetColumnIndexOrThrow("Field"));
                yearET.Text = details.GetString(details.GetColumnIndexOrThrow("Year"));

            }
            editButton.Click += delegate
            {
                nameET.Enabled = true;
                collET.Enabled = true;
                passET.Enabled = true;
                ageET.Enabled = true;
                contactET.Enabled = true;
                genderET.Enabled = true;
                fieldET.Enabled = true;
                yearET.Enabled = true;
                editButton.Enabled = false;
                editButton.Visibility = ViewStates.Invisible;
                saveButton.Enabled = true;
                saveButton.Visibility = ViewStates.Visible;
            };
            saveButton.Click += delegate
            {
                nameET.Enabled = false;
                collET.Enabled = false;
                passET.Enabled = false;
                ageET.Enabled = false;
                contactET.Enabled = false;
                genderET.Enabled = false;
                fieldET.Enabled = false;
                yearET.Enabled = false;
                editButton.Enabled = true;
                editButton.Visibility = ViewStates.Visible;
                saveButton.Enabled = false;
                saveButton.Visibility = ViewStates.Invisible;
            };
            logOut.Click += delegate
            {
                Intent LogOut = new Intent(this, typeof(MainActivity));
                StartActivity(LogOut);
            };


        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            if ((e.Position) == 1)
            {
                Intent searchIntent = new Intent(this, typeof(SearchPage));

                StartActivity(searchIntent);
            } else if ((e.Position) == 2)
                {
                    Intent favIntent = new Intent(this, typeof(favouriteTeacher));
                    StartActivity(favIntent);
                }
            else
            {
                Toast.MakeText(this, "Page already open", ToastLength.Long).Show();

            }
        }
    }
}