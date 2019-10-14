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
	public partial class ListviewMedicamente : ContentPage
	{
        public ListviewMedicamente(string ghidName, string tipName, string crtName, string substantaName)
        {
            InitializeComponent();
            Title = substantaName;

            List<Medicament> v = new List<Medicament>();

            for (int i = 0; i < DBConnection.ListaMedicamente.Count; i++)
            {
                if (DBConnection.ListaMedicamente[i].Ghid == ghidName && DBConnection.ListaMedicamente[i].Tip == tipName && DBConnection.ListaMedicamente[i].Crt == crtName && DBConnection.ListaMedicamente[i].Substanta == substantaName)
                {
                    v.Add(DBConnection.ListaMedicamente[i]);
                    v[v.Count - 1].FontBold = FontAttributes.None;

                    if (DBConnection.ListaMedicamente[i].CompanieProducatoare.ToLower() == "rompharm")
                    {
                        v[v.Count - 1].ImgSourceCompany = "http://corectie-pio.ro/icon.png";
                        v[v.Count - 1].FontBold = FontAttributes.Bold;
                    }
                }
            }

            MedList.ItemsSource = v;
        }

        private void MedList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = MedList.SelectedItem as Medicament;

            Navigation.PushAsync(new MedicamentDetalii(Selected));

            MedList.SelectedItem = null;
        }
    }
}