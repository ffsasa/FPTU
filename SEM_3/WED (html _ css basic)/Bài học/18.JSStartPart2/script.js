const para2 = document.querySelector('#p2')

/* Loại bỏ para2: Lệnh remove
        para2.remove();
*/

/* Set thuộc tính tạo ra js, onclick đã được thêm ở bên html, khi click sẽ thêm alert vào và hiện ra cửa sổ alert
        para2.setAttribute('onclick', 'alert("Hello")')
*/

/*Dù bên html là p2 nhưng sau khi chạy trình duyệt sẽ thấy là p5 (f12) vì JS chạy cuối cùng
        para2.setAttribute('id', 'p5')
*/

/* Thêm hoặc xóa 1 class khác vào tức là cộng thêm class
        para2.classList.add('quote')
        para2.classList.remove('paragraph')
        para2.classList.toggle('paragraph') -> Nếu đã có class là paragraph trong attribute class thì xóa ngược lại thì thêm
*/




/*
Chỉnh sửa style
        para2.style.color = 'red'

        para2.style.backgroundColor = 'red'
*/