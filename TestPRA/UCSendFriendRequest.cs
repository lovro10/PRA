using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi.DTOs;

namespace TestPRA
{
    public partial class UCSendFriendRequest : UserControl
    {
        private string loggedInUser;

        private static readonly string URL = "http://localhost:5233/api/";

        public UserDto _userDto { get; private set; }

        private UserDto user;

        public UCSendFriendRequest(UserDto userDto, string username)
        {
            loggedInUser = username;
            InitializeComponent();
            _userDto = userDto;
            btnSendFriendRequest.Click += BtnSendFriendRequest_Click;
        }

        private async void BtnSendFriendRequest_Click(object? sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                user = await client.GetFromJsonAsync<UserDto>($"{URL}User/GetUserByUsername/{loggedInUser}");

                FriendDto friendDto = new FriendDto
                {
                    Id = _userDto.Id,
                    SenderId = user.Id,
                    ReceiverId = _userDto.Id,
                    DateSent = DateTime.UtcNow,
                    IsAccepted = false
                };

                var jsonFriendDto = JsonSerializer.Serialize(friendDto);

                try
                {
                    HttpResponseMessage res = await client.PostAsJsonAsync(URL + $"Friend/CreateFriendRequest", jsonFriendDto);

                    btnSendFriendRequest.Enabled = false;
                    btnSendFriendRequest.Text = "Pending";
                    BackColor = Color.DarkRed;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
