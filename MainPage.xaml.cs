namespace PesoIseal
{
    using Microsoft.Maui.Controls;
    using System.Globalization;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    
        private async void OnCounterClickedAsync(object sender, EventArgs e)
        {
            double peso = double.Parse(PesoEntry.Text);
            double altura = double.Parse(AlturaEntry.Text);
            double imc = peso / (altura * altura);

            if (imc > 0 && imc <= 17)
            {

                teste.Text = $"esta abaixo do peso {imc.ToString("0.0")} kg";
                await TextToSpeech.SpeakAsync(teste.Text);

            }
            else if (imc >= 18 && imc < 24)
            {

                teste.Text = $"esta dentro do peso ideal {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 25 && imc <= 29)
            {

                teste.Text = $"esta com pre obesidade {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 29 && imc <= 35)
            {

                teste.Text = $"esta com obesidade grau 1 {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 35 && imc <= 39)
            {

                teste.Text = $"esta com obesidade grau 2 {imc.ToString("0.0")}kg";
                await TextToSpeech.SpeakAsync(teste.Text);
            }
            else if (imc >= 40)
            {

                teste.Text = $"Estado critico, esta com obesidade grau 3 {imc.ToString("0.0")}kg";
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