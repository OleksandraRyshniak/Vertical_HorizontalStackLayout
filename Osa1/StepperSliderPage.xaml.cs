using Microsoft.Maui.Layouts;

namespace Osa1;

public partial class StepperSliderPage : ContentPage
{
	Label lbl;
	Stepper stepper;
	Slider slider;
	AbsoluteLayout al;

	public StepperSliderPage()
	{
		lbl = new Label
		{
			Text = "...",
			BackgroundColor = Colors.Lavender
		};

		stepper = new Stepper
		{
			Minimum = 0,
			Maximum = 100,
			Increment = 5,
			Value = 50,
			HorizontalOptions = LayoutOptions.Center
		};
        stepper.ValueChanged += Stepper_Slider_ValueChanged;

		slider = new Slider
		{
			Minimum = 0,
			Maximum = 100,
			Value = 50,
			HorizontalOptions = LayoutOptions.Center,
			MinimumTrackColor = Colors.LightBlue,
			MaximumTrackColor = Colors.Blue,
			ThumbColor = Colors.Gray,
			WidthRequest = 300,
			//ThumbImageSource = "thumb.png"
		};
        slider.ValueChanged += Stepper_Slider_ValueChanged;

        al = new AbsoluteLayout { Children = { lbl, stepper, slider } };
		List<View> controls = new List<View> { lbl, stepper, slider };
		for (int i=0; i< controls.Count; i++)
		{
            double yKoht = 0.2 + i * 0.2;
            AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht,300, 60));
			AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
		}
		Content = al;
	}

    private void Stepper_Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
		lbl.Text = $"Stepperi/Slider väärtus: {e.NewValue: F0}";
		lbl.FontSize = 24 + e.NewValue / 4;
		lbl.Rotation = e.NewValue;
    }
}