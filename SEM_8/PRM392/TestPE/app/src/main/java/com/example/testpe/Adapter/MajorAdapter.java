package com.example.testpe.Adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;

import com.example.testpe.MajorManagerActivity;
import com.example.testpe.R;
import com.example.testpe.model.Major;

import java.util.List;

public class MajorAdapter extends ArrayAdapter<Major> {
    private Context context;
    private List<Major> majorList;

    public MajorAdapter(Context context, List<Major> majors) {
        super(context, R.layout.major_item, majors);
        this.context = context;
        this.majorList = majors;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            LayoutInflater inflater = LayoutInflater.from(context);
            convertView = inflater.inflate(R.layout.major_item, parent, false);
        }

        TextView tvMajorId = convertView.findViewById(R.id.tvMajorId);
        TextView tvMajorName = convertView.findViewById(R.id.tvMajorName);
        Button btnEdit = convertView.findViewById(R.id.btnEdit);
        Button btnDelete = convertView.findViewById(R.id.btnDelete);

        Major major = majorList.get(position);
        tvMajorId.setText("ID: " + major.getId());
        tvMajorName.setText("Name: " + major.getNameMajor());

        btnEdit.setOnClickListener(v -> ((MajorManagerActivity) context).showEditMajorDialog(major));
        btnDelete.setOnClickListener(v -> ((MajorManagerActivity) context).deleteMajor(major));

        return convertView;
    }
}
