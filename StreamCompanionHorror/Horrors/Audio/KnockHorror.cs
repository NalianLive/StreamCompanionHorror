using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class KnockHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.knock);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}
