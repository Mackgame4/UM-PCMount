using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazorWinForms
{
    public partial class FormWindow : Form
    {
        private readonly List<string> Urls = [
            "http://localhost:5106",
            "http://localhost:7061",
            "https://localhost:5106",
            "https://localhost:7061"
        ];
        private const int Threshold = 2000; // Tempo de espera em milissegundos
        private readonly HttpClient _httpClient;

        public FormWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            CheckServerAndLoadAsync();
        }

        // Funcao assincrona para verificar se o servidor esta online e carregar o WebView
        private void CheckServerAndLoadAsync()
        {
            Task.Run(async () =>
            {
                foreach (var url in Urls)
                {
                    try
                    {
                        var response = await _httpClient.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                webView2.Source = new Uri(url);
                            }));
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        // Ignorar excecoes
                    }
                    await Task.Delay(Threshold);
                }
            });
        }
    }
}
