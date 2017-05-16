using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomView {
	public class CustomViewSearch : RelativeLayout {
		Context context;
		private EditText edtSearch, edtStartPrice, edtEndPrice;

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

			edtSearch = view.FindViewById<EditText>(Resource.Id.et_search);
			edtStartPrice = view.FindViewById<EditText>(Resource.Id.et_StartPrice);
			edtEndPrice = view.FindViewById<EditText>(Resource.Id.et_EndPrice);

			SetEventForSearch();
		}

		void SetEventForSearch() {
			/*
			txtColumn1.Click += delegate {
			//onclick
			};

			*/

			edtSearch.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				CustomListViewProduct employeeProfileAdapter = new CustomListViewProduct(this, SearchValue(etSearch.Text)); //listProductModel
				listShow.Adapter = employeeProfileAdapter;

				//*controlHeight
				new ListViewAdapterUtil().GetTotalHeightofListView(listShow); //for non static
																			  //ListViewAdapterUtil.GetTotalHeightofListView(listShow); //for static class
			};
		}


	}
}
