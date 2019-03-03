using System;
using System.Media;
using System.Windows.Forms;

namespace Geotail
{
    internal static class WinFormsUtil
    {
        /// <summary>
        /// Displays a dialog showing the details of an error.
        /// </summary>
        /// <param name="lines">User-friendly message about the error.</param>
        /// <returns>The <see cref="DialogResult"/> associated with the dialog.</returns>
        internal static DialogResult Error(params string[] lines)
        {
            SystemSounds.Hand.Play();
            var msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, nameof(Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static DialogResult Alert(params string[] lines)
        {
            SystemSounds.Asterisk.Play();
            var msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, nameof(Alert), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static DialogResult Prompt(MessageBoxButtons btn, params string[] lines)
        {
            SystemSounds.Question.Play();
            var msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, nameof(Prompt), btn, MessageBoxIcon.Asterisk);
        }
    }
}
