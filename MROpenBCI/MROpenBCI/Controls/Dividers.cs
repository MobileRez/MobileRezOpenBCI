using System.Windows.Input;
using Xamarin.Forms;

namespace MROpenBCI.Controls
{
    public class HeaderDivider : ContentView
    {
        public HeaderDivider()
        {
            Content = new BoxView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = GetHightRequest() //Device.OnPlatform(0.5, 1, 1)
            };
            Content.SetDynamicResource(BackgroundColorProperty, "Divider");

            double GetHightRequest()
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return 0.5;
                    case Device.iOS:
                        return 1;
                    case Device.UWP:
                        return 1;
                    default:
                        return 1;
                }
            }



        }
    }

    public class FooterDivider : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            "Text", typeof(string), typeof(FooterDivider));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command", typeof(ICommand), typeof(FooterDivider));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            "CommandParameter", typeof(object), typeof(FooterDivider));

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        public FooterDivider()
        {
            Content = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
            };

            Padding = 10;
            Content.IsVisible = IsContentVisible(); //Device.OnPlatform(false, true, true);
            Content.SetDynamicResource(Label.StyleProperty, "BaseLabelTextStyle");
            SetDynamicResource(BackgroundColorProperty, "Divider");
            Content.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));

            var tgr = new TapGestureRecognizer();
            tgr.SetBinding(TapGestureRecognizer.CommandProperty, new Binding(nameof(Command), source: this));
            tgr.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding(nameof(CommandParameter), source: this));
            GestureRecognizers.Add(tgr);
        }

        bool IsContentVisible()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    return false;
                case Device.iOS:
                    return true;
                case Device.UWP:
                    return true;
                default:
                    return true;
            }
        }


    }
}
