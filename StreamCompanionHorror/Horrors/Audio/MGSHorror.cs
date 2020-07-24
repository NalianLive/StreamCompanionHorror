using System.Media;

namespace StreamCompanionHorror.Horrors.Audio
{
    // ReSharper disable once InconsistentNaming
    internal class MGSHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.mgs);
        public HorrorType GetHorrorType() => HorrorType.Audio;
        public void Execute() => _player.Play();
    }
}