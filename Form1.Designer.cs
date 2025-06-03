namespace Task_Scheduler
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
            textBox1 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            checkBox1 = new CheckBox();
            radioButton1 = new RadioButton();
            button1 = new Button();
            label2 = new Label();
            radioButton2 = new RadioButton();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(53, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(359, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "Введите новую задачу";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(199, 120);
            label1.Name = "label1";
            label1.Size = new Size(213, 20);
            label1.TabIndex = 1;
            label1.Text = "Выполненых/Невыполненых";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(53, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(359, 28);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Выберите приоритет задачи";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(53, 157);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(359, 84);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(53, 261);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(309, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Показать только невыполненые задачи";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(53, 331);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(135, 24);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "По приоритету";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(53, 403);
            button1.Name = "button1";
            button1.Size = new Size(359, 65);
            button1.TabIndex = 6;
            button1.Text = "Добавить задачу";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 120);
            label2.Name = "label2";
            label2.Size = new Size(136, 20);
            label2.TabIndex = 7;
            label2.Text = "Список всех задач";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(53, 361);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(172, 24);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "По дате добавления";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 299);
            label3.Name = "label3";
            label3.Size = new Size(178, 20);
            label3.TabIndex = 9;
            label3.Text = "Выбор типа сортировки";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 486);
            Controls.Add(label3);
            Controls.Add(radioButton2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(radioButton1);
            Controls.Add(checkBox1);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private ComboBox comboBox1;
        private ListBox listBox1;
        private CheckBox checkBox1;
        private RadioButton radioButton1;
        private Button button1;
        private Label label2;
        private RadioButton radioButton2;
        private Label label3;
    }
}
