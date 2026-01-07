//write a function to calculate the below sequece:
//1+1/2+1/3+1/4+...+1/n
//where n satify the condition of 1/n<e 
//and e is a given small number (e.g.e = 0.05)
//test the function where e is inputted from keyboard

#include<stdio.h>

float T(float e){
	float S=0, n;
	for(n=1;1/n>=e;n++){
		S=S+1/n;
	}
	return S;
}

int main(){
	float e;
	printf("Nhap e: ");
	scanf("%f", &e);
	
	float Tong = T(e);
	printf("Tong = %f", Tong);

return 0;
}
