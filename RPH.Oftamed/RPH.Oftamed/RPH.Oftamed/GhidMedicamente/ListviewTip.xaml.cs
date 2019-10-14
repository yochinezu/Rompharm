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
	public partial class ListviewTip : ContentPage
	{
        string ghidName;

		public ListviewTip (String ghidNameAux)
		{
			InitializeComponent ();

            ghidName = ghidNameAux;
            Title = ghidName;

            List<string> viz = new List<string>();
            List<SimpleText> v = new List<SimpleText>();

            for (int i = 0; i < DBConnection.ListaMedicamente.Count; i++)
            {
                if (DBConnection.ListaMedicamente[i].Ghid == ghidName)
                {
                    bool gasit = false;
                    for (int j = 0; j < viz.Count; j++)
                    {
                        if (viz[j] == DBConnection.ListaMedicamente[i].Tip)
                        {
                            gasit = true;
                            break;
                        }
                    }

                    if (gasit == false)
                    {
                        viz.Add(DBConnection.ListaMedicamente[i].Tip);
                        v.Add(new SimpleText() {
                            Titlu = DBConnection.ListaMedicamente[i].Tip
                        });
                    }
                }
            }

            TipList.ItemsSource = v;
        }

        private void TipList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = TipList.SelectedItem as SimpleText;

            Navigation.PushAsync(new ListviewCrt(ghidName, Selected.Titlu));

            TipList.SelectedItem = null;
        }
    }
}