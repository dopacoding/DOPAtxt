using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOPAnote
{
    public partial class aboutdopanote : Form
    {
        public aboutdopanote()
        {
            InitializeComponent();
            InitializeAboutContent();
        }

        private void InitializeAboutContent()
        {
            // Create a RichTextBox
            RichTextBox aboutTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,  // Make it read-only so users can't edit it
                BorderStyle = BorderStyle.None,  // Remove borders for a clean look
                BackColor = SystemColors.Control,  // Match the form background color
                Font = new System.Drawing.Font("Ubuntu", 12, System.Drawing.FontStyle.Bold)  // Customize the font
            };
            
            // Add content to the RichTextBox
            
            aboutTextBox.AppendText(" DOPAtxt\n\n");

            aboutTextBox.SelectionFont = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            aboutTextBox.AppendText(
                " DopaTxt is a lightweight, easy-to-use text editor designed for users who want a simple yet powerful tool for creating and editing text files. Whether you're writing code, drafting documents, or taking notes, DopaTxt provides a clean and intuitive interface to make text editing a breeze. \n\n" +
               
                " Key Features:\n" +
                " - User-Friendly Interface: DopaTxt offers a minimalistic and clutter-free workspace, allowing you to focus on your writing without distractions.\n" +
                " - Automatic File Saving: DopaTxt automatically saves your work to ensure you never lose any progress. If the file already exists, it generates a unique name to avoid overwriting your original file.\n" +
                " - Drag-and-Drop Support: Quickly drag and drop files into the editor to view or edit them directly within DopaTxt.\n" +
                " - Search & Replace: Find and replace text easily, even in large documents, to make your editing more efficient.\n" +
                " - Syntax Highlighting: Supports syntax highlighting for common programming languages to help developers edit code with ease\n\n");

          

            aboutTextBox.SelectionFont = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            aboutTextBox.AppendText(
                " We welcome your feedback and are always looking for ways to improve DopaTxt. If you have any questions, suggestions, or encounter any issues, please don't hesitate to contact us via our support email:\n" +
               
                " dopacoding@gmail.com\n\n");


            aboutTextBox.SelectionFont = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Italic);
            aboutTextBox.AppendText(
                " DOPAtxt v1.0\n\n"+
                "Created By: Amer Cherfi \n"+
                "2024");
            // Add the RichTextBox to the Form
            this.Controls.Add(aboutTextBox);
        }
    }
}
