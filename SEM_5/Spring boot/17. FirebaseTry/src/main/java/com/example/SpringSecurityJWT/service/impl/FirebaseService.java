package com.example.SpringSecurityJWT.service.impl;

import com.google.cloud.storage.Blob;
import com.google.cloud.storage.BlobId;
import com.google.cloud.storage.BlobInfo;
import com.google.cloud.storage.Storage;
import com.google.firebase.cloud.StorageClient;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.util.UUID;
import java.util.concurrent.TimeUnit;

@Service
public class FirebaseService {

    public String uploadImage(MultipartFile file) throws IOException {
        String fileName = UUID.randomUUID().toString() + "_" + file.getOriginalFilename();
        String bucketName = "testfirebase-e5f0f.appspot.com";

        Storage storage = StorageClient.getInstance().bucket().getStorage();

        BlobId blobId = BlobId.of(bucketName, fileName);
        BlobInfo blobInfo = BlobInfo.newBuilder(blobId).setContentType(file.getContentType()).build();

        // Tạo Blob và lưu trữ trong bucket
        Blob blob = storage.create(blobInfo, file.getBytes());

        // Tạo URL có chữ ký cho Blob
        String signedUrl = blob.signUrl(365, TimeUnit.DAYS).toString();

        return signedUrl;
    }
}
