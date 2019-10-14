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
	public partial class RiscGlaucomResult : ContentPage
	{
		public RiscGlaucomResult(int age, int iop, double psd, int cct, double vcd, string dmText)
		{
			InitializeComponent ();

            ageLabel.Text += age.ToString();
            iopLabel.Text += iop.ToString();
            psdLabel.Text += psd.ToString();
            cctLabel.Text += cct.ToString();
            vcdLabel.Text += vcd.ToString();
            dmLabel.Text += dmText;


            int dm = 0;
            if(dmText == "Yes")
            {
                dm = 1;
            }

            var risk = 1 - Math.Pow(0.906, Math.Exp(
                      ((Math.Log(1.25) / 10) * (age - 55.4)) +
                      (Math.Log(1.11) * (iop - 24.9)) +
                      ((Math.Log(1.25) / 0.2) * (psd - 1.90)) -
                      ((Math.Log(1.82) / 40) * (cct - 574.5)) +
                      ((Math.Log(1.32) / 0.1) * (vcd - 0.39)) +
                      (Math.Log(0.35) * (dm - 0.121))));

            rezLabel.Text +=  (Math.Round(risk * 1000) / 10).ToString();
            rezLabel.Text += "% in 5 ani";
        }

        private void CalculNou_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new RiscGlaucom());
        }
    }
}