using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MolkkyPistelaskuSovellus
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, int> pisteet = new Dictionary<string, int>();
        List<string> pelaajat = new List<string>();
        int vuoro = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnSyotaPelaajatButtonClicked(object sender, EventArgs args)
        {
            string[] syotetytPelaajat = pelaajatEntry.Text.Split(',');

            foreach (string pelaaja in syotetytPelaajat)
            {
                pelaajat.Add(pelaaja.Trim());
                pisteet[pelaaja.Trim()] = 0;
            }

            pelaajatEntry.IsVisible = false;
            syotaPelaajatButton.IsVisible = false;
            kaadetutKeilatEntry.IsVisible = true;
            heitaButton.IsVisible = true;

            vuoroLabel.Text = $"Vuorossa: {pelaajat[vuoro]}";
            NaytaKaikkiPisteet();
        }

        void OnHeitaButtonClicked(object sender, EventArgs args)
        {
            int kaadetutKeilat = int.Parse(kaadetutKeilatEntry.Text);

            if (kaadetutKeilat < 0 || kaadetutKeilat > 12)
            {
                DisplayAlert("Virhe", "Voit syöttää vain 0-12 välillä olevia pisteitä.", "OK");
                return;
            }

            pisteet[pelaajat[vuoro]] += kaadetutKeilat;

            if (pisteet[pelaajat[vuoro]] > 50)
            {
                pisteet[pelaajat[vuoro]] = 25;
            }

            if (pisteet[pelaajat[vuoro]] == 50)
            {
                DisplayAlert("Onnittelut!", $"{pelaajat[vuoro]} on voittanut!", "OK");
                return;
            }

            vuoro = (vuoro + 1) % pelaajat.Count;
            vuoroLabel.Text = $"Vuorossa: {pelaajat[vuoro]}";
            NaytaKaikkiPisteet();
        }

        void NaytaKaikkiPisteet()
        {
            pisteetLabel.Text = "";

            foreach (KeyValuePair<string, int> entry in pisteet)
            {
                pisteetLabel.Text += $"{entry.Key}: {entry.Value}\n";
            }
        }
    }
}
