using Repositories.Entities;

namespace Service
{
    //3 Layer Architecture:
    //   [1]        [2]             [3]                         SQLServer
    //UI-Form -- Services    -- Repository                  -- DB
    //MainUI  -- BookService -- BookRepository(BookEntity)  -- BookTable
    //Request/Response     <----------->
    //Đưa data xuống DB                   Chơi trực tiếp DB: lên, xuống
    //Lấy data từ DB show                       CRUD table thực sự
    //Ram                                                DB đĩa cứng HĐ/SSD
    public class BookService
    {
        //Class này trung chuyển dữ liệu giữa Forms UI và CSDL
        //Nó chứa data trong Ram, xử lí mọi thứ thuật toán nếu cần rồi đẩy lên UI
        //Hoặc cất xuống DB
        //Chứa list các book đọc từ DB hoặc lấy từ màn hình cập nhật xuống DB.

        //Chứa CRUD
        public List<Book> GetAllBooks()
        {
            //TODO: Gọi class BookRepository để lấy toàn bộ sách từ DB
            //Call class BookRepository to retrieve all books from DB
            List<Book> arr = new List<Book>();

            //using object initialization
            arr.Add(new Book()
            {
                BookId = 1,
                BookName = "Đời Ngắn Đừng Ngủ Dài-Short Life Don’t Sleep Long",
                Description = "Sách dành cho lứa tuổi thanh thiếu niên",
                Author = "Robin Sharma",
                PublicationDate = "2023-01-01",
                BookCategoryId = 5
            });

            arr.Add(new Book()
            {
                BookId = 2,
                BookName = "Mình Là Nắng, Việc Của Mình Là Chói Chang-I Am the Sun, My Job Is to Shine Bright",
                Description = "Hãy phát huy tố chất vốn có trong bạn",
                Author = "Kazuko Watanabe",
                PublicationDate = "2023-01-01",
                BookCategoryId = 5
            });

            arr.Add(new Book()
            {
                BookId = 3,
                BookName = "Tuổi Trẻ Đáng Giá Bao Nhiêu-How Much Is Youth Worth",
                Description = "Những bài học kĩ năng mềm gói gọn trong 1 trang giấy",
                Author = "Rosie Nguyễn",
                PublicationDate = "2018-01-01",
                BookCategoryId = 5
            });

            arr.Add(new Book()
            {
                BookId = 4,
                BookName = "Snow Crash",
                Description = "Hiro lives in a Los Angeles where franchises line the freeway...",
                Author = "Neal Stephenson",
                PublicationDate = "2001-01-01",
                BookCategoryId = 2
            });

            return arr;
        }
    }
}
