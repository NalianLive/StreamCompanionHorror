using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class InceptionHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.inception);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}