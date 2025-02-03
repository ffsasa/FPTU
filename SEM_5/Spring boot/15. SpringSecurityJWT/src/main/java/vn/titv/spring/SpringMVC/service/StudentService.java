package vn.titv.spring.SpringMVC.service;

import vn.titv.spring.SpringMVC.entity.Student;

import java.util.List;

public interface StudentService {
    public List<Student> getAllStudents();

    public Student getStudentById(int id);

    public Student addStudent(Student student);

    public void updateStudent(Student student);

    public void deleteStudentById(int id);
}
