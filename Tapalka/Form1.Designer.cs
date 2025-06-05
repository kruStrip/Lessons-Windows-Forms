namespace Tapalka
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            играToolStripMenuItem = new ToolStripMenuItem();
            новаяИграToolStripMenuItem = new ToolStripMenuItem();
            выйтиToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(639, 687);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(progressBar1);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(631, 654);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Игра";
            tabPage1.UseVisualStyleBackColor = true;
            //tabPage1.Click += tabPage1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(631, 654);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Настройки";
            tabPage2.UseVisualStyleBackColor = true;
            //tabPage2.Click += tabPage2_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(640, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { играToolStripMenuItem, выйтиToolStripMenuItem });
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(65, 24);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // играToolStripMenuItem
            // 
            играToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новаяИграToolStripMenuItem });
            играToolStripMenuItem.Name = "играToolStripMenuItem";
            играToolStripMenuItem.Size = new Size(224, 26);
            играToolStripMenuItem.Text = "Игра";
            // 
            // новаяИграToolStripMenuItem
            // 
            новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            новаяИграToolStripMenuItem.Size = new Size(224, 26);
            новаяИграToolStripMenuItem.Text = "Новая игра";
            // 
            // выйтиToolStripMenuItem
            // 
            выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            выйтиToolStripMenuItem.Size = new Size(224, 26);
            выйтиToolStripMenuItem.Text = "Выйти";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(235, 8);
            label1.Name = "label1";
            label1.Size = new Size(142, 41);
            label1.TabIndex = 0;
            label1.Text = "Уровень:";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(30, 52);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(574, 43);
            progressBar1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 101);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(574, 547);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleTurquoise;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Location = new Point(167, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 354);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(24, 145);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(229, 28);
            comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Violet;
            button1.Location = new Point(24, 237);
            button1.Name = "button1";
            button1.Size = new Size(229, 90);
            button1.TabIndex = 1;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(24, 18);
            label2.Name = "label2";
            label2.Size = new Size(229, 107);
            label2.TabIndex = 2;
            label2.Text = "Выберите длительность игры (в секундах)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 193);
            label3.Name = "label3";
            label3.Size = new Size(172, 20);
            label3.TabIndex = 3;
            label3.Text = "Текущая длительность: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 709);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Тапалка";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem играToolStripMenuItem;
        private ToolStripMenuItem новаяИграToolStripMenuItem;
        private ToolStripMenuItem выйтиToolStripMenuItem;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private Button button1;
        private ComboBox comboBox1;
        private Label label3;
        private Label label2;
    }
}
