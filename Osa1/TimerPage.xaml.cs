namespace Osa1;

public partial class TimerPage : ContentPage
{
    Label lbl;
    HorizontalStackLayout hsl;
    VerticalStackLayout vsl;
    Button btn;
    List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };
    public TimerPage()
	{
        lbl = new Label
        {
            Text = "Timer",
            FontSize = 36,
            FontFamily = "Impact",
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center,
            FontAttributes = FontAttributes.Bold
        };
        hsl = new HorizontalStackLayout
        {
            Spacing = 20,
            HorizontalOptions = LayoutOptions.Center
        };
        for (int j = 0; j < nupud.Count; j++)
        {
            Button nupp = new Button
            {
                Text = nupud[j],
                FontSize = 18,
                FontFamily = "Impact",
                TextColor = Colors.Black,
                BackgroundColor = Colors.LightBlue,
                CornerRadius = 10,
                HeightRequest = 40,
                ZIndex = j
            };
            hsl.Add(nupp);
            nupp.Clicked += Liikumine;
        }
        btn = new Button
        {
            Text = "Info",
            FontSize = 18,
            FontFamily = "Impact",
            TextColor = Colors.Black,
            BackgroundColor = Colors.LightBlue,
            CornerRadius = 10,
            HeightRequest = 40
        };
        btn.Clicked += timer_btn_Clicked;
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            HorizontalOptions = LayoutOptions.Center,
            Children = { lbl, hsl, btn }
        };
        Content = vsl;
        
    }
    private void Liikumine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;
        if (nupp.ZIndex == 0)
        {
            Navigation.PushAsync(new FigurePage());
        }
        else if (nupp.ZIndex == 1)
        {
            Navigation.PopToRootAsync();
        }
        else if (nupp.ZIndex == 2)
        {
            Navigation.PushAsync(new TextPage(0));
        }
    }


    bool on_off = true;
    private async void ShowTime()
    {
        while (on_off)
        {
            btn.Text = DateTime.Now.ToString("T");
            await Task.Delay(1000);
        }
    }
    private void timer_btn_Clicked (object sender, EventArgs e)
    {
        if (on_off)
        {
            on_off = false;
        }
        else
        {
            on_off = true;
        }
        ShowTime();
    }
}