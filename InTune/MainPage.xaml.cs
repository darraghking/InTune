using InTune.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InTune
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<Sound> Sounds;
        private List<String> Suggestions;
        private List<MenuItem> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);

            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/guitarIcon.png", Category = SoundCategory.Strings });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/guitarChordIcon.png", Category = SoundCategory.Chords });

            butBackButton.Visibility = Visibility.Collapsed;
        }

        private void butCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;

            // Filter per category
            CategoryTextBlock.Text = menuItem.Category.ToString();
            SoundManager.getSoundsByCategory(Sounds, menuItem.Category);
            butBackButton.Visibility = Visibility.Visible;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);
        }

        private void butBackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(Sounds);
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            butBackButton.Visibility = Visibility.Collapsed;
        }

        // When the back button is called or when the text changes in the AutoSuggestBox
        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // If the AutoSuggestBox is empty call goBack
            if (String.IsNullOrEmpty(sender.Text)) goBack();

            SoundManager.GetAllSounds(Sounds);
            Suggestions = Sounds
                .Where(p => p.Name.StartsWith(sender.Text))
                .Select(p => p.Name)
                .ToList();
            SearchAutoSuggestBox.ItemsSource = Suggestions;
        }

        // Contains all the functionality needed to put the application in a valid state after it leaves the search bar or back button
        private void goBack()
        {
            // Get all sounds
            SoundManager.GetAllSounds(Sounds);
            // Set title to "All Sounds"
            CategoryTextBlock.Text = "All Sounds";
            // Set to no selection
            MenuItemsListView.SelectedItem = null;
            butBackButton.Visibility = Visibility.Collapsed;
        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            SoundManager.GetSoundsByName(Sounds, sender.Text);
            CategoryTextBlock.Text = sender.Text;
            MenuItemsListView.SelectedItem = null;
            butBackButton.Visibility = Visibility.Visible;
        }

       

       
    }
}
