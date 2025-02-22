package com.example.lab51;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {
    private RecyclerView recyclerView;
    private UserAdapter userAdapter;
    private List<User> userList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        recyclerView = findViewById(R.id.recyclerView);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        // Tạo danh sách user
        userList = new ArrayList<>();
        userList.add(new User("john_doe", "John Doe", "john@example.com"));
        userList.add(new User("jane_smith", "Jane Smith", "jane@example.com"));
        userList.add(new User("alice_johnson", "Alice Johnson", "alice@example.com"));

        // Kết nối RecyclerView với Adapter
        userAdapter = new UserAdapter(userList);
        userAdapter.notifyDataSetChanged();
        recyclerView.setAdapter(userAdapter);
    }
}