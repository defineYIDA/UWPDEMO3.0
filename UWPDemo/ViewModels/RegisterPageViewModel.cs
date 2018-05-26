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

namespace UWPDemo.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Register_Click()
        {
        }
        public void Back_Click()
        {
            //将当前激活页面实例
            Frame root = Window.Current.Content as Frame;//获取当前激活页面
            root.Navigate(typeof(LoginPage));
        }
    }
}
