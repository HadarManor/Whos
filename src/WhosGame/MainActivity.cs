using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
namespace WhosGame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button createBtn;
        Button joinBtn;
        Button shopBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            createBtn = (Button)FindViewById(Resource.Id.createBtn);
            joinBtn = (Button)FindViewById(Resource.Id.joinBtn);
            shopBtn = (Button)FindViewById(Resource.Id.shopBtn);
            createBtn.Click += CreateBtn_Click;
            joinBtn.Click += JoinBtn_Click;
            shopBtn.Click += ShopBtn_Click;
        }

        private void ShopBtn_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(Shop));
            StartActivity(i);
        }

        private void JoinBtn_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(Lobby));
            i.PutExtra("isCreator", false);
            StartActivity(i);
        }

        private void CreateBtn_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(Lobby));
            i.PutExtra("isCreator", true);
            StartActivity(i);
        }
    }
}