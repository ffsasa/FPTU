package com.example.lab31;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

public class CustomAdapter extends ArrayAdapter<Item> {
    private Context mContext;
    private int mResource;

    public CustomAdapter(Context context, int resource, ArrayList<Item> objects) {
        super(context, resource, objects);
        this.mContext = context;
        this.mResource = resource;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.list_item_layout, parent, false);
        }

        Item currentItem = getItem(position);

        ImageView imageView = convertView.findViewById(R.id.imageView);
        TextView titleView = convertView.findViewById(R.id.editTitle);
        TextView descriptionView = convertView.findViewById(R.id.editDescription);

        // Hiển thị hình ảnh từ URI
        if (currentItem.getImageUri() != null) {
            imageView.setImageURI(currentItem.getImageUri());
        } else {
            imageView.setImageResource(R.drawable.ic_launcher_background); // Ảnh mặc định
        }

        titleView.setText(currentItem.getTitle());
        descriptionView.setText(currentItem.getDescription());

        return convertView;
    }
}

