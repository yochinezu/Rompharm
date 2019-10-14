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
	public partial class CorectiePio : ContentPage
	{
		public CorectiePio ()
		{
			InitializeComponent ();
		}

        private void Calculeaza_Clicked(object sender, EventArgs e)
        {
            try
            {
                int pio = Convert.ToInt32(pioEntry.Text);
                int cct = Convert.ToInt32(cctEntry.Text);

                Navigation.PopAsync();
                Navigation.PushAsync(new CorectiePioResult(pio, cct));
            } catch
            {
                errorLabel.Text = "Invalid input";
                pioEntry.Text = string.Empty;
                cctEntry.Text = string.Empty;
            }
        }
    }
}