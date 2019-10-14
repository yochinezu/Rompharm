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
    public partial class ListviewSubstanta : ContentPage
    {
        string ghidName;
        string tipName;
        string crtName;

        public ListviewSubstanta(string ghidNameAux, string tipNameAux, string crtNameAux)
        {
            InitializeComponent();

            ghidName = ghidNameAux;
            tipName = tipNameAux;
            crtName = crtNameAux;

            Title = crtName;

            List<string> viz = new List<string>();
            List<SimpleText> v = new List<SimpleText>();

            for (int i = 0; i < DBConnection.ListaMedicamente.Count; i++)
            {
                if (DBConnection.ListaMedicamente[i].Ghid == ghidName && DBConnection.ListaMedicamente[i].Tip == tipName && DBConnection.ListaMedicamente[i].Crt == crtName)
                {
                    bool gasit = false;
                    for (int j = 0; j < viz.Count; j++)
                    {
                        if (viz[j] == DBConnection.ListaMedicamente[i].Substanta)
                        {
                            gasit = true;
                            break;
                        }
                    }

                    if (gasit == false)
                    {
                        viz.Add(DBConnection.ListaMedicamente[i].Substanta);
                        v.Add(new SimpleText()
                        {
                            Titlu = DBConnection.ListaMedicamente[i].Substanta
                        });
                    }
                }
            }

            SubstantaList.ItemsSource = v;
        }

        private void SubstantaList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = SubstantaList.SelectedItem as SimpleText;

            Navigation.PushAsync(new ListviewMedicamente(ghidName, tipName, crtName, Selected.Titlu));

            SubstantaList.SelectedItem = null;
        }
    }
}