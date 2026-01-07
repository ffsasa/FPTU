//Viet chuong trinh tinh trung binh cong cua mot khoang so nguyen [a,b]

#include<stdio.h>

int main(){
	
	int i,a,b,n,S,T;
	float TBC;
	
	
	printf("Nhap a va b");
	scanf("%d %d", a, b);
	
	if (a<b){
	n=b-a+1;
	    while (i<n){
		    T=T+i;
		    i++;
       	}
    S=a*n+T;
    TBC=S/n;
    
    printf("Trung binh cong cua doan so nguyen [a,b] la: %f", TBC);
    }else{
    	printf("Day so khong hop le");
    	}
    return 0;
}
