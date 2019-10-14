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
	public partial class CorectiePioResult : ContentPage
	{
		public CorectiePioResult (int pio, int cct)
		{
			InitializeComponent ();

            pioLabel.Text += pio.ToString();
            cctLabel.Text += cct.ToString();

            int rezultat = (int)((double)pio + ((double)23.28 - (double)0.0423 * (double)cct));

            rezLabel.Text += rezultat.ToString();
		}

        private void CalculNou_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new CorectiePio());
        }
    }
}