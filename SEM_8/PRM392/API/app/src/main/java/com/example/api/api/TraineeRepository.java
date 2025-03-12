package com.example.api.api;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class TraineeRepository {
    private static final String BASE_URL = "https://67d114fb825945773eb2f4ab.mockapi.io/v1/"; // Thay bằng URL của bạn
    private TraineeService traineeService;

    public TraineeRepository() {
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        traineeService = retrofit.create(TraineeService.class);
    }

    public TraineeService getTraineeService() {
        return traineeService;
    }
}
