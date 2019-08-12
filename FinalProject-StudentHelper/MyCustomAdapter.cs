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
    public class MyCustomAdapter : BaseAdapter<UserObject>
    {
        List<UserObject> myUserList;
        Activity localContext;

        public MyCustomAdapter(Activity myContext, List<UserObject> myUsers) : base()
        {
            localContext = myContext;
            myUserList = myUsers;
        }


        public override UserObject this[int position]
        {
            get { return myUserList[position]; }
        }

        public override int Count
        {
            get { return myUserList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            UserObject myObject = myUserList[position];

            View myView = convertView; // re-use an existing view, if one is

            if (myView == null)
            {
                myView = localContext.LayoutInflater.Inflate(Resource.Layout.searchResultList, null);

                myView.FindViewById<TextView>(Resource.Id.searchName).Text = myObject.searchname;
                myView.FindViewById<TextView>(Resource.Id.SearchEmail).Text = myObject.searchEmail;
                myView.FindViewById<RatingBar>(Resource.Id.ratingbar).Rating = myObject.rating;

            }

            return myView;
        }
    }
}
