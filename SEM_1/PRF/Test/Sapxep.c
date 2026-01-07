#include<stdio.h>
void sortArray(int arr[], int n);
int main(){
	
	int array[6]={84, 23, 14, 39, 52, 7};
	
	                                                            //Sap xep mang	
//	for(int i=0; i<6; i++){
//		for (int j=i+1;j<6;j++){
//			if(array[i]>array[j]){
//			
//				int t = array[i];
//				array[i]=array[j];
//				array[j]=t;
//			}
//		}
//	}	

	sortArray(array,6);
	
	printf ("The array after being sorted: \n");
	for(int i=0; i<6;i++){
		printf("%d  ", array[i]);
	}

	return 0;
}

void sortArray(int arr[], int n){
	for(int i=0;i<6;i++){
		for(int j=i+1;j<6;j++){
			if(arr[i]>arr[j]){
				int t = arr[i];
				arr[i]=arr[j];
				arr[j]=t;
			}
		}
	}
}