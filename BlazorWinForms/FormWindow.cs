using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazorWinForms
{
    public partial class FormWindow : Form
    {
        private const string Url = "https://localhost:7061";
        private const int Threshold = 2000; // Tempo de espera em milissegundos
        private readonly HttpClient _httpClient;

        public FormWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            CheckServerAndLoadAsync();
        }

        // Função assíncrona para verificar se o servidor está online e carregar o WebView
        private async void CheckServerAndLoadAsync()
        {
            while (!await IsServerAvailableAsync())
            {
                await Task.Delay(Threshold);
            }
            webView2.Source = new Uri(Url);
        }

        // Função para verificar se o servidor está acessível
        private async Task<bool> IsServerAvailableAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(Url);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
