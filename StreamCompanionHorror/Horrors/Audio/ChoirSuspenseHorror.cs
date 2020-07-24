using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class ChoirSuspenseHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.choirSuspense);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}