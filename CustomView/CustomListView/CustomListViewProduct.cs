using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CustomView {
	public class CustomListViewProduct : BaseAdapter {

		Activity activity;
		List<ProductModel> productList;

		public CustomListViewProduct(Activity activity, List<ProductModel> productList) {
			this.activity = activity;
			this.productList = productList;
		}



		public override int Count {
			get {
				return productList.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position) {
			return position;
		}

		public override long GetItemId(int position) {
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent) {

			View view = convertView;
			ViewHolder viewHolder;

			return view;
		}
		private class ViewHolder : Java.Lang.Object {
			public ImageView imvShow;
			public TextView txtTitle;
			public TextView txtDes
				}
	}
}
