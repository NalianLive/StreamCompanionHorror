using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class DunHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.dun);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}