using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomView {
	public class CustomViewSearchEdittext : RelativeLayout {
		//private EditText etSearch;
		Context context;

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

			//etSearch = view.FindViewById<EditText>(Resource.Id.et_search);

		}

	}
}
