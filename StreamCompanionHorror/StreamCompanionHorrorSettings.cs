using System;
using System.Windows.Forms;

namespace StreamCompanionHorror
{
    public partial class StreamCompanionHorrorSettings : UserControl
    {
        private readonly HorrorConfiguration _configuration;

        internal delegate void ConfigUpdateEventHandler();
        internal event ConfigUpdateEventHandler ConfigUpdated;

        public StreamCompanionHorrorSettings(HorrorConfiguration configuration)
        {
            _configuration = configuration;
            InitializeComponent();

            checkboxEnable.Checked = _configuration.Enable;
        }

        private void checkboxEnable_CheckedChanged(object sender, EventArgs e)
        {
            _configuration.Enable = checkboxEnable.Checked;
            ConfigUpdated?.Invoke();
        }
    }
}
