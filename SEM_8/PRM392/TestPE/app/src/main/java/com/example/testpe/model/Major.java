package com.example.testpe.model;

public class Major {
    private String id;
    private String nameMajor;

    public Major() {
    }

    public Major(String id, String nameMajor) {
        this.id = id;
        this.nameMajor = nameMajor;
    }

    public String getId() {
        return id;
    }

    public String getNameMajor() {
        return nameMajor;
    }

    public void setId(String id) {
        this.id = id;
    }

    public void setNameMajor(String nameMajor) {
        this.nameMajor = nameMajor;
    }
}
