package com.example.demo.service.implement;

import com.example.demo.model.Categories;
import com.example.demo.repository.CategoriesRepository;
import com.example.demo.service.CategoriesService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CategoriesServiceImpl implements CategoriesService {

    @Autowired//Tự động tạo đối tượng bỏ qua lệnh new, bên dưới
    CategoriesRepository categoriesRepository;
    @Override
    public List<Categories> getAll() {
        return categoriesRepository.findAll(); //Đây là câu lệnh rút gọn
    }
}
