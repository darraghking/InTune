using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTune.Model
{
    class Sound
    {
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
    }

    // Populate categories


    public enum SoundCategory
    {
        // Categories
        Strings,
        Chords
    }
}
