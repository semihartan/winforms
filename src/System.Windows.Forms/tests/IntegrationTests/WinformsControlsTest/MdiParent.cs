﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinformsControlsTest
{
    public partial class MdiParent : Form
    {
        private readonly MenuStrip _menuStrip;

        public MdiParent()
        {
            InitializeComponent();

            Text = RuntimeInformation.FrameworkDescription;

            ToolStripMenuItem menu = new() { Text = "Open new child" };
            menu.Click += (s, e) =>
            {
                var child = new Form();
                child.MdiParent = this;
                child.WindowState = FormWindowState.Maximized;
                child.Show();
            };

            _menuStrip = new MenuStrip();
            _menuStrip.Items.Add(menu);

            for (int i = 1; i < 7; i++)
            {
                ToolStripMenuItem item = new()
                {
                    Alignment = i < 4 ? ToolStripItemAlignment.Left : ToolStripItemAlignment.Right,
                    Text = $"Item{i}"
                };
                _menuStrip.Items.Add(item);
            }
        }

        public MenuStrip MainMenu => _menuStrip;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            MdiChild frm = new MdiChild();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
