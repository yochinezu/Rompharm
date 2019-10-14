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
	public partial class ListviewCrt : ContentPage
	{
        string ghidName;
        string tipName;

        public ListviewCrt(string ghidNameAux, string tipNameAux)
        {
            InitializeComponent();

            ghidName = ghidNameAux;
            tipName = tipNameAux;
            Title = tipName;

            List<string> viz = new List<string>();
            List<SimpleText> v = new List<SimpleText>();

            for (int i = 0; i < DBConnection.ListaMedicamente.Count; i++)
            {
                if (DBConnection.ListaMedicamente[i].Ghid == ghidName && DBConnection.ListaMedicamente[i].Tip == tipName)
                {
                    bool gasit = false;
                    for (int j = 0; j < viz.Count; j++)
                    {
                        if (viz[j] == DBConnection.ListaMedicamente[i].Crt)
                        {
                            gasit = true;
                            break;
                        }
                    }

                    if (gasit == false)
                    {
                        viz.Add(DBConnection.ListaMedicamente[i].Crt);
                        v.Add(new SimpleText()
                        {
                            Titlu = DBConnection.ListaMedicamente[i].Crt
                        });
                    }
                }
            }

            CrtList.ItemsSource = v;
        }

        private void CrtList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = CrtList.SelectedItem as SimpleText;

            Navigation.PushAsync(new ListviewSubstanta(ghidName, tipName, Selected.Titlu));

            CrtList.SelectedItem = null;
        }
    }
}