using System;
using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace CustomView {
	public class CustomProfile : RelativeLayout {
		Context context;
		private TextView TxtCenter1;
		private TextView TxtCenter2 { get; set; }
		private TextView TxtCenter3 { get; set; }
		private ImageView ImvCover { get; set; }
		private ImageView ImvDisplay { get; set; }

		public CustomProfile(Context context) :
					base(context) {
			this.context = context;
			Initialize();
		}

		public CustomProfile(Context context, IAttributeSet attrs) :
					base(context, attrs) {
			this.context = context;
			Initialize();
		}

		public CustomProfile(Context context, IAttributeSet attrs, int defStyle) :
					base(context, attrs, defStyle) {
			this.context = context;
			Initialize();
		}

		void Initialize() //create findview
		{
			LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
			View view = inflater.Inflate(Resource.Layout.CustomView_Profile, this);

			TxtCenter1 = view.FindViewById<TextView>(Resource.Id.txtCenter1);
			TxtCenter2 = view.FindViewById<TextView>(Resource.Id.txtCenter2);
			TxtCenter3 = view.FindViewById<TextView>(Resource.Id.txtCenter3);
			ImvCover = view.FindViewById<ImageView>(Resource.Id.imvCover);
			ImvDisplay = view.FindViewById<ImageView>(Resource.Id.imvDisplay);
			//string.Format("{0}", checkin.DateCheckin.Day);
		}

		public void SetData(ProfileModel profileModel) {
			/*
			 * not use
						TxtCenter1.Text = "TitlePassSetValue";
						TxtCenter2.Text = "EmailPassSetValue";
						TxtCenter3.Text = "TelPassSetValue";
			*/
			//position Overwrite 0

			TxtCenter1.Text = profileModel.TxtCenter1;
			TxtCenter2.Text = profileModel.TxtCenter2;
			TxtCenter3.Text = profileModel.TxtCenter3;

			Picasso.With(context)
				   	.Load(profileModel.ImvCover)
	   				.Into(ImvCover);

			Picasso.With(context)
					   .Load(profileModel.ImvDisplay)
					.Into(ImvDisplay);

			/*
			 * wait to do
						ImvCover
						ImvDisplay
			*/
		}

	}
}