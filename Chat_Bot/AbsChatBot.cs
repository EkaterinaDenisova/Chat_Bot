//@author Денисова Екатерина
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Bot
{
    // абстрактный класс бота
    public abstract class AbsChatBot
    {
        public abstract void Answer(string q);
    }
}
