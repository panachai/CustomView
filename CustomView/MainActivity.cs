using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomView {


	[Activity(Label = "CustomView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity {
		public CustomViewProfile customViewProfile;
		public CustomViewSearch customViewSearch;
		private ProfileModel profileModel;
		private List<ProductModel> listProductModel;
		ListView listShow;


		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			//*Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Init();

			AddDataProfile();
			AddDataProduct();

			//ProcessSpinner();
		}

		void Init() {
			//customprofile
			customViewProfile = FindViewById<CustomViewProfile>(Resource.Id.csProfile);
			//main
			//etSearch = FindViewById<EditText>(Resource.Id.et_search);
			listShow = FindViewById<ListView>(Resource.Id.lvShow);
			//customview search
			customViewSearch = FindViewById<CustomViewSearch>(Resource.Id.csSearch);
			//txtColumn1 = FindViewById<TextView>(Resource.Id.txtColumn1)
		}

		private List<ProductModel> SearchValue(string value) { //Contains = like in sql
															   //.ToLower() for search in lowercase
			List<ProductModel> productList = listProductModel.Where(l => l.ProductName.ToLower().Contains(value.ToLower())).ToList();

			return productList; //wait to do
		}



		/*
		void ProcessSpinner() {

			Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerSearch);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource(
					this, Resource.Array.search_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;
		}

		private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) { //callback spinner
			Spinner spinner = (Spinner)sender;

			string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
			Toast.MakeText(this, toast, ToastLength.Long).Show();
		}		*/

		/*
				//[Example]
				void TestLinQ() {
					var productList = listProductModel.Where(l => l.ProductName.Contains("Galaxy S80+")).ToList();

					var productModel = listProductModel.SingleOrDefault(l => l.ProductName.Contains("Galaxy S80+"));
					//var productName = listProductModel.Single(l => l.ProductName.Contains("Galaxy S80+")).ProductName;
					var productName = listProductModel.First(l => l.ProductName.Contains("Galaxy S80+"));
					var count = listProductModel.Where(l => l.ProductId.Equals("0000000019")).Count();


								//foreach (var item in listProductModel) {
							//		var product = item.ProductName.Contains("Galaxy S80+");
							//		if (product != null) {

							//		} else {

							//		}
							//	}


				}
		*/

		private void AddDataProfile() {
			profileModel = new ProfileModel();
			//Data dummy

			profileModel.TxtCenter1 = "Title_by_List";
			profileModel.TxtCenter2 = "Email_by_List";
			profileModel.TxtCenter3 = "Tel_by_List";
			profileModel.ImvCover = "http://beingcovers.com/media/facebook-cover/Cat-Paws-facebook-covers-2649.jpeg";
			profileModel.ImvDisplay = "http://i50.photobucket.com/albums/f350/pervyicons/100x100/Animals/icon_cat4.png";

			customViewProfile.SetData(profileModel);
		}

		private void AddDataProduct() {
			listProductModel = new List<ProductModel>();

			listProductModel.Add(new ProductModel {
				ProductId = 0000000001,
				ProductName = "Galaxy S8",
				ProductPrice = 28000,
				ProductAmount = 10,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g950-sm-g950fzvdcam-frontgray-thumb-61707961?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000002,
				ProductName = "Galaxy S8+",
				ProductPrice = 34000,
				ProductAmount = 9,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000003,
				ProductName = "Galaxy S7",
				ProductPrice = 15000,
				ProductAmount = 10,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s7-g930fd-sm-g930fzduthl-001-front-gold-thumb-1?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000004,
				ProductName = "Galaxy S7 Edge",
				ProductPrice = 18000,
				ProductAmount = 10,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s7-edge-g935fd-sm-g935fzbuthl-lightblue-thumb-63582220?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000005,
				ProductName = "Galaxy S6Edge+",
				ProductPrice = 14000,
				ProductAmount = 90,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s6-edge-plus-g928c-sm-g928czdathl-005-sidel-gold-thumb?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000006,
				ProductName = "Galaxy S5+",
				ProductPrice = 34000,
				ProductAmount = 9,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000007,
				ProductName = "Galaxy S9",
				ProductPrice = 2800,
				ProductAmount = 10,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g950-sm-g950fzvdcam-frontgray-thumb-61707961?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000008,
				ProductName = "Galaxy S10",
				ProductPrice = 27900,
				ProductAmount = 10,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g950-sm-g950fzvdcam-frontgray-thumb-61707961?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000009,
				ProductName = "Galaxy S11",
				ProductPrice = 28600,
				ProductAmount = 960,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g950-sm-g950fzvdcam-frontgray-thumb-61707961?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000010,
				ProductName = "Galaxy S12",
				ProductPrice = 21100,
				ProductAmount = 19,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g950-sm-g950fzvdcam-frontgray-thumb-61707961?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000011,
				ProductName = "Galaxy S12+",
				ProductPrice = 340000,
				ProductAmount = 9,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000012,
				ProductName = "Galaxy S80+",
				ProductPrice = 34090,
				ProductAmount = 12,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000013,
				ProductName = "Galaxy S18",
				ProductPrice = 39000,
				ProductAmount = 15,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000014,
				ProductName = "Galaxy J1",
				ProductPrice = 34010,
				ProductAmount = 9,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000015,
				ProductName = "Galaxy J2",
				ProductPrice = 30010,
				ProductAmount = 12,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000016,
				ProductName = "Galaxy J3",
				ProductPrice = 1500,
				ProductAmount = 99,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000017,
				ProductName = "Galaxy J4",
				ProductPrice = 94010,
				ProductAmount = 99,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

			listProductModel.Add(new ProductModel {
				ProductId = 0000000018,
				ProductName = "Galaxy J5",
				ProductPrice = 9010,
				ProductAmount = 99,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});


			listProductModel.Add(new ProductModel {
				ProductId = 0000000019,
				ProductName = "Galaxy J6",
				ProductPrice = 3010,
				ProductAmount = 79,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});


			listProductModel.Add(new ProductModel {
				ProductId = 0000000020,
				ProductName = "Galaxy J6+",
				ProductPrice = 110,
				ProductAmount = 91,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});



		}


	}
}

