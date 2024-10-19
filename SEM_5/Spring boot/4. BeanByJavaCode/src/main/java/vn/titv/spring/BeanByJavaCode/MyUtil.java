package vn.titv.spring.BeanByJavaCode;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MyUtil {

    @Bean
    public Calculator getCalculator(){
        return new Calculator();
    }
}
