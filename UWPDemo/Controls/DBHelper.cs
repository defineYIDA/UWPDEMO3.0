using System;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPDemo.Models;

namespace UWPDemo.Models
{
    public class DBHelper
    {
        private static string DbFilename;
        private static string dBPath;
        public static string DbFilename1 { get => DbFilename; set => DbFilename = value; }
        public static string DBPath { get => dBPath; }
        public static void SetDBFilename(string Filename)
        {
            if (string.IsNullOrEmpty(Filename) && string.IsNullOrWhiteSpace(Filename))
            {
                throw new ArgumentNullException("操作数据库名称不合法!");
            }
            else
            {
                DbFilename1 = Filename;
                dBPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbFilename1);
            }
        }
        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="DBFilename">数据库名称</param>
        public static void InitDB(string DBFilename)
        {
            SetDBFilename(DBFilename);
            // ApplicationData.Current.LocalFolder.Path balabala的指的是这个位置 ->C:\Users\xiao22805378\AppData\Local\Packages\92211ab1-5481-4a1a-9111-a3dd87b81b72_8zmgqd0netmce\LocalState\
            if (!File.Exists(dBPath))
            {
                // ApplicationData.Current.LocalFolder.Path balabala的指的是这个位置 ->C:\Users\xiao22805378\AppData\Local\Packages\92211ab1-5481-4a1a-9111-a3dd87b81b72_8zmgqd0netmce\LocalState\
                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), dBPath))
                {
                    conn.CreateTable<User>();//创建数据表user
                }
            }
        }
        public static int InsertOneUser(User user)//向数据表插入一条数据
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), dBPath))
            {
                result = conn.Insert(user);
            }
            return result;
        }
        /// <summary>
        /// 返回所有的用户
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUser()
        {
            List<User> r;
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), dBPath))
            {
                r = conn.Table<User>().ToList<User>();
            }
            return r;
        }
        /// <summary>
        /// 根据记录Username获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserByUsername(string Username)
        {
            User l;
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), DBHelper.DBPath))
            {
                try
                {
                    l = conn.Table<User>().Where(v => v.Username == Username).ToList<User>()[0];
                }
                catch
                {
                    l = new User();
                }
            }
            return l;
        }
    }
}