package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.myapplication.lab4.MainActivity;

public class ActivityOrderSuccess extends AppCompatActivity {

    TextView textSuccessMessage, textTransactionId;
    Button buttonBackToHome;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_success);

        textSuccessMessage = findViewById(R.id.textSuccessMessage);
        textTransactionId = findViewById(R.id.textTransactionId);
        buttonBackToHome = findViewById(R.id.buttonBackToHome);

        String transactionId = getIntent().getStringExtra("transactionId");
        textSuccessMessage.setText("Payment successful!");
        textTransactionId.setText("Transaction ID: " + transactionId);

        buttonBackToHome.setOnClickListener(v -> {
            Intent intent = new Intent(ActivityOrderSuccess.this, MainActivity.class);
            intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);
            startActivity(intent);
            finish();
        });
    }
}
