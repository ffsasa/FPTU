package com.example.sp25_tangocan_net1717.api;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class MajorRepository {
    private static final String BASE_URL = "https://67d114fb825945773eb2f4ab.mockapi.io/v1/";
    private MajorService majorService;

    public MajorRepository() {
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        majorService = retrofit.create(MajorService.class);
    }

    public MajorService getMajorService() {
        return majorService;
    }
}
