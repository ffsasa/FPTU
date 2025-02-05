package com.example.lab31;

import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.io.IOException;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    private static final int PICK_IMAGE_REQUEST = 1;
    private ArrayList<Item> items;
    private CustomAdapter adapter;
    private ListView listView;
    EditText titleInput, descriptInput;
    Button btnAdd, btnUpdate, btnSelectImage;
    int selectedIndex = -1;
    ImageView imageView;
    private Uri imageUri = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Khởi tạo ListView
        listView = findViewById(R.id.listView);
        titleInput = findViewById(R.id.editTitle);
        descriptInput = findViewById(R.id.editDescription);
        imageView = findViewById(R.id.imageView);
        btnAdd = findViewById(R.id.addButton);
        btnUpdate = findViewById(R.id.updateButton);
        btnSelectImage = findViewById(R.id.selectImageButton);

        // Tạo danh sách các Item
        items = new ArrayList<>();
        items.add(new Item(getUriFromDrawable(R.drawable.banana), "Chuối tiêu", "Chuối tiêu Long An"));
        items.add(new Item(getUriFromDrawable(R.drawable.dragon_fruit), "Thanh Long", "Thanh long ruột đỏ"));
        items.add(new Item(getUriFromDrawable(R.drawable.strawberry), "Dâu tây", "Dâu tây Đà Lạt"));
        items.add(new Item(getUriFromDrawable(R.drawable.watermelon), "Dưa hấu", "Dưa hấu Tiền Giang"));
        items.add(new Item(getUriFromDrawable(R.drawable.orange), "Cam vàng", "Cam vàng nhập khẩu"));

        // Tạo CustomAdapter và set vào ListView
        adapter = new CustomAdapter(this, R.layout.list_item_layout, items);
        listView.setAdapter(adapter);

        // Xử lý chọn ảnh
        btnSelectImage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openImagePicker();
            }
        });

        // Xử lý sự kiện giữ lâu để xóa phần tử
        listView.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> adapterView, View view, int i, long l) {
                items.remove(i);
                adapter.notifyDataSetChanged();
                titleInput.setText("");
                descriptInput.setText("");
                selectedIndex = -1;
                Toast.makeText(MainActivity.this, "Đã xóa!", Toast.LENGTH_SHORT).show();
                return true;
            }
        });

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                selectedIndex = i;
                titleInput.setText(items.get(i).getTitle());
                descriptInput.setText(items.get(i).getDescription());
                imageUri = items.get(i).getImageUri();
                if (imageUri != null) {
                    imageView.setImageURI(imageUri);
                }
            }
        });

        // Xử lý sự kiện khi bấm nút "Thêm"
        btnAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String title = titleInput.getText().toString().trim();
                String description = descriptInput.getText().toString().trim();

                if (!title.isEmpty() && !description.isEmpty() && imageUri != null) {
                    Item newItem = new Item(imageUri, title, description); // Sử dụng imageUri đã chọn
                    items.add(newItem);
                    adapter.notifyDataSetChanged();
                    titleInput.setText("");
                    descriptInput.setText("");
                    imageView.setImageResource(R.drawable.ic_launcher_background); // Reset ảnh về ảnh mặc định
                    imageUri = null; // Reset URI ảnh
                    Toast.makeText(MainActivity.this, "Đã thêm!", Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(MainActivity.this, "Nhập đủ thông tin và chọn ảnh!", Toast.LENGTH_SHORT).show();
                }
            }
        });


        // Xử lý sự kiện khi bấm nút "Cập nhật"
        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String title = titleInput.getText().toString().trim();
                String description = descriptInput.getText().toString().trim();

                if (selectedIndex != -1 && !title.isEmpty() && !description.isEmpty() && imageUri != null) {
                    Item updatedItem = new Item(imageUri, title, description);
                    items.set(selectedIndex, updatedItem);
                    adapter.notifyDataSetChanged();
                    Toast.makeText(MainActivity.this, "Đã cập nhật!", Toast.LENGTH_SHORT).show();
                    selectedIndex = -1;
                    titleInput.setText("");
                    descriptInput.setText("");
                    imageUri = null; // Reset URI ảnh
                    imageView.setImageResource(R.drawable.ic_launcher_background); // Reset ảnh
                } else {
                    Toast.makeText(MainActivity.this, "Chọn một mục và nhập nội dung mới!", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    private void openImagePicker() {
        Intent intent = new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
        startActivityForResult(intent, PICK_IMAGE_REQUEST);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == PICK_IMAGE_REQUEST && resultCode == RESULT_OK && data != null && data.getData() != null) {
            imageUri = data.getData();
            try {
                Bitmap bitmap = MediaStore.Images.Media.getBitmap(this.getContentResolver(), imageUri);
                imageView.setImageBitmap(bitmap);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    private Uri getUriFromDrawable(int drawableId) {
        return Uri.parse("android.resource://" + getPackageName() + "/" + drawableId);
    }
}
