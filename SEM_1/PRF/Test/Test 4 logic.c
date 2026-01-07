#include<stdio.h>

int main(){
	float x;
	printf("Nhap vao mot so thuc: ");
	scanf("%f", &x);
	
	if(x<2){
		printf("x thuoc khoang (1)\n");
	} else if ((x<=5) && (2<=x)){
		    printf("x thuoc khoang (2)\n");
		}else {
			printf("x thuoc khoang (3)\n");
			}
		
	return 0;
}

