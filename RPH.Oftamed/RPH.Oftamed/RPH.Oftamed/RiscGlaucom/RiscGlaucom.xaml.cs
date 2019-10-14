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
	public partial class RiscGlaucom : ContentPage
	{
		public RiscGlaucom ()
		{
			InitializeComponent ();
		}

        private void Calculeaza_Clicked(object sender, EventArgs e)
        {
            try
            {
                int age = Convert.ToInt32(ageEntry.Text);
                int iop = Convert.ToInt32(iopEntry.Text);
                double psd = Convert.ToDouble(psdEntry.Text);
                int cct = Convert.ToInt32(cctEntry.Text);
                double vcd = Convert.ToDouble(vcdEntry.Text);

                if(age < 40 || age > 90 || iop < 22 || iop > 32 || psd < 0.50 || psd > 4.0 || cct < 450 || cct > 700 || vcd < 0 || vcd > 0.9)
                {
                    errorLabel.Text = "Invalid input";
                }
                else
                {
                    Navigation.PopAsync();
                    Navigation.PushAsync(new RiscGlaucomResult(age, iop, psd, cct, vcd, dmEntry.SelectedItem.ToString()));
                }
            }
            catch
            {
                errorLabel.Text = "Invalid input";
            }
        }
    }
}