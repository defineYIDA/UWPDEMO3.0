using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using UWPDemo.Views;
using Windows.UI.Popups;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using UWPDemo.Models;

namespace UWPDemo.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
            }
        }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }
        private string confirm;
        public string Confirm
        {
            get => confirm;
            set
            {
                confirm = value;
            }
        }
        ContentDialog termsOfUseContentDialog = null;
        public void Loaded(ContentDialog contentDialog)
        {
            termsOfUseContentDialog = contentDialog;
        }
        public async Task Register_Click()
        {
            //RegisterPage registerPage = new RegisterPage();

            SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), DBHelper.DBPath);
            if (username == null && password == null && confirm == null )
            {
                var dialog = new MessageDialog("用户名或密码为空！", "提示");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                dialog.Commands.Add(new UICommand("取消", cmd => { }, commandId: 1));
                //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
                return;
            }

                if (username.Length < 6)
            {
                var dialog = new MessageDialog("用户名少于六位！", "提示");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                dialog.Commands.Add(new UICommand("取消", cmd => { }, commandId: 1));
                //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
                return;

            }
            if (Password.Length < 6)
            {
                var dialog = new MessageDialog("密码少于六位！", "提示");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                dialog.Commands.Add(new UICommand("取消", cmd => { }, commandId: 1));
                //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
                return;
            }
            if (Password != Confirm)
            {
                var dialog = new MessageDialog("两次密码输入不相同！", "提示");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                dialog.Commands.Add(new UICommand("取消", cmd => { }, commandId: 1));
                //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
                return;
            }
            User user = DBHelper.GetUserByUsername(Username);
            if(user.Id != 0)
            {
                var dialog = new MessageDialog("用户已存在！", "提示");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                dialog.Commands.Add(new UICommand("取消", cmd => { }, commandId: 1));
                //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
                await dialog.ShowAsync();
                return;
            }
            else
            {
                User user1 = new User(){
                Username = username,
                Password = password};
                DBHelper.InsertOneUser(user1);
                var dialog = new MessageDialog("注册成功", "提示");
                dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
                dialog.Commands.Add(new UICommand("取消", cmd => { }, commandId: 1));
                //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
                dialog.DefaultCommandIndex = 0;
                dialog.CancelCommandIndex = 1;
                var result = await dialog.ShowAsync();
            }
        }
        public void Back_Click()
        {
            //将当前激活页面实例
            Frame root = Window.Current.Content as Frame;//获取当前激活页面
            root.Navigate(typeof(LoginPage));
        }
    }
}
