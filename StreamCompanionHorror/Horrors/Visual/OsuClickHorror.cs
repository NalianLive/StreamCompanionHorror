using System.Windows.Forms;

namespace StreamCompanionHorror.Horrors.Visual
{
    internal class OsuClickHorror : IHorror
    {
        public HorrorType GetHorrorType() => HorrorType.Visual;
        public void Execute() => Application.Run(new VisualHorrorForm(Properties.Resources.osuClick));
    }
}
