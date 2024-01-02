using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static TLTask.Controllers.UserController;

namespace TLTask.Model
{
    public class AddUserRequest
    {
        public string FullName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string CreationDate { get; set; }
    }
}
