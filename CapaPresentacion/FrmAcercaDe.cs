using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmAcercaDe : Form
    {
        public FrmAcercaDe()
        {
            InitializeComponent();
        }

        private void lklLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void FrmAcercaDe_Load(object sender, EventArgs e)
        {
            lklGitHub.Links.Add(0, lklGitHub.Text.Length, "https://github.com/robertlluberes/");
            lklLinkedIn.Links.Add(0, lklLinkedIn.Text.Length, "https://do.linkedin.com/in/robertlluberes");
            lklTutorial.Links.Add(0, lklTutorial.Text.Length, "https://www.youtube.com/playlist?list=PLZPrWDz1Molqn16IORKg8nFYTejgYCHJp");

        }

        private void lklGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void lklTutorial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
    }
}
