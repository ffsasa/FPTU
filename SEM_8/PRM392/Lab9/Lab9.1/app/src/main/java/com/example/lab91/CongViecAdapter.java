package com.example.lab91;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class CongViecAdapter extends BaseAdapter {
    private Context context;
    private int layout;
    private List<CongViec> congViecList;
    private OnItemClickListener listener;

    public interface OnItemClickListener {
        void onEditClick(CongViec congViec);
        void onDeleteClick(CongViec congViec);
    }

    public CongViecAdapter(Context context, int layout, List<CongViec> congViecList) {
        this.context = context;
        this.layout = layout;
        this.congViecList = congViecList;
    }

    @Override
    public int getCount() {
        return congViecList.size();
    }

    @Override
    public Object getItem(int i) {
        return congViecList.get(i); // Trả về công việc tại vị trí i
    }

    @Override
    public long getItemId(int i) {
        return congViecList.get(i).getIdCV(); // Trả về ID của công việc
    }

    private class ViewHolder {
        TextView txtTen;
        ImageView imgDelete, imgEdit;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        ViewHolder holder;

        if (view == null) {
            holder = new ViewHolder();
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = inflater.inflate(layout, null);
            holder.txtTen = view.findViewById(R.id.textviewTen);
            holder.imgDelete = view.findViewById(R.id.imageviewDelete);
            holder.imgEdit = view.findViewById(R.id.imageviewEdit);
            view.setTag(holder);
        } else {
            holder = (ViewHolder) view.getTag();
        }

        CongViec congViec = congViecList.get(i);
        holder.txtTen.setText(congViec.getTenCV()); // Gán tên công việc

        // Xử lý sự kiện click cho nút Edit
        holder.imgEdit.setOnClickListener(v -> {
            if (listener != null) {
                listener.onEditClick(congViec);
            }
        });

        // Xử lý sự kiện click cho nút Delete
        holder.imgDelete.setOnClickListener(v -> {
            if (listener != null) {
                listener.onDeleteClick(congViec);
            }
        });

        return view;
    }
}
