using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class NopeHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.nope);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}