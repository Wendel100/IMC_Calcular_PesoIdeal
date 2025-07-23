namespace PesoIseal
{
    using Microsoft.Maui.Controls;
    using System.Globalization;

    public partial class MainPage : ContentPage
    {
        private bool _formatandoAltura = false;
        private bool _formatandoPeso = false;
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnAlturaTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_formatandoAltura) return;
            _formatandoAltura = true;

            var entry = (Entry)sender;
            var texto = new string(entry.Text.Where(char.IsDigit).ToArray());

            if (double.TryParse(texto, out double alturaCm))
            {
                double alturaMetros = alturaCm / 100; // 170 cm → 1.70 m
                entry.Text = alturaMetros.ToString("N2", CultureInfo.CurrentCulture); // 2 casas decimais
            }
            else
            {
                entry.Text = "";
            }

            _formatandoAltura = false;
        }

        // PESO: 705 → 70,5 kg
        private void OnPesoTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_formatandoPeso) return;
            _formatandoPeso = true;

            var entry = (Entry)sender;
            var texto = new string(entry.Text.Where(char.IsDigit).ToArray());

            if (double.TryParse(texto, out double pesoGramas))
            {
                double pesoKg = pesoGramas / 10; // 705 → 70.5
                entry.Text = pesoKg.ToString("N1", CultureInfo.CurrentCulture); // 1 casa decimal
            }
            else
            {
                entry.Text = "";
            }

            _formatandoPeso = false;
        }
        private async void OnCounterClickedAsync(object sender, EventArgs e)
        {
            double peso = double.Parse(PesoEntry.Text);
            double altura = double.Parse(AlturaEntry.Text);
            double imc = peso / (altura * altura);

            if (imc > 0 && imc <= 17)
            {

                teste.Text = $"O vc esta abaixo do peso {imc.ToString("0.0")} kg";
                await TextToSpeech.SpeakAsync(teste.Text);

            }
            else if (imc >= 18 && imc < 24)
            {

                teste.Text = $"O vc esta dentro do peso ideal {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 25 && imc <= 29)
            {

                teste.Text = $"O vc esta com pre obesidade {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 29 && imc <= 35)
            {

                teste.Text = $"O vc esta com obesidade grau 1 {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 35 && imc <= 39)
            {

                teste.Text = $"O vc esta com obesidade grau 2 {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 40)
            {

                teste.Text = $"Estado critico!!!!!,n/ vc esta com obesidade grau 3 {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else
            {
                teste.Text = $"Não foi possível fazer o Calculo";
                await TextToSpeech.SpeakAsync(teste.Text);
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void limpar_Clicked(object sender, EventArgs e)
        {
            AlturaEntry.Text = "";
            PesoEntry.Text = "";
            teste.Text = "";

        }
    }
}