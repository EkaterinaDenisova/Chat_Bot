using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; // регулярные выражения
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chat_Bot
{
    // класс формы для общения с ботом
    public partial class FormChat : Form
    {
        
        // указатель на объект класса ChatBot
        public ChatBot bot = new ChatBot();

        // конструктор формы
        public FormChat()
        {
            InitializeComponent();

            // загрузка истории из файла в list history
            bot.LoadHistory();

            // вывод истории на форму из history
            for (int i = 0; i < bot.history.Count; i++)
            {
                textBox_chat.AppendText(bot.history[i] + "\r\n");
                if ((i+1)%4 == 0)
                {
                    textBox_chat.AppendText("\r\n");                    
                }
            }

            // прокрутка к последней строке в поле вывода
            //textBox_chat.ScrollToEnd();
            //textBox_chat.SelectionStart = textBox_chat.Text.Length;
            //textBox_chat.Focus();
            //textBox_chat.ScrollToCaret();
            //textBox_chat.Select();

            // активное поле ввода
            textBox_request.Select();

            /*bot.LoadHistory();
            bot.lastLineIndex = bot.history.Count()-1;

            for (int i = 0; i <= bot.lastLineIndex; i++)
            {
                textBox_chat.AppendText(bot.history[i]);
            }*/
        }




        // очистить поле вывода
        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_chat.Clear();
        }

        // при нажатии кнопки "Отправить запрос"
        private void button_request_Click(object sender, EventArgs e)
        {
            // количество элементов в history до обработки запроса
            int countlines = bot.history.Count;

            // обработка запроса пользователя
            bot.Answer(textBox_request.Text);

            // вывод запроса пользователя и ответа бота в поле вывода            
            for (int i = countlines; i < bot.history.Count; i++)
            {
                textBox_chat.AppendText(bot.history[i] + "\r\n");
            }
            textBox_chat.Text += "\r\n";

            // очистить поле ввода
            textBox_request.Clear(); 

            // прокрутка к последнему сообщению в поле вывода
            textBox_chat.SelectionStart = textBox_chat.TextLength;
            textBox_chat.ScrollToCaret();
        }

        // при закрытии формы чата
        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            // сохранение истории в файл
            bot.SaveHistory();
            // закрытие приложения
            Application.Exit();
        }

        // справка
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_chat.Text += "Вот что я умею: \r\n" +
                "1) Здороваться (напиши мне \"привет\", \"хай:)\" и всё в таком духе)\r\n" +
                "2) Складывать, вычитать, умножать и делить числа (\"сложи 5 и 7\",\r\n" +
                "\"вычти 5 из 10\", \"умножь 11 на 4\", \"подели 9 на 3\")\r\n" +
                "3) Говорить дату или время (\"Который час?\", \"Сколько времени\",\r\n" +
                "\"Какая сегодня дата/число/день?\")\r\n" +
                "4) Говорить температуру (\"Какая погода/температура?\", \"Сколько градусов?\")\r\n\r\n";

            // прокрутка к последнему сообщению в поле вывода
            textBox_chat.SelectionStart = textBox_chat.TextLength;
            textBox_chat.ScrollToCaret();

        }

        // при нажатии клавиши
        private void FormChat_KeyDown(object sender, KeyEventArgs e)
        {
            // если нажатая клавиша - Enter
            if (e.KeyValue == (char)Keys.Enter)
            {
                button_request_Click(button_request,null);

                e.Handled = true;
                // больше не передавать событие нажатия на клавишу элементу управления
                e.SuppressKeyPress = true;
            }
        }
    }
}
