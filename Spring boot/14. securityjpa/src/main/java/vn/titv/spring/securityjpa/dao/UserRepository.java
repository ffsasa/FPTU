package vn.titv.spring.securityjpa.dao;

import org.springframework.data.jpa.repository.JpaRepository;
import vn.titv.spring.securityjpa.entity.User;

public interface UserRepository extends JpaRepository<User, Long> {
    public User findByUsername(String username);

}
