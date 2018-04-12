using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Gets instances of sounds
namespace InTune.Model
{
    // Whats passing in from MainPage.xaml.cs
    // Gets instances of sound
    public class SoundManager
    {
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = getSounds();
            sounds.Clear();
            /* Lambda Expression */
            allSounds.ForEach(p => sounds.Add(p));
        }

        public static void getSoundsByCategory(ObservableCollection<Sound> sounds, SoundCategory soundCategory)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(p => p.Category == soundCategory).ToList();
            sounds.Clear();
            filteredSounds.ForEach(p => sounds.Add(p));
        }

        public static void GetSoundsByName(ObservableCollection<Sound> sounds, string name)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(p => p.Name == name).ToList();
            sounds.Clear();
            filteredSounds.ForEach(p => sounds.Add(p));
        }

        // Returns list of sounds
        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();

            // Individual Strings
            sounds.Add(new Sound("6EString", SoundCategory.Strings));
            sounds.Add(new Sound("5AString", SoundCategory.Strings));
            sounds.Add(new Sound("4DString", SoundCategory.Strings));
            sounds.Add(new Sound("3GString", SoundCategory.Strings));
            sounds.Add(new Sound("2BString", SoundCategory.Strings));
            sounds.Add(new Sound("1EString", SoundCategory.Strings));

            // Chords
            sounds.Add(new Sound("AMajorChord", SoundCategory.Chords));
            sounds.Add(new Sound("AMinorChord", SoundCategory.Chords));
            sounds.Add(new Sound("CMajorChord", SoundCategory.Chords));
            sounds.Add(new Sound("DMajorChord", SoundCategory.Chords));
            sounds.Add(new Sound("EMajorChord", SoundCategory.Chords));
            sounds.Add(new Sound("EMinorChord", SoundCategory.Chords));
            sounds.Add(new Sound("GMajorChord", SoundCategory.Chords));

            return sounds;
        }
    }
}
