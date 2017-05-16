using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomView {
	public class CustomViewSearch : RelativeLayout {
		Context context;
		//private TextView txtColumn1, txtColumn2;


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

			//txtColumn1 = view.FindViewById<TextView>(Resource.Id.txtColumn1);
			//txtColumn2 = view.FindViewById<TextView>(Resource.Id.txtColumn2);

			//string.Format("{0}", checkin.DateCheckin.Day)
		}

	}
}
