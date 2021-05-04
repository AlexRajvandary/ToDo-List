using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using TaskLib;
using Newtonsoft.Json;
using System.IO;


namespace MyToDoList
{
   
    public partial class Form1 : Form
    {
        List<_Task> _Tasks = new List<_Task>();
        string path = "SavedText.json";
        string content;
        DateTime deadline;
        

        public Form1()

        {
            InitializeComponent();
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            content = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _Task task = new _Task(content, deadline);


                
                _Tasks.Add(task);
                TaskSerializer(_Tasks, path);
                Logger.Log($"Задание:{task.Content}, дедлайн {task.DeadLine}");
                
            }catch(Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}");
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            deadline = dateTimePicker1.Value;
        }
        private void TaskSerializer (List<_Task> tasks,string path)
        {
            //string serialized_list = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            //File.WriteAllText(path, serialized_list);
            using (StreamWriter writer = new StreamWriter(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, tasks);
            }
        }
       
        /// <summary>
        /// Десериализация
        ///     Служит для открытия сохраненных задач
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<_Task> TaskDeserializer (string path)
        {
            if (File.Exists(path))
            {
                List<_Task> resultObjects = JsonConvert.DeserializeObject<List<_Task>>(File.ReadAllText(path));
                return resultObjects;
            }
            else
            {
                return new List<_Task>();
            }
           
        }

        /// <summary>
        /// Кнопка Load загружает сохраненные задачи и отображает их в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _Tasks= TaskDeserializer(path);
            
            foreach(var i  in _Tasks)
            {
                taskBindingSource.Add(i);
            }
          

        }

      
        /// <summary>
        /// Кнопка Clean memory, удаляет сохраненные раннее задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanMemory_Click(object sender, EventArgs e)
        {
            
                _Tasks.Clear();
                File.Delete(path);
            taskBindingSource.Clear();
                dataGridView1.Update();
           

          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    

}
