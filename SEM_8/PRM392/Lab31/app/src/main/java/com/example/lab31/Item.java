package com.example.lab31;

import android.net.Uri;

public class Item {
    private Uri imageUri; // Lưu URI của hình ảnh
    private String title;
    private String description;

    public Item(Uri imageUri, String title, String description) {
        this.imageUri = imageUri;
        this.title = title;
        this.description = description;
    }

    public Uri getImageUri() {
        return imageUri;
    }

    public String getTitle() {
        return title;
    }

    public String getDescription() {
        return description;
    }
}


