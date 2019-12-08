using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using System;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class GoogleAuthenticationTests
    {
        [Theory(Skip ="Run Only to Test Google Authentification")]
        [InlineData(@"C:\TFS\OnlineServices-d9921f8e5f21.json")]//TODO Students: Put your projectIdHere
        public void GoogleAuthentificationImplicit(string JSONFile)
        {
            // If you don't specify credentials when constructing the client, the
            // client library will look for credentials in the environment.
            var credential = GoogleCredential.FromFile(JSONFile);

            using (var client = TranslationClient.Create(credential, TranslationModel.NeuralMachineTranslation))
            {

                var ReturnedValue = client.DetectLanguage("Bonjour Google!").Language;
                Console.WriteLine(ReturnedValue);
                Assert.Equal("fr", ReturnedValue);
            }

        }
    }
}
