using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi.DTOs;

namespace TestPRA
{
    public partial class MainWindow : Form
    {
        private string loggedInUser;

        private static readonly string URL = "http://localhost:5233/api/";

        CreateNewGroup createNewGroupForm = null;


        private IEnumerable<GroupDto> groupChats = new List<GroupDto>();

        public MainWindow(string username)
        {
            InitializeComponent();
            InitializeSidebar();
            loggedInUser = username;
        }

        private async void InitializeSidebar()
        {
            using (HttpClient client = new HttpClient())
            {
                groupChats = await client.GetFromJsonAsync<IList<GroupDto>>($"{URL}Group/GetAllGroups");
            }

            foreach (var item in groupChats)
            {
                listGroups.Items.Add(item.Name);
            }
        }

        private async void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if (createNewGroupForm is null)
            {
                createNewGroupForm = new CreateNewGroup();
            }

            if (createNewGroupForm.lblGroupNameError.Visible == true)
            {
                createNewGroupForm.lblGroupNameError.Visible = true;
            }

            if (createNewGroupForm.ShowDialog() == DialogResult.OK)
            {

                string groupName = createNewGroupForm.inputGroupName.Text.Trim();

                if (!string.IsNullOrWhiteSpace(groupName))
                {
                    createNewGroupForm.lblGroupNameError.Visible = false;

                    using (HttpClient client = new HttpClient())
                    {
                        GroupDto groupDto = new GroupDto
                        {
                            Name = groupName
                        };

                        var jsonGroupDto = JsonSerializer.Serialize(groupDto);

                        try
                        {
                            HttpResponseMessage res = await client.PostAsJsonAsync(URL + $"Group/CreateGroup", jsonGroupDto);

                            if (res.StatusCode == HttpStatusCode.BadRequest)
                            {
                                createNewGroupForm.lblGroupNameError.Text = $"Group with name {groupDto.Name} already exists";
                                createNewGroupForm.lblGroupNameError.Visible = true;
                                btnCreateGroup.PerformClick();
                            }
                            else
                            {
                                listGroups.Items.Add(groupDto.Name);
                                createNewGroupForm.lblGroupNameError.Visible = false;
                                createNewGroupForm.inputGroupName.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Friends friendsForm = new Friends(loggedInUser);
            friendsForm.Show();
        }
    }
}
