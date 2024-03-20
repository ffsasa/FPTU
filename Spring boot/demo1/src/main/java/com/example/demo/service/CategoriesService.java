package com.example.demo.service;

import com.example.demo.model.Categories;
import org.springframework.stereotype.Service;

import java.util.List;

public interface CategoriesService {
    public List<Categories> getAll();
}
