using System.ComponentModel.DataAnnotations;


namespace TLTask.Model
{
    public class User
    {

        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
       
        public string UserName { get; set; }

        public string Password { get; set; }

        public string CreationDate { get; set; }

       
    }
}
