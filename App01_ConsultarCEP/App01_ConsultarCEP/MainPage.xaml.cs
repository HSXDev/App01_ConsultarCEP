using System;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BuscarCEP.Clicked += ProcuraCEP;
        }

        private void ProcuraCEP(Object sender, EventArgs args)
        {
            if (isValidCEP(CEP.Text.Trim()))
            {
                try
                {
                    var end = Services.ViaCEP.BuscarEnderecoVIACEP(CEP.Text.Trim());

                    if (end.cep == null)
                    {
                        Retorno.Text = "Cep não encontrado!";
                    }
                    else
                    {
                        Retorno.Text = String.Format("Endereco: {0}, {1} {2}", end.localidade, end.uf, end.logradouro);
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRITICO!", ex.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (string.IsNullOrEmpty(cep))
            {
                DisplayAlert("ERRO", "O campo cep é obrigatório!", "OK");
                valido = false;
            }
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "O campo cep deve ter 8 caractéres!", "OK");
                valido = false;
            }
            if (!int.TryParse(cep, out int teste))
            {
                DisplayAlert("ERRO", "O campo cep deve ter somente números!", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
