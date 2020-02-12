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

namespace WhosGame
{
    [Activity(Label = "Lobby")]
    public class Lobby : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_lobby);
            bool isCreator = Intent.GetBooleanExtra("isCreator", false);
            if (isCreator)
            {
                Button createBtn = new Button(this);
                createBtn.SetHeight(100);
                createBtn.SetWidth(100);
                createBtn.Text = "Create Game";

            }
            else
            {
                //joining game
            }
            // Create your application here
        }
    }
}