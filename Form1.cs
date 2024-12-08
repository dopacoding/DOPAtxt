using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DOPAnote
{
    public partial class dopatxt : Form
    {


        public static dopatxt instance;
        public RichTextBox rtb1;
        public dopatxt()
        {
            InitializeComponent();

            instance = this;
            rtb1 = richTextBox1;
            this.richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += richTextBox1_DragEnter;
            richTextBox1.DragDrop += richTextBox1_DragDrop;


        }
        // Handle the DragEnter event to determine if the drop is valid
        string[] Files = null;
        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            Files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            // Check if the dragged data is a list of files
            if (Path.GetExtension(Files[0])==".txt")
            {
                // Allow the drop if the data is a list of files
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Deny the drop for non-file data
                e.Effect = DragDropEffects.None;
            }
        }

        // Handle the DragDrop event to process the dropped files
        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            // Get the list of dropped files
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in Files)
                {
                   

                    // Option 2: If it's a text file, read and display its content
                    if (Path.GetExtension(file).ToLower() == ".txt")
                    {
                        try
                        {
                            string fileContent = File.ReadAllText(file);
                            
                            richTextBox1.AppendText(fileContent + "\n");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error reading file {file}: {ex.Message}");
                        }
                    }
                }
            }
        }


        private void SaveAs()
        {
            saveFileDialog1.InitialDirectory = @".Desktop";
            saveFileDialog1.Title = "SAVE As";
            saveFileDialog1.Filter = "txt files(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog1.DefaultExt = "txt";



            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strPath = saveFileDialog1.FileName;
                if (Path.GetExtension(saveFileDialog1.FileName) != ".txt")
                {
                    strPath += ".txt";
                }
                StreamWriter sw = new StreamWriter(strPath);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
            }
        }
        private void Copy()
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                CopyText = richTextBox1.SelectedText;
            }
            else
            {
                CopyText = richTextBox1.Text;
            }
        }

        private void Past()
        {
            richTextBox1.Text += CopyText;
        }

        private void Cut()
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                CopyText = richTextBox1.SelectedText;
                richTextBox1.SelectedText = "";
            }
            else
            {
                CopyText = richTextBox1.Text;
                richTextBox1.Clear();
            }
        }

        private void redo()
        {
            richTextBox1.Redo();
        }
        private void undo()
        {
            richTextBox1.Undo();
        }

        private void AlignTextRightToLeft()
        {
            richTextBox1.RightToLeft = RightToLeft.Yes;
        }
        private void AlignTextLeftToRight()
        {
            richTextBox1.RightToLeft = RightToLeft.No;
        }

        private void OpenNewWindow()
        {
            dopatxt newdopanote = new dopatxt();
            newdopanote.Show();
        }
       
        private void Clear()
        {
            richTextBox1.Clear();
        }
        private void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        private void Print()
        {
            printDialog1.ShowDialog();
        }
        
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }


       

        private void Save()
        {

            
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DOPAtxt.txt");
            // Check if the file already exists
            if (File.Exists(filePath))
            {
                // Generate a new file name by appending a number to the base name
                string directory = Path.GetDirectoryName(filePath);
                string extension = Path.GetExtension(filePath);
                string baseName = Path.GetFileNameWithoutExtension(filePath);

                int count = 1;
                string newFilePath;

                do
                {
                    // Create a new file path with an incrementing number
                    newFilePath = Path.Combine(directory, $"{baseName} ({count}){extension}");
                    count++;
                }
                while (File.Exists(newFilePath)); // Keep generating names until we find one that's available

                // Save the file with the new name
                File.WriteAllText(newFilePath, richTextBox1.Text);
                MessageBox.Show($"File saved as: {newFilePath}", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the file doesn't exist, just save it normally
                File.WriteAllText(filePath, richTextBox1.Text);
                MessageBox.Show($"File saved as: {filePath}", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Save();
        }
        private Color currentTextColor = Color.Black; // Default color is black

        private void FontColor()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the selected color
                    currentTextColor = colorDialog.Color;

                    // Check if text is selected
                    if (richTextBox1.SelectionLength > 0)
                    {
                        // Change the color of selected text
                        richTextBox1.SelectionColor = currentTextColor;
                    }
                    else
                    {
                        // No text is selected: set the color for future text
                        richTextBox1.SelectionColor = currentTextColor;
                    }
                }
            }
        }
        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {


            FontColor();

        }

        // Initialize default font (can be set to any default)
        Font currentFont = new Font("Arial", 12, FontStyle.Regular);
        private void Font()
        {
            fontDialog1.ShowApply = true;

            using (FontDialog fontDialog = new FontDialog())
            {
                // Set the current font as the default in the FontDialog
                fontDialog.Font = currentFont;

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected font from the dialog
                    currentFont = fontDialog.Font;

                    // Check if text is selected in the RichTextBox
                    if (richTextBox1.SelectionLength > 0)
                    {
                        // Apply the selected font to the selected text
                        richTextBox1.SelectionFont = currentFont;
                    }
                    else
                    {
                        // If no text is selected, set the font for future text
                        richTextBox1.SelectionFont = currentFont;
                    }
                }
            }
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font();

        }

        private void BackGroundColor()
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
            }
        }
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackGroundColor();
        }

        private void DesactivateButtons()
        {

            copyToolStripMenuItem.Enabled = false;

            cutToolStripMenuItem.Enabled = false;
            clearToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;


        }

        private void AtivateButtons()
        {

            copyToolStripMenuItem.Enabled = true;

            cutToolStripMenuItem.Enabled = true;
            clearToolStripMenuItem.Enabled = true;
            selectAllToolStripMenuItem.Enabled = true;


        }
        private void dopanote_Load(object sender, EventArgs e)
        {
            richTextBox1.Dock = DockStyle.Fill;

            DesactivateButtons();

            ModeLight();
            TranslateToEnglish();
            
        }

        private void TranslateToEnglish()
        {
            en.Checked = true;
            en.CheckOnClick = true;
            if (en.Checked)
            {
                menuStrip1.RightToLeft = RightToLeft.No;
                richTextBox1.RightToLeft = RightToLeft.No;
                toolStrip1.RightToLeft = RightToLeft.No;
                fileToolStripMenuItem.Text = "&File";
                editToolStripMenuItem.Text = "&Edit";
                formatToolStripMenuItem.Text = "F&ormat";
                colorToolStripMenuItem.Text = "&Color";
                viewToolStripMenuItem.Text = "&View";
                modeToolStripMenuItem.Text = "&Mode";
                languageToolStripMenuItem.Text = "&Language";
                helpToolStripMenuItem.Text = "&Help";
                //------------------------------------------//
                newToolStripMenuItem.Text = "Ne&w...";
                openToolStripMenuItem.Text = "&Open";
                newWindowToolStripMenuItem.Text = "N&ew Window";
                saveToolStripMenuItem.Text = "&Save";
                saveAsToolStripMenuItem.Text = "Sa&ve As";
                printToolStripMenuItem.Text = "&Print";
                exitToolStripMenuItem.Text = "&Exit";
                //-----------------------------------------//
                undoToolStripMenuItem.Text = "&Undo";
                redoToolStripMenuItem.Text = "&Redo";
                copyToolStripMenuItem.Text = "&Copy";
                pastToolStripMenuItem.Text = "&Past";
                cutToolStripMenuItem.Text = "C&ut";
                clearToolStripMenuItem.Text = "C&lear";
                replaceToolStripMenuItem.Text = "&Find and Re&place  ";
                selectAllToolStripMenuItem.Text = "&Select All";
                //-------------------------------------------//
                fontToolStripMenuItem.Text = "&Font";
                rightToLeftToolStripMenuItem.Text = "&Right To Left";
                leftToRightToolStripMenuItem.Text = "&Left To Right";
                //-------------------------------------------//
                fontColorToolStripMenuItem.Text = "&Font Color";
                backgroundColorToolStripMenuItem.Text = "&BackGround Color";
                //-----------------------------------------------//
                editBarToolStripMenuItem.Text = "&Edit Bar";
                //-----------------------------------------------//
                modeNightToolStripMenuItem.Text = "Mode &Night";
                modeLightToolStripMenuItem.Text = "Mode &Light";
                //---------------------------------------------//
                aboutDopaNoteToolStripMenuItem.Text = "&About DOPAnote";
                //-------------------------------------------//
                tsbtnnewwindow.Text = "New Window";
                tsbtnsave.Text = "Save";
                tabtnsaveas.Text = "Save As";
                tsbtnundo.Text = "Undo";
                tsbtnredo.Text = "Redo";
                tsbtncopy.Text = "Copy";
                tsbtncut.Text = "Cut";
                tsbtnpast.Text = "Past";
                tsbtnselectall.Text = "Select All";
                tsbtnclear.Text = "Clear";
                tsbtnalightextleft.Text = "Align Text Right";
                tsbtnaligntextright.Text = "Align Text Left";
                tsbtnfont.Text = "Font";
                tsbtnfontcolor.Text = "Font Color";
                tsbtnbackgroundcolor.Text = "Background Color";
                tsbtnprint.Text = "Print";
                //------------------------------------------//


                ar.Text = "&Arabic";
                en.Text = "&English";
                ru.Text = "&Russian";
                ar.Checked = false;
                ru.Checked = false;
            }
        }

        private void TranslateToArabic()
        {
            ar.Checked = true;
            ar.CheckOnClick = true;
            if (ar.Checked)
            {
                menuStrip1.RightToLeft = RightToLeft.Yes;
                richTextBox1.RightToLeft = RightToLeft.Yes;
               toolStrip1.RightToLeft= RightToLeft.Yes;
                fileToolStripMenuItem.Text = "&ملف";
                editToolStripMenuItem.Text = "&تعديل";
                formatToolStripMenuItem.Text = "تحوي&ل";
                colorToolStripMenuItem.Text = "&الألوان";
                viewToolStripMenuItem.Text = "من&ظر";
                modeToolStripMenuItem.Text = "الوض&ع";
                languageToolStripMenuItem.Text = "اللغ&ة";
                helpToolStripMenuItem.Text = "مس&اعدة";
                //------------------------------------------//
                newToolStripMenuItem.Text = "&مستند جديد...";
                openToolStripMenuItem.Text = "&فتح ملف";
                newWindowToolStripMenuItem.Text = "نافذة جديدة";
                saveToolStripMenuItem.Text = "&حفظ";
                saveAsToolStripMenuItem.Text = "حفظ في...";
                printToolStripMenuItem.Text = "&طباعة";
                exitToolStripMenuItem.Text = "&خروج";
                //-----------------------------------------//
                undoToolStripMenuItem.Text = "&للخلف";
                redoToolStripMenuItem.Text = "&للأمام";
                copyToolStripMenuItem.Text = "&نسخ";
                pastToolStripMenuItem.Text = "&لصق";
                cutToolStripMenuItem.Text = "قطع";
                clearToolStripMenuItem.Text = "تنظيف";
                replaceToolStripMenuItem.Text = "بحث و اٍستبدال";
                selectAllToolStripMenuItem.Text = "تحديد الكل";
                //-------------------------------------------//
                fontToolStripMenuItem.Text = "&تحديد الخط";
                rightToLeftToolStripMenuItem.Text = "&من اليمين الى اليسار";
                leftToRightToolStripMenuItem.Text = "&من اليسار الى اليمين";
                //-------------------------------------------//
                fontColorToolStripMenuItem.Text = "&لون الخط";
                backgroundColorToolStripMenuItem.Text = "&لون الخلفية";
                //-----------------------------------------------//
                editBarToolStripMenuItem.Text = "&شريط التعديل";
                //-----------------------------------------------//
                modeNightToolStripMenuItem.Text = "وضع الليل";
                modeLightToolStripMenuItem.Text = "الوضع المضيئ";
                //---------------------------------------------//
                aboutDopaNoteToolStripMenuItem.Text = "&معلومات عن DOPAnote";
                //------------------------------------------//
                tsbtnnewwindow.Text = "نافذة جديدة";
                tsbtnsave.Text = "حفظ";
                tabtnsaveas.Text = "حفظ في...";
                tsbtnundo.Text = "للخلف";
                tsbtnredo.Text = "للأمام";
                tsbtncopy.Text = "نسخ";
                tsbtncut.Text = "قطع";
                tsbtnpast.Text = "لصق";
                tsbtnselectall.Text = "تحديد الكل";
                tsbtnclear.Text = "تنظيف";
                tsbtnalightextleft.Text = "من اليمين الى اليسار";
                tsbtnaligntextright.Text = "من اليسار الى اليمين";
                tsbtnfont.Text = "تحديد الخط";
                tsbtnfontcolor.Text = "لون الخط";
                tsbtnbackgroundcolor.Text = "لون الخلفية";
                tsbtnprint.Text = "طباعة";
                //-------------------------------------------//

                ar.Text = "الع&ربية";
                en.Text = "الاٍنج&ليزية";
                ru.Text = "الروس&ية";
                en.Checked = false;
                ru.Checked = false;


            }
        }

        private void TranslateToRussian()
        {
            ru.Checked = true;
            ru.CheckOnClick = true;
            if (ru.Checked)
            {
                menuStrip1.RightToLeft = RightToLeft.No;
                richTextBox1.RightToLeft = RightToLeft.No;
                toolStrip1.RightToLeft = RightToLeft.No;
                fileToolStripMenuItem.Text = "&Файл";
                editToolStripMenuItem.Text = "&Редактировать";
                formatToolStripMenuItem.Text = "Ф&ормат";
                colorToolStripMenuItem.Text = "&Цвет";
                viewToolStripMenuItem.Text = "&Вид";
                modeToolStripMenuItem.Text = "Ре&жим";
                languageToolStripMenuItem.Text = "&Язык";
                helpToolStripMenuItem.Text = "&Помощь";

                //------------------------------------------//
                newToolStripMenuItem.Text = "Новый...";
                openToolStripMenuItem.Text = "&Открыть";
                newWindowToolStripMenuItem.Text = "&Новое окно";
                saveToolStripMenuItem.Text = "&Сохранить";
                saveAsToolStripMenuItem.Text = "Сохранить как";
                printToolStripMenuItem.Text = "&Печать";
                exitToolStripMenuItem.Text = "&Выйти";
                //-----------------------------------------//
                undoToolStripMenuItem.Text = "&Назад";
                redoToolStripMenuItem.Text = "&Вперед";
                copyToolStripMenuItem.Text = "&Копировать";
                pastToolStripMenuItem.Text = "&Вставить";
                cutToolStripMenuItem.Text = "Вырезать";
                clearToolStripMenuItem.Text = "Очистить";
                replaceToolStripMenuItem.Text = "искать и Заменить";
                selectAllToolStripMenuItem.Text = "&Выбрать все";
                //-------------------------------------------//
                fontToolStripMenuItem.Text = "&Шрифт";
                rightToLeftToolStripMenuItem.Text = "&Справа налево";
                leftToRightToolStripMenuItem.Text = "&Слева направо";
                //-------------------------------------------//
                fontColorToolStripMenuItem.Text = "&Цвет шрифта";
                backgroundColorToolStripMenuItem.Text = "&Цвет фона";
                //-----------------------------------------------//
                editBarToolStripMenuItem.Text = "&Панель редактирования";
                //-----------------------------------------------//
                modeNightToolStripMenuItem.Text = "Режим &Ночь";
                modeLightToolStripMenuItem.Text = "Режим &Свет";
                //---------------------------------------------//
                aboutDopaNoteToolStripMenuItem.Text = "&О DOPAnote";
                //-------------------------------------------//
                tsbtnnewwindow.Text = "Новое окно";
                tsbtnsave.Text = "Сохранить";
                tabtnsaveas.Text = "Сохранить как";
                tsbtnundo.Text = "Назад";
                tsbtnredo.Text = "Вперед";
                tsbtncopy.Text = "Копировать";
                tsbtncut.Text = "Вырезать";
                tsbtnpast.Text = "Вставить";
                tsbtnselectall.Text = "Выбрать все";
                tsbtnclear.Text = "Очистить";
                tsbtnalightextleft.Text = "Справа налево";
                tsbtnaligntextright.Text = "Слева направо";
                tsbtnfont.Text = "Шрифт";
                tsbtnfontcolor.Text = "Цвет шрифта";
                tsbtnbackgroundcolor.Text = "Цвет фона";
                tsbtnprint.Text = "Печать";
                //------------------------------------------//

                ar.Text = "&Арабский";
                en.Text = "А&нглийский";
                ru.Text = "&Русский";
                ar.Checked = false;
                en.Checked = false;
            }
        }
        private void ModeLight()
        {
            modeLightToolStripMenuItem.CheckOnClick = true;
            modeLightToolStripMenuItem.Checked = true;

            if (modeLightToolStripMenuItem.Checked)
            {
                richTextBox1.BackColor = Color.WhiteSmoke;
                richTextBox1.ForeColor = Color.Black;
                menuStrip1.BackColor = Color.LightGray;
                modeNightToolStripMenuItem.Checked = false;
            }

        }
        private void ModeNight()
        {
            modeNightToolStripMenuItem.CheckOnClick = true;
            if (modeNightToolStripMenuItem.Checked)
            {
                richTextBox1.BackColor = Color.Black;
                richTextBox1.ForeColor = Color.White;
                menuStrip1.BackColor = Color.DarkGray;
                modeLightToolStripMenuItem.Checked = false;
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to close file?", "information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                richTextBox1.Clear();

            }

        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewWindow();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "OPEN";
            openFileDialog1.Filter = "txt files(*.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.FilterIndex = 1;
            

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "OPEN",
               
                DefaultExt = "txt",
               FilterIndex = 1
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string content = File.ReadAllText(filePath); // قراءة الملف بالكامل
                    richTextBox1.Text = content; // عرض المحتوى في TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveAs();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (!String.IsNullOrWhiteSpace(richTextBox1.Text) && en.Checked)
          {
     if (MessageBox.Show("you want to save it ?", "information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
     {
         SaveAs();

     }
     else
     {

     }
 }

 else if (!String.IsNullOrWhiteSpace(richTextBox1.Text) && ar.Checked)
 {
     if (MessageBox.Show("هل تريد حفظ الملف؟ ", "معلومات", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
     {
         SaveAs();

     }
     else
     {

     }
 }
 else
 {
     if (MessageBox.Show("Хотите сохранить файл? ?", "информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
     {
         SaveAs();

     }
     else
     {

     }
 }
            this.Close();
        }
        string CopyText;
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Copy();


        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Past();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlignTextRightToLeft();
        }

        private void leftToRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlignTextLeftToRight();

        }



        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                AtivateButtons();
            }
            else
            {
                DesactivateButtons();
            }
        }

        private void aboutDopaNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutdopanote frm = new aboutdopanote();
            frm.ShowDialog();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redo();
        }

        private void modeNightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModeNight();
         
        }



        private void modeLightToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ModeLight();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm1 = new ReplaceForm();
            frm1.ShowDialog();
        }

      

        private void editBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editBarToolStripMenuItem.Checked)
            {
                toolStrip1.Visible = true;
            }
            else
            {
                toolStrip1.Visible = false;
            }
        }

        private void tsbtnnewwindow_Click(object sender, EventArgs e)
        {
            OpenNewWindow();
        }

        private void tsbtnsave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tabtnsaveas_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void tsbtnundo_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void tsbtnredo_Click(object sender, EventArgs e)
        {
            redo();
        }

        private void tsbtncopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void tsbtncut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void tsbtnpast_Click(object sender, EventArgs e)
        {
            Past();
        }

        private void tsbtnselectall_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void tsbtnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsbtnalightextleft_Click(object sender, EventArgs e)
        {
            AlignTextLeftToRight();
        }

        private void tsbtnaligntextright_Click(object sender, EventArgs e)
        {
            AlignTextRightToLeft();
        }

        private void tsbtnfont_Click(object sender, EventArgs e)
        {
            Font();
        }

        private void tsbtnfontcolor_Click(object sender, EventArgs e)
        {
            FontColor();
        }

        private void tsbtnbackgroundcolor_Click(object sender, EventArgs e)
        {
            BackGroundColor();
        }

        private void tsbtnprint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void ar_Click(object sender, EventArgs e)
        {
            TranslateToArabic();
        }

        private void en_Click(object sender, EventArgs e)
        {
            TranslateToEnglish();
        }

        private void ru_Click(object sender, EventArgs e)
        {
            TranslateToRussian();
        }

        private void copToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pastToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Past();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }


}
       

