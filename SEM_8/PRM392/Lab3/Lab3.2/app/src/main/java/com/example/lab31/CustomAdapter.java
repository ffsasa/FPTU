package com.example.lab31;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

public class CustomAdapter extends BaseAdapter {

    private Context context; // => Là bối cảnh Adapter chạy, dùng để nạp dữ liệu
    private int layout; // => Lưu layout mà mỗi item được biểu diễn
    private List<Item> fruitList; // => Lưu danh sách mà Adapter chứa

    public CustomAdapter(Context context, int layout, List<Item> fruitList) {
        this.context = context;
        this.layout = layout;
        this.fruitList = fruitList;
    }

    @Override
    public int getCount() {
        return this.fruitList.size();
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(context.LAYOUT_INFLATER_SERVICE);
        view = inflater.inflate(layout, null);
        // Anh xa
        TextView txtName = view.findViewById(R.id.tvName);
        TextView txtDescription = view.findViewById(R.id.tvDescription);
        ImageView image = view.findViewById(R.id.imgFruit);

        //Gan gia tri
        Item fruit = fruitList.get(position);

        txtName.setText(fruit.getTitle());
        txtDescription.setText(fruit.getDescription());
        image.setImageResource(fruit.getImage());

        return view;
    }
}

