using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// если выбрали отключить nullable
#nullable disable

namespace Text_Editor
{
    public class TextEditorForm : Form
    {
        // Пример с null!-инициализацией
        private MenuStrip menuStrip = null!;
        private ToolStripMenuItem fileMenu = null!;
        private ToolStripMenuItem openMenuItem = null!;
        private ToolStripMenuItem saveMenuItem = null!;
        private OpenFileDialog openFileDialog = null!;
        private SaveFileDialog saveFileDialog = null!;
        private RichTextBox richTextBox = null!;
        private VScrollBar fontSizeScrollBar = null!;

        public TextEditorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form
            this.Text = "Simple Text Editor";
            this.ClientSize = new Size(800, 600);

            // MenuStrip
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem("Файл");
            openMenuItem = new ToolStripMenuItem("Открыть", null, OpenMenuItem_Click);
            saveMenuItem = new ToolStripMenuItem("Сохранить", null, SaveMenuItem_Click);
            fileMenu.DropDownItems.AddRange(new[] { openMenuItem, saveMenuItem });
            menuStrip.Items.Add(fileMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // OpenFileDialog
            openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            // SaveFileDialog
            saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            // RichTextBox
            richTextBox = new RichTextBox
            {
                Location = new Point(10, 30),
                Size = new Size(760, 520),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font(FontFamily.GenericSansSerif, 12f)
            };
            this.Controls.Add(richTextBox);

            // VScrollBar for font size
            fontSizeScrollBar = new VScrollBar
            {
                Location = new Point(775, 30),
                Size = new Size(20, 520),
                Minimum = 8,
                Maximum = 72,
                Value = 12,
                SmallChange = 1,
                LargeChange = 2,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right
            };
            fontSizeScrollBar.ValueChanged += FontSizeScrollBar_ValueChanged;
            this.Controls.Add(fontSizeScrollBar);
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, richTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
                }
            }
        }

        private void FontSizeScrollBar_ValueChanged(object sender, EventArgs e)
        {
            float newSize = fontSizeScrollBar.Value;
            richTextBox.Font = new Font(richTextBox.Font.FontFamily, newSize);
        }
    }
}
