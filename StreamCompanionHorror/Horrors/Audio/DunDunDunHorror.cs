using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class DunDunDunHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.dunDunDun);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}