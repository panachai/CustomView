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
		private ListView customListViewProduct;
		private List<ProductModel> listProductModel;
		//private List<ProductModel> resultProductList;
		//private List<ProductModel> listProductModel; //move to customviewsearch

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			//*Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Init();

			AddDataProfile();
			AddDataProduct();

			//customViewSearch.SetEventForSearch(this);
			callbackSearch();


			//move to customviewsearch
			//AddDataProduct();

			//ProcessSpinner();
		}

		void Init() {
			//customprofile
			customViewProfile = FindViewById<CustomViewProfile>(Resource.Id.csProfile);


			//listview
			customListViewProduct = FindViewById<ListView>(Resource.Id.lvShow);

			//customview search
			customViewSearch = FindViewById<CustomViewSearch>(Resource.Id.csSearch);

			//callbackSearch
			//resultProductList = new List<ProductModel>();
		}

		void callbackSearch() {
			//wait callback from CustomViewsearch
			customViewSearch.StartSearch += (object sender, EventArgs e) => {
				//var type = customViewSearch.searchType;
				var type = customViewSearch.GetSearchType();

				if (type == CustomViewSearchMenu.SearchBy.ProductId) {

				} else if (type == CustomViewSearchMenu.SearchBy.ProductName) {

					List<ProductModel> resultProductList = new List<ProductModel>();

					if (!string.IsNullOrEmpty(customViewSearch.GetSearchValueByName().Text)) {

						string valueSearch = customViewSearch.GetSearchValueByName().Text;
						resultProductList = SearchByNameValue(valueSearch);

					} else {

					}
					CustomListViewProduct employeeProfileAdapter = new CustomListViewProduct(this, CheckEmptyValue(resultProductList)); //listProductModel
					customListViewProduct.Adapter = employeeProfileAdapter;

					//*controlHeight
					new ListViewAdapterUtil().GetTotalHeightofListView(customListViewProduct);

				} else if (type == CustomViewSearchMenu.SearchBy.ProductPrice) {
					//var price = customViewSearch.edtPrice;

					if (!string.IsNullOrEmpty(customViewSearch.GetSearchValueByPriceStart().Text)
						&& !string.IsNullOrEmpty(customViewSearch.GetSearchValueByPriceEnd().Text)) {

						int starPrice = int.Parse(customViewSearch.GetSearchValueByPriceStart().Text);
						int endPrice = int.Parse(customViewSearch.GetSearchValueByPriceEnd().Text);

						List<ProductModel> resultProductList = SearchByPriceValue(starPrice, endPrice);

						CustomListViewProduct employeeProfileAdapter = new CustomListViewProduct(this, CheckEmptyValue(resultProductList)); //listProductModel
						customListViewProduct.Adapter = employeeProfileAdapter;

						//*controlHeight
						new ListViewAdapterUtil().GetTotalHeightofListView(customListViewProduct);
					}


				}
				//DeleteNotfouneValue();
			};
		}

		void DeleteNotfouneValue() {//(l => l.ProductName.ToLower().Contains(value.ToLower())).ToList();
			ProductModel itemToRemove = listProductModel.SingleOrDefault(l => l.ProductId == 0000000000);

			if (itemToRemove != null) {
				listProductModel.Remove(itemToRemove);
			}

		}

		List<ProductModel> CheckEmptyValue(List<ProductModel> productValue) {
			if (productValue.Count == 0) {

				productValue.Add(new ProductModel {
					ProductId = 0000000000,
					ProductName = "Not Found",
					ProductPrice = 0,
					ProductAmount = 0,
					ProductPictureUrl = " "
				});

				return productValue;
			} else {
				return productValue;
			}
		}

		private List<ProductModel> SearchByNameValue(string value) { //Contains = like in sql
																	 //.ToLower() for search in lowercase
			List<ProductModel> productList = listProductModel.Where(l => l.ProductName.ToLower().Contains(value.ToLower())).ToList();

			return productList;
		}

		private List<ProductModel> SearchByPriceValue(int startValue, int endValue) {

			List<ProductModel> productList = listProductModel.Where(l => l.ProductPrice >= startValue && l.ProductPrice <= endValue).ToList();

			return productList;
		}


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

			listProductModel.Add(new ProductModel {
				ProductId = 0000000021,
				ProductName = "Nexus",
				ProductPrice = 110,
				ProductAmount = 91,
				ProductPictureUrl = "http://images.samsung.com/is/image/samsung/th-galaxy-s8-g955-sm-g955fzvdcam-frontgray-thumb-61707983?$PG_PRD_CARD_PNG2$"
			});

		}

	}
}

