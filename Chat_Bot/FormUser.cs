using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Threading; // для переключения между формами

namespace Chat_Bot
{
    // класс формы для ввода имени пользователя
    public partial class FormUser : Form
    {
        //Thread th;

        // конструктор формы
        public FormUser()
        {
            InitializeComponent();
        }

        // при нажатии кнопки "Запустить бота"
        private void button_start_Click(object sender, EventArgs e)
        {
            //th = new Thread(open);
            //th.SetApartmentState(ApartmentState.STA);
            //th.Start();

            // второе окно
            FormChat chat_window = new FormChat();

            if (textBox_name.Text == "")
            {
                // автоматически задать имя, если пользователь его не ввёл
                chat_window.bot.SetUserName("user");
            }
            else
            {
                chat_window.bot.SetUserName(textBox_name.Text);  // считывание имени
            }

            // показать второе окно
            chat_window.Show();

            // закрытие формы для ввода имени пользователя
            this.Hide();
        }

        // при нажатии клавиши Enter
        private void FormUser_KeyDown(object sender, KeyEventArgs e)
        {
            // если нажатая клавиша - Enter
            if (e.KeyValue == (char)Keys.Enter)
            {
                button_start_Click(button_start, null);
                e.Handled = true;
                // больше не передавать событие нажатия на клавишу элементу управления
                e.SuppressKeyPress = true;
            }
        }

        /*public void open (object obj)
        {
            Application.Run(new FormChat()); // запуск окна для общения с ботом
        }*/
    }
}
