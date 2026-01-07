#include<stdio.h>

//Ham co doi so, co gia tri tra ve
float rectangleArea(float width, float length){
	
	float area = width*length;
	
	return area;
	}
	
int main(){
	float S = rectangleArea(2, 6);
	printf("S = %f\n", S);
	
	return 0;
}
