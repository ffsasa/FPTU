#include<stdio.h>

int main(){
	int n = 11;
	printf("n = %d\n", n);
	printf("n = %x\n", n);
	
	int m = 4;
	printf("m = %d\n", m);
	
	int x;
	x = n/m;
	printf("x = %d\n", x);
	
	x=n%m;
	printf("x = %d", x);

	
	return 0;
}
