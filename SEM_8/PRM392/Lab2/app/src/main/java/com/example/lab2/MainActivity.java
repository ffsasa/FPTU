package com.example.lab2;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.NumberPicker;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.util.Random;

public class MainActivity extends AppCompatActivity {
    EditText Min;
    EditText Max;
    TextView Result;
    Button btnGenetare;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.random);

        Min = findViewById(R.id.textView4);
        Max = findViewById(R.id.textView5);
        Result = findViewById(R.id.textView7);
        btnGenetare = findViewById(R.id.button);

        btnGenetare.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int min = Integer.parseInt(Min.getText().toString());
                int max = Integer.parseInt(Max.getText().toString());

                if(min >= max){
                    max = min + 1;
                    Max.setText(max+"");
                }

                int randomNumber = getRandomNumber(min, max);

                String currentTime = java.text.DateFormat.getDateTimeInstance().format(new java.util.Date());

                String resultText = String.format("%d\nMin: %d, Max: %d\n%s", randomNumber, min, max, currentTime);
                Result.setText(resultText);

                ViewGroup.LayoutParams params = Result.getLayoutParams();
                params.height = 160;
                Result.setLayoutParams(params);
            }
        });
    }

    private int getRandomNumber(int min, int max) {
        Random random = new Random();
        return random.nextInt((max - min) + 1) + min;
    }
}