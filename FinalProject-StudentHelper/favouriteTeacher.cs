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
    [Activity(Label = "favouriteTeacher")]
    public class favouriteTeacher : Activity
    {
        ListView myList;

        List<UserObject> myFavList = new List<UserObject>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.favTeacher);
            //spinner
         /*   Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner2);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            */
            DBHelper sqlFunctions = new DBHelper(this);
            ICursor details = sqlFunctions.searchFavResult();
            
            myFavList.Add(new UserObject("Gurjot", "gurjot@gmail.com", 4));
            
            while (details.MoveToNext())
            {
                myFavList.Add(new UserObject(details.GetString(details.GetColumnIndexOrThrow("Name")), details.GetString(details.GetColumnIndexOrThrow("Email")), 3));
            }
            myList = FindViewById<ListView>(Resource.Id.favlistViewID);

            var myAdapter = new MyCustomAdapter(this, myFavList);
            myList.SetAdapter(myAdapter);
        //    myList.ItemClick += myItemClickMethod;
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            if ((e.Position) == 1)
            {
                Intent searchIntent = new Intent(this, typeof(SearchPage));
                StartActivity(searchIntent);
            }
            else if ((e.Position) == 0)
            {
                Intent profIntent = new Intent(this, typeof(studentProfile));
                StartActivity(profIntent);
            }
            else
            {
                Toast.MakeText(this, "Page already open", ToastLength.Long).Show();

            }
        }
    }
}