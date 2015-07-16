﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModpackHelper.UserInteraction;

namespace ModpackHelper.GUI.UserInteraction
{
    public class MessageShower : IMessageShower
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowMessageAsync(string message)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (sender, e) =>
            {
                MessageBox.Show(message);
            };
            bw.RunWorkerAsync();
        }
    }
}
