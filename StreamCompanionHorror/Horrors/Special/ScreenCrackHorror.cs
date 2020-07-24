using System.Media;
using System.Windows.Forms;

namespace StreamCompanionHorror.Horrors.Special
{
    internal class ScreenCrackHorror : IHorror
    {
        private readonly SoundPlayer _player = new SoundPlayer(Properties.Resources.screenSmash);
        public HorrorType GetHorrorType() => HorrorType.Special;

        public void Execute()
        {
            _player.Play();
            Application.Run(new VisualHorrorForm(Properties.Resources.screenCrack));
        }
    }
}