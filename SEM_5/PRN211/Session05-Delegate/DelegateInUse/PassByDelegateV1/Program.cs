namespace PassByDelegateV1
{
    //C1: In ra 2 bài hát của Taylor Swift
    //C2: Sử dụng qua delegate
    //C3: Sử dụng hàm ẩn danh vào Lambda để gọi 2 bài khác
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C1: Call explicit method:");
            Song.PrintSongLyricsThe1();
            PrintSongLyricsThe2();
            Console.WriteLine();

            Console.WriteLine("C2: Call explicit method by delegate:");
            Action f1 = Song.PrintSongLyricsThe1;
            f1 += PrintSongLyricsThe2;
            f1();
            Console.WriteLine();


            Console.WriteLine("C3: Call explicit method by lambda:");
            Action f2 = () =>
            {
                Console.WriteLine("The song The 3 - by Taylor Swift");
                Console.WriteLine("Lyrics 3 ...");
            };
            f2 += () =>
            {
                Console.WriteLine("The song The 4 - by Taylor Swift");
                Console.WriteLine("Lyrics 4 ...");
            };
            f2();
        }

        static void PrintSongLyricsThe2()
        {
            Console.WriteLine("The song The 2 - by Taylor Swift");
            Console.WriteLine("Lyrics 2 ...");
        }
    }
}
