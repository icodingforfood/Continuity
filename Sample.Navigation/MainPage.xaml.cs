﻿using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace Sample.Navigation
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            // The following cannot be done in XAML in this build yet.
            MyNavigationView.AddMenuItem(Symbol.AllApps, "All Applications", (s, e) => RootFrame.Navigate(typeof(AppsPage)), true);
            MyNavigationView.AddMenuItem(Symbol.Video, "Games", (s, e) => RootFrame.Navigate(typeof(GamesPage)));
            MyNavigationView.AddMenuItem(Symbol.Calendar, "Calendar", (s, e) => RootFrame.Navigate(typeof(CalendarPage)));
            MyNavigationView.AddMenuItemSeparator();
            MyNavigationView.AddMenuItem(Symbol.Admin, "My Account", (s, e) => RootFrame.Navigate(typeof(AccountPage)));

            MyNavigationView.SettingsInvoked += (s, e) => RootFrame.Navigate(typeof(SettingsPage));
            RootFrame.Navigate(typeof(AppsPage));
        }
    }

    public static class NavigationViewExtensions
    {
        public static void AddMenuItem(this NavigationView navigationView, Symbol icon, string text,
            TypedEventHandler<NavigationMenuItem, object> handler, bool selected = false)
        {
            var item = new NavigationMenuItem
            {
                Icon = new SymbolIcon(icon),
                Text = text,
                IsSelected = selected
            };
            item.Invoked += handler;
            navigationView.MenuItems.Add(item);
        }

        public static void AddMenuItemSeparator(this NavigationView navigationView)
        {
            var item = new NavigationMenuItemSeparator();
            navigationView.MenuItems.Add(item);
        }
    }
}