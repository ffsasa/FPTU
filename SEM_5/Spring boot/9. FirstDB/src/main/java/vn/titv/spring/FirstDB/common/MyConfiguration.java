package vn.titv.spring.FirstDB.common;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import vn.titv.spring.FirstDB.dao.SinhVienDaoImpl;
import vn.titv.spring.FirstDB.entity.SinhVien;

import java.util.List;
import java.util.Scanner;

@Configuration
public class MyConfiguration {

    @Bean
    @Autowired
    public CommandLineRunner getRunner(SinhVienDaoImpl sinhVienDAOImpl) {
        return runner -> {
            Scanner scanner = new Scanner(System.in);
            while (true) {
                inMenu();
                int luaChon = scanner.nextInt();
                scanner.nextLine();
                if (luaChon == 1) {
                    // Gọi phương thức thêm sinh viên
                    themSinhVien(sinhVienDAOImpl);
                } else if (luaChon == 2) {
                    //Gọi hàm tìm sinh viên
                    timSinhVien(sinhVienDAOImpl);
                } else if (luaChon == 3) {
                    timSinhVienBangTen(sinhVienDAOImpl);
                } else if (luaChon == 4) {
                    inTatCaSinhVien(sinhVienDAOImpl);
                } else if (luaChon == 5) {
                    capNhatSinhVienTheoId(sinhVienDAOImpl);
                } else if (luaChon == 6) {
                    capNhatTheoTen(sinhVienDAOImpl);
                } else if (luaChon == 7) {
                    xoaTheoId(sinhVienDAOImpl);
                } else if (luaChon == 8) {
                    xoaTheoTen(sinhVienDAOImpl);
                }
            }
        };
    }

    public void inMenu() {
        System.out.println("============================================\n");
        System.out.println("MENU:\n" +
                "1. Thêm sinh viên\n" +
                "2. Tìm sinh viên\n" +
                "3. Tìm kiếm sinh viên theo tên\n" +
                "4. Hiển thị tất cả sinh viên\n" +
                "5. Cập nhật sinh viên dựa trên id\n" +
                "6. Cập nhật toàn bộ tên của sinh viên\n" +
                "7. Xóa sinh viên theo id\n" +
                "8. Xóa sinh viên theo tên\n" +
                "Lựa chọn: \n"
        );
    }


    public void themSinhVien(SinhVienDaoImpl sinhVienDAOImpl) {
        Scanner scanner = new Scanner(System.in);
        // Lấy thông tin sinh viên
        System.out.println("Nhập họ đệm: ");
        String ho_dem = scanner.nextLine();
        System.out.println("Nhập tên: ");
        String ten = scanner.nextLine();
        System.out.println("Nhập email: ");
        String email = scanner.nextLine();
        SinhVien sinhVien = new SinhVien(ho_dem, ten, email);
        // Luu xuong CSDL
        sinhVienDAOImpl.save(sinhVien);
    }

    public void timSinhVien(SinhVienDaoImpl sinhVienDao) {
        Scanner scanner = new Scanner(System.in);
        // Lấy thông tin sinh viên
        System.out.println("Nhập mã sinh viên: ");
        int id = scanner.nextInt();
        SinhVien sinhVien = sinhVienDao.getById(id);
        if (sinhVien == null) {
            System.out.println("Không tìm thấy!");
        } else {
            System.out.println(sinhVien);
        }
    }

    public void timSinhVienBangTen(SinhVienDaoImpl sinhVienDao) {
        Scanner scanner = new Scanner(System.in);
        // Lấy thông tin sinh viên
        System.out.println("Nhập tên sinh viên: ");
        String ten = scanner.nextLine();
        List<SinhVien> sinhVien = sinhVienDao.getByTen(ten);
        if (sinhVien.size() == 0) {
            System.out.println("Không tìm thấy!");
        } else {
            for (SinhVien s : sinhVien) {
                System.out.println(s);
            }
        }
    }

    public void inTatCaSinhVien(SinhVienDaoImpl sinhVienDao) {
        List<SinhVien> sinhViens = sinhVienDao.getAll();
        for (SinhVien s : sinhViens) {
            System.out.println(s);
        }
    }

    public void capNhatSinhVienTheoId(SinhVienDaoImpl sinhVienDao) {
        Scanner scanner = new Scanner(System.in);
        // Lấy thông tin sinh viên
        System.out.println("Nhập mã sinh viên: ");
        int id = scanner.nextInt();
        scanner.nextLine();
        SinhVien sinhVien = sinhVienDao.getById(id);
        if (sinhVien == null) {
            System.out.println("Không tìm thấy!");
        } else {
            System.out.println("Nhập họ đệm: ");
            String ho_dem = scanner.nextLine();
            System.out.println("Nhập tên: ");
            String ten = scanner.nextLine();
            System.out.println("Nhập email: ");
            String email = scanner.nextLine();
            sinhVien.setTen(ten);
            sinhVien.setHoDem(ho_dem);
            sinhVien.setEmail(email);
            sinhVienDao.update(sinhVien);
        }
    }

    private void capNhatTheoTen(SinhVienDaoImpl sinhVienDao) {
        Scanner scanner = new Scanner(System.in);
        // Lấy thông tin sinh viên
        System.out.println("Nhập tên sinh viên: ");
        String ten = scanner.nextLine();
        sinhVienDao.updateAllTen(ten);
    }

    private void xoaTheoId(SinhVienDaoImpl sinhVienDao) {
        Scanner scanner = new Scanner(System.in);
        // Lấy thông tin sinh viên
        System.out.println("Nhập id sinh viên: ");
        int id = scanner.nextInt();
        sinhVienDao.delete(id);
    }

    private void xoaTheoTen(SinhVienDaoImpl sinhVienDao) {
        Scanner scanner = new Scanner(System.in);
        // Lấy thông tin sinh viên
        System.out.println("Nhập tên sinh viên: ");
        String ten = scanner.nextLine();
        List<SinhVien> sinhVien = sinhVienDao.getByTen(ten);
        if (sinhVien.size() == 0) {
            System.out.println("Không tìm thấy!");
        } else {
            sinhVienDao.deleteByTen(ten);
        }
    }
}
