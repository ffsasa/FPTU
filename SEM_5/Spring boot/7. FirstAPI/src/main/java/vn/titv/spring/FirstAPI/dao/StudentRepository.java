package vn.titv.spring.FirstAPI.dao;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;
import vn.titv.spring.FirstAPI.entity.Student;

@RepositoryRestResource
public interface StudentRepository extends JpaRepository<Student, Integer> {
    // Có thể thêm các phương thức khác, khi thêm thì phải viết StudentRepositoryImpl
}
