#include<stdio.h>

double factorial(int n);
int main(){
	int n;
	double S;
	
	do {
		printf("Nhap n:");
		scanf("%d", &n);
	}while(n<0);
	
	S = factorial(n);
	printf("The Factorial of n is equal to: %lf", S);
	
    return 0;
}
double factorial(int n){
	double p=1;
	int i;
	for(i=2;i<=n;i++){
		p*=i;
	}
	return p;
}