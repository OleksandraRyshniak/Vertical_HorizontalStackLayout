namespace Osa1;

public partial class StartPage : ContentPage
{
    VerticalStackLayout vst;
    ScrollView sv;

    public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(0), new FigurePage(), new TimerPage(), new DateTimePage(), new StepperSliderPage(), new RGB_color()};
    public List<string> LeheNimed = new List<string>() { "Tekst", "Joonis", "Timer", "Kuupäev/Aeg", "Liigur", "Värv" };

    public StartPage()
    {
        Title = "Avaleht";
        vst = new VerticalStackLayout { Padding = 20, Spacing = 15 };
        for (int i = 0; i < Lehed.Count; i++)
        {
            Button nupp = new Button
            {
                Text = LeheNimed[i],
                FontSize = 18,
                FontFamily = "Impact",
                BackgroundColor = Colors.Blue,
                TextColor = Colors.Black,
                ZIndex = i,
                HeightRequest = 50,
                CornerRadius = 10
            };
            vst.Add(nupp);
            nupp.Clicked += (sender, e) =>
            {
                var valik = Lehed[nupp.ZIndex];
                Navigation.PushAsync(valik);
            };
        }
        sv = new ScrollView { Content = vst };
        Content = sv;

    }
}