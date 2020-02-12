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

namespace Whos
{
    [Activity(Label = "Lobby")]
    public class Lobby : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_lobby);
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}