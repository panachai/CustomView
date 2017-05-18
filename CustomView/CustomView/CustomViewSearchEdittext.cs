using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomView {
	public class CustomViewSearchEdittext : RelativeLayout {
		//private EditText etSearch;
		Context context;
		public EditText edtSearch { get; set; }
		public EditText edtStartPrice { get; set; }
		public EditText edtEndPrice { get; set; }
		public EventHandler StartSearch;

		public CustomViewSearchEdittext(Context context) : base(context) {
			this.context = context;
			Initialize();
		}

		public CustomViewSearchEdittext(Context context, IAttributeSet attrs) : base(context, attrs) {
			this.context = context;
			Initialize();
		}

		public CustomViewSearchEdittext(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) {
			this.context = context;
			Initialize();
		}

		void Initialize() //create findview
		{
			LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
			View view = inflater.Inflate(Resource.Layout.CustomView_SearchEdittext, this);

			edtSearch = view.FindViewById<EditText>(Resource.Id.edt_search);
			edtStartPrice = view.FindViewById<EditText>(Resource.Id.et_StartPrice);
			edtEndPrice = view.FindViewById<EditText>(Resource.Id.et_EndPrice);

			edtSearch.Visibility = ViewStates.Gone;
			edtStartPrice.Visibility = ViewStates.Gone;
			edtEndPrice.Visibility = ViewStates.Gone;


			//etSearch = view.FindViewById<EditText>(Resource.Id.et_search);
			SetSearchFunction();
		}

		void SetSearchFunction() {

			edtSearch.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

				StartSearch.Invoke(sender, e); ;
			};

			edtStartPrice.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

				StartSearch.Invoke(sender, e);
			};

			edtEndPrice.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

				StartSearch.Invoke(sender, e);
			};
		}


		public void VisibleEditeText(CustomViewSearchMenu.SearchBy searchType) {
			if (searchType == CustomViewSearchMenu.SearchBy.ProductId) {

			} else if (searchType == CustomViewSearchMenu.SearchBy.ProductName) {
				edtSearch.Visibility = ViewStates.Visible;
				edtStartPrice.Visibility = ViewStates.Gone;
				edtEndPrice.Visibility = ViewStates.Gone;

			} else if (searchType == CustomViewSearchMenu.SearchBy.ProductPrice) {
				edtSearch.Visibility = ViewStates.Gone;
				edtStartPrice.Visibility = ViewStates.Visible;
				edtEndPrice.Visibility = ViewStates.Visible;

			}
		}

	}
}
