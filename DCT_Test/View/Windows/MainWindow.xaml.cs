﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DCT_Test.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SwitchLanguage("en");
            SwitchStyle("Light");
        }
        private void NumberValidTB(object sender, TextCompositionEventArgs eventArgs)
        {
            Regex regex = new Regex("[^0-9.]+");
            eventArgs.Handled = regex.IsMatch(eventArgs.Text);
        }
        private void ChooseEnglishLang(object sender, RoutedEventArgs eventArgs) =>
            SwitchLanguage("en");

        private void ChooseUkrainianLang(object sender, RoutedEventArgs eventArgs) =>
            SwitchLanguage("ua");

        private void ChooseRussianLang(object sender, RoutedEventArgs eventArgs) =>
            SwitchLanguage("ru");

        private void ChooseLightTheme(object sender, RoutedEventArgs e)
        {
            SwitchStyle("Light");
        }
        private void ChooseDarkTheme(object sender, RoutedEventArgs e)
        {
            SwitchStyle("Dark");
        }
        private void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (languageCode)
            {
                case "en":
                    dictionary.Source = new Uri("..\\DCT.Domain/Lang/EN.xaml", UriKind.Relative);
                    break;
                case "ua":
                    dictionary.Source = new Uri("..\\DCT.Domain/Lang/UA.xaml", UriKind.Relative);
                    break;
                case "ru":
                    dictionary.Source = new Uri("..\\DCT.Domain/Lang/RU.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("..\\DCT.Domain/Lang/EN.xaml", UriKind.Relative);
                    break;
            }

            this.Resources.MergedDictionaries.Add(dictionary);
        }

        private void SwitchStyle(string styleName)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (styleName)
            {
                case "Dark":
                    dictionary.Source = new Uri("..\\DCT.Domain/Theme/Dark.xaml", UriKind.Relative);
                    break;
                case "Light":
                    dictionary.Source = new Uri("..\\DCT.Domain/Theme/Light.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("..\\DCT.Domain/Theme/Light.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
