using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomView {
	public class CustomViewSearchMenu : LinearLayout {
		private TextView txtByName, txtByPrice;
		Context context;

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

		}

	}
}
