#include<stdio.h>
#include<string.h>

int main(){
	char Ho[100][20];
	char Ten[100][30];
	int n;
	int T=0;
	
	printf("Ban muon them bao nhieu phan tu?");
	scanf("%d", &n);
	fflush(stdin);
	for(int i=0;i<n;i++){
		printf("Nhap ho:\n");
		gets(Ho[T]);
		fflush(stdin);
		printf("Nhap ten:\n");
		gets(Ten[T]);
		fflush(stdin);
		T++;
	}
	for(int i=0;i<=T-1;i++){
		printf("%s %s\n",Ho[i],Ten[i]);
	}
}