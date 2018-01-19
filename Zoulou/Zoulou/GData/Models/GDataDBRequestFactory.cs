using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace Zoulou.GData.Models {
    public class GDataDBRequestFactory {
        private static string[] Scopes = new[] {
            "https://www.googleapis.com/auth/spreadsheets.readonly",
            "https://www.googleapis.com/auth/spreadsheets",
            "https://www.googleapis.com/auth/drive.readonly",
            "https://www.googleapis.com/auth/drive"
        };
        public readonly SheetsService SheetsService;

        public GDataDBRequestFactory(string ServiceAccountEmail, string ServiceAccountCredentialFilePath) {
            this.SheetsService = AuthenticateServiceAccount(ServiceAccountEmail, ServiceAccountCredentialFilePath);
        }

        private SheetsService AuthenticateServiceAccount(string ServiceAccountEmail, string ServiceAccountCredentialFilePath) {
            try {
                if(string.IsNullOrEmpty(ServiceAccountCredentialFilePath))
                    throw new Exception("Path to the .p12 service account credentials file is required.");
                if(!File.Exists(ServiceAccountCredentialFilePath))
                    throw new Exception("The service account credentials .p12 file does not exist at: " + ServiceAccountCredentialFilePath);
                if(string.IsNullOrEmpty(ServiceAccountEmail))
                    throw new Exception("ServiceAccountEmail is required.");

                if(Path.GetExtension(ServiceAccountCredentialFilePath).ToLower() == ".json") {
                    var Credential = GoogleCredential.FromFile(ServiceAccountCredentialFilePath).CreateScoped(Scopes);

                    return new SheetsService(new BaseClientService.Initializer() {
                        HttpClientInitializer = Credential,
                        ApplicationName = "Zoulou"
                    });
                } else if(Path.GetExtension(ServiceAccountCredentialFilePath).ToLower() == ".p12") {
                    var Certificate = new X509Certificate2(ServiceAccountCredentialFilePath, "notasecret", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                    var Credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(ServiceAccountEmail) { Scopes = Scopes }.FromCertificate(Certificate));
                    
                    return new SheetsService(new BaseClientService.Initializer() {
                        HttpClientInitializer = Credential,
                        ApplicationName = "Zoulou"
                    });
                } else {
                    throw new Exception("Unsupported Service accounts credentials.");
                }
            } catch(Exception ex) {
                Console.WriteLine("Authenticate service account failed" + ex.Message);
                throw new Exception("AuthenticateServiceAccountFailed", ex);
            }
        }

        private SheetsService AuthenticateServiceAccountFromKey(string ServiceAccountEmail, string Key) {
            try {
                if(string.IsNullOrEmpty(ServiceAccountEmail))
                    throw new Exception("ServiceAccountEmail");
                if(string.IsNullOrEmpty(Key))
                    throw new Exception("Key");

                var Credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(ServiceAccountEmail) { Scopes = Scopes }.FromPrivateKey(Key));

                return new SheetsService(new BaseClientService.Initializer() {
                    HttpClientInitializer = Credential,
                    ApplicationName = "Zoulou"
                });

            } catch(Exception ex) {
                Console.WriteLine("Authenticate service account failed" + ex.Message);
                throw new Exception("AuthenticateServiceAccountFailed", ex);
            }
        }

        public HttpClient GetHttpClient() {
            return this.SheetsService.HttpClient;
        }
    }
}