package com.example.testpe.api;

import com.example.testpe.model.Major;
import com.example.testpe.model.Student;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface MajorService {
    @GET("major")
    Call<List<Major>> getAllMajors();

    @GET("major/{id}")
    Call<Major> getMajorById(@Path("id") String id);

    @POST("major")
    Call<Major> createMajor(@Body Major major);

    @PUT("major/{id}")
    Call<Major> updateMajor(@Path("id") String id, @Body Major major);

    @DELETE("major/{id}")
    Call<Void> deleteMajor(@Path("id") String id);
}
