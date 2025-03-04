package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

public class MainActivity extends AppCompatActivity {

    private final String ITEM_NAME = "Team 4";
    private final int ITEM_PRICE = 100000;

    Button btnConfirm;
    EditText editQuantity;
    TextView textProductName;
    TextView textProductPrice;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        btnConfirm = findViewById(R.id.buttonConfirm);
        editQuantity = findViewById(R.id.editTextQuantity);

        textProductName = findViewById(R.id.textProductName);
        textProductName.setText("Product: " + ITEM_NAME);

        textProductPrice = findViewById(R.id.textProductPrice);
        textProductPrice.setText("Price: " + ITEM_PRICE + " VND per unit");

        btnConfirm.setOnClickListener(v -> {
            if (editQuantity.getText() == null || editQuantity.getText().toString().isEmpty()) {
                Toast.makeText(MainActivity.this, "Select quantity to purchase", Toast.LENGTH_SHORT).show();
                return;
            }

            String s = editQuantity.getText().toString();
            double total = Double.parseDouble(s) * ITEM_PRICE;

            Intent intent = new Intent(MainActivity.this, OrderPayment.class);
            int quantity = Integer.parseInt(editQuantity.getText().toString());
            intent.putExtra("name", ITEM_NAME);
            intent.putExtra("quantity", quantity);
            intent.putExtra("total", total);
            startActivity(intent);
        });
    }
}