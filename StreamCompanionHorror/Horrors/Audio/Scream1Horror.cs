using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class Scream1Horror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.scream1);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}