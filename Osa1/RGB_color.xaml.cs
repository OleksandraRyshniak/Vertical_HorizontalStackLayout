using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace Osa1;

public partial class RGB_color : ContentPage
{
	BoxView box1, box2, box3, color;
	Label lbl, green_lbl, red_lbl, blue_lbl;
	Slider sl1, sl2, sl3;
	AbsoluteLayout abs;
	Button btn;
    Random rnd = new Random();
	Stepper stp;

    public RGB_color()
	{
		lbl = new Label
		{
			Text = "RGB mudel",
			FontSize = 24,
        };

		color = new BoxView
		{
			Color = Colors.Black,
			WidthRequest = 200,
			HeightRequest = 200
		};
		btn = new Button
		{
			Text = "Random Color",
			WidthRequest= 100,
			HeightRequest = 40
		};
        btn.Clicked += Btn_Clicked;

        stp = new Stepper
        {
           Minimum = 0,
           Maximum = 1,
           Increment = 0.1,
           Value = 1,
           HorizontalOptions = LayoutOptions.Center
        };
        stp.ValueChanged += Stp_ValueChanged;


        box1 = Create_box();
		box2 = Create_box();
		box3 = Create_box();

		sl1 = Create_slider();
        red_lbl = create_lbl("Red: 0");
        sl2 = Create_slider();
        green_lbl = create_lbl("Green: 0");
        sl3 = Create_slider();
		blue_lbl = create_lbl("Blue: 0");

        abs = new AbsoluteLayout { Children = { lbl, box1, box2, box3, sl1, red_lbl, sl2, green_lbl, sl3, blue_lbl, btn, color, stp } };
        List<View> controls = new List<View> { lbl, box1, box2,  box3, sl1, red_lbl, sl2, green_lbl, sl3, blue_lbl, btn,  color, stp };
        for (int i = 0; i < controls.Count; i++)
        {
            View v = controls[i];

            if (i == 0) 
            {
                AbsoluteLayout.SetLayoutBounds(v, new Rect(0.5, 0.05, 200, 40));
            }
            else if (i >= 1 && i <= 3) 
            {
                double x = 0.2 + (i - 1) * 0.3;
                AbsoluteLayout.SetLayoutBounds(v, new Rect(x, 0.15, 80, 80));
            }
            else if (v == color)
            {
                AbsoluteLayout.SetLayoutBounds(v, new Rect(0.5, 1, 200, 200));
            }
            else 
            {
                double y = 0.30 + (i - 4) * 0.04;
                AbsoluteLayout.SetLayoutBounds(v, new Rect(0.5, y, 300, 40));
            }

            AbsoluteLayout.SetLayoutFlags(v, AbsoluteLayoutFlags.PositionProportional);
        }
        Content = abs;
    }

    private void Stp_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        color.Opacity = e.NewValue;
    }

    private void Btn_Clicked(object? sender, EventArgs e)
    {
        sl1.Value = rnd.Next(256);
        sl2.Value = rnd.Next(256);
        sl3.Value = rnd.Next(256);
    }

    private BoxView Create_box()
	{
		var box = new BoxView
		{
			Color = Colors.Black,
			WidthRequest = 80,
			HeightRequest = 80,
			CornerRadius = 20, 
			BackgroundColor = Colors.White

        };
		return box;
	}

	private Slider Create_slider()
	{
		var sl = new Slider
		{
			Minimum = 0,
			Maximum = 255,
			Value = 0
        };
		sl.ValueChanged += Sl_ValueChanged;
        return sl;
    }
	private Label create_lbl(string text)
	{
		var lbl = new Label
		{
			Text = text,
			FontSize = 18
		};
		return lbl;
    }

	private void Sl_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (sender == sl1)
		{
			red_lbl.Text = String.Format("Red: {0:X2}", (int)e.NewValue);
        }
		else if (sender == sl2)
		{
            green_lbl.Text = String.Format("Green: {0:X2}", (int)e.NewValue);
        }
		else if (sender == sl3)
		{
            blue_lbl.Text = String.Format("Blue: {0:X2}", (int)e.NewValue);
        }

		box1.Color = Color.FromRgb((int)sl1.Value, 0, 0);
        box2.Color = Color.FromRgb(0, (int)sl2.Value, 0); 
		box3.Color = Color.FromRgb(0, 0, (int)sl3.Value);

        color.Color = Color.FromRgb((int)sl1.Value, (int)sl2.Value, (int)sl3.Value);
		lbl.TextColor = Color.FromRgb((int)sl1.Value, (int)sl2.Value, (int)sl3.Value);
    }
}
