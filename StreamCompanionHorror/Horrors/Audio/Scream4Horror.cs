using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class Scream4Horror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.scream4);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}