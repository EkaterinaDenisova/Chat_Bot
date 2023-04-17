using Chat_Bot;
namespace TestProject_Chat
{
    [TestClass]
    public class ChatBotTest
    {
        [TestMethod]
        public void TestMethodBotSum()
        {
            ChatBot bot = new ChatBot();
            Assert.AreEqual(5, bot.BotSum("Сложи 2 и 3"));
            Assert.AreEqual(11, bot.BotSum("Сложи 10 и 1"));
            Assert.AreEqual(121, bot.BotSum("Сложи 50 и 71"));
        }

        [TestMethod]
        public void TestMethodBotSub()
        {
            ChatBot bot = new ChatBot();
            Assert.AreEqual(5, bot.BotSub("Вычти 5 из 10"));
            Assert.AreEqual(12, bot.BotSub("Вычти 22 из 34"));
            Assert.AreEqual(-2, bot.BotSub("Вычти 42 из 40"));
        }

        [TestMethod]
        public void TestMethodBotMult()
        {
            ChatBot bot = new ChatBot();
            Assert.AreEqual(10, bot.BotMult("Умножь 5 на 2"));
            Assert.AreEqual(24, bot.BotMult("Умножь 3 на 8"));
            Assert.AreEqual(186, bot.BotMult("Умножь 62 на 3"));
        }

        [TestMethod]
        public void TestMethodBotDiv()
        {
            ChatBot bot = new ChatBot();
            Assert.AreEqual(21, bot.BotDiv("Подели 63 на 3"));
            Assert.AreEqual(2.5, bot.BotDiv("Подели 5 на 2"));
            Assert.AreEqual(8, bot.BotDiv("Раздели 40 на 5"));
        }

        [TestMethod]
        public void TestMethodBotAnswer()
        {
            ChatBot bot = new ChatBot();

            bot.Answer("Сложи 3 и 61");
            Assert.AreEqual("64", bot.history[bot.history.Count-1]);

            bot.Answer("Вычти 5 из 77");
            Assert.AreEqual("72", bot.history[bot.history.Count - 1]);

            bot.Answer("Умножь 5 на 11");
            Assert.AreEqual("55", bot.history[bot.history.Count - 1]);

            bot.Answer("Подели 12 на 6");
            Assert.AreEqual("2", bot.history[bot.history.Count - 1]);

            bot.Answer("Какое сегодня число?");
            Assert.AreEqual("Дата: " + DateTime.Now.ToString("dd/MM/yyyy"), bot.history[bot.history.Count - 1]);

            bot.Answer("Сколько времени?");
            Assert.AreEqual("Время: " + DateTime.Now.ToString("HH:mm:ss"), bot.history[bot.history.Count - 1]);

            bot.Answer("сложи 3");
            Assert.AreEqual("Не знаю такой команды", bot.history[bot.history.Count - 1]);

            bot.Answer("Как дела?");
            Assert.AreEqual("Не знаю такой команды", bot.history[bot.history.Count - 1]);

            bot.Answer("Пока");
            Assert.AreEqual("Не знаю такой команды", bot.history[bot.history.Count - 1]);

        }

    }
}