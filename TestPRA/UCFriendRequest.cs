using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi.DTOs;

namespace TestPRA
{
    public partial class UCFriendRequest : UserControl
    {
        private string loggedInUser;

        private static readonly string URL = "http://localhost:5233/api/";

        public FriendDto _friendDto { get; private set; }

        private UserDto user;

        public UCFriendRequest(FriendDto friendDto, string username)
        {
            loggedInUser = username;
            InitializeComponent();
            _friendDto = friendDto;
            btnAcceptFriendRequest.Click += btnAcceptFriendRequest_Click;
            btnDeclineFriendRequest.Click += btnDeclineFriendRequest_Click;
        }

        private async void btnAcceptFriendRequest_Click(object? sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                user = await client.GetFromJsonAsync<UserDto>($"{URL}User/GetUserByUsername/{loggedInUser}");

                FriendDto friendDto = new FriendDto
                {
                    Id = _friendDto.Id,
                    SenderId = _friendDto.SenderId,
                    ReceiverId = _friendDto.ReceiverId,
                    DateSent = _friendDto.DateSent,
                    IsAccepted = _friendDto.IsAccepted
                };

                var jsonFriendDto = JsonSerializer.Serialize(friendDto);

                try
                {
                    HttpResponseMessage res = await client.PutAsJsonAsync(URL + $"Friend/AcceptFriendRequest", jsonFriendDto);

                    btnAcceptFriendRequest.Enabled = false;
                    btnAcceptFriendRequest.Text = "Accepted";
                    BackColor = Color.Green;
                    btnDeclineFriendRequest.Visible = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnDeclineFriendRequest_Click(object? sender, EventArgs e)
        {

        }
    }
}
