using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPH.Oftamed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GhidMedicamente : ContentPage
	{
		public GhidMedicamente ()
		{
			InitializeComponent ();

            GhidList.ItemsSource = DBConnection.GetGhidName();
        }

        private void GhidList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = GhidList.SelectedItem as GhidHardCode;

            Navigation.PushAsync(new ListviewTip(Selected.Ghid));

            GhidList.SelectedItem = null;
        }
    }
}