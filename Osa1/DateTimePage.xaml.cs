using Microsoft.Maui.Layouts;
using System.Data;

namespace Osa1;

public partial class DateTimePage : ContentPage
{
	DatePicker datePicker;
	TimePicker timePicker;
	Label lbl_time;
	AbsoluteLayout al;

	public DateTimePage()
	{
		datePicker = new DatePicker
		{
			MinimumDate = DateTime.Now.AddDays(-15),
			MaximumDate = DateTime.Now.AddDays(15),
			Date = DateTime.Now,
			HorizontalOptions = LayoutOptions.Center,
			Format = "D"
		};

		datePicker.DateSelected += (sender, e) =>
		{
			lbl_time.Text = $"Valitud kuupäev: {datePicker.Date:D}";
		};

		timePicker = new TimePicker
		{
			Time = DateTime.Now.TimeOfDay,
            //Time = new TimeSpan(12, 0, 0),
            HorizontalOptions = LayoutOptions.Center,
            Format = "T"
        };


		timePicker.PropertyChanged += (sender, e) =>
		{
            lbl_time.Text = $"Valitud kellaaeg: \n{timePicker.Time}";

        };

		lbl_time = new Label
		{
			Text = "Vali kuupäev või aeg",
			FontSize = 24,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

		al = new AbsoluteLayout { Children = { datePicker, timePicker, lbl_time } };

		//AbsoluteLayout.SetLayoutBounds(datePicker, new Rect(0.5, 0.2, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
		//AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.PositionProportional);
		//      AbsoluteLayout.SetLayoutBounds(timePicker, new Rect(0.5, 0.4, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
		//      AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.PositionProportional);
		//      AbsoluteLayout.SetLayoutBounds(lbl_time, new Rect(0.5, 0.6, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
		//      AbsoluteLayout.SetLayoutFlags(lbl_time, AbsoluteLayoutFlags.PositionProportional);

		List<View> controls = new List<View> { datePicker, timePicker, lbl_time };
		for (int i = 0; i < controls.Count; i++)
		{
			double yKoht = 0.2 + i * 0.2;
			AbsoluteLayout.SetLayoutBounds(controls[i], new Rect(0.5, yKoht, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags(controls[i], AbsoluteLayoutFlags.PositionProportional);
        }

        Content = al;
    }
}