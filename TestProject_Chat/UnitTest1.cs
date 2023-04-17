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
            Assert.AreEqual(5, bot.BotSum("����� 2 � 3"));
            Assert.AreEqual(11, bot.BotSum("����� 10 � 1"));
            Assert.AreEqual(121, bot.BotSum("����� 50 � 71"));
        }

        [TestMethod]
        public void TestMethodBotSub()
        {
            ChatBot bot = new ChatBot();
            Assert.AreEqual(5, bot.BotSub("����� 5 �� 10"));
            Assert.AreEqual(12, bot.BotSub("����� 22 �� 34"));
            Assert.AreEqual(-2, bot.BotSub("����� 42 �� 40"));
        }

        [TestMethod]
        public void TestMethodBotMult()
        {
            ChatBot bot = new ChatBot();
            Assert.AreEqual(10, bot.BotMult("������ 5 �� 2"));
            Assert.AreEqual(24, bot.BotMult("������ 3 �� 8"));
            Assert.AreEqual(186, bot.BotMult("������ 62 �� 3"));
        }

        [TestMethod]
        public void TestMethodBotDiv()
        {
            ChatBot bot = new ChatBot();
            Assert.AreEqual(21, bot.BotDiv("������ 63 �� 3"));
            Assert.AreEqual(2.5, bot.BotDiv("������ 5 �� 2"));
            Assert.AreEqual(8, bot.BotDiv("������� 40 �� 5"));
        }

        [TestMethod]
        public void TestMethodBotAnswer()
        {
            ChatBot bot = new ChatBot();

            bot.Answer("����� 3 � 61");
            Assert.AreEqual("64", bot.history[bot.history.Count-1]);

            bot.Answer("����� 5 �� 77");
            Assert.AreEqual("72", bot.history[bot.history.Count - 1]);

            bot.Answer("������ 5 �� 11");
            Assert.AreEqual("55", bot.history[bot.history.Count - 1]);

            bot.Answer("������ 12 �� 6");
            Assert.AreEqual("2", bot.history[bot.history.Count - 1]);

            bot.Answer("����� ������� �����?");
            Assert.AreEqual("����: " + DateTime.Now.ToString("dd/MM/yyyy"), bot.history[bot.history.Count - 1]);

            bot.Answer("������� �������?");
            Assert.AreEqual("�����: " + DateTime.Now.ToString("HH:mm:ss"), bot.history[bot.history.Count - 1]);

            bot.Answer("����� 3");
            Assert.AreEqual("�� ���� ����� �������", bot.history[bot.history.Count - 1]);

            bot.Answer("��� ����?");
            Assert.AreEqual("�� ���� ����� �������", bot.history[bot.history.Count - 1]);

            bot.Answer("����");
            Assert.AreEqual("�� ���� ����� �������", bot.history[bot.history.Count - 1]);

        }

    }
}