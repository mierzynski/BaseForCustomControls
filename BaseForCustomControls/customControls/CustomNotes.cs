using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;


namespace BaseForCustomControls.customControls
{
    public partial class CustomNotes : UserControl
    {
        private bool isDocumentLoaded = false;

        public CustomNotes()
        {
            InitializeComponent();
            AttachEventHandlers();
            InitializeWebBrowserWithBackground(Color.White);
            InitializeTextStyleDropdown();
        }


        private void InitializeWebBrowserWithBackground(Color backgroundColor)
        {
            webBrowser.AllowWebBrowserDrop = false;
            webBrowser.IsWebBrowserContextMenuEnabled = false;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.WebBrowserShortcutsEnabled = false;

            string colorHex = ColorTranslator.ToHtml(backgroundColor);

            webBrowser.DocumentText = $@"<!DOCTYPE html>
                                        <html lang='pl'>
                                            <head>
                                                <meta charset='utf-8'>
                                                <meta http-equiv='X-Ua-Compatible' content='IE=edge,chrome=1'>
                                                <style>
                                                    body {{
                                                        font-family: Arial, sans-serif;
                                                        word-wrap: break-word;
                                                        background-color: {colorHex};
                                                    }}
                                                    hr {{
                                                        border: 1px solid black; /* Kolor separatora */
                                                        height: 1px;
                                                       }}
                                                    p {{
                                                        margin: 0;
                                                    }}
                                                </style>
                                            </head>
                                            <body contenteditable='true' tabindex='0'></body>
                                        </html>";


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
            buttonInsertSeparator.Click += ButtonInsertSeparator_Click;
            buttonHighlightColor.Click += ButtonHighlightColor_Click;
            buttonUndo.Click += ButtonUndo_Click;
            buttonRedo.Click += ButtonRedo_Click;
            buttonRemoveFormatting.Click += ButtonRemoveFormatting_Click;
            buttonInsertCheckbox.Click += ButtonInsertCheckbox_Click;

            //TESTY POBIERANIA TREŚCI Z KONTROLKI WEBBROWSER
            buttonGetContent.Click += ButtonGetContent_Click;
        }

        private void InitializeTextStyleDropdown()
        {
            ToolStripMenuItem normalText = new ToolStripMenuItem("Normalny tekst");
            normalText.Font = new Font("Arial", 12);
            normalText.Click += (sender, e) => SetTextStyle("3");

            ToolStripMenuItem heading1 = new ToolStripMenuItem("Nagłówek 1");
            heading1.Font = new Font("Arial", 20);
            heading1.Click += (sender, e) => SetTextStyle("7");

            ToolStripMenuItem heading2 = new ToolStripMenuItem("Nagłówek 2");
            heading2.Font = new Font("Arial", 18);
            heading2.Click += (sender, e) => SetTextStyle("6");

            ToolStripMenuItem heading3 = new ToolStripMenuItem("Nagłówek 3");
            heading3.Font = new Font("Arial", 16);
            heading3.Click += (sender, e) => SetTextStyle("5");

            ToolStripMenuItem heading4 = new ToolStripMenuItem("Nagłówek 4");
            heading4.Font = new Font("Arial", 14);
            heading4.Click += (sender, e) => SetTextStyle("4");


            buttonTextStyles.DropDownItems.Add(normalText);
            buttonTextStyles.DropDownItems.Add(heading1);
            buttonTextStyles.DropDownItems.Add(heading2);
            buttonTextStyles.DropDownItems.Add(heading3);
            buttonTextStyles.DropDownItems.Add(heading4);
        }

        //TESTY POBIERANIA TREŚCI Z KONTROLKI WEBBROWSER
        private void ButtonGetContent_Click(object sender, EventArgs e)
        {
            string content = GetWebBrowserContent();
            MessageBox.Show(content);
        }

        private string GetWebBrowserContent()
        {
            if (webBrowser.Document != null)
            {
                string htmlContent = webBrowser.Document.Body.InnerHtml;
               // string textContent = webBrowser.Document.Body.InnerText;
                string textContent = ConvertInnerHtmlToText(htmlContent); // Konwersja HTML na tekst

                return $"Zawartość HTML:\n{htmlContent}\n\nZawartość tekstowa:\n{textContent}";
            }
            return string.Empty;
        }

