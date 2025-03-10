package com.example.lab91;

import android.database.Cursor;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    Database database;
    ListView lvCongViec;
    ArrayList<CongViec> arrayCongViec;
    CongViecAdapter adapter; // Sử dụng adapter tùy chỉnh từ trước


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main); // Giả sử layout chứa ListView

        // Khởi tạo ListView
        lvCongViec = findViewById(R.id.listViewCongViec);

        // Khởi tạo database
        database = new Database(this, "Ghichu.sqlite", null, 1);

        // Tạo bảng nếu chưa tồn tại
        database.QueryData("CREATE TABLE IF NOT EXISTS CongViec(id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "TenCV varchar(200))");

        // Chèn dữ liệu mẫu
        database.QueryData("INSERT INTO CongViec VALUES(null, 'Project Android')");
        database.QueryData("INSERT INTO CongViec VALUES(null, 'Design app')");

        // Lấy dữ liệu từ database
        Cursor dataCongViec = database.GetData("SELECT * FROM CongViec");
        while (dataCongViec.moveToNext()){
            String ten = dataCongViec.getString(1);
            int id = dataCongViec.getInt(0);

            arrayCongViec.add(new CongViec(id, ten));
        }

        // Cập nhật adapter khi dữ liệu thay đổi
        adapter.notifyDataSetChanged();
    }
}