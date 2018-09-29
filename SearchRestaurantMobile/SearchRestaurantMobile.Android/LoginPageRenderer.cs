using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using SearchRestaurantMobile;

[assembly: ExportRenderer(typeof(Login), typeof(SearchRestaurantMobile.Droid.LoginPageRenderer))]
namespace SearchRestaurantMobile.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        
        #pragma warning disable CS0618 // Type or member is obsolete
                public LoginPageRenderer()
                {
                    var activity = Context as Activity;

                    var auth = new OAuth2Authenticator(
                        clientId: "1822293971186067", // your OAuth2 client id
                        scope: "email", // the scopes for the particular API you're accessing, delimited by "+" symbols
                        authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                        redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));


                    auth.Completed += async (sender, eventArgs) => {

                        if (eventArgs.IsAuthenticated)
                        {
                            var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                            var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                            var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                            var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                            var response = await request.GetResponseAsync();
                            var obj = JObject.Parse(response.GetResponseText());

                            var id = obj["id"].ToString().Replace("\"", "");
                            var name = obj["name"].ToString().Replace("\"", "");

                            await App.NavigateToDetails(string.Format("{0}", name).ToUpper());
                        }
                        else
                        {

                            await App.NavigateToDetails("Usuário Cancelou o login");
                        }
                    };

                    activity.StartActivity(auth.GetUI(activity));
                }

        #pragma warning restore CS0618 // Type or member is obsolete

    }
}