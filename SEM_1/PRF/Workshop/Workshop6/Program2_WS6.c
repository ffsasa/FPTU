#include<stdio.h>
#include<math.h>

void addArray(int array[],int *size);
void searchArray(int array[], int size);
void printArray(int array[], int size);
void rangeOfArray(int array[], int size);
void arrayAscend(int array[], int size);
int main(){
	int choice;
	char buffer;
	int array[100];
	int p,size=0;
do{  // OPTION TRONG MENU
	printf("\n===========================MENU==========================");
	printf("\n1 - Add a value                                  Press 1.");
	printf("\n2 - Search a value                               Press 2.");
	printf("\n3 - Print out the array                          Press 3.");
    printf("\n4 - Print out values in a range                  Press 4.");
    printf("\n5 - Print out the array in ascending order       Press 5.");
    printf("\nOther - Quit");
    printf("\n");
	
	do{ // EP NGUOI DUNG NHAP SO NGUYEN
    	printf("\nPlease choose from 1 to 5: ");
        scanf("%d", &choice);
        scanf("%c", &buffer);
		fflush(stdin);
		if(buffer != 10) printf("\nPlease enter a number.");
	}while(buffer != 10);
	
	switch(choice){
		case 1:
                addArray(array, &size);
                printf("\n");
                break;
        case 2:
                searchArray(array, size);
                printf("\n");
                break;
        case 3:
                printArray(array,size);
                printf("\n");
                break;
        case 4:
                rangeOfArray(array, size);
                printf("\n");
                break;
        case 5:
                arrayAscend(array, size);
                printf("\n");
                break;
        default: 
				printf("Goodbye and see you again");
				break;
		}
	}while(choice>=1&&choice<=5);
}

void addArray(int array[],int *size){
	printf("\nEnter the dimension: ");
    scanf("%d", size);
    for(int i=0;i<=*size-1;i++){
	printf("\nArray[%d]: ", i);
    scanf("%d", &array[i]);
    }
    printf("\n------------");
    printf("\nDone!");
}

void searchArray(int array[], int size){
	if(size==0){printf("Nothing to printf\n");
	}else{
	int value,count;
	printf("Enter the value you want to find: ");
	scanf("%d", &value);
	
	for(int i=0;i<=size-1;i++){
		if(array[i]==value){
			printf("%5d  ", i);
            count++;
		}
	}
	if(count==0)  printf("\nThere is no %d in the array!",value);}
}

void printArray(int array[], int size){
	if(size==0){printf("Nothing to printf\n");
	}else{
		for(int i=0;i<=size-1;i++){
			printf("%d  ",array[i]);
		}
	}
}

void rangeOfArray(int array[], int size){
	if(size==0){printf("Nothing to printf\n");
	}else{
		int min,max;
		printf("\nEnter min: ");
    	scanf("%d", &min);
    	printf("\nEnter max: ");
    	scanf("%d", &max);
    	printf("\nThe values in the interval min max is: ");
    	for(int i=0;i<=size-1;i++){
    		if(array[i] >= min && array[i] <= max) printf("%5d", array[i]);
		}
	}
}

void arrayAscend(int array[], int size){
	if(size==0){printf("Nothing to printf\n");
	}else{
		int i,j;
		for(int i=0;i<=size-1;i++){
			for(j=i+1;j<=size-1;j++){
				if(array[j]<array[i]){
					int t = array[i];
					array[i]=array[j];
					array[j]=t;
				}
			}
		}
	printArray(array, size);	
	}
}

