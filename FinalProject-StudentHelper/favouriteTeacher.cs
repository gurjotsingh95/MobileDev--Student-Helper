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

            DBHelper sqlFunctions = new DBHelper(this);
            ICursor details = sqlFunctions.searchFavResult();
            
            myFavList.Add(new UserObject("WELL THIS", "Is it", 4));
            
            while (details.MoveToNext())
            {
                myFavList.Add(new UserObject(details.GetString(details.GetColumnIndexOrThrow("Name")), details.GetString(details.GetColumnIndexOrThrow("Email")), 3));
            }
            myList = FindViewById<ListView>(Resource.Id.favlistViewID);

            var myAdapter = new MyCustomAdapter(this, myFavList);
            myList.SetAdapter(myAdapter);
        //    myList.ItemClick += myItemClickMethod;

        }
    }
}