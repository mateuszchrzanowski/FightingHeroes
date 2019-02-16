using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace FightingHeroes.Sound
{
    static class SoundEffect
    {
        public static void GetSound(string location)
        {
            var sound = new SoundPlayer
            {
                SoundLocation = location
            };
            sound.Play();
        }
    }
}
