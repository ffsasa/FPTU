#include<stdio.h>

int main(){
	
	int i,n,S;
	
	printf("Nhap so can cong: ");
	scanf("%d", &n);
	
	S=0;
	
	for(i=0;i<=n;i++){
		S=S+i;
	}
    
    printf("Tong la %d", S);
	
	return 0;
}
