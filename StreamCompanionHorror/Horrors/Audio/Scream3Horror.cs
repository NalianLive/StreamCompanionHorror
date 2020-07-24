using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class Scream3Horror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.scream3);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}