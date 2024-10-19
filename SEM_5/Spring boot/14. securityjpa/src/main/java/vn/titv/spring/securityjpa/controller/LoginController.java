package vn.titv.spring.securityjpa.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class LoginController {

    @GetMapping("/showLoginPage")
    public String showLoginPage(Model model){
        return "login";
    }

    @GetMapping("/showPage403")
    public String showPage403(Model model){
        return "error/403";
    }
}
