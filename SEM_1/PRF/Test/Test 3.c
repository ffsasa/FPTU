#include<stdio.h>
#include<stdlib.h>
void add(int arr[],int n);
int main(){
	int*p;
	int array[100];
	p=(int)calloc(10,sizeof(int));
	p = array;
	int n=10;
	add(array,n);
}

void add(int arr[],int n){
	for (int i=0; i<10;i++){
		printf("Nhap:");
		scanf("%d", &arr[i]);
	}
}