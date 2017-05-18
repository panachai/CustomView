using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomView {
	public class CustomViewSearchMenu : LinearLayout {
		//private TextView txtByName, txtByPrice;
		Context context;
		private TextView txtByName;
		private TextView txtByPrice;
		public EventHandler Search;
		public enum SearchBy {
			ProductId,
			ProductName,
			ProductPrice
		};

		//public SearchBy searchType = SearchBy.ProductId;

		public SearchBy searchType = SearchBy.ProductId; //enum

		public CustomViewSearchMenu(Context context) : base(context) {
			this.context = context;
			Initialize();
		}

		public CustomViewSearchMenu(Context context, IAttributeSet attrs) : base(context, attrs) {
			this.context = context;
			Initialize();
		}

		public CustomViewSearchMenu(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) {
			this.context = context;
			Initialize();
		}

		void Initialize() //create findview
		{
			LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
			View view = inflater.Inflate(Resource.Layout.CustomView_SearchMenu, this);


			txtByName = view.FindViewById<TextView>(Resource.Id.txtByName);
			txtByPrice = view.FindViewById<TextView>(Resource.Id.txtByPrice);

			SetEventOnClick();
			//SetCallbackForSearch();
		}

		void SetEventOnClick() {
			txtByName.Click += (sender, e) => {

				//do in CustomViewSearchEditext (callback)
				//edtStartPrice.Visibility = ViewStates.Gone;
				//edtEndPrice.Visibility = ViewStates.Gone;
				//edtSearch.Visibility = ViewStates.Invisible;

				searchType = SearchBy.ProductName;
				Search.Invoke(sender, e);
			};

			txtByPrice.Click += (sender, e) => {
				//edtStartPrice.Visibility = ViewStates.Invisible;
				//edtEndPrice.Visibility = ViewStates.Invisible;
				//edtSearch.Visibility = ViewStates.Gone;

				searchType = SearchBy.ProductPrice;

				Search.Invoke(sender, e);
			};
		}

		/*
		public void SetCallbackForSearch() {

			edtSearch.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

				Search.Invoke(sender, e);
			};
		}
*/
	}
}
