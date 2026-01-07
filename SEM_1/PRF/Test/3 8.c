#include<stdio.h>

double makeDouble(int ipart, int fraction){ 
    double d_f= fraction;
    while (d_f >=1) d_f = d_f/10;
    if (ipart<0) return ipart - d_f;
    return ipart + d_f ;
}
int main(){
	int ipart;
	int fraction;
	double value;

    printf("Enter ipart: ");
    scanf("%d", &ipart);
    
    do{ 
	printf("Enter fraction: ");
	scanf("%d", &fraction);
    }while (fraction<0);
    
	value= makeDouble(ipart,fraction);
 
    printf("Value = %lf", value);
}