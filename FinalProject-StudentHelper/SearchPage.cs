using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database;
namespace FinalProject_StudentHelper
{
    [Activity(Label = "SearchPage")]
    public class SearchPage : Activity
    {
        ListView myList;
        SearchView mySearch;
        List<UserObject> myUserList = new List<UserObject>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            //spinner
           /* Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            */

    /*        Button favourite = FindViewById<Button>(Resource.Id.advancedSearch);
            favourite.Click += delegate
            {
                Intent fav = new Intent(this, typeof(favouriteTeacher));
                StartActivity(fav);
            };
            */
            DBHelper sqlFunctions = new DBHelper(this);
            ICursor details = sqlFunctions.searchResult("Name", "");

            // Set our view from the "main" layout resource
            while (details.MoveToNext())
            {             
                myUserList.Add(new UserObject(details.GetString(details.GetColumnIndexOrThrow("Name")), details.GetString(details.GetColumnIndexOrThrow("Email")), 3));
            }
            myList = FindViewById<ListView>(Resource.Id.listViewID);

            var myAdapter = new MyCustomAdapter(this, myUserList);
            myList.SetAdapter(myAdapter);
            myList.ItemClick += myItemClickMethod;


            Button favButton = FindViewById<Button>(Resource.Id.addToFav);
            mySearch = FindViewById<SearchView>(Resource.Id.searchID);
            //Search Events
            mySearch.QueryTextChange += mySearchMethod;
 //           favButton.Click += myItemClickMethod;
        }
        public void mySearchMethod(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            RadioGroup searchColumn = FindViewById<RadioGroup>(Resource.Id.searchTypeRG);
            RadioButton nameSearch = FindViewById<RadioButton>(Resource.Id.NameSearchID);
            nameSearch.Checked = true;
            var columnName = (FindViewById<RadioButton>(searchColumn.CheckedRadioButtonId)).Text;
            DBHelper sqlFunctions = new DBHelper(this);
            var mySearchValue = e.NewText;
            //call search func
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);
            ICursor newDetails = sqlFunctions.searchResult(columnName, mySearchValue);
            if(newDetails.Count != 0)
            {
                myUserList.Clear();

            }
            while (newDetails.MoveToNext())
            {
                myUserList.Add(new UserObject(newDetails.GetString(newDetails.GetColumnIndexOrThrow("Name")), newDetails.GetString(newDetails.GetColumnIndexOrThrow("Email")), 3));
            }

            myList = FindViewById<ListView>(Resource.Id.listViewID);

            var myAdapter = new MyCustomAdapter(this, myUserList);
            myList.SetAdapter(myAdapter);
            myList.ItemClick += myItemClickMethod;

            mySearch = FindViewById<SearchView>(Resource.Id.searchID);
            //Search Events
            mySearch.QueryTextChange += mySearchMethod;
        }
        public void myItemClickMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine("I am clicking on the list item \n\n");
            var indexValue = e.Position;
            var myValue = myUserList[indexValue].searchname;
            DBHelper sqlFunctions = new DBHelper(this);
            Console.WriteLine("The chosen teacher is ===== " + myValue);
            sqlFunctions.insertValueFav(myValue);
           // var myValue = movieArray[indexValue];
           // System.Console.WriteLine("Value is \n\n " + myValue);
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            if ((e.Position) == 0)
            {
                Intent profileIntent = new Intent(this, typeof(studentProfile));
                StartActivity(profileIntent);
            }
            else if ((e.Position) == 2)
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