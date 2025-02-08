package com.example.myapplication;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    EditText number1;
    EditText number2;
    TextView result;
    Button btnCong;
    Button btnTru;
    Button btnNhan;
    Button btnChia;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calculator);

        number1 = findViewById(R.id.textView);
        number2 = findViewById(R.id.textView2);
        result = findViewById(R.id.textView3);
        btnCong = findViewById(R.id.button);
        btnTru = findViewById(R.id.button2);
        btnNhan = findViewById(R.id.button3);
        btnChia = findViewById(R.id.button4);

        btnCong.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                    String input1 = number1.getText().toString();
                    String input2 = number2.getText().toString();

                    int st1 = input1.isEmpty() || !input1.matches("\\d+") ? 0 : Integer.parseInt(input1);
                    int st2 = input2.isEmpty() || !input2.matches("\\d+") ? 0 : Integer.parseInt(input2);

                    int ketQua = st1 + st2;

                    result.setText("Kết quả: " + ketQua);
            }
        });

        btnTru.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String input1 = number1.getText().toString();
                String input2 = number2.getText().toString();

                int st1 = input1.isEmpty() || !input1.matches("\\d+") ? 0 : Integer.parseInt(input1);
                int st2 = input2.isEmpty() || !input2.matches("\\d+") ? 0 : Integer.parseInt(input2);

                int ketQua = st1 - st2;

                result.setText("Kết quả: " + ketQua);
            }
        });

        btnNhan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String input1 = number1.getText().toString();
                String input2 = number2.getText().toString();

                int st1 = input1.isEmpty() || !input1.matches("\\d+") ? 0 : Integer.parseInt(input1);
                int st2 = input2.isEmpty() || !input2.matches("\\d+") ? 0 : Integer.parseInt(input2);

                int ketQua = st1*st2;

                result.setText("Kết quả: " + ketQua);
            }
        });

        btnChia.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String input1 = number1.getText().toString();
                String input2 = number2.getText().toString();

                int st1 = input1.isEmpty() || !input1.matches("\\d+") ? 0 : Integer.parseInt(input1);
                int st2 = input2.isEmpty() || !input2.matches("\\d+") ? 0 : Integer.parseInt(input2);

                float ketQua = st1/st2;

                result.setText("Kết quả: " + ketQua);
            }
        });
    }
}