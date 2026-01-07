#include<stdio.h>

int main(){
	
	int array[6]={84, 23, 14, 39, 52, 7};
	
	//Sap xep mang
	
	for(int i=0; i<6; i++){
		for (int j=i+1;j<6;j++){
			if(array[i]>array[j]){
				
				int t = array[i];
				array[i]=array[j];
				array[j]=t;
			}
		}
	}	
	printf ("The array after being sorted: \n");
	for(int i=0; i<6;i++){
		printf("%d", array[i]);
	}

	return 0;
}