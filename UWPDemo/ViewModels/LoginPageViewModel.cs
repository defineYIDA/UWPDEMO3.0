using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using Windows.UI.Xaml.Controls;
using UWPDemo.Views;

namespace UWPDemo.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Register_Click()
        {
            //将当前激活页面实例
            Frame root = Window.Current.Content as Frame;//获取当前激活页面
            root.Navigate(typeof(RegisterPage));
        }
    }

} 