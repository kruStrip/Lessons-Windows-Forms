using System;
using System.Windows.Forms;

namespace The_Clicker_game
{
    public partial class Form1 : Form
    {
        // Переменные для игры:
        private int currentLevel;           // текущий уровень
        private int clicksToNextLevel;      // сколько кликов нужно для перехода дальше
        private int timeLeft;               // сколько секунд осталось до конца игры
        private int gameDuration = 30;      // длительность игры в секундах (по умолчанию 30)

        public Form1()
        {
            InitializeComponent();

            // ↓↓↓ Инициализация интерфейса при старте программы ↓↓↓

            // 1) Пока игра не запущена, картинка не кликабельна
            pictureBox1.Enabled = false;

            // 2) Подпись «Уровень X» выставляем в 0
            label1.Text = "Уровень 0";

            // 3) Настроим comboBox1: добавим фиксированные варианты (5, 10, 15, 20, 30, 60, 90, 120)
            comboBox1.Items.Clear();
            comboBox1.Items.Add("5");
            comboBox1.Items.Add("10");
            comboBox1.Items.Add("15");
            comboBox1.Items.Add("20");
            comboBox1.Items.Add("30");
            comboBox1.Items.Add("60");
            comboBox1.Items.Add("90");
            comboBox1.Items.Add("120");
            // Выберем по умолчанию «30»
            comboBox1.SelectedItem = "30";

            // 4) Обновим подпись «Текущая длительность: XX сек.»
            label3.Text = "Текущая длительность: " + gameDuration.ToString() + " сек.";

            // 5) Таймер (timer1) у нас в Designer-е уже создан с Interval = 1000
            //    Код обработчика timer1_Tick мы опишем ниже.
        }

        // ============================
        // Обработчики пунктов меню
        // ============================

        // Меню «Игра → Новая игра»
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        // Меню «Выход»
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ============================
        // Обработчик кнопки «Изменить» на вкладке «Настройки»
        // ============================
        private void button1_Click(object sender, EventArgs e)
        {
            // Пользователь нажал «Изменить», когда выбрал что-то в comboBox1
            if (comboBox1.SelectedItem != null)
            {
                // Пробуем распарсить выбранную строку в число
                bool ok = Int32.TryParse(comboBox1.SelectedItem.ToString(), out int val);
                if (ok && val > 0)
                {
                    // Если всё нормально, запомним новую длительность
                    gameDuration = val;
                    // Уведомим пользователя
                    MessageBox.Show(
                        "Длительность игры установлена: " + gameDuration + " секунд.",
                        "Настройки сохранены",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    // Перепишем надпись «Текущая длительность:»
                    label3.Text = "Текущая длительность: " + gameDuration.ToString() + " сек.";
                }
                else
                {
                    // Парсить не удалось (маловероятно, т.к. ComboBox статический)
                    MessageBox.Show(
                        "Неверное значение длительности. Пожалуйста, выберите число из списка.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            else
            {
                // Если вообще ничего не выбрано
                MessageBox.Show(
                    "Для начала выберите длительность в списке.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // ============================
        // Запуск новой игры
        // ============================
        private void StartNewGame()
        {
            // 1) Считываем, сколько секунд даём игроку
            timeLeft = gameDuration;

            // 2) Ставим первый уровень
            currentLevel = 1;
            label1.Text = "Уровень " + currentLevel.ToString();

            // 3) На 1-м уровне нужно 10 кликов
            clicksToNextLevel = 10;
            progressBar1.Maximum = clicksToNextLevel;
            progressBar1.Value = 0;

            // 4) Включаем клики по картинке
            pictureBox1.Enabled = true;

            // 5) Переключаемся на вкладку «Игра»
            tabControl1.SelectedTab = Игра;

            // 6) Запускаем таймер
            timer1.Start();
        }

        // ============================
        // Обработчик клика по картинке
        // ============================
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Если прогресс-бар ещё не заполнен, добавляем 1 к Value
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                // Если теперь Value == Maximum, значит уровень пройден
                if (progressBar1.Value >= progressBar1.Maximum)
                {
                    GoToNextLevel();
                }
            }
        }

        // ============================
        // Переход на следующий уровень
        // ============================
        private void GoToNextLevel()
        {
            currentLevel++;
            label1.Text = "Уровень " + currentLevel.ToString();

            // Пусть каждый новый уровень требует на 5 кликов больше, чем предыдущий
            clicksToNextLevel += 5;
            progressBar1.Maximum = clicksToNextLevel;
            progressBar1.Value = 0;
        }

        // ============================
        // Обработчик таймера (1 тик = 1 секунда)
        // ============================
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                // Для наглядности напишем оставшееся время прямо в заголовок окна
                this.Text = "Тапалка – Осталось: " + timeLeft.ToString() + " сек.";
            }
            else
            {
                // Время закончилось
                timer1.Stop();
                pictureBox1.Enabled = false; // запретим клики по картинке

                MessageBox.Show(
                    "Время вышло!\nВы достигли уровня " + currentLevel.ToString() + ".",
                    "Игра завершена",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Сбросим интерфейс в исходное состояние
                label1.Text = "Уровень 0";
                progressBar1.Value = 0;
                this.Text = "Тапалка";
            }
        }
    }
}
