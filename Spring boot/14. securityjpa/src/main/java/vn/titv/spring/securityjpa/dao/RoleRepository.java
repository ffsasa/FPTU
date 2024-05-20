package vn.titv.spring.securityjpa.dao;

import org.springframework.data.jpa.repository.JpaRepository;
import vn.titv.spring.securityjpa.entity.Role;

public interface RoleRepository extends JpaRepository<Role, Long> {
    public Role findByName(String name);
}
