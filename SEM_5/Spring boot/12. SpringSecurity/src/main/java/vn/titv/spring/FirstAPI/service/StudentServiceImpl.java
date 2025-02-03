package vn.titv.spring.FirstAPI.service;

import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import vn.titv.spring.FirstAPI.dao.StudentRepository;
import vn.titv.spring.FirstAPI.entity.Student;

import java.util.List;
import java.util.Optional;

@Service
public class StudentServiceImpl implements StudentService{

    private final StudentRepository studentRepository;

    @Autowired
    public StudentServiceImpl(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    @Override
    public List<Student> getAllStudents() {
        return studentRepository.findAll();
    }

    @Override
    public List<Student> getAllStudentNotFirstName(String name) {
        return studentRepository.findByFirstNameNot(name);
    }

    @Override
    public Student getStudentById(int id){
        return studentRepository.getById(id);
    }

    @Override
    @Transactional
    public Student addStudent(Student student) {
        return studentRepository.save(student);
    }

    @Override
    @Transactional
    public void updateStudent(Student student) {
        studentRepository.saveAndFlush(student);
    }

    @Override
    @Transactional
    public void deleteStudentById(int id) {
        studentRepository.deleteById(id);
    }
}
