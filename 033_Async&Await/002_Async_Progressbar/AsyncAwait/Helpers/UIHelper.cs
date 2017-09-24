using System;
using System.Linq;
using System.Windows.Forms;

namespace AsyncAwait.Helpers
{
    internal static class UIHelper
    {
        internal static void EnableControls<T>(this Control controlPanel, Func<T, bool> predicate = null)
              where T : Control
        {
            SwitchControls(controlPanel, true, predicate);
        }
        internal static void DisableControls<T>(this Control controlPanel, Func<T, bool> predicate = null)
           where T : Control
        {
            SwitchControls(controlPanel, false, predicate);
        }

        private static void SwitchControls<T>(Control controlPanel, bool enable, Func<T,bool> predicate)
           where T : Control
        {
            var controls = controlPanel.Controls.OfType<T>();

            if (predicate != null) controls = controls.Where(predicate);

            foreach (var control in controls)
            {
                control.Enabled = enable;
            }

        }
    }
}
