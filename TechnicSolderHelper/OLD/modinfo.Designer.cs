﻿using System.ComponentModel;
using System.Windows.Forms;

namespace TechnicSolderHelper.OLD
{
    partial class Modinfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.modlist = new System.Windows.Forms.ListBox();
            this.dataBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxModVersion = new System.Windows.Forms.TextBox();
            this.textBoxModID = new System.Windows.Forms.TextBox();
            this.textBoxModName = new System.Windows.Forms.TextBox();
            this.technicPermissions = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTechnicLicenseLink = new System.Windows.Forms.TextBox();
            this.textBoxTechnicModLink = new System.Windows.Forms.TextBox();
            this.textBoxTechnicPermissionLink = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.showDone = new System.Windows.Forms.CheckBox();
            this.FTBPermissions = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxFTBLicenseLink = new System.Windows.Forms.TextBox();
            this.textBoxFTBModLink = new System.Windows.Forms.TextBox();
            this.textBoxFTBPermissionLink = new System.Windows.Forms.TextBox();
            this.getPermissions = new System.Windows.Forms.Button();
            this.Done = new System.Windows.Forms.Button();
            this.skipmod = new System.Windows.Forms.CheckBox();
            this.permssionFTBUnknown = new ReadOnlyRadioButton();
            this.permissionFTBRequest = new ReadOnlyRadioButton();
            this.permissionFTBNotify = new ReadOnlyRadioButton();
            this.permissionFTBClosed = new ReadOnlyRadioButton();
            this.permissionFTBFTBExclusive = new ReadOnlyRadioButton();
            this.permissionFTBOpen = new ReadOnlyRadioButton();
            this.permissionTechnicUnknown = new ReadOnlyRadioButton();
            this.permissionTechnicRequest = new ReadOnlyRadioButton();
            this.permissionTechnicNotify = new ReadOnlyRadioButton();
            this.permissionTechnicClosed = new ReadOnlyRadioButton();
            this.permissionTechnicFTBExclusive = new ReadOnlyRadioButton();
            this.permissionTechnicOpen = new ReadOnlyRadioButton();
            this.dataBox.SuspendLayout();
            this.technicPermissions.SuspendLayout();
            this.FTBPermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // modlist
            // 
            this.modlist.FormattingEnabled = true;
            this.modlist.Location = new System.Drawing.Point(12, 30);
            this.modlist.Name = "modlist";
            this.modlist.Size = new System.Drawing.Size(163, 381);
            this.modlist.TabIndex = 0;
            this.modlist.SelectedIndexChanged += new System.EventHandler(this.modlist_SelectedIndexChanged);
            // 
            // dataBox
            // 
            this.dataBox.Controls.Add(this.label8);
            this.dataBox.Controls.Add(this.label4);
            this.dataBox.Controls.Add(this.label3);
            this.dataBox.Controls.Add(this.label2);
            this.dataBox.Controls.Add(this.label1);
            this.dataBox.Controls.Add(this.textBoxFileName);
            this.dataBox.Controls.Add(this.textBoxAuthor);
            this.dataBox.Controls.Add(this.textBoxModVersion);
            this.dataBox.Controls.Add(this.textBoxModID);
            this.dataBox.Controls.Add(this.textBoxModName);
            this.dataBox.Location = new System.Drawing.Point(181, 13);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(253, 251);
            this.dataBox.TabIndex = 1;
            this.dataBox.TabStop = false;
            this.dataBox.Text = "Mod Data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "File Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mod Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ModID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mod Name";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(24, 211);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(205, 20);
            this.textBoxFileName.TabIndex = 5;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(24, 167);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(205, 20);
            this.textBoxAuthor.TabIndex = 4;
            this.textBoxAuthor.TextChanged += new System.EventHandler(this.textBoxAuthor_TextChanged);
            // 
            // textBoxModVersion
            // 
            this.textBoxModVersion.Location = new System.Drawing.Point(24, 124);
            this.textBoxModVersion.Name = "textBoxModVersion";
            this.textBoxModVersion.Size = new System.Drawing.Size(205, 20);
            this.textBoxModVersion.TabIndex = 3;
            this.textBoxModVersion.TextChanged += new System.EventHandler(this.textBoxModVersion_TextChanged);
            // 
            // textBoxModID
            // 
            this.textBoxModID.Location = new System.Drawing.Point(24, 80);
            this.textBoxModID.Name = "textBoxModID";
            this.textBoxModID.Size = new System.Drawing.Size(205, 20);
            this.textBoxModID.TabIndex = 2;
            this.textBoxModID.TextChanged += new System.EventHandler(this.textBoxModID_TextChanged);
            // 
            // textBoxModName
            // 
            this.textBoxModName.Location = new System.Drawing.Point(24, 36);
            this.textBoxModName.Name = "textBoxModName";
            this.textBoxModName.Size = new System.Drawing.Size(205, 20);
            this.textBoxModName.TabIndex = 1;
            this.textBoxModName.TextChanged += new System.EventHandler(this.textBoxModName_TextChanged);
            // 
            // technicPermissions
            // 
            this.technicPermissions.Controls.Add(this.label7);
            this.technicPermissions.Controls.Add(this.label6);
            this.technicPermissions.Controls.Add(this.label5);
            this.technicPermissions.Controls.Add(this.permissionTechnicUnknown);
            this.technicPermissions.Controls.Add(this.permissionTechnicRequest);
            this.technicPermissions.Controls.Add(this.permissionTechnicNotify);
            this.technicPermissions.Controls.Add(this.permissionTechnicClosed);
            this.technicPermissions.Controls.Add(this.textBoxTechnicLicenseLink);
            this.technicPermissions.Controls.Add(this.textBoxTechnicModLink);
            this.technicPermissions.Controls.Add(this.textBoxTechnicPermissionLink);
            this.technicPermissions.Controls.Add(this.permissionTechnicFTBExclusive);
            this.technicPermissions.Controls.Add(this.permissionTechnicOpen);
            this.technicPermissions.Location = new System.Drawing.Point(182, 270);
            this.technicPermissions.Name = "technicPermissions";
            this.technicPermissions.Size = new System.Drawing.Size(252, 245);
            this.technicPermissions.TabIndex = 2;
            this.technicPermissions.TabStop = false;
            this.technicPermissions.Text = "Technic Permissions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "License Link";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mod Link";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Permission Link";
            // 
            // textBoxTechnicLicenseLink
            // 
            this.textBoxTechnicLicenseLink.Location = new System.Drawing.Point(23, 201);
            this.textBoxTechnicLicenseLink.Name = "textBoxTechnicLicenseLink";
            this.textBoxTechnicLicenseLink.Size = new System.Drawing.Size(205, 20);
            this.textBoxTechnicLicenseLink.TabIndex = 8;
            this.textBoxTechnicLicenseLink.TextChanged += new System.EventHandler(this.textBoxLicenseLink_TextChanged);
            // 
            // textBoxTechnicModLink
            // 
            this.textBoxTechnicModLink.Location = new System.Drawing.Point(23, 154);
            this.textBoxTechnicModLink.Name = "textBoxTechnicModLink";
            this.textBoxTechnicModLink.Size = new System.Drawing.Size(205, 20);
            this.textBoxTechnicModLink.TabIndex = 7;
            this.textBoxTechnicModLink.TextChanged += new System.EventHandler(this.textBoxModLink_TextChanged);
            // 
            // textBoxTechnicPermissionLink
            // 
            this.textBoxTechnicPermissionLink.Location = new System.Drawing.Point(23, 112);
            this.textBoxTechnicPermissionLink.Name = "textBoxTechnicPermissionLink";
            this.textBoxTechnicPermissionLink.Size = new System.Drawing.Size(205, 20);
            this.textBoxTechnicPermissionLink.TabIndex = 6;
            this.textBoxTechnicPermissionLink.TextChanged += new System.EventHandler(this.textBoxPermissionLink_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Select Mod";
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // showDone
            // 
            this.showDone.AutoSize = true;
            this.showDone.Location = new System.Drawing.Point(12, 417);
            this.showDone.Name = "showDone";
            this.showDone.Size = new System.Drawing.Size(82, 17);
            this.showDone.TabIndex = 15;
            this.showDone.Text = "Show Done";
            this.toolTip1.SetToolTip(this.showDone, "Show all items, even the once without any issues.\r\nCurrently only showing files w" +
        "ith issues.");
            this.showDone.UseVisualStyleBackColor = true;
            this.showDone.CheckedChanged += new System.EventHandler(this.showDone_CheckedChanged);
            // 
            // FTBPermissions
            // 
            this.FTBPermissions.Controls.Add(this.label10);
            this.FTBPermissions.Controls.Add(this.label11);
            this.FTBPermissions.Controls.Add(this.label12);
            this.FTBPermissions.Controls.Add(this.permssionFTBUnknown);
            this.FTBPermissions.Controls.Add(this.permissionFTBRequest);
            this.FTBPermissions.Controls.Add(this.permissionFTBNotify);
            this.FTBPermissions.Controls.Add(this.permissionFTBClosed);
            this.FTBPermissions.Controls.Add(this.textBoxFTBLicenseLink);
            this.FTBPermissions.Controls.Add(this.textBoxFTBModLink);
            this.FTBPermissions.Controls.Add(this.textBoxFTBPermissionLink);
            this.FTBPermissions.Controls.Add(this.permissionFTBFTBExclusive);
            this.FTBPermissions.Controls.Add(this.permissionFTBOpen);
            this.FTBPermissions.Location = new System.Drawing.Point(440, 270);
            this.FTBPermissions.Name = "FTBPermissions";
            this.FTBPermissions.Size = new System.Drawing.Size(252, 245);
            this.FTBPermissions.TabIndex = 2;
            this.FTBPermissions.TabStop = false;
            this.FTBPermissions.Text = "FTB Permissions";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "License Link";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Mod Link";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Permission Link";
            // 
            // textBoxFTBLicenseLink
            // 
            this.textBoxFTBLicenseLink.Location = new System.Drawing.Point(23, 201);
            this.textBoxFTBLicenseLink.Name = "textBoxFTBLicenseLink";
            this.textBoxFTBLicenseLink.Size = new System.Drawing.Size(205, 20);
            this.textBoxFTBLicenseLink.TabIndex = 11;
            this.textBoxFTBLicenseLink.TextChanged += new System.EventHandler(this.textBoxLicenseLink_TextChanged);
            // 
            // textBoxFTBModLink
            // 
            this.textBoxFTBModLink.Location = new System.Drawing.Point(23, 154);
            this.textBoxFTBModLink.Name = "textBoxFTBModLink";
            this.textBoxFTBModLink.Size = new System.Drawing.Size(205, 20);
            this.textBoxFTBModLink.TabIndex = 10;
            this.textBoxFTBModLink.TextChanged += new System.EventHandler(this.textBoxModLink_TextChanged);
            // 
            // textBoxFTBPermissionLink
            // 
            this.textBoxFTBPermissionLink.Location = new System.Drawing.Point(23, 112);
            this.textBoxFTBPermissionLink.Name = "textBoxFTBPermissionLink";
            this.textBoxFTBPermissionLink.Size = new System.Drawing.Size(205, 20);
            this.textBoxFTBPermissionLink.TabIndex = 9;
            this.textBoxFTBPermissionLink.TextChanged += new System.EventHandler(this.textBoxPermissionLink_TextChanged);
            // 
            // getPermissions
            // 
            this.getPermissions.Location = new System.Drawing.Point(101, 419);
            this.getPermissions.Name = "getPermissions";
            this.getPermissions.Size = new System.Drawing.Size(75, 44);
            this.getPermissions.TabIndex = 13;
            this.getPermissions.Text = "Get Permissions";
            this.getPermissions.UseVisualStyleBackColor = true;
            this.getPermissions.Click += new System.EventHandler(this.getPermissions_Click);
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(12, 440);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 14;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // skipmod
            // 
            this.skipmod.AutoSize = true;
            this.skipmod.Location = new System.Drawing.Point(101, 473);
            this.skipmod.Name = "skipmod";
            this.skipmod.Size = new System.Drawing.Size(71, 17);
            this.skipmod.TabIndex = 12;
            this.skipmod.Text = "Skip Mod";
            this.skipmod.UseVisualStyleBackColor = true;
            this.skipmod.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // permssionFTBUnknown
            // 
            this.permssionFTBUnknown.AutoSize = true;
            this.permssionFTBUnknown.Location = new System.Drawing.Point(161, 66);
            this.permssionFTBUnknown.Name = "permssionFTBUnknown";
            this.permssionFTBUnknown.ReadOnly = true;
            this.permssionFTBUnknown.Size = new System.Drawing.Size(71, 17);
            this.permssionFTBUnknown.TabIndex = 0;
            this.permssionFTBUnknown.Text = "Unknown";
            this.permssionFTBUnknown.UseVisualStyleBackColor = true;
            // 
            // permissionFTBRequest
            // 
            this.permissionFTBRequest.AutoSize = true;
            this.permissionFTBRequest.Location = new System.Drawing.Point(161, 43);
            this.permissionFTBRequest.Name = "permissionFTBRequest";
            this.permissionFTBRequest.ReadOnly = true;
            this.permissionFTBRequest.Size = new System.Drawing.Size(65, 17);
            this.permissionFTBRequest.TabIndex = 0;
            this.permissionFTBRequest.Text = "Request";
            this.permissionFTBRequest.UseVisualStyleBackColor = true;
            // 
            // permissionFTBNotify
            // 
            this.permissionFTBNotify.AutoSize = true;
            this.permissionFTBNotify.Location = new System.Drawing.Point(23, 66);
            this.permissionFTBNotify.Name = "permissionFTBNotify";
            this.permissionFTBNotify.ReadOnly = true;
            this.permissionFTBNotify.Size = new System.Drawing.Size(52, 17);
            this.permissionFTBNotify.TabIndex = 0;
            this.permissionFTBNotify.Text = "Notify";
            this.permissionFTBNotify.UseVisualStyleBackColor = true;
            // 
            // permissionFTBClosed
            // 
            this.permissionFTBClosed.AutoSize = true;
            this.permissionFTBClosed.Location = new System.Drawing.Point(161, 20);
            this.permissionFTBClosed.Name = "permissionFTBClosed";
            this.permissionFTBClosed.ReadOnly = true;
            this.permissionFTBClosed.Size = new System.Drawing.Size(57, 17);
            this.permissionFTBClosed.TabIndex = 0;
            this.permissionFTBClosed.Text = "Closed";
            this.permissionFTBClosed.UseVisualStyleBackColor = true;
            // 
            // permissionFTBFTBExclusive
            // 
            this.permissionFTBFTBExclusive.AutoSize = true;
            this.permissionFTBFTBExclusive.Location = new System.Drawing.Point(23, 43);
            this.permissionFTBFTBExclusive.Name = "permissionFTBFTBExclusive";
            this.permissionFTBFTBExclusive.ReadOnly = true;
            this.permissionFTBFTBExclusive.Size = new System.Drawing.Size(93, 17);
            this.permissionFTBFTBExclusive.TabIndex = 0;
            this.permissionFTBFTBExclusive.Text = "FTB Exclusive";
            this.permissionFTBFTBExclusive.UseVisualStyleBackColor = true;
            // 
            // permissionFTBOpen
            // 
            this.permissionFTBOpen.AutoSize = true;
            this.permissionFTBOpen.Location = new System.Drawing.Point(23, 20);
            this.permissionFTBOpen.Name = "permissionFTBOpen";
            this.permissionFTBOpen.ReadOnly = true;
            this.permissionFTBOpen.Size = new System.Drawing.Size(51, 17);
            this.permissionFTBOpen.TabIndex = 0;
            this.permissionFTBOpen.Text = "Open";
            this.permissionFTBOpen.UseVisualStyleBackColor = true;
            // 
            // permissionTechnicUnknown
            // 
            this.permissionTechnicUnknown.AutoSize = true;
            this.permissionTechnicUnknown.Location = new System.Drawing.Point(161, 66);
            this.permissionTechnicUnknown.Name = "permissionTechnicUnknown";
            this.permissionTechnicUnknown.ReadOnly = true;
            this.permissionTechnicUnknown.Size = new System.Drawing.Size(71, 17);
            this.permissionTechnicUnknown.TabIndex = 0;
            this.permissionTechnicUnknown.Text = "Unknown";
            this.permissionTechnicUnknown.UseVisualStyleBackColor = true;
            // 
            // permissionTechnicRequest
            // 
            this.permissionTechnicRequest.AutoSize = true;
            this.permissionTechnicRequest.Location = new System.Drawing.Point(161, 43);
            this.permissionTechnicRequest.Name = "permissionTechnicRequest";
            this.permissionTechnicRequest.ReadOnly = true;
            this.permissionTechnicRequest.Size = new System.Drawing.Size(65, 17);
            this.permissionTechnicRequest.TabIndex = 0;
            this.permissionTechnicRequest.Text = "Request";
            this.permissionTechnicRequest.UseVisualStyleBackColor = true;
            // 
            // permissionTechnicNotify
            // 
            this.permissionTechnicNotify.AutoSize = true;
            this.permissionTechnicNotify.Location = new System.Drawing.Point(23, 66);
            this.permissionTechnicNotify.Name = "permissionTechnicNotify";
            this.permissionTechnicNotify.ReadOnly = true;
            this.permissionTechnicNotify.Size = new System.Drawing.Size(52, 17);
            this.permissionTechnicNotify.TabIndex = 0;
            this.permissionTechnicNotify.Text = "Notify";
            this.permissionTechnicNotify.UseVisualStyleBackColor = true;
            // 
            // permissionTechnicClosed
            // 
            this.permissionTechnicClosed.AutoSize = true;
            this.permissionTechnicClosed.Location = new System.Drawing.Point(161, 20);
            this.permissionTechnicClosed.Name = "permissionTechnicClosed";
            this.permissionTechnicClosed.ReadOnly = true;
            this.permissionTechnicClosed.Size = new System.Drawing.Size(57, 17);
            this.permissionTechnicClosed.TabIndex = 0;
            this.permissionTechnicClosed.Text = "Closed";
            this.permissionTechnicClosed.UseVisualStyleBackColor = true;
            // 
            // permissionTechnicFTBExclusive
            // 
            this.permissionTechnicFTBExclusive.AutoSize = true;
            this.permissionTechnicFTBExclusive.Location = new System.Drawing.Point(23, 43);
            this.permissionTechnicFTBExclusive.Name = "permissionTechnicFTBExclusive";
            this.permissionTechnicFTBExclusive.ReadOnly = true;
            this.permissionTechnicFTBExclusive.Size = new System.Drawing.Size(93, 17);
            this.permissionTechnicFTBExclusive.TabIndex = 0;
            this.permissionTechnicFTBExclusive.Text = "FTB Exclusive";
            this.permissionTechnicFTBExclusive.UseVisualStyleBackColor = true;
            // 
            // permissionTechnicOpen
            // 
            this.permissionTechnicOpen.AutoSize = true;
            this.permissionTechnicOpen.Location = new System.Drawing.Point(23, 20);
            this.permissionTechnicOpen.Name = "permissionTechnicOpen";
            this.permissionTechnicOpen.ReadOnly = true;
            this.permissionTechnicOpen.Size = new System.Drawing.Size(51, 17);
            this.permissionTechnicOpen.TabIndex = 0;
            this.permissionTechnicOpen.Text = "Open";
            this.permissionTechnicOpen.UseVisualStyleBackColor = true;
            // 
            // Modinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 527);
            this.Controls.Add(this.skipmod);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.getPermissions);
            this.Controls.Add(this.showDone);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.FTBPermissions);
            this.Controls.Add(this.technicPermissions);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.modlist);
            this.Name = "Modinfo";
            this.Text = "modinfo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.modinfo_Closing);
            this.Load += new System.EventHandler(this.Modinfo_Load);
            this.dataBox.ResumeLayout(false);
            this.dataBox.PerformLayout();
            this.technicPermissions.ResumeLayout(false);
            this.technicPermissions.PerformLayout();
            this.FTBPermissions.ResumeLayout(false);
            this.FTBPermissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox modlist;
        private GroupBox dataBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxModVersion;
        private TextBox textBoxModID;
        private TextBox textBoxModName;
        private GroupBox technicPermissions;
        private ReadOnlyRadioButton permissionTechnicUnknown;
        private ReadOnlyRadioButton permissionTechnicRequest;
        private ReadOnlyRadioButton permissionTechnicNotify;
        private ReadOnlyRadioButton permissionTechnicClosed;
        private ReadOnlyRadioButton permissionTechnicFTBExclusive;
        private ReadOnlyRadioButton permissionTechnicOpen;
        private Label label4;
        private TextBox textBoxAuthor;
        private Label label6;
        private Label label5;
        private TextBox textBoxTechnicModLink;
        private TextBox textBoxTechnicPermissionLink;
        private Label label7;
        private TextBox textBoxTechnicLicenseLink;
        private Label label8;
        private TextBox textBoxFileName;
        private Label label9;
        private ToolTip toolTip1;
        private CheckBox showDone;
        private GroupBox FTBPermissions;
        private Label label10;
        private Label label11;
        private Label label12;
        private ReadOnlyRadioButton permssionFTBUnknown;
        private ReadOnlyRadioButton permissionFTBRequest;
        private ReadOnlyRadioButton permissionFTBNotify;
        private ReadOnlyRadioButton permissionFTBClosed;
        private TextBox textBoxFTBLicenseLink;
        private TextBox textBoxFTBModLink;
        private TextBox textBoxFTBPermissionLink;
        private ReadOnlyRadioButton permissionFTBFTBExclusive;
        private ReadOnlyRadioButton permissionFTBOpen;
        private Button getPermissions;
        private Button Done;
        private CheckBox skipmod;
    }
}