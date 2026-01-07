#include<stdio.h>

int main(){
	
	int array[6]={1,9,4,2,8,5};
	int max=array[0];
	int j, idx;
	
	//Tim kiem max
	for(int i=1;i<6;i++){
		if (max<array[i]){
			max=array[i];
		j=i;
		}
	}
	printf("Max = %d, Index = %d\n", max, j);
	
	//TIm kiem vi tri ref
	int ref=4;
	idx=searchNumber(array, 6,ref);
	if(idx==-1){
		printf("Khong ton tai %d trong day", ref);
	}else printf("%d", idx);
	
	return 0;
}

int searchNumber(int arr[], int n, int ref){
	int index=-1;
	
	for(int i=0;i<n;i++){
		if(arr[i]==ref){
			index=i;
		}
	}
	return index;
}