package com.example.myapplication;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;

public class FoodActivity extends AppCompatActivity {
    ListView listView;
    Button btnOrder;
    ArrayList<Item> itemList = new ArrayList<Item>();
    String selectedFood;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_food);

        listView = findViewById(R.id.listViewFood);
        btnOrder = findViewById(R.id.btnOrderFood);

        itemList.add(new Item(R.drawable.bunbohue,"Bún bò Huế","Đây là bún bò Huế","50.000 VNĐ"));
        itemList.add(new Item(R.drawable.hutieusaigon,"Hủ tiếu Sài Gòn","Đây là hủ tiếu Sài Gòn","50.000 VNĐ"));
        itemList.add(new Item(R.drawable.miquang,"Mì quảng","Đây là mì quảng","50.000 VNĐ"));
        itemList.add(new Item(R.drawable.phohanoi,"Phở Hà Nội","Đây là phở Hà Nội","50.000 VNĐ"));

        CustomAdapter customAdapter = new CustomAdapter(this, R.layout.list_item_layout, itemList);
        listView.setAdapter(customAdapter);

        listView.setOnItemClickListener( new AdapterView.OnItemClickListener(){
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Item selected = itemList.get(i);
                selectedFood = selected.getName();

                Toast.makeText(FoodActivity.this, "Đã chọn món ăn: " + selectedFood, Toast.LENGTH_SHORT).show();
            }
        });

        btnOrder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent resultIntent = new Intent();
                resultIntent.putExtra("SELECTED_FOOD", selectedFood);
                setResult(Activity.RESULT_OK, resultIntent);
                finish();
            }
        });
    }
}
