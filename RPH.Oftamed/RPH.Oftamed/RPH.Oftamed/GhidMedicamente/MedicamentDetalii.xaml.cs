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
    public partial class MedicamentDetalii : ContentPage
    {
        public MedicamentDetalii(Medicament med)
        {
            InitializeComponent();

            Title = med.DenumireComerciala;

            SubstantaLabel.Text = med.Substanta;
            FormaFarmaceuticaLabel.Text = med.FormaFarmaceutica;
            DenumireComercialaLabel.Text = med.DenumireComerciala;

            try
            {
                CoplataPacientLabel.Text = Math.Round(Convert.ToDouble(med.CoplataPacient), 2).ToString();
            }
            catch
            {
                CoplataPacientLabel.Text = med.CoplataPacient;
            }

            try
            {
                PretFarmacieLabel.Text = Math.Round(Convert.ToDouble(med.PretFarmacie), 2).ToString();
            }
            catch
            {
                PretFarmacieLabel.Text = med.PretFarmacie;
            }

            CompanieProducatoareLabel.Text = med.CompanieProducatoare;

            if (CompanieProducatoareLabel.Text.ToLower() == "rompharm")
            {
                LogoRompharm.IsVisible = true;
            }

            ModDeActiuneLabel.Text = med.ModDeActiune;
            ReducereIopLabel.Text = med.ReducereIop;
            ContraIndicatiiLabel.Text = med.ContraIndicatii;
            EfecteAdverseLabel.Text = med.EfecteAdverse;
        }
    }
}