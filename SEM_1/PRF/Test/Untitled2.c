#include<stdio.h>
#define PI 3.14

int main(){
	float r;
	float P;
	printf("Nhap ban kinh duong tron: ");
	scanf("%f", &r);
	
	if(r>0){
  	
	P = PI*2*r;
	printf("Chu vi duong tron: %f", P);
	}
	
	if(r<0){
	
		printf("Ban kinh duong tron khong hop le");
		}
	
	return 0;
}
