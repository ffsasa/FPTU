package vn.titv.spring.demo.application;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication(
		scanBasePackages = {
				"net.khoahocdulieu",
				"vn.titv.spring.demo.application",
				"vn.titv.spring.demo.rest",
				"vn.titv.spring.demo.service",
		}
)
public class DemoApplication {
	public static void main(String[] args) {
		SpringApplication.run(DemoApplication.class, args);
	}
}
