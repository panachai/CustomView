using System;
using Android.Views;
using Android.Widget;

namespace CustomView {
	public class ListViewAdapterUtil {

		public void GetTotalHeightofListView(ListView listView) {
			IListAdapter listAdapter = listView.Adapter;
			int totalHeight = 0;

			for (int i = 0; i < listAdapter.Count; i++) {
				View mView = listAdapter.GetView(i, null, listView);

				mView.Measure(0, 0);
				totalHeight += mView.MeasuredHeight;
			}

			int test = totalHeight + (listView.DividerHeight * (listAdapter.Count - 1));
			listView.LayoutParameters.Height = test;
		}
	}
}
