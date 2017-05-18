using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace CustomView {
	public class CustomViewSearch : RelativeLayout {
		private Context context;
		CustomViewSearchMenu customViewSearchMenu;
		CustomViewSearchEdittext customViewSearchEdittext;
		public EventHandler Searchtype;

		//private TextView txtByName;
		//private TextView txtByPrice;

		public CustomViewSearch(Context context) : base(context) {
			this.context = context;
			Initialize();
		}

		public CustomViewSearch(Context context, IAttributeSet attrs) : base(context, attrs) {
			this.context = context;
			Initialize();
		}

		public CustomViewSearch(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) {
			this.context = context;
			Initialize();
		}

		void Initialize() //create findview
		{
			LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
			View view = inflater.Inflate(Resource.Layout.CustomView_Search, this);
			customViewSearchMenu = FindViewById<CustomViewSearchMenu>(Resource.Id.csvSearchMenu);
			customViewSearchEdittext = FindViewById<CustomViewSearchEdittext>(Resource.Id.csvSearchEdittext);
		}
		//send to MainActivity
		void setCallbackFromCustomViewSearchMenu() {
			customViewSearchMenu.Search += (object sender, EventArgs e) => {

				Searchtype.Invoke(sender, e);
			};

		}

		public CustomViewSearchMenu.SearchBy GetSearchType() {

			return customViewSearchMenu.searchType;
		}
		public EditText GetSearchValueByName() {

			return customViewSearchEdittext.edtSearch;
		}
		public EditText GetSearchValueByPriceStart() {

			return customViewSearchEdittext.edtStartPrice;
		}
		public EditText GetSearchValueByPriceEnd() {

			return customViewSearchEdittext.edtEndPrice;
		}

	}
}
