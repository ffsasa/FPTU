package vn.titv.spring.FirstDB.entity;

import jakarta.persistence.*;

@Entity
@Table(name = "sinhvien")
public class SinhVien {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @Column(name = "ho_dem", length = 45)
    private String hoDem;
    @Column(name = "ten", length = 45)
    private String ten;
    @Column(name = "email", length = 45)
    private String email;

    public SinhVien() {
    }

    public SinhVien(String hoDem, String ten, String email) {
        this.hoDem = hoDem;
        this.ten = ten;
        this.email = email;
    }

    public int getId() {
        return id;
    }

    public String getHoDem() {
        return hoDem;
    }

    public String getTen() {
        return ten;
    }

    public String getEmail() {
        return email;
    }


    public void setHoDem(String hoDem) {
        this.hoDem = hoDem;
    }

    public void setTen(String ten) {
        this.ten = ten;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public String toString() {
        return "SinhVien{" +
                "id=" + id +
                ", hoDem='" + hoDem + '\'' +
                ", ten='" + ten + '\'' +
                ", email='" + email + '\'' +
                '}';
    }
}
