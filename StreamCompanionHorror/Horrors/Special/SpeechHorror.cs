using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace StreamCompanionHorror.Horrors.Special
{
    internal class SpeechHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.screenSmash);
        private readonly SpeechSynthesizer _synth = new SpeechSynthesizer();
        private readonly List<string> _lines = new List<string>
        {
            "Shit",
            "Fuck",
            "I'm gaming",
            "Pain",
            "This is neverending suffering",
            "You'll never get 800 p p",
            "Another miss?",
            "Beast Troll M C",
            "@@@@@@@@@@@@@@@@@@@@@@@@@",
            "Zallius' eyes have awakened"
        };

        public HorrorType GetHorrorType() => HorrorType.Special;

        public SpeechHorror()
        {
            _synth.SetOutputToDefaultAudioDevice();
        }

        public void Execute() => _synth.Speak(_lines.OrderBy(_ => Guid.NewGuid()).First());
    }
}