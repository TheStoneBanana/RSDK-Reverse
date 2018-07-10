﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroED.Tools.GFXTool
{
    public partial class MainForm : Form
    {

        string filename;

        bool dcGFX = false;

        RSDKv1.gfx GFX;
        System.Drawing.Imaging.ColorPalette GFXPal;

        Bitmap IMG;
        System.Drawing.Imaging.ColorPalette IMGPal;

        public MainForm()
        {
            InitializeComponent();
            GFX = new RSDKv1.gfx();
            IMG = new Bitmap(1,1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".gfx";
            dlg.Filter = "Sage 2007 (PC Demo) Retro-Sonic Graphics Files|*.gfx|Dreamcast Demo Retro-Sonic Graphics Files|*.gfx";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                filename = dlg.FileName;
                SourceGFXLocation.Text = dlg.FileName;
                if (dlg.FilterIndex-1 == 1)
                {
                    dcGFX = true;
                }
                GFX = new RSDKv1.gfx(filename, dcGFX);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".GIF";
            dlg.Filter = "PNG|*.png|GIF|*.gif|Bitmap Image|*.bmp";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                    //RSDKv1.gfx old = new RSDKv1.gfx(filename,dcGFX);

                    switch (dlg.FilterIndex - 1)
                    {
                        case 0:
                        string txt0 = this.Text;
                        this.Text = "Exporting - " + txt0;
                        GFX.export(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        this.Text = txt0;
                        break;
                        case 1:
                        string txt1 = this.Text;
                        this.Text = "Exporting - " + txt1;
                        GFX.export(dlg.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        this.Text = txt1;
                        break;
                        case 2:
                        string txt2 = this.Text;
                        this.Text = "Exporting - " + txt2;
                        GFX.export(dlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        this.Text = txt2;
                        break;
                        default:
                        string txt3 = this.Text;
                        this.Text = "Exporting - " + txt3;
                        GFX.export(dlg.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        this.Text = txt3;
                        break;
                    }
            }

        }

        private void SelectGIFButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".GIF";
            dlg.Filter = "GIF|*.gif|Bitmap Image|*.bmp";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                filename = dlg.FileName;
                SourceIMGLocation.Text = dlg.FileName;
                IMG = (Bitmap)Image.FromFile(dlg.FileName).Clone();
                GFX.importFromBitmap(IMG);
            }
        }

        private void ExportToGFX_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".gfx";
            dlg.Filter = "Sage 2007 (PC Demo) Retro-Sonic Graphics Files|*.gfx|Dreamcast Demo Retro-Sonic Graphics Files|*.gfx";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                filename = dlg.FileName;
                SourceGFXLocation.Text = dlg.FileName;
                if (dlg.FilterIndex - 1 == 1)
                {
                    dcGFX = true;
                }
                string txt = this.Text;
                this.Text = "Exporting - " + txt;
                GFX.Write(dlg.FileName,dcGFX);
                this.Text = txt;
            }
        }
    }
}
