        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveStory
{
    delegate void SendLoveMessageDelegate();
    internal class KuKia
    {   
        public static void MeetSweetHeart()
        {
            Console.WriteLine("Hey baby, oh my sweet heart.");
            SendLoveMessageDelegate message = new SendLoveMessageDelegate(Tui.TellHer);
            message += Ban.NhanEm;

            Console.WriteLine("By the way, you have message from...");
            message();
        }
    }
}
