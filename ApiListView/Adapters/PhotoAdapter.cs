using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ApiListView.Model;
using ApiListView.ViewHolders;
using FFImageLoading;

namespace ApiListView.Adapters
{
    public class PhotoAdapter : RecyclerView.Adapter
    {
        private readonly List<Photo> photos;

        public PhotoAdapter(List<Photo> photos)
        {
            this.photos = photos;
        }

        public override int ItemCount => this.photos.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            var vh = holder as PhotoViewHolder;

            vh.TvTitle.Text = this.photos[position].Title;
            var urlUri = Android.Net.Uri.Parse(this.photos[position].Url);

            ImageService.Instance.LoadUrl(this.photos[position].Url).Into(vh.IvPhoto);        

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.layout_timeline_row, parent, false);

            var vh = new PhotoViewHolder(view);

            return vh;
        }
    }

}