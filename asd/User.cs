using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_nm;
using User_nm;
using Post_nm;
namespace User_nm
{
    class User
    {
        //id,name,surname,age,email,password
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int ID, string Name, string Surname, int Age, string Email, string Password)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Email = Email;
            this.Password = Password;
        }


    }
}
