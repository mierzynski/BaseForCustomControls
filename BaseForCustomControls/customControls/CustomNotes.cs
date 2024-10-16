using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseForCustomControls.customControls
{
    public partial class CustomNotes : UserControl
    {
        private bool isDocumentLoaded = false;  // Flaga, żeby śledzić, czy dokument jest załadowany

        public CustomNotes()
        {
            InitializeComponent();
            AttachEventHandlers();
            InitializeWebBrowser();
            AdjustWebBrowserMargin();
        }

        private void InitializeWebBrowser()
        {
            // Załadowanie niestandardowego dokumentu HTML do kontrolki z Designera
            webBrowser.AllowWebBrowserDrop = false;
            webBrowser.IsWebBrowserContextMenuEnabled = false;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.WebBrowserShortcutsEnabled = false;

            // Ładowanie edytowalnego dokumentu HTML
            webBrowser.DocumentText = @"
        <html>
            <head>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        word-wrap: break-word;
                    }
                </style>
            </head>
            <body contenteditable='true'></body>
        </html>";

            // Podłączenie zdarzeń
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            webBrowser.PreviewKeyDown += WebBrowser_PreviewKeyDown;
        }

        private void AttachEventHandlers()
        {
            buttonBold.Click += ButtonBold_Click;
            buttonItalic.Click += ButtonItalic_Click;
            buttonUnderline.Click += ButtonUnderline_Click;
            buttonChangeColor.Click += ButtonChangeColor_Click;
            buttonAlignLeft.Click += ButtonAlignLeft_Click;
            buttonAlignCenter.Click += ButtonAlignCenter_Click;
            buttonAlignRight.Click += ButtonAlignRight_Click;
            buttonJustify.Click += ButtonJustify_Click;
            //buttonInsertImage.Click += ButtonInsertImage_Click;
            buttonLineSpacing.DropDownItemClicked += ButtonLineSpacing_DropDownItemClicked;
            buttonBulletList.Click += ButtonBulletList_Click;
            buttonNumberedList.Click += ButtonNumberedList_Click;
            buttonIndent.Click += ButtonIndent_Click;
            buttonOutdent.Click += ButtonOutdent_Click;

            toolStrip.SizeChanged += ToolStrip_SizeChanged;
        }

        private void AdjustWebBrowserMargin()
        {
            if (webBrowser != null && toolStrip != null)
            {
                // Ustawiamy margines górny WebBrowsera równy wysokości ToolStripa
                webBrowser.Margin = new Padding(0, toolStrip.Height, 0, 0);
            }
        }

        private void ToolStrip_SizeChanged(object sender, EventArgs e)
        {
            // Za każdym razem, gdy rozmiar ToolStripa się zmieni, aktualizujemy margines WebBrowsera
            AdjustWebBrowserMargin();
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isDocumentLoaded = true;

        }

        private void WebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    webBrowser.Document.ExecCommand("SelectAll", false, null);
                    e.IsInputKey = true;
                }
                else if (e.KeyCode == Keys.C)
                {
                    webBrowser.Document.ExecCommand("Copy", false, null);
                    e.IsInputKey = true;
                }
                else if (e.KeyCode == Keys.X)
                {
                    webBrowser.Document.ExecCommand("Cut", false, null);
                    e.IsInputKey = true;
                }
                else if (e.KeyCode == Keys.V)
                {
                    e.IsInputKey = true;
                    webBrowser.Document.ExecCommand("Paste", false, null);
                }
                else if (e.KeyCode == Keys.B)
                {
                    webBrowser.Document.ExecCommand("Bold", false, null);
                    e.IsInputKey = true;
                }
                else if (e.KeyCode == Keys.I)
                {
                    webBrowser.Document.ExecCommand("Italic", false, null);
                    e.IsInputKey = true;
                }
                else if (e.KeyCode == Keys.U)
                {
                    webBrowser.Document.ExecCommand("Underline", false, null);
                    e.IsInputKey = true;
                }
            }
        }


        private void ButtonLineSpacing_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string selectedOption = e.ClickedItem.Text;

            string lineHeight = "1,0";

            switch (selectedOption)
            {
                case "1,0":
                    lineHeight = "1.0";
                    break;
                case "1,5":
                    lineHeight = "1.5";
                    break;
                case "2,0":
                    lineHeight = "2.0";
                    break;
            }

            UpdateLineHeight(lineHeight);
        }

        private void UpdateLineHeight(string lineHeight)
        {
            if (isDocumentLoaded)
            {
                string script = $"document.body.style.lineHeight = '{lineHeight}';";
                webBrowser.Document.InvokeScript("eval", new object[] { script });
            }
        }

        private void ButtonBold_Click(object sender, EventArgs e)
        {
            ExecuteCommand("bold");
        }

        private void ButtonItalic_Click(object sender, EventArgs e)
        {
            ExecuteCommand("italic");
        }

        private void ButtonUnderline_Click(object sender, EventArgs e)
        {
            ExecuteCommand("underline");
        }

        private void ButtonChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                string color = ColorTranslator.ToHtml(colorDialog.Color);
                ExecuteCommand("forecolor", color);
            }
        }

        private void ButtonAlignLeft_Click(object sender, EventArgs e)
        {
            ExecuteCommand("justifyleft");
        }

        private void ButtonAlignCenter_Click(object sender, EventArgs e)
        {
            ExecuteCommand("justifycenter");
        }

        private void ButtonAlignRight_Click(object sender, EventArgs e)
        {
            ExecuteCommand("justifyright");
        }

        private void ButtonJustify_Click(object sender, EventArgs e)
        {
            ExecuteCommand("justifyfull");
        }

        private void ButtonInsertImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Obrazy|*.bmp;*.jpg;*.jpeg;*.png;*.gif",
                Title = "Wybierz obraz do wstawienia"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                ExecuteCommand("insertImage", imagePath);
            }
        }

        private void ButtonBulletList_Click(object sender, EventArgs e)
        {
            ExecuteCommand("insertUnorderedList");
        }

        private void ButtonNumberedList_Click(object sender, EventArgs e)
        {
            ExecuteCommand("insertOrderedList");
        }

        private void ButtonIndent_Click(object sender, EventArgs e)
        {
            ExecuteCommand("indent");
        }

        private void ButtonOutdent_Click(object sender, EventArgs e)
        {
            ExecuteCommand("outdent");
        }


        private void ExecuteCommand(string command, string value = null)
        {
            if (isDocumentLoaded)
            {
                webBrowser.Document.ExecCommand(command, false, value);
            }
        }
    }
}
