package com.example.lab63;

import android.graphics.Color;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    private Button btnChonMau;
    private LinearLayout mainLayout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Tìm các view
        btnChonMau = findViewById(R.id.btnChonMau);
        mainLayout = findViewById(R.id.mainLayout);

        // Đăng ký Context Menu cho Button
        registerForContextMenu(btnChonMau);

        // Xử lý click để mô phỏng long press (kích hoạt Context Menu)
        btnChonMau.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                v.performLongClick(); // Mô phỏng long press để hiển thị Context Menu
            }
        });
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        getMenuInflater().inflate(R.menu.context_menu, menu);
    }

    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        // Xử lý khi chọn mục trong Context Menu
        int itemId = item.getItemId();

        if (itemId == R.id.menuRed) {
            mainLayout.setBackgroundColor(Color.RED);
            return true;
        } else if (itemId == R.id.menuYellow) {
            mainLayout.setBackgroundColor(Color.YELLOW);
            return true;
        } else if (itemId == R.id.menuBlue) {
            mainLayout.setBackgroundColor(Color.BLUE);
            return true;
        } else {
            return super.onContextItemSelected(item); // Giao lại cho hệ thống nếu không xử lý
        }
    }
}