#include<stdio.h>

int Tong(int x){
    int a, S=0, i;
	
	for (i=1;i<=x;i++){
	    
		a=i%2;
	    if(a==1){
		    S=S+i;
	    }
	}
    return S;
}

int main(){
	
	int x;
	printf("Nhap x: ");
	scanf("%d", &x);
	
	int T = Tong(x);
	printf("Tong = %d", T);
	
}
	
	
