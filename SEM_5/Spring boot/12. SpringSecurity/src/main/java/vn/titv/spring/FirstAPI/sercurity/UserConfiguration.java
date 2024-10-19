package vn.titv.spring.FirstAPI.sercurity;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.Customizer;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.provisioning.JdbcUserDetailsManager;
import org.springframework.security.web.SecurityFilterChain;

import javax.sql.DataSource;

@Configuration
public class UserConfiguration {

    @Bean
    @Autowired
    public JdbcUserDetailsManager jdbcUserDetailsManager(DataSource dataSource){
        JdbcUserDetailsManager jdbcUserDetailsManager = new JdbcUserDetailsManager(dataSource);
        //Nếu tên bảng và cột khác mặc định: users(username, password, enabled)
        //Ta cấu hình lại: jdbcUserDetailsManager.setUsersByUsernameQuery("SELECT id, pw, active FROM accounts WHERE id=?");
        //Nếu tên bảng và cột khác mặc định: authorities(username, authority)
        //Ta cấu hình lại: jdbcUserDetailsManager.setAuthoritiesByUsernameQuery("SELECT id, role FROM roles WHERE id=?");
        return jdbcUserDetailsManager;
    }

//    @Bean
//    public InMemoryUserDetailsManager inMemoryUserDetailsManager(){
//        UserDetails tung = User.withUsername("an").password("{noop}123456").roles("teacher").build();
//
//        UserDetails quoc = User.withUsername("quoc").password("{noop}123").roles("manager").build();
//
//        UserDetails kiet = User.withUsername("kiet").password("{noop}kiet456").roles("admin").build();
//
//        return new InMemoryUserDetailsManager(tung, quoc, kiet);
//    }

    @Bean
    public SecurityFilterChain securityFilterChain(HttpSecurity httpSecurity) throws Exception {
        httpSecurity.authorizeHttpRequests(
                configurer->configurer
                        .requestMatchers(HttpMethod.GET, "api/students").hasAnyRole("TEACHER", "MANAGER", "ADMIN")
                        .requestMatchers(HttpMethod.GET, "api/students/**").hasAnyRole("TEACHER", "MANAGER", "ADMIN")
                        .requestMatchers(HttpMethod.POST, "api/students").hasAnyRole("MANAGER", "ADMIN")
                        .requestMatchers(HttpMethod.PUT, "api/students/**").hasAnyRole("MANAGER", "ADMIN")
                        .requestMatchers(HttpMethod.DELETE, "api/students/**").hasRole("ADMIN")
        );
        httpSecurity.httpBasic(Customizer.withDefaults());
        httpSecurity.csrf(csrf->csrf.disable());

        return httpSecurity.build();
    }
}

