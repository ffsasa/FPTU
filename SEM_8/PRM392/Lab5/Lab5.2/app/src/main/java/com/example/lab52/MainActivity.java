package com.example.lab52;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.lab52.adapter.user_adapter;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private user_adapter userAdapter;
    private List<Module> moduleList;
    private Button buttonAddModule;
    private int selectedOSIndex = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        recyclerView = findViewById(R.id.recyclerView);
        buttonAddModule = findViewById(R.id.buttonAddModule);

        moduleList = new ArrayList<>();

        // Thêm dữ liệu mẫu
        moduleList.add(new Module(R.drawable.ipad_air_5th, "Module 1", "Description 1", "Air5"));
        moduleList.add(new Module(R.drawable.ipad_gen_9, "Module 2", "Description 2", "Gen9"));

        userAdapter = new user_adapter(this, moduleList);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        recyclerView.setAdapter(userAdapter);

        buttonAddModule.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showAddModuleDialog();
            }
        });
    }

    private void showAddModuleDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        LayoutInflater inflater = getLayoutInflater();
        View dialogView = inflater.inflate(R.layout.dialog_add_item, null);
        builder.setView(dialogView);

        EditText editTextTitle = dialogView.findViewById(R.id.editTextTitle);
        EditText editTextDescription = dialogView.findViewById(R.id.editTextDescription);

        builder.setTitle("Add New Module")
                .setSingleChoiceItems(new String[]{"Air5", "Gen9"}, -1, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        selectedOSIndex = which;
                    }
                })
                .setPositiveButton("Add", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        String title = editTextTitle.getText().toString();
                        String description = editTextDescription.getText().toString();
                        String operatingSystem = selectedOSIndex == 0 ? "Air5" : "Gen9";
                        int selectedImage = selectedOSIndex == 0 ? R.drawable.ipad_air_5th : R.drawable.ipad_gen_9;

                        Module newModule = new Module(selectedImage, title, description, operatingSystem);
                        userAdapter.addModule(newModule);
                    }
                })
                .setNegativeButton("Cancel", null);

        builder.create().show();
    }
}