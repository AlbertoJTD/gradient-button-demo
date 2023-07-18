using MagicGradients;
using NControl.Abstractions;
using NGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GradientButtonDemo.MyControls
{
	public class GradientButton: NControlView
	{
        public GradientButton()
        {
			var label = new Label
			{
				Text = "Test 1",
				TextColor = Xamarin.Forms.Color.White,
				VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
				HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center
			};

			var gradient = new GradientView
			{
				GradientSource = new CssGradientSource
				{
					Stylesheet = "linear-gradient(90deg, #74EBD5 0%, #9FACE6 100%)"
				}
			};

			Content = new Grid
			{
				Children =
				{
					gradient,
					label
				}
			};
        }

		public override bool TouchesBegan(IEnumerable<NGraphics.Point> points)
		{
			this.ScaleTo(0.96, 65, Easing.CubicInOut);
			return true;
		}

		public override bool TouchesCancelled(IEnumerable<NGraphics.Point> points)
		{
			this.ScaleTo(1, 65, Easing.CubicInOut);
			return true;
		}

		public override bool TouchesEnded(IEnumerable<NGraphics.Point> points)
		{
			this.ScaleTo(1, 65, Easing.CubicInOut);
			return true;
		}

		//public override void Draw(ICanvas canvas, NGraphics.Rect rect)
		//{
		//	canvas.DrawLine(rect.Left, rect.Top, rect.Width, rect.Height, NGraphics.Colors.Red);
		//	canvas.DrawLine(rect.Width, rect.Top, rect.Left, rect.Height, NGraphics.Colors.Green);
		//}
	}
}
