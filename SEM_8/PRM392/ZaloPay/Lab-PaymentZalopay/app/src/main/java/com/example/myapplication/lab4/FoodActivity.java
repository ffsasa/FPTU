package com.example.myapplication.lab4;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.text.Editable;
import android.text.InputType;
import android.text.TextWatcher;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.myapplication.R;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class FoodActivity extends AppCompatActivity {
    private final Map<String, Integer> foodPrices = new HashMap<>();
    private final Map<String, Integer> selectedFoods = new HashMap<>();
    private int totalFoodPrice = 0;
    private int totalDrinkPrice = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_food);

        ScrollView scrollView = findViewById(R.id.scrollViewFood);
        LinearLayout foodListLayout = findViewById(R.id.foodListLayout);
        Button btnOrderFood = findViewById(R.id.btnOrderFood);

        // Nhận tổng tiền đồ uống từ DrinkActivity
        Bundle bundle = getIntent().getExtras();
        if (bundle != null) {
            totalDrinkPrice = bundle.getInt("totalDrinkPrice", 0);
        }

        // Khai báo giá tiền cho từng loại món ăn
        foodPrices.put("Phở Hà Nội", 40000);
        foodPrices.put("Bún Bò Huế", 35000);
        foodPrices.put("Mì Quảng", 30000);
        foodPrices.put("Hủ Tíu Sài Gòn", 25000);

        // Hiển thị danh sách món ăn với giá tiền và ô nhập số lượng
        for (Map.Entry<String, Integer> entry : foodPrices.entrySet()) {
            String food = entry.getKey();
            int price = entry.getValue();

            LinearLayout itemLayout = new LinearLayout(this);
            itemLayout.setOrientation(LinearLayout.HORIZONTAL);
            itemLayout.setPadding(20, 20, 20, 20);

            // TextView hiển thị tên món ăn và giá tiền
            TextView foodText = new TextView(this);
            foodText.setText(food + " - " + price + "đ");
            foodText.setTextSize(16);
            foodText.setPadding(10, 0, 20, 0);
            foodText.setTextColor(Color.BLACK);

            // Tạo ô nhập số lượng
            EditText quantityInput = new EditText(this);
            quantityInput.setInputType(InputType.TYPE_CLASS_NUMBER);
            quantityInput.setWidth(150);
            quantityInput.setTextColor(Color.BLACK);
            quantityInput.setPadding(20, 0, 20, 0);

            // Xử lý sự kiện nhập số lượng
            quantityInput.addTextChangedListener(new TextWatcher() {
                @Override
                public void beforeTextChanged(CharSequence s, int start, int count, int after) {}

                @Override
                public void onTextChanged(CharSequence s, int start, int before, int count) {
                    String input = s.toString();
                    int quantity = input.isEmpty() ? 0 : Integer.parseInt(input);
                    if (quantity > 0) {
                        selectedFoods.put(food, quantity);
                    } else {
                        selectedFoods.remove(food);
                    }
                    updateTotalPrice();
                }

                @Override
                public void afterTextChanged(Editable s) {}
            });

            // Thêm TextView và EditText vào Layout
            itemLayout.addView(foodText);
            itemLayout.addView(quantityInput);

            // Thêm item vào danh sách hiển thị
            foodListLayout.addView(itemLayout);
        }

        // Nút đặt món - gửi danh sách và tổng tiền về MainActivity
        btnOrderFood.setOnClickListener(v -> {
            if (selectedFoods.isEmpty()) {
                Toast.makeText(FoodActivity.this, "Bạn chưa chọn món ăn nào.", Toast.LENGTH_SHORT).show();
                return;
            }

            Intent intent = new Intent(FoodActivity.this, MainActivity.class);
            Bundle resultBundle = new Bundle();

            // Chuyển danh sách món ăn thành danh sách chuỗi để gửi về MainActivity
            ArrayList<String> orderedFoodList = new ArrayList<>();
            for (Map.Entry<String, Integer> entry : selectedFoods.entrySet()) {
                orderedFoodList.add(entry.getKey() + " x" + entry.getValue());
            }

            resultBundle.putStringArrayList("orderedFood", orderedFoodList);
            resultBundle.putInt("totalFoodPrice", totalFoodPrice);
            resultBundle.putInt("totalDrinkPrice", totalDrinkPrice);

            intent.putExtras(resultBundle);
            startActivity(intent);
        });
    }

    private void updateTotalPrice() {
        totalFoodPrice = 0;
        for (Map.Entry<String, Integer> entry : selectedFoods.entrySet()) {
            totalFoodPrice += foodPrices.get(entry.getKey()) * entry.getValue();
        }
    }
}
