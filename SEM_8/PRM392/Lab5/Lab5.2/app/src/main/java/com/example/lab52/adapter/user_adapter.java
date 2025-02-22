package com.example.lab52.adapter;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.lab52.Module;
import com.example.lab52.R;

import java.util.List;

public class user_adapter  extends RecyclerView.Adapter<user_adapter.ModuleViewHolder> {
    private Context context;
    private List<Module> moduleList;

    public user_adapter(Context context, List<Module> moduleList) {
        this.context = context;
        this.moduleList = moduleList;
    }

    @NonNull
    @Override
    public ModuleViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_layout, parent, false);
        return new ModuleViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ModuleViewHolder holder, int position) {
        Module module = moduleList.get(position);
        holder.imageViewModule.setImageResource(module.getImage());
        holder.textViewTitle.setText(module.getTitle());
        holder.textViewDescription.setText(module.getDescription());
        holder.textViewOperatingSystem.setText(module.getOperatingSystem());

        holder.itemView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showUpdateModuleDialog(holder.getAdapterPosition());
            }
        });
    }

    public void deleteModule(int position) {
        if (position >= 0 && position < moduleList.size()) {
            moduleList.remove(position);
            notifyItemRemoved(position);
            notifyItemRangeChanged(position, moduleList.size()); // Cập nhật lại vị trí
        }
    }

    public void addModule(Module module) {
        moduleList.add(module);
        notifyItemInserted(moduleList.size() - 1);
    }

    public void updateModule(int position, Module module) {
        moduleList.set(position, module);
        notifyItemChanged(position);
    }

    private void showUpdateModuleDialog(int position) {
        Module currentModule = moduleList.get(position);
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        LayoutInflater inflater = LayoutInflater.from(context);
        View dialogView = inflater.inflate(R.layout.dialog_add_item, null);
        builder.setView(dialogView);

        EditText editTextTitle = dialogView.findViewById(R.id.editTextTitle);
        EditText editTextDescription = dialogView.findViewById(R.id.editTextDescription);
        editTextTitle.setText(currentModule.getTitle());
        editTextDescription.setText(currentModule.getDescription());

        int checkedItem = currentModule.getOperatingSystem().equals("Android") ? 0 : 1;
        final int[] selectedOS = new int[1];
        builder.setTitle("Update Module")
                .setSingleChoiceItems(new String[]{"Air5", "Gen9"}, checkedItem, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        selectedOS[0] = which;
                    }
                })
                .setPositiveButton("Update", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        String title = editTextTitle.getText().toString();
                        String description = editTextDescription.getText().toString();
                        String operatingSystem = selectedOS[0] == 0 ? "Air5" : "Gen9";
                        int selectedImage = operatingSystem.equals("Air5") ? R.drawable.ipad_air_5th : R.drawable.ipad_gen_9;
                        Log.d("ModuleAdapter", "Updating module to OS: " + operatingSystem);
                        Module updatedModule = new Module(selectedImage, title, description, operatingSystem);
                        updateModule(position, updatedModule);
                    }
                })
                .setNeutralButton("Delete", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        deleteModule(position);
                    }
                })
                .setNegativeButton("Cancel", null);

        builder.create().show();
    }

    public static class ModuleViewHolder extends RecyclerView.ViewHolder {
        ImageView imageViewModule;
        TextView textViewTitle;
        TextView textViewDescription;
        TextView textViewOperatingSystem;

        public ModuleViewHolder(@NonNull View itemView) {
            super(itemView);
            imageViewModule = itemView.findViewById(R.id.imageViewModule);
            textViewTitle = itemView.findViewById(R.id.textViewTitle);
            textViewDescription = itemView.findViewById(R.id.textViewDescription);
            textViewOperatingSystem = itemView.findViewById(R.id.textViewOperatingSystem);
        }
    }

    @Override
    public int getItemCount() {
        return moduleList.size();
    }
}
