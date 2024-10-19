package vn.titv.spring.FirstDB.dao;

import vn.titv.spring.FirstDB.entity.SinhVien;

import java.util.List;

public interface SinhVienDAO {
    public void save(SinhVien sinhvien);

    public SinhVien getById(int id);

    public List<SinhVien> getAll();

    public List<SinhVien> getByTen(String ten);

    public SinhVien update(SinhVien sinhVien);

    public int updateAllTen(String ten);

    public void delete(int id);

    public void deleteByTen(String ten);
}

