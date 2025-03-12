package com.example.api.api;

import com.example.api.model.Trainee;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface TraineeService {
    @GET("nhanvien")
    Call<List<Trainee>> getAllTrainees();

    @POST("nhanvien")
    Call<Trainee> createTrainee(@Body Trainee trainee);

    @PUT("nhanvien/{id}")
    Call<Trainee> updateTrainee(@Path("id") String id, @Body Trainee trainee);

    @DELETE("nhanvien/{id}")
    Call<Void> deleteTrainee(@Path("id") String id);
}