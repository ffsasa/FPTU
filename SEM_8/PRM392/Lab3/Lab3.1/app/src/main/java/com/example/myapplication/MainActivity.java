package com.example.myapplication;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ListView lvMonHoc;
    ArrayList <String> arraycourse;
    EditText edtInput;
    Button btnAdd, btnUpdate;
    ArrayAdapter<String> adapter;
    int selectedIndex = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.list_view);

        lvMonHoc = findViewById(R.id.ListViewMonHoc);
        edtInput = findViewById(R.id.edtInput);
        btnAdd = findViewById(R.id.btnAdd);
        btnUpdate = findViewById(R.id.btnUpdate);

        arraycourse = new ArrayList<>();
        arraycourse.add("Android");
        arraycourse.add("PHP");
        arraycourse.add("iOS");
        arraycourse.add("Unity");
        arraycourse.add("ASP.net");
        adapter = new ArrayAdapter(
                MainActivity.this,
                android.R.layout.simple_list_item_1,
                arraycourse
        );
        lvMonHoc.setAdapter(adapter);

        lvMonHoc.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                selectedIndex = i;
                edtInput.setText(arraycourse.get(i));
            }
        });

        // Xử lý sự kiện giữ lâu để xóa phần tử
        lvMonHoc.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> adapterView, View view, int i, long l) {
                arraycourse.remove(i);
                adapter.notifyDataSetChanged();
                Toast.makeText(MainActivity.this, "Đã xóa!", Toast.LENGTH_SHORT).show();
                return true;
            }
        });

        // Xử lý sự kiện khi bấm nút "Thêm"
        btnAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String newItem = edtInput.getText().toString().trim();
                if (!newItem.isEmpty()) {
                    arraycourse.add(newItem);
                    adapter.notifyDataSetChanged();
                    edtInput.setText("");
                    Toast.makeText(MainActivity.this, "Đã thêm!", Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(MainActivity.this, "Nhập nội dung trước!", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // Xử lý sự kiện khi bấm nút "Cập nhật"
        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String updatedText = edtInput.getText().toString().trim();
                if (selectedIndex != -1 && !updatedText.isEmpty()) {
                    arraycourse.set(selectedIndex, updatedText);
                    adapter.notifyDataSetChanged();
                    Toast.makeText(MainActivity.this, "Đã cập nhật!", Toast.LENGTH_SHORT).show();
                    selectedIndex = -1;
                    edtInput.setText("");
                } else {
                    Toast.makeText(MainActivity.this, "Chọn một mục và nhập nội dung mới!", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }
}