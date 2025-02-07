package com.example.myapplication;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private String selectedFood = "";
    private String selectedDrinks = "";
    Button btnFood, btnDrinks, btnQuit;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);

        btnDrinks = findViewById(R.id.btnDrinks);
        btnFood = findViewById(R.id.btnFood);
        btnQuit = findViewById(R.id.btnQuit);

        ActivityResultLauncher<Intent> foodActivityLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            new ActivityResultCallback<ActivityResult>() {
                @Override
                public void onActivityResult(ActivityResult result) {
                    if (result.getResultCode() == Activity.RESULT_OK) {
                        Intent data = result.getData();
                        if (data != null) {
                            selectedFood = data.getStringExtra("SELECTED_FOOD");
                            // Xử lý kết quả từ FoodActivity
                            updateUI();
                        }
                    }
                }
            }
        );

        ActivityResultLauncher<Intent> drinksActivityLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            new ActivityResultCallback<ActivityResult>() {
                @Override
                public void onActivityResult(ActivityResult result) {
                    if (result.getResultCode() == RESULT_OK){
                        Intent data = result.getData();
                        if (data != null){
                            selectedDrinks = data.getStringExtra("SELECTED_DRINKS");
                            // Xử lý kết quả từ DrinksActivity
                            updateUI();
                        }
                    }
                }
            }
        );

        btnFood.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, FoodActivity.class);
                foodActivityLauncher.launch(intent);
            }
        });

        btnDrinks.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, DrinksActivity.class);
                drinksActivityLauncher.launch(intent);
            }
        });

        btnQuit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });
    }

    public void updateUI(){
        TextView txtResult = findViewById(R.id.txtResult);

        if (!selectedFood.isEmpty() && !selectedDrinks.isEmpty()) {
            txtResult.setText("Món đã chọn: " + selectedFood + " - Nước đã chọn: " + selectedDrinks);
        }
        else if (!selectedFood.isEmpty()) {
            txtResult.setText("Món đã chọn: " + selectedFood);
        }
        else if (!selectedDrinks.isEmpty()) {
            txtResult.setText("Nước đã chọn: " + selectedDrinks);
        }
        else {
            txtResult.setText("Chưa chọn món hoặc nước!");
        }
    }
}