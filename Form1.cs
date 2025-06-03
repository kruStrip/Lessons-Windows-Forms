namespace Task_Scheduler
{
    public partial class Form1 : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("Высокий");
            comboBox1.Items.Add("Средний");
            comboBox1.Items.Add("Низкий");
            comboBox1.SelectedIndex = 0; // по умолчанию “Высокий”
        }

        // Обработчик кнопки “Добавить задачу”
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && comboBox1.SelectedItem != null)
            {
                // Создаём новую задачу
                TaskItem newTask = new TaskItem
                {
                    Description = textBox1.Text,
                    Priority = comboBox1.SelectedItem.ToString(),
                    DateAdded = DateTime.Now,
                    Completed = false
                };

                // Добавляем задачу
                tasks.Add(newTask);

                // Очищаем текстовое поле
                textBox1.Text = "";

                // Перерисовываем список
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show(
                    "Нельзя добавить пустую задачу. Введите текст и выберите приоритет.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Метод для фильтрации + сортировки + перерисовки
        private void UpdateTaskList()
        {
            // Показывать только невыполненные
            List<TaskItem> displayTasks = new List<TaskItem>();
            foreach (TaskItem t in tasks)
            {
                if (!checkBox1.Checked || (checkBox1.Checked && t.Completed == false))
                {
                    displayTasks.Add(t);
                }
            }

            // 2) Сортировка
            if (radioButton1.Checked)
            {
                // По приоритету
                List<TaskItem> high = new List<TaskItem>();
                List<TaskItem> medium = new List<TaskItem>();
                List<TaskItem> low = new List<TaskItem>();

                foreach (TaskItem t in displayTasks)
                {
                    if (t.Priority == "Высокий") high.Add(t);
                    else if (t.Priority == "Средний") medium.Add(t);
                    else low.Add(t);
                }

                displayTasks.Clear();
                displayTasks.AddRange(high);
                displayTasks.AddRange(medium);
                displayTasks.AddRange(low);
            }
            else if (radioButton2.Checked)
            {
                // По дате добавления
                for (int i = 0; i < displayTasks.Count - 1; i++)
                {
                    for (int j = i + 1; j < displayTasks.Count; j++)
                    {
                        if (displayTasks[i].DateAdded > displayTasks[j].DateAdded)
                        {
                            TaskItem tmp = displayTasks[i];
                            displayTasks[i] = displayTasks[j];
                            displayTasks[j] = tmp;
                        }
                    }
                }
            }

            listBox1.Items.Clear();
            foreach (TaskItem t in displayTasks)
            {

                listBox1.Items.Add(t);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Показать только невыполненные
            UpdateTaskList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При клике по задаче в списке переключаем у неё состояние на Выполненая 
            if (listBox1.SelectedIndex == -1)
                return;

            TaskItem selectedTask = (TaskItem)listBox1.SelectedItem;
            selectedTask.Completed = !selectedTask.Completed;
            UpdateTaskList();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // По приоритету
            UpdateTaskList();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // По дате добавления
            UpdateTaskList();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    // Хранит данные одной задачи
    public class TaskItem
    {
        public string Description { get; set; }   // Текст задачи
        public string Priority { get; set; }      
        public DateTime DateAdded { get; set; }   // Время, когда задача была создана
        public bool Completed { get; set; }       // Выполнена ли задача

        // Отображение
        public override string ToString()
        {
            string status = Completed ? " [Выполнено]" : "";
            return Description + " (" + Priority + ")" + status;
        }
    }
}
