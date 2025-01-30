using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Json;
using System.Net.Mail;
using System.Net;
using System.Text;
using RestSharp;
using TestPRA.Models;
using System.Net.Http.Json;
using WebApi.DTOs;
using Microsoft.AspNetCore.Http;
using BL.Models;

namespace TestPRA
{
    public partial class Register : Form
    {
        private static readonly string URL = "http://localhost:5233/api/";

        List<TextBox> textBoxes = new List<TextBox>();

        public Register()
        {
            InitializeComponent();
            ClearRegisterForm(textBoxes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearRegisterForm(textBoxes);
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            textBoxes.AddRange(new List<TextBox> { inputName, inputLastName, inputEmail, inputUsername, inputPass, inputConfirmPass });

            foreach (var item in textBoxes)
            {
                if (item.Text == "")
                {
                    lblRegisterError.Text = "All fields must contain data!";
                    lblRegisterError.Visible = true;
                    return;
                }
                lblRegisterError.Visible = false;
            }

            if (inputPass.Text == inputConfirmPass.Text)
            {
                lblRegisterError.Visible = false;

                using (HttpClient client = new HttpClient())
                {
                    UserRegisterDto user = new UserRegisterDto
                    {
                        FirstName = inputName.Text,
                        LastName = inputLastName.Text,
                        DateOfBirth = datePicker.Value,
                        Email = inputEmail.Text,
                        Username = inputUsername.Text,
                        Password = inputPass.Text
                    };


                    var jsonRegisterDto = JsonSerializer.Serialize(user);

                    try
                    {
                        HttpResponseMessage res = await client.PostAsJsonAsync(URL + $"User/Register", jsonRegisterDto);

                        if (res.StatusCode == HttpStatusCode.BadRequest)
                        {
                            lblRegisterError.Text = $"Username {user.Username} already exists";
                            lblRegisterError.Visible = true;
                        }
                        else
                        {
                            var httpResponse = await client.GetFromJsonAsync<int>($"{URL}User/GetUserId/{user.Username}");

                            var emailFrom = "friedrich.hilll12@ethereal.email";
                            var password = "PRynF6SZQ9S1VG5ujG";

                            MailMessage message = new MailMessage()
                            {
                                From = new MailAddress(emailFrom),
                                Subject = "FICHTE - Confirm your email",
                                Body = $"http://localhost:5233/api/User/ConfirmAccount/{httpResponse}",
                                IsBodyHtml = true
                            };

                            message.To.Add(new MailAddress(user.Email));

                            var smtp = new SmtpClient("smtp.ethereal.email")
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(emailFrom, password),
                                UseDefaultCredentials = false,
                                EnableSsl = true
                            };

                            smtp.Send(message);

                            DialogResult conMsg = new DialogResult();

                            conMsg = MessageBox.Show("Check your email and activate your account before signing in!", "Registration succesful!", MessageBoxButtons.OK);

                            ClearRegisterForm(textBoxes);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                lblRegisterError.Text = "Passwords must match!";
                lblRegisterError.Visible = true;
            }
        }

        private void ClearRegisterForm(List<TextBox> textBoxes)
        {
            foreach (var item in textBoxes)
            {
                item.Text = "";
            }
            lblRegisterError.Visible = false;
        }
    }
}
