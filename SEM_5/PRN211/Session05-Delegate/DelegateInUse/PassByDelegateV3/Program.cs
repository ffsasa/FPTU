namespace PassByDelegateV3
{
    //C5: In ra lời của 2 bài hát thông qua truyền hàm in bài hát vào 1 hàm in tập trung
    //1 hàm chịu trách nhiệm thầu một cái trung tâm nhận các lệnh in khác nhau được đưa vào.
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSongLyricsThe1();
            PrintSongLyricsThe2();

            Console.WriteLine();
            Console.WriteLine("Call by delegate:");
            Action f = PrintSongLyricsThe1;
            f += PrintSongLyricsThe2;
            f();

            Console.WriteLine("Call both method at the same time.");
            PrintOnDemand();

            Console.WriteLine("Call method - dependency injection style");
            PrintOnDemand(f);
            //PrintOnDemand(Action f = () => {});
            //PrintOnDemand(Action f = delegate () {});
            //PrintOnDemand(f);

            PrintOnDemand(PrintSongLyricsThe1);
            PrintOnDemand(() => { Console.WriteLine("Chúc ta của tương lai"); });
            PrintOnDemand(delegate () { });

            //In ra các số từ 1...100
            //In ra các số nguyên tố 1..100
            PrintOnDemand(() =>
            {
                Console.WriteLine("1..100");
                for(int i = 1; i <= 100; i++) 
                {
                    Console.Write(i + " ");
                }
            });

        }


        //Cần in gì, truyền vào tao in cho, truyền hàm vào, t làm cho
        //Style của Solution Architect
        //Call back function
        static void PrintOnDemand(Action f)
        {
            f();
        }
        static void PrintOnDemand()
        {
            PrintSongLyricsThe1();
            PrintSongLyricsThe2();
        }

        static void PrintSongLyricsThe1()
        {
            Console.WriteLine("The song The 1 - by Taylor Swift");
            Console.WriteLine("Lyrics 1 ...");
        }
        static void PrintSongLyricsThe2()
        {
            Console.WriteLine("The song The 2 - by Taylor Swift");
            Console.WriteLine("Lyrics 2 ...");
        }
    }
}
