package com.example.SpringSecurityJWT.controllers;

import com.example.SpringSecurityJWT.models.UserEntity;
import com.example.SpringSecurityJWT.service.impl.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;

@RestController
@RequestMapping("/api/users")
public class UserController {

    @Autowired
    private UserService userService;

    @PostMapping(value ="/upload", consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public ResponseEntity<UserEntity> uploadUserWithImage(
            @RequestPart(name = "fileImg", required = false) MultipartFile file,
            @RequestPart String userName,
            @RequestPart String passWord) throws IOException {
        UserEntity user = userService.saveUserWithImage(file, userName, passWord);
        return ResponseEntity.ok(user);
    }
}
