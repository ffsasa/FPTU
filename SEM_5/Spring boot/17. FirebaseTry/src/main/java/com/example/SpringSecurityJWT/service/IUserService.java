package com.example.SpringSecurityJWT.service;

import com.example.SpringSecurityJWT.models.UserEntity;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;

public interface IUserService {
    public UserEntity saveUserWithImage(MultipartFile file, String userName, String passWord) throws IOException;
}
