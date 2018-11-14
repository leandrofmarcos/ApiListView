using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading.Views;

namespace ApiListView.ViewHolders
{
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public TextView TvTitle { get; set; }
        public ImageViewAsync IvPhoto { get; set; }

        public PhotoViewHolder(View view) : base(view)
        {
            TvTitle = view.FindViewById<TextView>(Resource.Id.tvTitle);
            IvPhoto = view.FindViewById<ImageViewAsync>(Resource.Id.ivPhoto);
        }
    }
}