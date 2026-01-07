#include<stdio.h>
#include<stdlib.h>
void initArray(int arr[]);
void setArray2(int arr[],int n);
void createArray(int n, int *p);
int main(){

//Mang co ban
	int i, seq[5];
	int array2[5];

	int array1[5]={1.0, 3.0, 5.7, 4.2}; 
	
	int a=array1[0];
	
	printf("the first element of array1: %f\n", array1[0]);
	printf("the first element of array1: %f\n", a);

	
	printf("address of the first element: %u\n",&array1[0]);
	printf("address of the second element: %u\n",&array1[1]);
	printf("address of the third element: %u\n",&array1[2]);
	printf("address of the fourth element: %u\n",&array1[3]);
	printf("address of the fifth element: %u\n",&array1[4]);


//Gan con cho cho mang
	int *p;
	p = array1;
	printf("Value of p: %u\n", p);
	
	printf("the first element of array1: %f\n", *p);
	printf("the third element of array1: %f\n", *(p+2));

//	Xuat mang, Duyet Mang.
	initArray(array1);
	
	for(i=0;i<=5;i++){
		printf("the value of array1[%d]: %d\n", i, array1[i]);
	}


//Khai bao dong
	int*p2;
	p2=(int*)calloc(4214123,sizeof(int));
	int b=2;
	printf("b=%d\n", b);

	setArray2(array2,5);
	for(int i=0;i<5;i++){
		printf("array[%d]: %d\n", i, array2[i]);
	}


//In mang gom so le
	createArray(50,&p2);

	return 0;
}



void initArray(int arr[]){                                            //Truyen mang vao ham
	arr[0]=3;
	arr[1]=4;
	arr[2]=5;
	arr[3]=6;	                  
}


//Ham set mang
void setArray2(int arr[],int n){
	for (int i=0;i<n;i++) arr[i] = (i+1)*7;
}


//Ham mang so le
void createArray(int n, int *p){
	int k=0;
	for (int i=1; i<=n;i++)
		{
			if (i%2==1) {
				printf("p[%d]=%d\n",k,i);
				k=k+1;
			}
		}
}
