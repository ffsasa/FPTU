#include<stdio.h>


void Avg(float a, float b){
// Ham co doi so, nhung khong co gia tri tra ve
	float average = (a+b)/2;
	printf ("Average of a and b is: %f", average);
}	
int main(){
	Avg(2, 5);
	
	return 0;
}

