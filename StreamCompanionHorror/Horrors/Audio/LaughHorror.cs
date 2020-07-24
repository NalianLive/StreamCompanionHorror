using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class LaughHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.laugh);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}
