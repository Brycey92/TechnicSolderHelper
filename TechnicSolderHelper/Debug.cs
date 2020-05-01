﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TechnicSolderHelper
{
    public class Debug
    {
        private static readonly string Output =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                "DebugFromModpackHelper.txt");
        private static readonly StringBuilder sb = new StringBuilder();
        private static CheckBox _box;

        public static void AssignCheckbox(CheckBox checkBox)
        {
            _box = checkBox;
        }

        public static void WriteLine(string text, bool condition = false)
        {
            System.Diagnostics.Debug.WriteLine(text);
            if (condition || _box != null && _box.Checked)
            {
                sb.AppendLine(text);
            }
        }

        public static void WriteLine(object o, bool condition = false)
        {
            try
            {
                WriteLine(o.ToString(), condition);
            }
            catch (Exception)
            {
                // Ignored
            }
        }

        public static void Save()
        {
            if (!string.IsNullOrWhiteSpace(sb.ToString()))
                File.AppendAllText(Output, sb.ToString());
            sb.Clear();
        }
    }
}
