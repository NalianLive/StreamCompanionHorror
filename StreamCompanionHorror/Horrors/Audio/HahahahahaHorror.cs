using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class HahahahahaHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.hahahahaha);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}