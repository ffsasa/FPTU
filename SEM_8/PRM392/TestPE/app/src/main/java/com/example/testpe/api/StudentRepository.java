package com.example.testpe.api;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class StudentRepository {
    private static final String BASE_URL = "https://67d114fb825945773eb2f4ab.mockapi.io/v1/"; // Thay bằng URL của bạn
    private StudentService studentService;

    public StudentRepository() {
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        studentService = retrofit.create(StudentService.class);
    }

    public StudentService getStudentService() {
        return studentService;
    }
}
