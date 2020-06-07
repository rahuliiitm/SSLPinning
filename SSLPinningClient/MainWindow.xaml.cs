using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSLPinningClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetPostDetails();
        }

        private static readonly string PostCollectionBaseAddress = "https://localhost:44305/";

        private static string PostCollectionApiAddress
        {
            get
            {
                string baseAddress = PostCollectionBaseAddress;
                return baseAddress.EndsWith("/") ? PostCollectionBaseAddress + "post/v1/all"
                                                 : PostCollectionBaseAddress + "/post/v1/all";
            }
        }

        public bool TrustAllCertificatesCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private void GetPostDetails()
        {
            GetPostDetails(true).ConfigureAwait(false);
        }

        private HttpClientHandler GetClientHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = ValidateCertificate;
            return handler;
        }

        private static bool ValidateCertificate(HttpRequestMessage request, X509Certificate2 certificate, X509Chain certificateChain, SslPolicyErrors policy)
        {
            var validCertificate = new[] { "CN=localhost" };
            int absoluteUriLength = request.RequestUri.AbsoluteUri.Length;
            int absolutePathLength = request.RequestUri.AbsolutePath.Length;
            string host = request.RequestUri.AbsoluteUri.Substring(0, absoluteUriLength - absolutePathLength +1);
            if (!host.Equals(PostCollectionBaseAddress))
            {
                return false;
            }
            if (certificateChain.ChainStatus.Any(status => status.Status != X509ChainStatusFlags.UntrustedRoot))
                return false;

            foreach (var element in certificateChain.ChainElements)
            {
                if (validCertificate.Any(cert => cert.Equals(element.Certificate.Issuer)))
                    return true; // Process the next status
            }

            // Return true only if all certificates of the chain are valid
            return false;
        }

        private async Task GetPostDetails(bool _)
        {
            using (var handler = GetClientHandler())
            {
                using (HttpClient _httpClient = new HttpClient(handler))
                {

                    HttpResponseMessage response = await _httpClient.GetAsync(PostCollectionApiAddress);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response and data-bind to the GridView to display Post.
                        string s = await response.Content.ReadAsStringAsync();
                        List<PostDetails> postList = JsonConvert.DeserializeObject<List<PostDetails>>(s);

                        Dispatcher.Invoke(() =>
                        {
                            PostGrid.ItemsSource =  postList;
                        });
                    }
                }
            }
        }

    }
}
