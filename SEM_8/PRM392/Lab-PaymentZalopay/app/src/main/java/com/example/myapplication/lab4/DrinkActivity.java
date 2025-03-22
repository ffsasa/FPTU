package com.example.myapplication.lab4;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.text.InputType;
import android.text.TextWatcher;
import android.text.Editable;
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

public class DrinkActivity extends AppCompatActivity {
    private final Map<String, Integer> drinkPrices = new HashMap<>();
    private final Map<String, Integer> selectedDrinks = new HashMap<>();
    private int totalDrinkPrice = 0;
    private int totalFoodPrice = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_drink);

        ScrollView scrollView = findViewById(R.id.scrollViewDrink);
        LinearLayout drinkListLayout = findViewById(R.id.drinkListLayout);
        Button btnOrderDrink = findViewById(R.id.btnOrderDrink);

        // Nhận tổng tiền món ăn từ MainActivity
        Bundle bundle = getIntent().getExtras();
        if (bundle != null) {
            totalFoodPrice = bundle.getInt("totalFoodPrice", 0);
        }

        // Khai báo giá tiền cho từng loại nước uống
        drinkPrices.put("Pepsi", 15000);
        drinkPrices.put("Heineken", 25000);
        drinkPrices.put("Tiger", 20000);
        drinkPrices.put("Sài Gòn Đỏ", 18000);
        drinkPrices.put("CocaCola", 15000);
        drinkPrices.put("Trà Sữa", 30000);

        // Hiển thị danh sách đồ uống với giá tiền và ô nhập số lượng
        for (Map.Entry<String, Integer> entry : drinkPrices.entrySet()) {
            String drink = entry.getKey();
            int price = entry.getValue();

            LinearLayout itemLayout = new LinearLayout(this);
            itemLayout.setOrientation(LinearLayout.HORIZONTAL);
            itemLayout.setPadding(20, 20, 20, 20);

            // TextView hiển thị tên đồ uống và giá tiền
            TextView drinkText = new TextView(this);
            drinkText.setText(drink + " - " + price + "đ");
            drinkText.setTextSize(16);
            drinkText.setPadding(10, 0, 20, 0);
            drinkText.setTextColor(Color.BLACK);

            // Tạo ô nhập số lượng
            EditText quantityInput = new EditText(this);
//            quantityInput.setHint("Số lượng");
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
                        selectedDrinks.put(drink, quantity);
                    } else {
                        selectedDrinks.remove(drink);
                    }
                    updateTotalPrice();
                }

                @Override
                public void afterTextChanged(Editable s) {}
            });

            // Thêm TextView và EditText vào Layout
            itemLayout.addView(drinkText);
            itemLayout.addView(quantityInput);

            // Thêm item vào danh sách hiển thị
            drinkListLayout.addView(itemLayout);
        }

        // Nút đặt đồ uống - gửi danh sách và tổng tiền về MainActivity
        btnOrderDrink.setOnClickListener(v -> {
            if (selectedDrinks.isEmpty()) {
                Toast.makeText(DrinkActivity.this, "Bạn chưa chọn đồ uống nào.", Toast.LENGTH_SHORT).show();
                return;
            }

            Intent intent = new Intent(DrinkActivity.this, MainActivity.class);
            Bundle resultBundle = new Bundle();

            // Chuyển danh sách đồ uống và số lượng thành danh sách chuỗi để gửi về MainActivity
            ArrayList<String> orderedDrinkList = new ArrayList<>();
            for (Map.Entry<String, Integer> entry : selectedDrinks.entrySet()) {
                orderedDrinkList.add(entry.getKey() + " x" + entry.getValue());
            }

            resultBundle.putStringArrayList("orderedDrink", orderedDrinkList);
            resultBundle.putInt("totalDrinkPrice", totalDrinkPrice);
            resultBundle.putInt("totalFoodPrice", totalFoodPrice);

            intent.putExtras(resultBundle);
            startActivity(intent);
        });
    }

    private void updateTotalPrice() {
        totalDrinkPrice = 0;
        for (Map.Entry<String, Integer> entry : selectedDrinks.entrySet()) {
            totalDrinkPrice += drinkPrices.get(entry.getKey()) * entry.getValue();
        }
    }
}
