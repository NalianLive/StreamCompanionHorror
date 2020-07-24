using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    internal class SadTromboneHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.sadTrombone);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}