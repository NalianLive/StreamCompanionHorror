using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class SuspenseHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.suspense);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}