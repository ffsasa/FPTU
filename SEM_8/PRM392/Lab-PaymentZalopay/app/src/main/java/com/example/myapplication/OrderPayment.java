package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.myapplication.Api.CreateOrder;
import com.example.myapplication.Constant.AppInfo;

import org.json.JSONObject;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Locale;

import vn.zalopay.sdk.Environment;
import vn.zalopay.sdk.ZaloPayError;
import vn.zalopay.sdk.ZaloPaySDK;
import vn.zalopay.sdk.listeners.PayOrderListener;

public class OrderPayment extends AppCompatActivity {

    TextView textProductList, textTotalPrice;
    Button buttonPayWithZaloPay;
    ArrayList<String> orderedFood, orderedDrink;
    double totalAmount;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_payment);

        // Thiết lập Toolbar
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        if (getSupportActionBar() != null) {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
            getSupportActionBar().setDisplayShowHomeEnabled(true);
            getSupportActionBar().setTitle("Xác Nhận Đơn Hàng");
        }

        // Ánh xạ UI
        textProductList = findViewById(R.id.textProductList);
        textTotalPrice = findViewById(R.id.textTotalPrice);
        buttonPayWithZaloPay = findViewById(R.id.buttonPayWithZaloPay);

        // Nhận dữ liệu từ Intent
        orderedFood = getIntent().getStringArrayListExtra("orderedFood");
        orderedDrink = getIntent().getStringArrayListExtra("orderedDrink");
        totalAmount = getIntent().getIntExtra("totalPrice", 0);

        // Hiển thị danh sách sản phẩm
        StringBuilder productDetails = new StringBuilder();
        if (orderedFood != null && !orderedFood.isEmpty()) {
            productDetails.append("Food:\n");
            for (String food : orderedFood) {
                productDetails.append("- ").append(food).append("\n");
            }
        }

        if (orderedDrink != null && !orderedDrink.isEmpty()) {
            productDetails.append("\nDrinks:\n");
            for (String drink : orderedDrink) {
                productDetails.append("- ").append(drink).append("\n");
            }
        }

        textProductList.setText(productDetails.toString());

        // Hiển thị tổng tiền
        NumberFormat formatter = NumberFormat.getInstance(Locale.getDefault());
        String formattedTotalAmount = formatter.format(totalAmount);
        textTotalPrice.setText("Total: " + formattedTotalAmount + " VND");

        // Cho phép kết nối mạng
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        // Khởi tạo ZaloPay
        ZaloPaySDK.init(AppInfo.APP_ID, Environment.SANDBOX);

        // Xử lý thanh toán ZaloPay
        buttonPayWithZaloPay.setOnClickListener(v -> initiateZaloPayTransaction());
    }

    private void initiateZaloPayTransaction() {
        if (totalAmount == 0) {
            Toast.makeText(this, "No items to pay for!", Toast.LENGTH_SHORT).show();
            return;
        }

        CreateOrder orderApi = new CreateOrder();
        try {
            String totalString = String.format("%.0f", totalAmount);
            Log.v("Total amount", totalString);
            JSONObject data = orderApi.createOrder(totalString);

            Log.v("Order", data.toString());
            String code = data.getString("return_code");
            if (code.equals("1")) {
                String token = data.getString("zp_trans_token");
                ZaloPaySDK.getInstance().payOrder(OrderPayment.this, token, "demozpdk://app", new PayOrderListener() {
                    @Override
                    public void onPaymentSucceeded(String s, String s1, String s2) {
                        Intent intent = new Intent(OrderPayment.this, ActivityOrderSuccess.class);
                        intent.putExtra("transactionId", s2);
                        startActivity(intent);
                    }

                    @Override
                    public void onPaymentCanceled(String s, String s1) {
                        Intent intent = new Intent(OrderPayment.this, ActivityOrderFailed.class);
                        intent.putExtra("status", "Payment canceled");
                        startActivity(intent);
                    }

                    @Override
                    public void onPaymentError(ZaloPayError zaloPayError, String s, String s1) {
                        Intent intent = new Intent(OrderPayment.this, ActivityOrderFailed.class);
                        intent.putExtra("status", "Error: " + zaloPayError.name());
                        startActivity(intent);
                    }
                });
            } else {
                Toast.makeText(this, "Failed to create order", Toast.LENGTH_SHORT).show();
            }

        } catch (Exception e) {
            Log.e("Error", e.getMessage());
            e.printStackTrace();
            Toast.makeText(this, "Payment error occurred!", Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        ZaloPaySDK.getInstance().onResult(intent);
    }

    @Override
    public boolean onSupportNavigateUp() {
        finish();
        return true;
    }
}
