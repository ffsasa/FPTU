package com.example.lab61;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.option_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        // Handle item selection
        if (item.getItemId() == R.id.action_share) {
            Toast.makeText(this, "Bạn đã chọn Share", Toast.LENGTH_SHORT).show();
            return true;
        } else if (item.getItemId() == R.id.action_search) {
            Toast.makeText(this, "Bạn đã chọn Search", Toast.LENGTH_SHORT).show();
            return true;
        } else if (item.getItemId() == R.id.action_context) {
            Toast.makeText(this, "Bạn đã chọn Context", Toast.LENGTH_SHORT).show();
            return true;
        } else if (item.getItemId() == R.id.action_email) {
            Toast.makeText(this, "Bạn đã chọn Email", Toast.LENGTH_SHORT).show();
            return true;
        } else if (item.getItemId() == R.id.action_phone) {
            Toast.makeText(this, "Bạn đã chọn Phone", Toast.LENGTH_SHORT).show();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}