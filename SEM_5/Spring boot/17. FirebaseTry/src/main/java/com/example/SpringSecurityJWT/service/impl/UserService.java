package com.example.SpringSecurityJWT.service.impl;

import com.example.SpringSecurityJWT.models.UserEntity;
import com.example.SpringSecurityJWT.repository.UserRepository;
import com.example.SpringSecurityJWT.service.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;

@Service
public class UserService implements IUserService {

    @Autowired
    FirebaseService firebaseService;

    @Autowired
    UserRepository userRepository;

    public UserEntity saveUserWithImage(MultipartFile file, String userName, String passWord) throws IOException {
        String imageUrl = firebaseService.uploadImage(file);

        UserEntity user = new UserEntity();
        user.setUsername(userName);
        user.setPassword(passWord);
        user.setImageUrl(imageUrl);

        return userRepository.save(user);
    }
}
