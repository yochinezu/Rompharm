using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RPH.Oftamed
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void GhidMedicamente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GhidMedicamente());
        }

        private void CorectiePio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CorectiePio());
        }

        private void RiscGlaucom_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RiscGlaucom());
        }

        private void ToU_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermsOfUse());
        }
    }
}
