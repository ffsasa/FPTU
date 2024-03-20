package vn.titv.spring.FirstAPI.handle;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

@ControllerAdvice
public class MyHandler {

    @ExceptionHandler
    public ResponseEntity<ErrorResponse> checkAll(Exception exception){
        ErrorResponse er = new ErrorResponse(HttpStatus.BAD_REQUEST.value(), exception.getMessage());
        return ResponseEntity.status(HttpStatus.BAD_REQUEST.value()).body(er);
    }
}
