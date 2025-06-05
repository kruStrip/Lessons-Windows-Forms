using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tapalka
{
    public partial class Form1 : Form
    {
        // настройки и состояние игры
        private const int ProgressPerClick = 1;   // очков за клик
        private const int ProgressBarMax = 10;  // кликов до нового уровня

        private int _level = 1;                    // текущий уровень
        private int _score = 0;                    // всего кликов

        private int _gameDurationSec = 30;         // длительность раунда (сек)
        private int _timeLeft;                     // секунд осталось

        private bool _isRunning = false;           // флаг «игра идёт»

        //конструктор
        public Form1()
        {
            InitializeComponent();

            // базовые свойства
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            progressBar1.Maximum = ProgressBarMax;
            progressBar1.Value = 0;

            // таймер
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;

            // клики по картинке
            pictureBox1.Click += pictureBox1_Click;

            // меню
            новаяИграToolStripMenuItem.Click += (_, __) => StartGame();
            выйтиToolStripMenuItem.Click += (_, __) => Close();

            // Настройки
            if (comboBox1 != null)
            {
                comboBox1.Items.AddRange(new object[] { 10, 20, 30, 45, 60 });
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                comboBox1.SelectedItem = _gameDurationSec;
            }
            if (button1 != null)
                button1.Click += ButtonChange_Click;

            UpdateDurationLabel();
            UpdateLevelLabel();
        }

        // запуск и завершение раунда 
        private void StartGame()
        {
            _level = 1;
            _score = 0;
            _timeLeft = _gameDurationSec;
            _isRunning = true;

            progressBar1.Value = 0;
            progressBar1.Enabled = true;
            pictureBox1.Enabled = true;

            UpdateLevelLabel();
            UpdateDurationLabel();
            timer1.Enabled = true;
        }

        private void EndGame()
        {
            _isRunning = false;
            timer1.Enabled = false;
            pictureBox1.Enabled = false;

            MessageBox.Show(this,
                $"Игра окончена!\nВсего кликов: {_score}\nДостигнут уровень: {_level}",
                "Результат",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        //события 
        private void pictureBox1_Click(object? sender, EventArgs e)
        {
            if (!_isRunning) return;

            _score++;
            progressBar1.Value = Math.Min(progressBar1.Value + ProgressPerClick, ProgressBarMax);

            if (progressBar1.Value >= ProgressBarMax)
            {
                _level++;
                progressBar1.Value = 0;
                UpdateLevelLabel();
            }
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            if (!_isRunning) return;

            _timeLeft--;
            UpdateDurationLabel();
            if (_timeLeft <= 0) EndGame();
        }

        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBox1?.SelectedItem is int sec)
            {
                _gameDurationSec = sec;
                UpdateDurationLabel();
            }
        }

        private void ButtonChange_Click(object? sender, EventArgs e) => StartGame();

        //вспомогательные
        private void UpdateLevelLabel() => label1.Text = $"Уровень {_level}";

        private void UpdateDurationLabel()
        {
            if (label3 != null)
            {
                label3.Text = _isRunning
                    ? $"Осталось: {_timeLeft} с"
                    : $"Текущая длительность: {_gameDurationSec} с";
            }
        }
    }
}
