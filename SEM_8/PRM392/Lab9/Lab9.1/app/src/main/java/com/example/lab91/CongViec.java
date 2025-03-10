package com.example.lab91;

public class CongViec {
    private int IdCV;
    private String TenCV;

    public CongViec(int idCV, String tenCV) {
        IdCV = idCV;
        TenCV = tenCV;
    }

    public int getIdCV() {
        return IdCV;
    }

    public String getTenCV() {
        return TenCV;
    }

    public void setIdCV(int idCV) {
        IdCV = idCV;
    }

    public void setTenCV(String tenCV) {
        TenCV = tenCV;
    }
}
