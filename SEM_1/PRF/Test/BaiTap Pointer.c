#include<stdio.h>

//int main(){
	
//	int n=5, m=7;
//	int *x, *y=&n; 
//	int **a=&x;
	
//	x=&m;
	
//	printf("%d\n", a);            //IN RA DIA CHI CUA POINTER X
	
//	n=*x+2;
//	printf("n = %d", n);
	
//	return 0;
//}

void hcn(float width, float length, float * CV, float * DT){
	*CV=(width+length)*2;
	*DT=width*length;
}
int main(){
	                              // HAM TRA VE NHIEU HON 1 GIAI TRI: Viet ham tinh chu vi va dien tich hinh chu nhat
	float a=2.0,b=5.0;
	float P,S;
	
	hcn(a,b,&P,&S);
	
	printf("P=%f, S=%f", P, S);	
	                     
	return 0;
}