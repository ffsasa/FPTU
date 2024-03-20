package com.example.demo.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;

@Getter //Tự tạo getter
@Setter //Tự tạo setter
@NoArgsConstructor //Tự tạo constructor không tham số
@AllArgsConstructor //Tự tạo constructor có tham số
@Entity
@Table(name="product")
public class Product {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY) //Tự tăng id

    private int id;

    private String name;

    private double price;

    private String address;

    private LocalDate D;
    @ManyToOne //Mối quan hệ với thằng nào đó
    @JoinColumn(name="categories_id") //Thêm cột này vào bảng và nó sẽ lấy thằng id của thằng bên dưới
    private Categories categories; //Thằng được lấy id để làm khóa ngoại được tạo ở đây
}
