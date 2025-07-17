namespace PesoIseal
{
    using Microsoft.Maui.Controls;
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnCounterClickedAsync(object sender, EventArgs e)
        {
            double peso = double.Parse(number1.Text);
            double altura = double.Parse(number2.Text);
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
            number1.Text = "";
            number2.Text = "";
            teste.Text = "";

        }
    }
}


