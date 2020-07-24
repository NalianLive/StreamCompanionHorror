using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class Scream2Horror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.scream2);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}