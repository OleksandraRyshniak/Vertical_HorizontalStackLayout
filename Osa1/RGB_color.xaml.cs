using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace Osa1;

public partial class RGB_color : ContentPage
{
	BoxView box1, box2, box3, color;
	Label lbl, green_lbl, red_lbl, blue_lbl;
	Slider sl1, sl2, sl3;
	AbsoluteLayout abs;

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

        box1 = Create_box(Colors.Red);
		box2 = Create_box(Colors.Green);
		box3 = Create_box(Colors.Blue);

		sl1 = Create_slider();
        red_lbl = create_lbl("Red: 255");
        sl2 = Create_slider();
        green_lbl = create_lbl("Green: 255");
        sl3 = Create_slider();
		blue_lbl = create_lbl("Blue: 255");

        abs = new AbsoluteLayout { Children = { lbl, box1, box2, box3, sl1, red_lbl, sl2, green_lbl, sl3, blue_lbl, color } };
        List<View> controls = new List<View> { lbl, box1, box2,  box3, sl1, red_lbl, sl2, green_lbl, sl3, blue_lbl, color };
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
                double y = 0.30 + (i - 4) * 0.07;
                AbsoluteLayout.SetLayoutBounds(v, new Rect(0.5, y, 300, 40));
            }

            AbsoluteLayout.SetLayoutFlags(v, AbsoluteLayoutFlags.PositionProportional);
        }
        Content = abs;
    }
    

	private BoxView Create_box(Color color)
	{
		var box = new BoxView
		{
			Color = color,
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

		color.Color = Color.FromRgb((int)sl1.Value, (int)sl2.Value, (int)sl3.Value);
		lbl.TextColor = Color.FromRgb((int)sl1.Value, (int)sl2.Value, (int)sl3.Value);
    }
}
