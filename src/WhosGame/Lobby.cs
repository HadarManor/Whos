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
        TextView PlayerTexts;
        Dialog d;
        //for the dialog
        EditText playerName;
        Button submitName;
        List<string> names = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_lobby);
            PlayerTexts = (TextView)FindViewById(Resource.Id.playerText);
            bool isCreator = Intent.GetBooleanExtra("isCreator", false);
            if (isCreator)
            {
                LinearLayout l2 = (LinearLayout)FindViewById(Resource.Id.linearl);
                Button createBtn = new Button(this);
                Button addPlayers = new Button(this);
                LinearLayout.LayoutParams lParams = new LinearLayout.LayoutParams(400, 100);
                //create button for the game 
                createBtn.LayoutParameters = lParams;
                createBtn.SetHeight(100);
                createBtn.SetWidth(100);
                createBtn.Text = "Create Game";
                l2.AddView(createBtn);
                //add players
                addPlayers.LayoutParameters = lParams;
                addPlayers.SetHeight(100);
                addPlayers.SetWidth(100);
                addPlayers.Text = "Add Players";
                l2.AddView(addPlayers);
                addPlayers.Click += AddPlayers_Click;
                createBtn.Click += CreateBtn_Click;
            }
            else
            {
                //joining game
                //for the multiplayer edition
            }
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Reveal));
            i.PutStringArrayListExtra("namesList", names);
            StartActivity(i);
        }

        private void AddPlayers_Click(object sender, EventArgs e)
        {
            AddUserDialog();
        }

        public void AddUserDialog()
        {
            d = new Dialog(this);
            d.SetContentView(Resource.Layout.add_player);
            d.SetCancelable(true);
            playerName = (EditText)d.FindViewById(Resource.Id.namePlayer);
            submitName = (Button)d.FindViewById(Resource.Id.clickName);
            d.Show();
            submitName.Click += SubmitName_Click;
        }

        private void SubmitName_Click(object sender, EventArgs e)
        {
            names.Add(playerName.Text);
            PlayerTexts.Text += playerName.Text+"\n";
            d.Dismiss();
        }
    }
}