package vn.titv.spring.RestController.entity;

public class SinhVien {
    private int id;
    private String hoVaTen;
    private int tuoi;
    private String nganhHoc;
    private double diemTB;

    public SinhVien() {
    }

    public SinhVien(int id, String hoVaTen, int tuoi, String nganhHoc, double diemTB) {
        this.id = id;
        this.hoVaTen = hoVaTen;
        this.tuoi = tuoi;
        this.nganhHoc = nganhHoc;
        this.diemTB = diemTB;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getHoVaTen() {
        return hoVaTen;
    }

    public void setHoVaTen(String hoVaTen) {
        this.hoVaTen = hoVaTen;
    }

    public int getTuoi() {
        return tuoi;
    }

    public void setTuoi(int tuoi) {
        this.tuoi = tuoi;
    }

    public String getNganhHoc() {
        return nganhHoc;
    }

    public void setNganhHoc(String nganhHoc) {
        this.nganhHoc = nganhHoc;
    }

    public double getDiemTB() {
        return diemTB;
    }

    public void setDiemTB(double diemTB) {
        this.diemTB = diemTB;
    }
}
