using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Xml.Linq;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

namespace BreakOut_Ver1
{
    public class Sound
    {
        public float volume;
        public string soundName;
        public SoundEffect sound;
        public SoundEffect instance;

        public Sound(string soundName, string soundPath, float volume)
        {
            //this.soundName = soundName;
            //this.volume = volume;
            //this.sound = Globals.content.Load<SoundEffect>(soundPath);
            ////https://www.youtube.com/watch?v=JykpElYLIk8
        }

    }
}
