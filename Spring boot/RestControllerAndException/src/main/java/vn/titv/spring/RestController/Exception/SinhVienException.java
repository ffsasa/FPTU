package vn.titv.spring.RestController.Exception;

public class SinhVienException extends RuntimeException{
    public SinhVienException(String message) {
        super(message);
    }
}