        private string ConvertInnerHtmlToText(string innerHtml)
        {
            // Usunięcie tagów <p> i zamiana </p> na </br>
            innerHtml = innerHtml.Replace("<p>", "").Replace("</p>", "\n");

            // Zamiana checkboxów na tekst "checkbox"
            innerHtml = innerHtml.Replace("<input type=\"checkbox\">", "[checkbox] ");

            // Zamiana poziomej linii (separatora) na pustą linię
            innerHtml = innerHtml.Replace("<hr>", "\n[separator]\n\n");

            // Obsługa listy numerowanej
            int listItemNumber = 1; // Zmienna pomocnicza do numerowania elementów listy
            innerHtml = System.Text.RegularExpressions.Regex.Replace(innerHtml, @"<ol>(.*?)</ol>", match =>
            {
                // Wnętrze <ol>...</ol> zastępujemy przetworzonymi elementami <li>
                string listContent = match.Groups[1].Value;
                return System.Text.RegularExpressions.Regex.Replace(listContent, @"<li>(.*?)</li>", m =>
                {
                    // Zastępujemy <li>...</li> numerowanym elementem
                    string result = $"{listItemNumber}. {m.Groups[1].Value}\n";
                    listItemNumber++;
                    return result;
                });
            }, System.Text.RegularExpressions.RegexOptions.Singleline);

            // Reset numeracji list po zakończeniu jednej listy
            listItemNumber = 1;

            // Obsługa listy punktowanej
            innerHtml = System.Text.RegularExpressions.Regex.Replace(innerHtml, @"<ul>(.*?)</ul>", match =>
            {
                // Wnętrze <ul>...</ul> przetwarzamy, zamieniając elementy <li> na punktor (•)
                string listContent = match.Groups[1].Value;
                return System.Text.RegularExpressions.Regex.Replace(listContent, @"<li>(.*?)</li>", m =>
                {
                    return $"• {m.Groups[1].Value}\n";
                });
            }, System.Text.RegularExpressions.RegexOptions.Singleline);

            // Konwersja do tekstu
            // Zastępujemy inne tagi HTML (jeśli są) pustym ciągiem
            innerHtml = System.Text.RegularExpressions.Regex.Replace(innerHtml, "<[^>]+>", "");

            // Usunięcie nadmiarowych białych znaków
            //innerHtml = System.Text.RegularExpressions.Regex.Replace(innerHtml, @"\s+", @"\s").Trim();

            // Usunięcie nadmiarowych \n (zostaje tylko jedna nowa linia)
            innerHtml = System.Text.RegularExpressions.Regex.Replace(innerHtml, @"\n{2,}", "\n\n");

            innerHtml = innerHtml.Trim();

            return innerHtml;
        }


        private void SetTextStyle(string tagName)
        {
            if (webBrowser.Document != null)
            {
                ExecuteCommand("fontsize", tagName);
            }
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isDocumentLoaded = true;
            if (webBrowser.Document != null && webBrowser.Document.Body != null)
            {
                webBrowser.Document.Body.SetAttribute("spellcheck", "true");
            }
        }
        private void WebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.Control && !e.Alt)
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
                    if (Clipboard.ContainsImage())
                    {
                        MessageBox.Show("Nie można wklejać obrazów. Proszę wkleić tekst.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.IsInputKey = true;
                        return;
                    }
                    else
                    {
                        webBrowser.Document.ExecCommand("Paste", false, null);
                        e.IsInputKey = true;

                    }
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
                else if (e.KeyCode == Keys.Z)
                {
                    webBrowser.Document.ExecCommand("Undo", false, null);
                    e.IsInputKey = true;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                webBrowser.Document.ExecCommand("Delete", false, null);
                e.IsInputKey = true;
            }
        }

        private void ButtonRemoveFormatting_Click(object sender, EventArgs e)
        {
            if (webBrowser.Document != null)
            {
                webBrowser.Document.ExecCommand("removeFormat", false, null);
            }
        }

        private void ButtonInsertCheckbox_Click(object sender, EventArgs e)
        {
            if (isDocumentLoaded)
            {
                InsertCheckbox();
            }
        }

        private void InsertCheckbox()
        {
            if (webBrowser.Document != null)
            {
                var selection = webBrowser.Document.ActiveElement;

                if (selection != null)
                {
                    selection.InnerHtml += "<span contenteditable='false'><input type='checkbox'/></span>";
                }

                RemoveEmptyParagraphsBeforeCheckbox();
            }
        }

        // Metoda pomocnicza do usunięcia <p><br></p> przed checkboxem
        private void RemoveEmptyParagraphsBeforeCheckbox()
        {
            if (webBrowser.Document != null)
            {
                string htmlContent = webBrowser.Document.Body.InnerHtml;
                string updatedHtmlContent = htmlContent.Replace("<p><br></p><span", "<span");

                webBrowser.Document.Body.InnerHtml = updatedHtmlContent;
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


        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            ExecuteCommand("undo");
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            ExecuteCommand("redo");
        }

        private void ButtonHighlightColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                string color = ColorTranslator.ToHtml(colorDialog.Color);
                ExecuteCommand("hiliteColor", color);
            }
        }

        private void ButtonInsertSeparator_Click(object sender, EventArgs e)
        {
            ExecuteCommand("insertHorizontalRule");
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
