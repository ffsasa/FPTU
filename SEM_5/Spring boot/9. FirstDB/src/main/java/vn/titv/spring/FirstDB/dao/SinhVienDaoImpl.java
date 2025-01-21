package vn.titv.spring.FirstDB.dao;

import jakarta.persistence.EntityManager;
import jakarta.persistence.Query;
import jakarta.persistence.TypedQuery;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import vn.titv.spring.FirstDB.entity.SinhVien;
import java.util.List;

@Repository
@Transactional
public class SinhVienDaoImpl implements SinhVienDAO{

    private EntityManager entityManager;

    @Autowired
    public SinhVienDaoImpl(EntityManager entityManager) {
        this.entityManager = entityManager;
    }

    @Override
    public void save(SinhVien sinhVien) {
        this.entityManager.persist(sinhVien);
    }

    @Override
    public SinhVien getById(int id) {
        return this.entityManager.find(SinhVien.class, id);
    }

    @Override
    public List<SinhVien> getAll() {
        String jpql = "SELECT s FROM SinhVien s";
        return this.entityManager.createQuery(jpql, SinhVien.class).getResultList();
    }

    @Override
    public List<SinhVien> getByTen(String ten) {
        String jpql = "SELECT s FROM SinhVien s WHERE s.ten = :t";
        TypedQuery<SinhVien> query = this.entityManager.createQuery(jpql, SinhVien.class);
        query.setParameter("t", ten);
        return query.getResultList();
    }

    @Override
    public SinhVien update(SinhVien sinhVien) {
        return this.entityManager.merge(sinhVien);
    }

    @Override
    public int updateAllTen(String ten) {
        String jpql = "UPDATE SinhVien s Set s.ten = :t";
        Query query = this.entityManager.createQuery(jpql);
        query.setParameter("t", ten);
        return query.executeUpdate();
    }

    @Override
    public void delete(int id) {
        SinhVien sinhVien = this.entityManager.find(SinhVien.class, id);
        this.entityManager.remove(sinhVien);
    }

    @Override
    public void deleteByTen(String ten) {
        String jpql = "DELETE FROM SinhVien WHERE ten = :t";
        Query query = this.entityManager.createQuery(jpql);
        query.setParameter("t", ten);
        query.executeUpdate();
    }
}
