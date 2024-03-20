package com.example.demo.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.List;

@Getter //Tự tạo getter
@Setter //Tự tạo setter
@NoArgsConstructor //Tự tạo constructor không tham số
@AllArgsConstructor //Tự tạo constructor có tham số
@Entity
public class Categories {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    private String name;
    @OneToMany(mappedBy = "categories", fetch = FetchType.EAGER) //Thằng này đã được tạo ở bên kia và nó map tới đây
    private List <Product> productList; //Đối tượng được liên kết ở đây
}
