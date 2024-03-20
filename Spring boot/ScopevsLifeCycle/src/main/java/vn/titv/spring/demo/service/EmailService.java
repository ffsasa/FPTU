package vn.titv.spring.demo.service;

import jakarta.annotation.PostConstruct;
import jakarta.annotation.PreDestroy;
import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Component;

@Component
public class EmailService implements MessageService {

    @PostConstruct
    public void init(){
        System.out.println("Đoạn code này được run ngay sau khi tạo " + getClass().getSimpleName());
    }

    @PreDestroy
    public void myDestroy(){
        System.out.println("Đoạn code này được run ngay trước khi hủy bỏ " + getClass().getSimpleName());
    }
    @Override
    public String sendMessage() {
        return "Email sending ..... ";
    }

}
