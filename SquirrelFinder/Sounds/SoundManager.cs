using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Sounds
{
    public enum SquirrelFinderSound
    {
        None,
        FlatLine,
        Gears,
        Squirrel
    }

    public class SoundManager
    {
        static SoundPlayer _player = new SoundPlayer();

        SquirrelFinderSound _currentSound = SquirrelFinderSound.None;

        static string _squirrelSound = AppDomain.CurrentDomain.BaseDirectory + "\\sounds\\squirrel.wav";
        static string _gearsSound = AppDomain.CurrentDomain.BaseDirectory + "\\sounds\\gears.wav";
        static string _flatLine = AppDomain.CurrentDomain.BaseDirectory + "\\sounds\\flatline.wav";

        public SoundManager()
        {

        }

        public virtual void PlayTone(SquirrelFinderSound sound)
        {
            if (sound == _currentSound) return;
            _currentSound = sound;

            var soundToPlay = "";
            switch (sound)
            {
                case SquirrelFinderSound.FlatLine:
                    soundToPlay = _flatLine;
                    //CurrentState = NutState.Lost;
                    break;
                case SquirrelFinderSound.Gears:
                    soundToPlay = _gearsSound;
                    //CurrentState = NutState.Searching;
                    break;
                case SquirrelFinderSound.Squirrel:
                    soundToPlay = _squirrelSound;
                    //CurrentState = NutState.Found;
                    break;
            }

            if (sound != SquirrelFinderSound.None)
            {
                _player.Stop();
                _player.SoundLocation = soundToPlay;
                _player.Play();
            }
        }
    }
}
