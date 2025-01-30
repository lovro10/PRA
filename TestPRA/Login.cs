using System.Net.Mail;
using System.Net;
using System.Text;
using RestSharp;
using TestPRA.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;
using WebApi.DTOs;
using System.Text.Json;
using BL.Singleton;

namespace TestPRA
{
    public partial class Login : Form
    {
        private string loggedInUser;

        private static readonly string URL = "http://localhost:5233/api/";

        List<TextBox> textBoxes = new List<TextBox>();

        public Login()
        {
            InitializeComponent();
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            textBoxes.AddRange(new List<TextBox> { inputEmail, inputPass });

            foreach (var item in textBoxes)
            {
                if (item.Text == "")
                {
                    lblLoginError.Text = "All fields must contain data!";
                    lblLoginError.Visible = true;
                    return;
                }
                lblLoginError.Visible = false;
            }

            using (HttpClient client = new HttpClient())
            {
                UserLoginDto user = new UserLoginDto
                {
                    Email = inputEmail.Text.Trim(),
                    Password = inputPass.Text.Trim()
                };


                var jsonLoginDto = JsonSerializer.Serialize(user);

                try
                {
                    HttpResponseMessage res = await client.PostAsJsonAsync(URL + $"User/Login", jsonLoginDto);

                    if (res.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        lblLoginError.Text = "Incorect username of password";
                        lblLoginError.Visible = true;
                    }
                    else
                    {
                        lblLoginError.ForeColor = Color.Green;
                        lblLoginError.Text = "Succesful login!";
                        lblLoginError.Visible = true;
                        loggedInUser = user.Email;
                        this.Hide();
                        MainWindow mainWindow = new MainWindow(loggedInUser);
                        mainWindow.FormClosed += (s, args) => this.Close();
                        mainWindow.Show();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //var cont = new StringContent(Response, Encoding.UTF8, "application/json");

            //var res = Client.PutAsync($"api/User/{users.ID}", cont).Result;
        }

        //public static T DeserializeJsonFromApi<T>(string https)
        //{
        //    var client = new RestClient(https);

        //    var result = client.Execute<T>(new RestRequest());

        //    if (https is null)
        //    {
        //        throw new Exception("Error while connecting to the API");
        //    }

        //    return JsonConvert.DeserializeObject<T>(result.Content);
        //}
    }
}
