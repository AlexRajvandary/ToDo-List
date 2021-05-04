using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace TaskLib
{
   /// <summary>
   /// Задача ToDo листа, которая обладает непосредственно самой формулировкой ( content ) и сроком выполнения ( deadline )
   /// </summary>
    public class _Task
    {
        private string _Content;
       
        /// <summary>
        /// Формулировка задачи
        /// </summary>
        public string Content
        {
            get => _Content;
            set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Ошибка: пустая задача!");
                _Content = value;
            }
        }
       /// <summary>
       /// Время создания задачи
       /// </summary>
        public DateTime CurrentDate { get; set; }
        private DateTime _DeadLine;
        
        /// <summary>
        /// Срок выполнения задачи
        /// </summary>
        public DateTime DeadLine
        {
            get => _DeadLine;
            set
            {
                if (value <= CurrentDate)
                {
                    throw new ArgumentException("Ошибка с датой: Дедлайн не может быть раньше текущего времени или совпадать с ним!");
                }
                _DeadLine = value;
            }
        }

        public _Task(string Content, DateTime DeadLine)
        {
            this.Content = Content;
            this.DeadLine = DeadLine;
            CurrentDate = DateTime.Now;
        }
    }
}