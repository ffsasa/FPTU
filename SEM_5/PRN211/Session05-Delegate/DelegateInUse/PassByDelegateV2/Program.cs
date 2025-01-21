namespace PassByDelegateV2
{
    internal class ShowBiz
    {
        public static void PrintSongLyricsThe1()
        {
            Console.WriteLine("The song The 1 - by Taylor Swift");
            Console.WriteLine("Lyrics 1 ...");
        }

        public void PrintSongLyricsThe2()
        {
            Console.WriteLine("The song The 2 - by Taylor Swift");
            Console.WriteLine("Lyrics 2 ...");
        }
    }
        internal class Program
    {
            static void Main(string[] args)
        {
            Console.WriteLine("C4: Call the method outside");
            Action f1 = ShowBiz.PrintSongLyricsThe1;

            ShowBiz a = new ShowBiz();
            Action f2 = a.PrintSongLyricsThe2;

            Action f3 = new ShowBiz().PrintSongLyricsThe2;

            f1();
            f2();
            f3();
        }
    }

}
