using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_nm;
using User_nm;
using Post_nm;

namespace Post_nm
{
    class Post
    {
        //id,Content,CreationDateTime,LikeCount,ViewCount
        public int ID { get; set; }
        public string Content { get; set; }
        public string CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        public User[] like_users = new User[1000];
        public int user_count { get; set; }


        public Post(int ID, string Content, string CreationDateTime, int LikeCount, int ViewCount)
        {
            this.ID = ID;
            this.Content = Content;
            this.CreationDateTime = CreationDateTime;
            this.LikeCount = LikeCount;
            this.ViewCount = ViewCount;
            user_count = 0;
        }
        public void Add_user_like(User user)
        {
            like_users[user_count++] = user;
        }

        public void Show_one_post()
        {
            Console.Clear();
            Console.WriteLine($@" -----------------------------

 ID : {this.ID}
 Content : {this.Content}
 Creation date time : {this.CreationDateTime}
 Like : {this.LikeCount}
 View : {this.ViewCount}

 -----------------------------
");
        }
        public override string ToString()
        {
            return $@" -----------------------------

 ID : {this.ID}
 Content : {this.Content}
 Creation date time : {this.CreationDateTime}
 Like : {this.LikeCount}
 View : {this.ViewCount}

";
        }

    }
}
