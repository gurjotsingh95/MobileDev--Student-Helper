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
    public class UserObject
    {
            public String searchname;
            public String searchEmail;
            public int rating;

            public UserObject(String myName, String searchEmail1, int rating1)
            {
                searchname = myName;
                searchEmail = searchEmail1;
                rating=rating1;
            }
    }
}