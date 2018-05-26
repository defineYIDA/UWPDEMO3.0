using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UWPDemo.Model
{
    //用户表
    [Table("User")]
    public class User
    {
        private int id;
        private string name;
        private string password;
        [PrimaryKey, AutoIncrement][NotNull]
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
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