using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace FightingHeroes.Sound
{
    static class SoundEffect
    {
        public static void GetSound(UnmanagedMemoryStream resource)
        {
            Stream str = resource;
            PlaySound(str);
        }

        public static void PlaySound(Stream stream)
        {
            SoundPlayer sound = new SoundPlayer(stream);
            sound.Play();
        }
    }
}
