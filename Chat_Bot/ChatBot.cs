/// @author Денисова Екатерина
/// класс бот

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using System.Windows.Forms;
using Newtonsoft.Json;

namespace Chat_Bot
{
    // класс бота (наследуется от AbsChatBot)
    public class ChatBot : AbsChatBot
    {

        // ссылка на сайт с погодой
        const string URL_WEATHER = "https://api.openweathermap.org/data/2.5/weather?q=Chita,ru&units=metric&appid=ab34896f51377943f5ff794a7f16498d";

        // имя пользователя
        public string uName;  

        // приветствие
        public static Regex regexHello = new Regex(@"пр(и|e)ве*т|прив|х(а|e|э)*й|hi*|hello*|(зд|д)(а|о)ро*(в|у)", RegexOptions.IgnoreCase);
        // время
        public static Regex regexTime = new Regex(@"ча(с|сов)|врем(я|ени)", RegexOptions.IgnoreCase);
        // дата
        public static Regex regexDate = new Regex(@"дата|число|день", RegexOptions.IgnoreCase);
        // команды с параметрами
        public static Regex regexSum = new Regex(@"^сложи \d* и \d*$", RegexOptions.IgnoreCase);
        public static Regex regexSub = new Regex(@"^вычти \d* из \d*$", RegexOptions.IgnoreCase);
        public static Regex regexMult = new Regex(@"^умножь \d* на \d*$", RegexOptions.IgnoreCase);
        public static Regex regexDiv = new Regex(@"^(раз|по)дели \d* на \d*$", RegexOptions.IgnoreCase);
        // погода
        public static Regex regexWeather = new Regex(@"погода|градус(ов|ы)|температура", RegexOptions.IgnoreCase);


        // задать имя пользователя
        public void SetUserName(string s)
        {
            uName = s;
        }

        // список из строк (история сообщений)
        public List<string> history = new List<string>();

        /// Загрузка истории из файла в list history
        public void LoadHistory(string path = "history.txt")
        {
            // проверка на существование файла
            // если не существует, то создать
            /*if (!File.Exists(path))
            {
                File.Create(path);

            }
            string s;*/
            // чтение
            /*using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }*/

            try
            {
                // загружаем историю из файла, если он существует
                // AddRange добавляет параметры в конец list
                // ReadAllLines считывает все строки из файла path
                history.AddRange(File.ReadAllLines(path, Encoding.GetEncoding(1251)));

            }
            catch
            {
                // Если файл не существует, то создаем его
                // WriteAllLines создаёт файл path, сохраняет в него history
                // ToArray() - преобразование list в массив
                File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));
            }



        }

        /// добавление строки s в history и в файл path
        public void SaveHistory(string path = "history.txt")
        {
            /*if (!File.Exists(path))
            {
                File.Create(path);
            }*/

            /*if (s == null)
            {
                s = "";
            }*/

            // добавление текста в файл
            /*using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(s);
            }*/

            // добавление в файл
            /*using (StreamWriter writer = new StreamWriter(path, true))
            {
                for (int i = lastLineIndex+1; i < history.Count(); i++)
                {
                    writer.WriteLine(history[i]);
                }  
            }*/

            File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));
        }


        // ответ бота на приветствие
        public string BotHello()
        {
            Random r = new Random();
            string[] arr = { "Привет", "Приветствую", "Хэй", "Здаров"};
            int a = r.Next(arr.Length); // случайный индекс массива

            return arr[a] + ", " + uName + "!";
        }

        /// ответ бота на запрос о времени
        public string BotTime()
        {
            return "Время: " + DateTime.Now.ToString("HH:mm:ss");
        }

        /// ответ бота на запрос о дате
        public string BotDate()
        {
            return "Дата: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        /// ответ бота на запрос о сумме
        public int BotSum(string s)
        {
            string[] s_arr = s.Split();
            int x1 = int.Parse(s_arr[1]);
            int x2 = int.Parse(s_arr[3]);
            return x1+x2;
        }

        /// ответ бота на запрос о разности
        public int BotSub(string s)
        {
            string[] s_arr = s.Split();
            int x1 = int.Parse(s_arr[1]);
            int x2 = int.Parse(s_arr[3]);
            return x2 - x1;
        }

        /// ответ бота на запрос об умножении
        public int BotMult(string s)
        {
            string[] s_arr = s.Split();
            int x1 = int.Parse(s_arr[1]);
            int x2 = int.Parse(s_arr[3]);
            return x1 * x2;
        }

        /// ответ бота на запрос о делении
        public double BotDiv(string s)
        {
            string[] s_arr = s.Split();
            double x1 = int.Parse(s_arr[1]);
            double x2 = int.Parse(s_arr[3]);
            return x1/x2;
        }

        /// ответ бота на запрос о погоде
        public string BotWeather()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL_WEATHER); 
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            return "Температура в " + weatherResponse.Name + ": " + weatherResponse.Main.Temp + "°C";
        }

        // шаблон ответа бота
        public string BotAnswer()
        {
            return "Бот, " + DateTime.Now.ToString("HH:mm:ss") + ":"; // + "\r\n" + ans + "\r\n";
        }

        // шаблон ответа пользователя
        public string UserRequest()
        {
            return uName + ", " + DateTime.Now.ToString("HH:mm:ss") + ":"; //+ "\r\n" + req + "\r\n";
        }


        /// обработка регулярных выражений и формирование ответа бота
        /// переопределённый метод абстрактного класса
        public override void Answer(string q)
        {   

            history.Add(UserRequest());
            history.Add(q);
            history.Add(BotAnswer());
          
            // если запрос совпадает с регулярным выражением
            if (regexHello.IsMatch(q))
            {
                history.Add(BotHello());
            }

            else if (regexTime.IsMatch(q))
            {
                history.Add(BotTime());
            }

            else if (regexDate.IsMatch(q))
            {
                history.Add(BotDate());
            }

            else if (regexSum.IsMatch(q))
            {
                history.Add(Convert.ToString((BotSum(q))));
            }

            else if (regexSub.IsMatch(q))
            {
                history.Add(Convert.ToString((BotSub(q))));
            }

            else if (regexMult.IsMatch(q))
            {
                history.Add(Convert.ToString((BotMult(q))));
            }

            else if (regexDiv.IsMatch(q))
            {

                history.Add(Convert.ToString((BotDiv(q))));
            }
            else if (regexWeather.IsMatch(q))
            {
                history.Add(BotWeather());
            }
            // если запрос не совпадает с регулярным выражением
            else
            {
                history.Add("Не знаю такой команды");
            }
        }


    }


}
