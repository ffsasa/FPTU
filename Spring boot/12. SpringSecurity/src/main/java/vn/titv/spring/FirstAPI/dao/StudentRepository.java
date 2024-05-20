package vn.titv.spring.FirstAPI.dao;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import vn.titv.spring.FirstAPI.entity.Student;
import java.util.List;

@Repository
public interface StudentRepository extends JpaRepository<Student, Integer> {
    // Có thể thêm các phương thức khác, khi thêm thì phải viết StudentRepositoryImpl
    //3 method đầu tiên này dùng đúng quy tắc đặt tên nên không cần tự viết Query
    public List<Student> findByFirstName(String firstName);

    public List<Student> findByFirstNameAndLastName(String firstName, String lastName);

//    public List<Student> findByFirstNameNot(String firstName);

    //Nếu cần tự viết Query ta sẽ viết như dưới
    @Query("SELECT u FROM Student u WHERE u.firstName<>?1")
    public List<Student> findByFirstNameNot(String firstName);

}
