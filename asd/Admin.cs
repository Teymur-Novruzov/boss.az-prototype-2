using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_nm;
using User_nm;
using Post_nm;
using System.Net.Mail;
using System.Net;

namespace Admin_nm
{
    class Notification
    {
        //id,Text,DateTime,FromUser
        public int ID { get; set; }
        public string Text { get; set; }
        public string DateTime { get; set; }
        public User FromUser { get; set; }

        public Notification(int ID, string Text, string DateTime, User FromUser)
        {
            this.ID = ID;
            this.Text = Text;
            this.DateTime = DateTime;
            this.FromUser = FromUser;










        }
        public override string ToString()
        {
            return $@" - - - - - - - - - - - - - - - - - - - 

   {this.DateTime} - Vaxtda 
   {this.FromUser.Name} - adli istifadeci terefinden 
   {this.Text} - prosesi bash verdi

";
        }

    }
    class Admin
    {
        public Post[] Posts = new Post[1000];
        public int posts_id { get; set; }
        public Notification[] Notifications = new Notification[1000];
        public int notifications_id { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Admin(int ID, string Username, string Email, string Password)
        {
            this.ID = ID;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
        }
        public void Add_post(Post new_post)
        {
            this.Posts[posts_id++] = new_post;
        }
        public void Add_Notifications(Notification new_notification)
        {
            this.Notifications[notifications_id++] = new_notification;
        }

        public void Show_all_posts()
        {
            Console.Clear();
            for (int i = 0; i < posts_id; i++)
            {
                Console.WriteLine(Posts[i].ToString());
            }
        }

    }
}
