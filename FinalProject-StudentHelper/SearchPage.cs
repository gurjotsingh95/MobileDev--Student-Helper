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
            // Set our view from the "main" layout resource
            myUserList.Add(new UserObject("TEST NAME", "Test EMAIL", 3));

            SetContentView(Resource.Layout.Search);

            myList = FindViewById<ListView>(Resource.Id.listViewID);

            var myAdapter = new MyCustomAdapter(this, myUserList);
            myList.SetAdapter(myAdapter);
            myList.ItemClick += myItemClickMethod;

            mySearch = FindViewById<SearchView>(Resource.Id.searchID);
            //Search Events
            mySearch.QueryTextChange += mySearchMethod;
        }
        public void mySearchMethod(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            RadioGroup searchColumn = FindViewById<RadioGroup>(Resource.Id.searchTypeRG);
            var columnName = FindViewById<RadioButton>(searchColumn.Id).Text;
            DBHelper sqlFunctions = new DBHelper(this);
            var mySearchValue = e.NewText;
            //call search func
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);
            sqlFunctions.searchResult(columnName, mySearchValue);
        }
        public void myItemClickMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine("I am clicking on the list item \n\n");
            var indexValue = e.Position;
           // var myValue = movieArray[indexValue];
           // System.Console.WriteLine("Value is \n\n " + myValue);
        }
    }
}