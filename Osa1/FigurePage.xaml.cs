using Microsoft.Maui.Controls.Shapes;

namespace Osa1;

public partial class FigurePage : ContentPage
{
	BoxView boxView;
    Ellipse pall;
    Polygon kolmnurk;
    ScrollView sv;
    Random rnd = new Random();
    HorizontalStackLayout hsl;
    VerticalStackLayout vsl;
    List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };
    public FigurePage()
	{
        //BoxView
        int r = rnd.Next(256);
        int g = rnd.Next(256);
        int b = rnd.Next(256);

        boxView = new BoxView
        {
            Color = Color.FromRgb(r, g, b), 
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 30
        };
        TapGestureRecognizer tap = new TapGestureRecognizer();
        boxView.GestureRecognizers.Add(tap);
        tap.Tapped += (sender, e) =>
        {
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            boxView.Color = Color.FromRgb(r, g, b);
            boxView.WidthRequest = boxView.Width + 20;
            boxView.HeightRequest= boxView.Height + 30;
            if (boxView.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width/3)
            {
                boxView.WidthRequest = 200;
                boxView.HeightRequest = 200;
            }
        };

        //Ellipse kasutamine
        pall = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Color.FromRgb(g, r, b)),
            Stroke = Colors.DodgerBlue,
            StrokeThickness=5,
            HorizontalOptions = LayoutOptions.Center
        };
        TapGestureRecognizer tap1 = new TapGestureRecognizer();
        pall.GestureRecognizers.Add(tap1);
        tap1.Tapped += (sender, e) =>
        {
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            pall.Fill = new SolidColorBrush(Color.FromRgb(g, r, b));
            pall.WidthRequest = pall.Width + 20;
            pall.HeightRequest = pall.Height + 20;
            if (pall.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width / 3)
            {
                pall.WidthRequest = 200;
                pall.HeightRequest = 200;
            }
        };

        //Polygon kasutamine
        kolmnurk = new Polygon
        {
            Points = new PointCollection
            {
                new Point(0,200),//vasak all
                new Point(100,0),//keskel
                new Point(200,200)//parem all
            },
            Fill = new SolidColorBrush(Color.FromRgb(g, r, b)),
            Stroke = Colors.DarkMagenta,
            StrokeThickness  = 5,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        TapGestureRecognizer tap2 = new TapGestureRecognizer();
        kolmnurk.GestureRecognizers.Add(tap2);
        tap2.Tapped += (sender, e) =>
        {
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            kolmnurk.Fill = new SolidColorBrush(Color.FromRgb(r, b, g));
            kolmnurk.WidthRequest = kolmnurk.Width + 20;
            kolmnurk.HeightRequest = kolmnurk.Height + 20;
            if (kolmnurk.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width / 3)
            {
                kolmnurk.WidthRequest = 200;
                kolmnurk.HeightRequest = 200;
            }
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
                TextColor = Colors.Black,
                BackgroundColor = Colors.LightBlue,
                CornerRadius = 10,
                HeightRequest = 40,
                ZIndex = j
            };
            hsl.Add(nupp);
            nupp.Clicked += Liikumine;
        }
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            HorizontalOptions = LayoutOptions.Center,
            Children = { boxView, hsl, pall, kolmnurk }
        };
        sv = new ScrollView { Content = vsl };
        Content = sv;

    }
    private void Liikumine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;
        if (nupp.ZIndex == 0)
        {
            Navigation.PushAsync(new TextPage(0));
        }
        else if (nupp.ZIndex == 1)
        {
            Navigation.PopToRootAsync();
        }
        else if (nupp.ZIndex == 2)
        {
            Navigation.PushAsync(new TimerPage());
        }
    }
}