package com.example.lab52;

public class Module {
    private int image;
    private String title;
    private String description;
    private String operatingSystem;

    public Module(int image, String title, String description, String operatingSystem) {
        this.image = image;
        this.title = title;
        this.description = description;
        this.operatingSystem = operatingSystem;
    }

    public int getImage() {
        return image;
    }

    public void setImage(int image) {
        this.image = image;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getOperatingSystem() {
        return operatingSystem;
    }

    public void setOperatingSystem(String operatingSystem) {
        this.operatingSystem = operatingSystem;
    }
}
