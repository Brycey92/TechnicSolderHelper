﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using TechnicSolderHelper.confighandler;
using TechnicSolderHelper.cryptography;

namespace TechnicSolderHelper.FileUpload
{
    public partial class ftpInfo : Form
    {
        public ftpInfo()
        {
            InitializeComponent();
            String url = "";
            String username = "";
            String pass = "";
            Crypto crypto = new Crypto();
            try
            {
                ConfigHandler ch = new ConfigHandler();
                url = ch.getConfig("ftpUrl");
                username = ch.getConfig("ftpUserName");
                pass = crypto.DecryptString(ch.getConfig("ftpPassword"));
            }
            catch (Exception)
            {
            }
            Username.Text = username;
            Password.Text = pass;
            Host.Text = url;
        }

        private void Acceptbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Username.Text) || String.IsNullOrWhiteSpace(Password.Text) || String.IsNullOrWhiteSpace(Host.Text))
            {
                MessageBox.Show("Please fill out all values");
                return;
            }
            else
            {
                String url = Host.Text;
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    Crypto crypto = new Crypto();
                    ConfigHandler ch = new ConfigHandler();
                    ch.setConfig("ftpUserName", Username.Text);
                    ch.setConfig("ftpUrl", url);
                    ch.setConfig("ftpPassword", crypto.EncryptToString(Password.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hostname is not valid");
                    return;
                }

            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            String url = Host.Text;
            String name = Username.Text;
            String pass = Password.Text;

            MessageBox.Show(isValidConnection(url, name, pass));
        }

        private String isValidConnection(string url, string user, string password)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    request.Credentials = new NetworkCredential(user, password);
                    request.GetResponse();
                }
                catch (WebException ex)
                {
                    return ex.Message;
                }
                return "All is working fine!!";
            }
            else
            {
                return "Invalid hostname";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
