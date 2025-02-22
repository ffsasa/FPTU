package com.example.lab4;

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

public class DrinksActivity extends AppCompatActivity {
    ListView listView;
    Button btnOrder;
    ArrayList<ItemF> itemList = new ArrayList<ItemF>();
    String selectedDrinks = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_drinks);

        listView = findViewById(R.id.listViewDrinks);
        btnOrder = findViewById(R.id.btnOrderDrinks);

        itemList.add(new ItemF(R.drawable.heineken,"Heineken","Bia Heineken","10.000 VNĐ"));
        itemList.add(new ItemF(R.drawable.saigondo,"Sài Gòn Đỏ","Bia Sài Gòn Đỏ","10.000 VNĐ"));
        itemList.add(new ItemF(R.drawable.tiger,"Tiger","Bia Tiger","10.000 VNĐ"));
        itemList.add(new ItemF(R.drawable.pepsi,"Pepsi","Nước Pepsi","10.000 VNĐ"));

        CustomAdapter customAdapter = new CustomAdapter(this, R.layout.list_item_layout, itemList);
        listView.setAdapter(customAdapter);

        listView.setOnItemClickListener( new AdapterView.OnItemClickListener(){
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                ItemF selected = itemList.get(i);
                selectedDrinks = selected.getName();

                Toast.makeText(DrinksActivity.this, "Đã chọn nước uống: " + selectedDrinks, Toast.LENGTH_SHORT).show();
            }
        });

        btnOrder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent resultIntent = new Intent();
                resultIntent.putExtra("SELECTED_DRINKS", selectedDrinks);
                setResult(Activity.RESULT_OK, resultIntent);
                finish();
            }
        });
    }
}