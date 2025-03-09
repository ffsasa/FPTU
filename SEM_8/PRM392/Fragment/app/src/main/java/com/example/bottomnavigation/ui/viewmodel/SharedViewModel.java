package com.example.bottomnavigation.ui.viewmodel;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class SharedViewModel extends ViewModel {
    private MutableLiveData<Integer> sharedData = new MutableLiveData<>();

    public SharedViewModel() {
        sharedData.setValue(0); // Giá trị ban đầu là 0
    }

    public LiveData<Integer> getSharedData() {
        return sharedData;
    }

    public void incrementData() {
        sharedData.setValue(sharedData.getValue() + 1);
    }
}
