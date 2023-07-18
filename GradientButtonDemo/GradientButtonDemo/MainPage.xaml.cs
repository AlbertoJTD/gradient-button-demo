using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GradientButtonDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			//View Model
			this.BindingContext = new
			{
				TextTest = "Hello Form ViewModel",
				RadiusTest = 45.0f,
				GradientStyle = "linear-gradient(135deg, rgba(76, 76, 76, 0.04) 0%, rgba(76, 76, 76, 0.04) 10%,rgba(149, 149, 149, 0.04) 10%, rgba(149, 149, 149, 0.04) 100%),linear-gradient(90deg, rgba(196, 196, 196, 0.04) 0%, rgba(196, 196, 196, 0.04) 59%,rgba(68, 68, 68, 0.04) 59%, rgba(68, 68, 68, 0.04) 100%),linear-gradient(45deg, rgba(39, 39, 39, 0.01) 0%, rgba(39, 39, 39, 0.01) 9%,rgba(218, 218, 218, 0.01) 9%, rgba(218, 218, 218, 0.01) 100%),linear-gradient(0deg, rgba(26, 26, 26, 0.04) 0%, rgba(26, 26, 26, 0.04) 33%,rgba(90, 90, 90, 0.04) 33%, rgba(90, 90, 90, 0.04) 100%),linear-gradient(135deg, rgba(37, 37, 37, 0.07) 0%, rgba(37, 37, 37, 0.07) 46%,rgba(50, 50, 50, 0.07) 46%, rgba(50, 50, 50, 0.07) 100%),linear-gradient(90deg, rgb(8, 28, 65),rgb(16, 173, 226))",
				Command = new Command(() =>
				{
					DisplayAlert("Test", "Command executed", "Ok");
				})
			};
		}
	}
}
