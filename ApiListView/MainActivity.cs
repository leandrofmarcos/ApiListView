using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ApiListView.Adapters;
using ApiListView.Service;

namespace ApiListView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        RecyclerView rvPhoto;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAdapter photoAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            FindByElements();
            RecuperaDados();

        }

        private void RecuperaDados()
        {

                var apiService = new ApiService();

                var photos = apiService.GetPhotoMock();

                //var photos = apiService.GetPhotoApi(10);

                photoAdapter = new PhotoAdapter(photos);
                rvPhoto.SetAdapter(photoAdapter);

        }

        private void FindByElements()
        {
            rvPhoto = FindViewById<RecyclerView>(Resource.Id.rvPhoto);
            mLayoutManager = new LinearLayoutManager(this);
            rvPhoto.SetLayoutManager(mLayoutManager);
        }
    }
}

