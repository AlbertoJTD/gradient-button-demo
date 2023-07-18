using MagicGradients;
using NControl.Abstractions;
using NGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GradientButtonDemo.MyControls
{
	public class GradientButton: NControlView
	{
		private Frame _frame;
		private Label _label;
		private GradientView _gradientview;

		#region BorderRadius
		public float BorderRadius
		{
			get => (float)GetValue(BorderRadiusProperty);
			set
			{
				SetValue(BorderRadiusProperty, value);
				Invalidate();
			}
		}

		public float initialRadius = 15;

		public static BindableProperty BorderRadiusProperty = BindableProperty.Create(
																				nameof(BorderRadius),
																				typeof(float),
																				typeof(GradientButton),
																				defaultValue: null,
																				propertyChanged: (b, o, n) =>
																				{
																					var control = (GradientButton)b;
																					control.BorderRadius = (float)n;
																				});
		#endregion

		#region Text
		public string Text
		{
			get => (string)GetValue(TextProperty);
			set
			{
				SetValue(TextProperty, value);
				Invalidate();
			}
		}

		public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
																			typeof(string),
																			typeof(GradientButton),
																			defaultValue: "",
																			propertyChanged: (b, o, n) =>
																			{
																				var control = (GradientButton)b;
																				control.Text = (string)n;
																			});
		#endregion

		#region GradientStyle
		public string GradientStyle
		{
			get => (string)GetValue(GradientStyleProperty);
			set
			{
				SetValue(GradientStyleProperty, value);
				Invalidate();
			}
		}

		public static BindableProperty GradientStyleProperty = BindableProperty.Create(nameof(GradientStyleProperty),
																			typeof(string),
																			typeof(GradientButton),
																			defaultValue: "linear-gradient(90deg, #74EBD5 0%, #9FACE6 100%)",
																			propertyChanged: (b, o, n) =>
																			{
																				var control = (GradientButton)b;
																				control.GradientStyle = (string)n;
																			});
		#endregion

		#region Command
		public ICommand Command
		{
			get => (ICommand)GetValue(CommandProperty);
			set
			{
				SetValue(CommandProperty, value);
				Invalidate();
			}
		}

		public static BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
																			typeof(ICommand),
																			typeof(GradientButton),
																			defaultBindingMode: BindingMode.TwoWay,
																			propertyChanged: (b, o, n) =>
																			{
																				var control = (GradientButton)b;
																				control.Command = (ICommand)n;
																			});
		#endregion

		public GradientButton()
        {
			BorderRadius = initialRadius;
			_label = new Label
			{
				Text = "Test 1",
				TextColor = Xamarin.Forms.Color.White,
				VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
				HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center
			};

			_gradientview = new GradientView
			{
				GradientSource = new CssGradientSource
				{
					Stylesheet = "linear-gradient(90deg, #74EBD5 0%, #9FACE6 100%)"
				}
			};

			_frame = new Frame
			{
				Content = new Grid
				{
					Children =
					{
						_gradientview,
						_label
					}
				},
				Padding = 0,
				CornerRadius = 15f
			};

			Content = _frame;

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
			if (Command != null && Command.CanExecute(null))
			{
				Command.Execute(null);
			}

			return true;
		}

		public override void Draw(ICanvas canvas, NGraphics.Rect rect)
		{
			//canvas.DrawLine(rect.Left, rect.Top, rect.Width, rect.Height, NGraphics.Colors.Red);
			//canvas.DrawLine(rect.Width, rect.Top, rect.Left, rect.Height, NGraphics.Colors.Green);
			_frame.CornerRadius = BorderRadius;
			_label.Text = Text;
			_gradientview.GradientSource = new CssGradientSource
			{
				Stylesheet = this.GradientStyle
			};
		}
	}
}
