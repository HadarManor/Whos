using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace WhosGame
{
    [Activity(Label = "Reveal")]
    public class Reveal : Activity
    {
        TextView textRev;
        List<string> names;
        List<string> bad;
        List<string> good;
        LinearLayout l2;
        Button revBtn;
        Button retBtn;
        string currPlayer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Random rand = new Random();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_reveal);
            textRev = (TextView)FindViewById(Resource.Id.currTXT);
            //min 5 ?
            names = Intent.GetStringArrayListExtra("namesList").ToList();
            bad = new List<string>();
            good = new List<string>();
            int[] beenArr = new int[2];
            int sizeList = names.Count;
            //randomize 2 bad guys and other good guys
            if(sizeList > 4 && sizeList < 8)
            {
                var n = rand.Next(0, sizeList);
                for(int i = 0; i < 2; i++)
                {
                    beenArr[i] = n;
                    bad.Append(names[n]); 
                }
                for(int i = 0; i < sizeList; i++) 
                {
                    if (!beenArr.Contains(i))
                    {
                        good.Append(names[i]);
                    }
                }
            }
            startRevealing();
         
        }
        public void startRevealing()
        {
            l2 = (LinearLayout)FindViewById(Resource.Id.layoutrev1);
            revBtn = new Button(this);
            LinearLayout.LayoutParams lParams = new LinearLayout.LayoutParams(400, 100);
            //create button for the game 
            revBtn.LayoutParameters = lParams;
            revBtn.SetHeight(100);
            revBtn.SetWidth(100);
            revBtn.Text = "Reveal Yourself";
            l2.AddView(revBtn);
            foreach (var player in names)
            {
                currPlayer = player;
                textRev.Text = "Player: " + player + "Your turn to see what you got!";
                revBtn.LongClick += RevBtn_LongClickAsync;
            }
        }

        private async void RevBtn_LongClickAsync(object sender, View.LongClickEventArgs e)
        {
            l2.RemoveView(revBtn);
            l2 = (LinearLayout)FindViewById(Resource.Id.layoutrev1);
            retBtn = new Button(this);
            LinearLayout.LayoutParams lParams = new LinearLayout.LayoutParams(400, 100);
            //create button for the game 
            retBtn.LayoutParameters = lParams;
            retBtn.SetHeight(100);
            retBtn.SetWidth(100);
            retBtn.Text = "Next Player";
            l2.AddView(retBtn);
            if (bad.Contains(currPlayer))
            {
                textRev.Text = "Player: " + currPlayer + "You are BAD guy";
            }
            else
            {
                textRev.Text = "Player: " + currPlayer + "You are good guy";
            }
            await Button_Clicked();
        }
        private async Task Button_Clicked()
        {
            retBtn.LongClick += RetBtn_LongClick;
        }
        private void RetBtn_LongClick(object sender, View.LongClickEventArgs e)
        {
            return;
        }
    }
}