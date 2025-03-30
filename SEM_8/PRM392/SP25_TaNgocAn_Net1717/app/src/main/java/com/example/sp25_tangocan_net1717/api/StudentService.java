package com.example.sp25_tangocan_net1717.api;

import com.example.sp25_tangocan_net1717.Model.Student;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface StudentService {
    @GET("student")
    Call<List<Student>> getAllStudents();

    @GET("student/{id}")
    Call<Student> getStudentById(@Path("id") String id);

    @POST("student")
    Call<Student> createStudent(@Body Student student);

    @PUT("student/{id}")
    Call<Student> updateStudent(@Path("id") String id, @Body Student student);

    @DELETE("student/{id}")
    Call<Void> deleteStudent(@Path("id") String id);
}
