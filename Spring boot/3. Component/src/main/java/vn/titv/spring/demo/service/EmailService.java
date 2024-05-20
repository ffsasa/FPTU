package vn.titv.spring.demo.service;

import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Component;

@Component
@Primary
public class EmailService implements MessageService {

    @Override
    public String sendMessage() {
        return "Email sending ..... ";
    }

}
