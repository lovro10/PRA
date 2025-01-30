using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi.DTOs;

namespace TestPRA
{
    public partial class Friends : Form
    {
        private string loggedInUser;

        private static readonly string URL = "http://localhost:5233/api/";

        private IEnumerable<UserDto> userDtos = new List<UserDto>();
        private IEnumerable<FriendDto> friendDtos = new List<FriendDto>();
        private UserDto user;

        public Friends(string username)
        {
            loggedInUser = username;
            InitializeComponent();
            LoadAllFriendData();
        }

        private async void LoadAllFriendData()
        {
            using (HttpClient client = new HttpClient())
            {
                user = await client.GetFromJsonAsync<UserDto>($"{URL}User/GetUserByUsername/{loggedInUser}");

                friendDtos = await client.GetFromJsonAsync<IList<FriendDto>>($"{URL}Friend/GetAllFriendRequests");

                userDtos = await client.GetFromJsonAsync<IList<UserDto>>($"{URL}User/GetAllUsers");
            }

            foreach (var item in userDtos.Where(x => x.Id != user.Id))
            {
                var uc = new UCSendFriendRequest(item, loggedInUser);

                uc.lblUsername.Text = item.Username;

                if (friendDtos.Where(x => x.SenderId == user.Id).Any(x => x.ReceiverId == item.Id))
                {
                    uc.btnSendFriendRequest.Enabled = false;
                    uc.btnSendFriendRequest.Text = "Pending";
                    uc.BackColor = Color.DarkRed;
                }

                foreach (var friend in friendDtos)
                {
                    if (friend.SenderId == user.Id && friend.ReceiverId == item.Id)
                    {
                        if (friend.IsAccepted == false)
                        {
                            flpSendFriendRequest.Controls.Add(uc);
                        }
                    }
                    else if (friend.SenderId == item.Id && friend.ReceiverId == user.Id)
                    {
                        if (friend.IsAccepted == false)
                        {
                            flpSendFriendRequest.Controls.Add(uc);
                        }
                    }
                    else
                    {
                        flpSendFriendRequest.Controls.Add(uc);
                    }
                }
                
            }

            foreach (var item in friendDtos.Where(x => x.ReceiverId == user.Id).Where(x => x.IsAccepted == false))
            {
                var uc = new UCFriendRequest(item, loggedInUser);

                uc.lblUsername.Text = item.UserSender.Username;

                uc.lblDateSent.Text = item.DateSent.ToString();

                flpFriendRequests.Controls.Add(uc);
            }
        }
    }
}
