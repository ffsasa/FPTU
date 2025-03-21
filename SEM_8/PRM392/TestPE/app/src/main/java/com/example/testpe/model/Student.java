package com.example.testpe.model;

import java.time.LocalDate;

public class Student {
    private String id;
    private String name;
    private String date;
    private Gender gender;
    private String email;
    private String address;
    private String majorId;

    public Student(String id, String name, String date, Gender gender, String email, String majorId, String address) {
        this.id = id;
        this.name = name;
        this.date = date;
        this.gender = gender;
        this.email = email;
        this.majorId = majorId;
        this.address = address;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getDate() {
        return date;
    }

    public Gender getGender() {
        return gender;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getAddress() {
        return address;
    }

    public String getEmail() {
        return email;
    }

    public String getMajorId() {
        return majorId;
    }

    public void setId(String id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public void setGender(Gender gender) {
        this.gender = gender;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setMajorId(String majorId) {
        this.majorId = majorId;
    }
}
