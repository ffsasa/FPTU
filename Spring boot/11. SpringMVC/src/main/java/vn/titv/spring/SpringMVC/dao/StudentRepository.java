package vn.titv.spring.SpringMVC.dao;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import vn.titv.spring.SpringMVC.entity.Student;


@Repository
public interface StudentRepository extends JpaRepository<Student, Integer> {
    // Có thể thêm các phương thức khác, khi thêm thì phải viết StudentRepositoryImpl
}
