using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClassModels
{
    /// <summary>
    /// DefaultExceptionHandler is used to display an error message when an unhandled
    /// exception occurs on the GUI thread.
    /// </summary>
    internal class DefaultExceptionHandler
    {
        // Handles the exception event.
        public void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = this.ShowThreadExceptionDialog(t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private DialogResult ShowThreadExceptionDialog(Exception e)
        {
            string errorMsg = "An unexpected error occurred. Please contact support with the following information:\n\n";
            errorMsg = errorMsg + e.GetType().Name + ": " + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

    }
}

