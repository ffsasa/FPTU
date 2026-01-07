#include <stdio.h>
#include <stdlib.h>
const int MAX = 100;
void addArray(int array[], int *size);
void searchArray(int array[], int size);
void printArray(int array[], int size);
void arrayAscend(int array[], int size);
void rangeOfArray(int array[], int size);
int main()
{
    int array[MAX];
    int size = 0;
    int choice, n, buffer;
    do{
        printf("\n1- Add  a value.");
    	printf("\n2- Search a value.");
    	printf("\n3- Print out the array.");
    	printf("\n4- Print out values in a range.");
    	printf("\n5- Print out the array in ascending order.");
    	printf("\n");
    	printf("\nOther- Quit.");
    	printf("\nSelect [1..5] : ");
		fflush(stdin);
		scanf("%d", &choice);
	

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
				printf("Good bye!");
				break;
        }
    }while (choice >= 1 && choice <=5);;
}



void addArray(int array[], int *size){
    printf("\nEnter the dimension: ");
    scanf("%d", size);

    for(int i = 0; i<= *size - 1; i++){
        printf("\nArray[%d]: ", i);
        scanf("%d", &array[i]);
    }

    printf("\n------------");
    printf("\nDone!");
}



void searchArray(int array[], int size){
    if(size == 0){
        printf("\nNothing to printf!!");
        return;
    }

    int key;
    printf("\nEnter the key you want to find: ");
    scanf("%d", &key);

    int count = 0;
    printf("\nThe position of %d is: ", key);
    for(int i = 0; i<= size -1; i++){
        if(array[i]== key){
            printf("%5d", i);
            count++;
        }
    }
    if(count == 0){
        printf("\nThere is no %d in the array!", key);
    }
}



void printArray(int array[], int size){
    if(size == 0){
        printf("\nNothing to printf!!");
        return;
    }
    printf("\n");
    for(int i = 0; i <= size -1; i++){
        printf("%5d", array[i]);
    }
}



void rangeOfArray(int array[], int size){
    if(size == 0){
        printf("\nNothing to printf!!");
        return;
    }
    int min, max;
    printf("\nEnter min: ");
    scanf("%d", &min);
    printf("\nEnter max: ");
    scanf("%d", &max);

    printf("\n The values in the interval min max is: ");
    for(int i = 0; i <= size -1; i++){
            if(array[i] >= min && array[i] <= max){
                    printf("%5d", array[i]);
            }
    }
}



void arrayAscend(int array[], int size){
    if(size == 0){
        printf("\nNothing to printf!!");
        return;
    }
    int minIndex;
    int i, j;

    for(i = 0; i<=size -1; i++){
        for(j=i+1; j<= size-1; j++){
            if(array[i]>array[j]){
                int t = array[i];
                array[i] = array[j];
                array[j] = t;
            }
        }
    }
    printArray(array, size);
}

