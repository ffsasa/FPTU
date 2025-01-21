//package vn.titv.spring.FirstAPI.rest;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.http.HttpStatus;
//import org.springframework.http.ResponseEntity;
//import org.springframework.web.bind.annotation.*;
//import vn.titv.spring.FirstAPI.entity.Student;
//import vn.titv.spring.FirstAPI.service.StudentService;
//
//import java.util.List;
//
//@RestController
//@RequestMapping("/api/students")
//public class StudentController {
//
//    StudentService studentService;
//
//    @Autowired
//    public StudentController(StudentService studentService) {
//        this.studentService = studentService;
//    }
//
//    @GetMapping
//    public List<Student> getAllStudent(){
//        return this.studentService.getAllStudents();
//    }
//
//    @GetMapping("/{id}")
//    public ResponseEntity<Student> getStudentById(@PathVariable int id){
//        Student student = studentService.getStudentById(id);
//        if(student!=null){
//            return ResponseEntity.ok(student);
//        } else {
//            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
//        }
//    }
//
//    @PostMapping
//    public ResponseEntity<Student> addStudent(@RequestBody Student student){
//        student.setId(0); //Bắt buộc tự tạo Id
//        student = studentService.addStudent(student);
//        return ResponseEntity.status(HttpStatus.CREATED).body(student);
//    }
//
//    @PutMapping("/{id}")
//    public ResponseEntity<Student> updateStudent(@PathVariable int id, @RequestBody Student student){
//        Student existingStudent = studentService.getStudentById(id);
//        if(existingStudent!=null){
//            existingStudent.setEmail(student.getEmail());
//            existingStudent.setFirstName(student.getFirstName());
//            existingStudent.setLastName(student.getLastName());
//            studentService.updateStudent(existingStudent);
//            return ResponseEntity.ok(existingStudent);
//        } else {
//            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
//        }
//    }
//
//    @DeleteMapping("/{id}")
//    public ResponseEntity<Void> deleteStudent(@PathVariable int id){
//        Student existingStudent = studentService.getStudentById(id);
//        if(existingStudent!=null){
//            studentService.deleteStudentById(id);
//            return ResponseEntity.ok().build();
//        } else {
//            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
//        }
//    }
//}
