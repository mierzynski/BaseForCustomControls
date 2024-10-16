namespace BaseForCustomControls.customControls
{
    partial class CustomNotes
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomNotes));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonBold = new System.Windows.Forms.ToolStripButton();
            this.buttonItalic = new System.Windows.Forms.ToolStripButton();
            this.buttonUnderline = new System.Windows.Forms.ToolStripButton();
            this.buttonChangeColor = new System.Windows.Forms.ToolStripButton();
            this.buttonAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.buttonAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.buttonAlignRight = new System.Windows.Forms.ToolStripButton();
            this.buttonJustify = new System.Windows.Forms.ToolStripButton();
            this.buttonBulletList = new System.Windows.Forms.ToolStripButton();
            this.buttonNumberedList = new System.Windows.Forms.ToolStripButton();
            this.buttonIndent = new System.Windows.Forms.ToolStripButton();
            this.buttonOutdent = new System.Windows.Forms.ToolStripButton();
            this.buttonLineSpacing = new System.Windows.Forms.ToolStripDropDownButton();
            this.pojedyńczyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonInsertSeparator = new System.Windows.Forms.ToolStripButton();
            this.buttonHighlightColor = new System.Windows.Forms.ToolStripButton();
            this.buttonTextStyles = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.webBrowser.MinimumSize = new System.Drawing.Size(30, 31);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1044, 629);
            this.webBrowser.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonBold,
            this.buttonItalic,
            this.buttonUnderline,
            this.buttonChangeColor,
            this.buttonAlignLeft,
            this.buttonAlignCenter,
            this.buttonAlignRight,
            this.buttonJustify,
            this.buttonBulletList,
            this.buttonNumberedList,
            this.buttonIndent,
            this.buttonOutdent,
            this.buttonLineSpacing,
            this.buttonInsertSeparator,
            this.buttonHighlightColor,
            this.buttonTextStyles});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip.Size = new System.Drawing.Size(1044, 33);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // buttonBold
            // 
            this.buttonBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBold.Image = ((System.Drawing.Image)(resources.GetObject("buttonBold.Image")));
            this.buttonBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBold.Name = "buttonBold";
            this.buttonBold.Size = new System.Drawing.Size(34, 28);
            this.buttonBold.Text = "Pogrubienie";
            // 
            // buttonItalic
            // 
            this.buttonItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonItalic.Image = ((System.Drawing.Image)(resources.GetObject("buttonItalic.Image")));
            this.buttonItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonItalic.Name = "buttonItalic";
            this.buttonItalic.Size = new System.Drawing.Size(34, 28);
            this.buttonItalic.Text = "Kursywa";
            // 
            // buttonUnderline
            // 
            this.buttonUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUnderline.Image = ((System.Drawing.Image)(resources.GetObject("buttonUnderline.Image")));
            this.buttonUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUnderline.Name = "buttonUnderline";
            this.buttonUnderline.Size = new System.Drawing.Size(34, 28);
            this.buttonUnderline.Text = "Podkreślenie";
            // 
            // buttonChangeColor
            // 
            this.buttonChangeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonChangeColor.Image = ((System.Drawing.Image)(resources.GetObject("buttonChangeColor.Image")));
            this.buttonChangeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonChangeColor.Name = "buttonChangeColor";
            this.buttonChangeColor.Size = new System.Drawing.Size(34, 28);
            this.buttonChangeColor.Text = "Kolor tekstu";
            // 
            // buttonAlignLeft
            // 
            this.buttonAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonAlignLeft.Image")));
            this.buttonAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAlignLeft.Name = "buttonAlignLeft";
            this.buttonAlignLeft.Size = new System.Drawing.Size(34, 28);
            this.buttonAlignLeft.Text = "Wyrównanie do lewej";
            // 
            // buttonAlignCenter
            // 
            this.buttonAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("buttonAlignCenter.Image")));
            this.buttonAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAlignCenter.Name = "buttonAlignCenter";
            this.buttonAlignCenter.Size = new System.Drawing.Size(34, 28);
            this.buttonAlignCenter.Text = "Wyrównanie do środka";
            // 
            // buttonAlignRight
            // 
            this.buttonAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonAlignRight.Image")));
            this.buttonAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAlignRight.Name = "buttonAlignRight";
            this.buttonAlignRight.Size = new System.Drawing.Size(34, 28);
            this.buttonAlignRight.Text = "Wyrównanie do prawej";
            // 
            // buttonJustify
            // 
            this.buttonJustify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonJustify.Image = ((System.Drawing.Image)(resources.GetObject("buttonJustify.Image")));
            this.buttonJustify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonJustify.Name = "buttonJustify";
            this.buttonJustify.Size = new System.Drawing.Size(34, 28);
            this.buttonJustify.Text = "Justowanie";
            // 
            // buttonBulletList
            // 
            this.buttonBulletList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBulletList.Image = ((System.Drawing.Image)(resources.GetObject("buttonBulletList.Image")));
            this.buttonBulletList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBulletList.Name = "buttonBulletList";
            this.buttonBulletList.Size = new System.Drawing.Size(34, 28);
            this.buttonBulletList.Text = "Lista punktowana";
            // 
            // buttonNumberedList
            // 
            this.buttonNumberedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNumberedList.Image = ((System.Drawing.Image)(resources.GetObject("buttonNumberedList.Image")));
            this.buttonNumberedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNumberedList.Name = "buttonNumberedList";
            this.buttonNumberedList.Size = new System.Drawing.Size(34, 28);
            this.buttonNumberedList.Text = "Lista numerowana";
            // 
            // buttonIndent
            // 
            this.buttonIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonIndent.Image = ((System.Drawing.Image)(resources.GetObject("buttonIndent.Image")));
            this.buttonIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonIndent.Name = "buttonIndent";
            this.buttonIndent.Size = new System.Drawing.Size(34, 28);
            this.buttonIndent.Text = "Zwiększ wcięcie";
            // 
            // buttonOutdent
            // 
            this.buttonOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOutdent.Image = ((System.Drawing.Image)(resources.GetObject("buttonOutdent.Image")));
            this.buttonOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOutdent.Name = "buttonOutdent";
            this.buttonOutdent.Size = new System.Drawing.Size(34, 28);
            this.buttonOutdent.Text = "Zmniejsz wcięcie";
            // 
            // buttonLineSpacing
            // 
            this.buttonLineSpacing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLineSpacing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pojedyńczyToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.buttonLineSpacing.Image = ((System.Drawing.Image)(resources.GetObject("buttonLineSpacing.Image")));
            this.buttonLineSpacing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLineSpacing.Name = "buttonLineSpacing";
            this.buttonLineSpacing.Size = new System.Drawing.Size(42, 28);
            this.buttonLineSpacing.Text = "Odstępy pomiędzy wierszami i akapitami";
            // 
            // pojedyńczyToolStripMenuItem
            // 
            this.pojedyńczyToolStripMenuItem.Name = "pojedyńczyToolStripMenuItem";
            this.pojedyńczyToolStripMenuItem.Size = new System.Drawing.Size(138, 34);
            this.pojedyńczyToolStripMenuItem.Text = "1,0";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 34);
            this.toolStripMenuItem2.Text = "1,5";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 34);
            this.toolStripMenuItem3.Text = "2,0";
            // 
            // buttonInsertSeparator
            // 
            this.buttonInsertSeparator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonInsertSeparator.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertSeparator.Image")));
            this.buttonInsertSeparator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonInsertSeparator.Name = "buttonInsertSeparator";
            this.buttonInsertSeparator.Size = new System.Drawing.Size(34, 28);
            this.buttonInsertSeparator.Text = "Separator";
            // 
            // buttonHighlightColor
            // 
            this.buttonHighlightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonHighlightColor.Image = ((System.Drawing.Image)(resources.GetObject("buttonHighlightColor.Image")));
            this.buttonHighlightColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonHighlightColor.Name = "buttonHighlightColor";
            this.buttonHighlightColor.Size = new System.Drawing.Size(34, 28);
            this.buttonHighlightColor.Text = "Kolor zaznaczenia";
            // 
            // buttonTextStyles
            // 
            this.buttonTextStyles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonTextStyles.Image = ((System.Drawing.Image)(resources.GetObject("buttonTextStyles.Image")));
            this.buttonTextStyles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonTextStyles.Name = "buttonTextStyles";
            this.buttonTextStyles.Size = new System.Drawing.Size(42, 28);
            this.buttonTextStyles.Text = "Style tekstu";
            // 
            // CustomNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.webBrowser);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomNotes";
            this.Size = new System.Drawing.Size(1044, 629);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonBold;
        private System.Windows.Forms.ToolStripButton buttonItalic;
        private System.Windows.Forms.ToolStripButton buttonUnderline;
        private System.Windows.Forms.ToolStripButton buttonChangeColor;
        private System.Windows.Forms.ToolStripButton buttonAlignLeft;
        private System.Windows.Forms.ToolStripButton buttonAlignCenter;
        private System.Windows.Forms.ToolStripButton buttonAlignRight;
        private System.Windows.Forms.ToolStripButton buttonJustify;
        private System.Windows.Forms.ToolStripButton buttonBulletList;
        private System.Windows.Forms.ToolStripButton buttonNumberedList;
        private System.Windows.Forms.ToolStripButton buttonIndent;
        private System.Windows.Forms.ToolStripButton buttonOutdent;
        private System.Windows.Forms.ToolStripDropDownButton buttonLineSpacing;
        private System.Windows.Forms.ToolStripMenuItem pojedyńczyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripButton buttonInsertSeparator;
        private System.Windows.Forms.ToolStripButton buttonHighlightColor;
        private System.Windows.Forms.ToolStripDropDownButton buttonTextStyles;
    }
}
