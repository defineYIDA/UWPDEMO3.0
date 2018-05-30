using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPDemo.Models
{
    //用户表
    [Table("User")]
    public class User
    {
        private int id;
        private string username;
        private string password;
        [PrimaryKey, AutoIncrement][NotNull]
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Username
        {
            get => username;
            set
            {
                username = value;
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }
    }
}