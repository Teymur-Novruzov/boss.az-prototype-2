using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_nm;
using User_nm;
using Post_nm;
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace Lesson7_17._04._2022_Task
{

    class Proses
    {
        public User[] users = new User[1000];
        int count_user_base = 0;
        public int Usercount { get; set; }
        Admin admin = new Admin(1, "Teymur", "email@gmail.com", "teymur1234");
        public void Base()
        {
            User user1 = new User(count_user_base++, "Tural", "Novruzov", 28, "TuraliNovruzov@gmail.com", "tural123");
            User user2 = new User(count_user_base++, "Turan", "Novruzov", 38, "TuraniNovruzov@gmail.com", "turan123");
            User user3 = new User(count_user_base++, "Elnur", "Eliyev", 20, "Elnur@gmail.com", "elnur123");
            User user4 = new User(count_user_base++, "Elgun", "Eliyev", 22, "Elgun@gmail.com", "elgun123");
            User user5 = new User(count_user_base++, "Eliheyder", "Eliyev", 20, "Eliheyder@gmail.com", "eliheyder123");

            Usercount = 0;
            users[Usercount++] = user1;
            users[Usercount++] = user2;
            users[Usercount++] = user3;
            users[Usercount++] = user4;
            users[Usercount++] = user5;

            Post post_1 = new Post(0, "Pisikler", DateTime.Now.ToString(), 0, 0);
            Post post_2 = new Post(1, "Itler", DateTime.Now.ToString(), 0, 0);
            Post post_3 = new Post(2, "Atlar", DateTime.Now.ToString(), 0, 0);
            Post post_4 = new Post(3, "Seherler", DateTime.Now.ToString(), 0, 0);
            Post post_5 = new Post(4, "Baki", DateTime.Now.ToString(), 0, 0);

            admin.Add_post(post_1);
            admin.Add_post(post_2);
            admin.Add_post(post_3);
            admin.Add_post(post_4);
            admin.Add_post(post_5);
        }
        public void Check_Admin()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("     Enter email : ");
            string check_email_admin = Console.ReadLine();
            Console.WriteLine();
            Console.Write("     Enter password : ");
            string check_password_admin = Console.ReadLine();
            if (check_email_admin == admin.Email && check_password_admin == admin.Password)
            {
                Admin_window();
            }
            else
            {
                Wront_choice();
                Check_Admin();
            }
        }
        public void Admin_window()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($@"          Back [0]          Posts [1]          Notvications [2] ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" Enter : ");
            string check_admin_win_choice = Console.ReadLine();
            if (check_admin_win_choice == "0")
            {
                First_page();
            }
            else if (check_admin_win_choice == "1")
            {
                Admin_posts();
            }
            else if (check_admin_win_choice == "2")
            {
                Show_notifications();
            }
            else
            {
                Wront_choice();
                Admin_window();
            }


        }
        public void Show_notifications()
        {
            Console.Clear();
            for (int i = 0; i < admin.notifications_id; i++)
            {
                Console.WriteLine(admin.Notifications[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Back [0]     ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("     Enter : ");
            string notvications_choice_str = Console.ReadLine();
            if (notvications_choice_str == "0")
            {
                Admin_window();
            }
            else
            {
                Wront_choice();
                Show_notifications();
            }
        }
        public void Admin_posts()
        {
            admin.Show_all_posts();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   Back [0]     Add post [1]     Delete post [2] ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("   Enter : ");
            string admin_second_page_choice = Console.ReadLine();
            if (admin_second_page_choice == "0")
            {
                Admin_window();
            }
            else if (admin_second_page_choice == "1")
            {
                Add_post_admin();
            }
            else if (admin_second_page_choice == "2")
            {
                Delete_post_admin();
            }
            else
            {
                Wront_choice();
                Admin_posts();
            }

        }
        public void Delete_post_admin()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  Enter posts Id : ");
            string delete_posts_content = Console.ReadLine();
            int delete_posts_content_int;
            bool v = int.TryParse(delete_posts_content, out delete_posts_content_int);
            if (v)
            {
                for (int i = 0; i < admin.posts_id; i++)
                {
                    if (delete_posts_content_int == admin.Posts[i].ID)
                    {
                        admin.Posts[i] = null;
                        for (int k = i; k < admin.posts_id; k++)
                        {
                            admin.Posts[k] = admin.Posts[k + 1];
                        }
                        admin.posts_id -= 1;
                        Delete_animasion();
                        Admin_posts();
                    }
                }
                Wront_choice();
                Delete_post_admin();
            }
            else
            {
                Wront_choice();
                Delete_post_admin();
            }
            Admin_posts();
        }
        public void Delete_animasion()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($@"                     

                                           Deleted   ");
                Thread.Sleep(1000);
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void Add_animasion()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($@"                     

                                           Added   ");
                Thread.Sleep(1000);
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void Add_post_admin()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  Enter Content : ");
            string new_posts_content = Console.ReadLine();
            Post new_post_admin = new Post(admin.posts_id, new_posts_content, DateTime.Now.ToString(), 0, 0);
            admin.Posts[admin.posts_id++] = new_post_admin;
            Add_animasion();
            Admin_posts();
        }
        static void Informations()
        {
            Console.Title = "Bos.az";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowHeight = 22;
            Console.WindowWidth = 90;
        }
        public void New_user()
        {
            //string Name,string Surname,int Age,string Email,string Password
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" Enter Name : ");
            string new_name_user = Console.ReadLine();
            Console.Write(" Enter Surname : ");
            string new_surname_user = Console.ReadLine();
            Console.Write(" Enter Email : ");
            string new_email_user = Console.ReadLine();
            Console.Write(" Enter Password : ");
            string new_pass_user = Console.ReadLine();
            Console.Write(" Enter Age : ");
            string new_age_user = Console.ReadLine();
            int new_age_user_int;
            bool check_new_user = int.TryParse(new_age_user, out new_age_user_int);
            if (check_new_user == true)
            {
                User new_user = new User(count_user_base++, new_name_user, new_surname_user, new_age_user_int, new_email_user, new_pass_user);
                users[Usercount++] = new_user;
            }
            else
            {
                Wront_choice();
                New_user();
            }
            First_page();
        }
        public void First_page()
        {
            Console.Clear();
            Console.Write($@"                   


                                 ADMIN [1]     or     User [2] 
                                
                                 If you not have account write [0]



                                 Enter : ");
            string first_pages_choice = Console.ReadLine();
            if (first_pages_choice == "0")
            {
                New_user();
            }
            else if (first_pages_choice == "1")
            {
                Check_Admin();
            }
            else if (first_pages_choice == "2")
            {
                check_user();
            }
            else
            {
                Wront_choice();
                First_page();
            }

        }
        public void check_user()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("               Enter email : ");
            string check_user_email = Console.ReadLine();
            Console.WriteLine();
            Console.Write("               Enter password : ");
            string check_user_pass = Console.ReadLine();
            for (int i = 0; i < Usercount; i++)
            {
                if (users[i].Email == check_user_email && users[i].Password == check_user_pass)
                {
                    Second_page_user(users[i]);
                }
            }
            Wront_choice();
            check_user();
        }
        public void Second_page_user(User user)
        {
            admin.Show_all_posts();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($@"     if you want go to back enter [ B ] or enter the ID

     Enter : ");
            string second_page_user_choice = Console.ReadLine();
            if (second_page_user_choice == "B" || second_page_user_choice == "b")
            {
                First_page();
            }
            else
            {
                for (int i = 0; i < admin.posts_id; i++)
                {
                    string i_str = i.ToString();
                    if (i_str == second_page_user_choice)
                    {
                        LikeAndView(admin.Posts[i], user);
                    }
                }
                Wront_choice();
                Second_page_user(user);
            }

        }
        public void LikeAndView(Post post, User user)
        {
            post.ViewCount += 1;
            post.Show_one_post();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Back [0]            Like [1]");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("     Enter : ");
            string likeOrBack_str = Console.ReadLine();
            if (likeOrBack_str == "0")
            {
                Second_page_user(user);
            }
            else if (likeOrBack_str == "1")
            {
                for (int i = 0; i < post.user_count; i++)
                {
                    if (post.like_users[i] == user)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("                    You are liked This post ");
                        Thread.Sleep(2000);
                        LikeAndView(post, user);
                    }
                }
                Notification new_notification = new Notification(admin.notifications_id, "Beyenme", DateTime.Now.ToString(), user);
                admin.Notifications[admin.notifications_id++] = new_notification;
                post.LikeCount += 1;
                post.like_users[post.user_count++] = user;
                Like_animasion();

                ///////////////////////////////////////////////////////////////////       Email system



                var fromAddress = new MailAddress("gonderen22@gmail.com", "From Name");
                var toAddress = new MailAddress(user.Email, "To Name");
                const string fromPassword = "g0Nderen1234";
                const string subject = "Subject";
                const string body = "Beyenme";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }


                ////////////////////////////////////////////////////////////////////


                LikeAndView(post, user);

            }
            else
            {
                Wront_choice();
                LikeAndView(post, user);
            }
        }
        public void Like_animasion()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($@"                     

                                           Liked   ");
                Thread.Sleep(1000);
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void Wront_choice()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($@"                     

                                           WRONG   ");
                Thread.Sleep(1000);
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void Start()
        {
            Informations();
            Base();
            First_page();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Proses proses = new Proses();
            proses.Start();
        }
    }
}
