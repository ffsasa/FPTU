package vn.titv.spring.RestController.rest;

import jakarta.annotation.PostConstruct;
import org.apache.coyote.Response;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import vn.titv.spring.RestController.Exception.SinhVienException;
import vn.titv.spring.RestController.entity.ErrorResponse;
import vn.titv.spring.RestController.entity.SinhVien;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/sinhvien")
public class SinhVienController {

    public List<SinhVien> danhSach;

    @PostConstruct
    public void createDanhSach() {
        danhSach = new ArrayList<SinhVien>();
        danhSach.add(new SinhVien(1, "Ta Ngoc An", 20, "KTPM", 8.9));
        danhSach.add(new SinhVien(2, "Mai Yen Binh", 21, "ATTT", 8.5));
        danhSach.add(new SinhVien(3, "Tran Quoc Cuong", 22, "SP", 8.2));
        danhSach.add(new SinhVien(4, "Tran Viet Duong", 23, "BD", 7.1));
        danhSach.add(new SinhVien(5, "Pham My Hanh", 24, "CK", 7.0));
    }

    @GetMapping("/")
    public List<SinhVien> getDanhSach() {
        return danhSach;
    }

    @GetMapping("/{id}")
    public SinhVien getSinhVien(@PathVariable int id) {
        SinhVien result = null;
        for (SinhVien a : danhSach) {
            if (id == a.getId()) {
                return a;
            }
        }

        if (result == null) {
            throw new SinhVienException("Không tìm thấy sinh viên với id là: " + id);
        }

        return result;
    }

    @GetMapping("/index/{index}")
    public SinhVien getSinhVien2(@PathVariable int index) {
        SinhVien sinhVien = null;
        try {
            sinhVien = danhSach.get(index);
        }catch (IndexOutOfBoundsException e){
            throw new SinhVienException("Không tìm thấy sinh viên với index là: " + index);
        }

        return sinhVien;
    }

    @ExceptionHandler
    public ResponseEntity<ErrorResponse> batLoi(SinhVienException ex){
        ErrorResponse er = new ErrorResponse(HttpStatus.NOT_FOUND.value(), ex.getMessage());
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(er);
    }
}
