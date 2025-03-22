package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.myapplication.lab4.MainActivity;

public class ActivityOrderFailed extends AppCompatActivity {

    TextView textStatus;
    Button buttonBackToHome;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_failed);

        buttonBackToHome = findViewById(R.id.buttonBackToHome);
        textStatus = findViewById(R.id.textStatus);

        String status = getIntent().getStringExtra("status");

        if (status != null) {
            textStatus.setText(status);
        }

        buttonBackToHome.setOnClickListener(v -> {
            Intent intent = new Intent(ActivityOrderFailed.this, MainActivity.class);
            intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);
            startActivity(intent);
            finish();
        });
    }
}
