package vn.titv.spring.BeanByJavaCode;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class Controller {

    private Calculator calculator;

    @Autowired
    public Controller(Calculator calculator) {
        this.calculator = calculator;
    }

    @GetMapping("/canbachai")
    public String canBacHai(@RequestParam("value") double variable) {
        return "SQRT(" + variable + ") = " + this.calculator.canBacHai(variable);
    }

    @GetMapping("/binhphuong")
    public String binhPhuong(@RequestParam("value") double variable) {
        return "(" + variable + ")^2 = " + this.calculator.binhPhuong(variable);
    }
}
