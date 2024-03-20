package com.example.demo.controller;

import com.example.demo.model.Categories;
import com.example.demo.service.CategoriesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import java.util.List;

@Controller
@RequestMapping(value = "/categories")
public class CategoriesController {
    @Autowired
    CategoriesService categoriesService;
    @RequestMapping(value = "/getAll")
    public String getAll(Model model){
        List<Categories> categoriesList = categoriesService.getAll();
        model.addAttribute("list", categoriesList);
        return "Categories-List";
    }

}
