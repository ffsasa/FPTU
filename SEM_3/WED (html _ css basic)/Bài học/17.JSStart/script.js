/*
conts là hằng
let là biết
alert: Tạo cửa sổ thông báo
confirm: Tạo cửa sổ Oke và cancel
prompt: Tạo cửa sổ nhập liệu. let a = prompt("Tuổi?")
*/
// 3 cách để lấy document
const headings = document.getElementsByClassName('heading');
console.log(headings)

const heading1 = document.getElementById('#h1'); //Lấy theo id

const heading = document.querySelector('.heading') //Lấy theo class nhưng bằng lệnh query phải có thêm . hoặc # với id

// Lệnh append thêm vào cuối html 1 element
const body = document.querySelector('body');
body.append('Hello World!')

// Tạo 1 element chỉ tạo không thêm, nếu muốn thêm phải append
const newDiv = document.createElement('div');
newDiv.innerText = 'Hello An!'
newDiv.textContent = 'Hello An!'
// innerHTML có thể code thẳng html, tác động đến web
newDiv.innerHTML = '<b>Hello An!</b>' 
body.append(newDiv);

// Tạo đối tượng và gán vào body
const Div = document.createElement('div') //Thẻ div
const bold = document.createElement('b') //Thẻ b

bold.innerText = 'An'
Div.append(bold)
body.append(Div)
