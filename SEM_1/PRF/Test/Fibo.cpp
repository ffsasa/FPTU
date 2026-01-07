#include<stdio.h>

double fibo(int n);
int main(){
	int n;
	
	do{
		printf("Nhap n: ");
		scanf("%d", &n);
	}while (n<1);
	
		double T = fibo(n);
		printf("%lf", T);
    return 0;
}
double fibo ( int n) {
    int t1=1, t2=1, f=1, i ;
    for (i=3; i<=n; i++) {
        f= t1 + t2;
        t1= t2;
        t2=f;
    }   
 return f;
}