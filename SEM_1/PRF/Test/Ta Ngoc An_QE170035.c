#include<stdio.h>
#include<math.h>
int taxifee();
int Sum(int n);
int prime (int n);
int integerString(char array[][100]);

int main(){
	int choice;
	char buffer;

do{  
	printf("\n===========================MENU==========================");
	printf("\n1 - Calculate the amount of taxi fee             Press 1.");
	printf("\n2 - Sum of all the digits in a integer           Press 2.");
	printf("\n3 - The number of integer strings                Press 3.");
    printf("\n4 - The prime less than N                        Press 4.");
    printf("\nOther - Quit");
    printf("\n");
	
	do{ 
    	printf("\nPlease enter your option: ");
        scanf("%d", &choice);
        scanf("%c", &buffer);
		fflush(stdin);
		if(buffer != 10) printf("\nPlease enter a number.");
	}while(buffer != 10);
	
	switch(choice){
		case 1:{
					double Sum = taxifee();
					printf("Taxi fee: %.0lf", Sum);
				}
				break;
				
		case 2:{
					int n=0;
					int S=0;
					printf("Enter a number: ");
					scanf("%d",&n);
					if(n<0){
						n=n*(-1);
					}
					S=Sum(n);
					printf("Sum of all the digits: %d",S);
				}
				break;
			
		case 3:{
				char array[100][100];
				int integerString(char array[][100]);
				break;
			}
		case 4:{
				int n;
				int count=0;
				int array[100];
	
				do{
					printf("Enter a number: ");
					scanf("%d", &n);
					if(n<0){
						printf("Please, Enter a positive number!\n");
					}
				}while(n<0);
	
				for(int i=0;i<n;i++){
					if(prime(i)==1){
						array[count]=i;
						count++;
					}
				}
	
				if(count==0){
					printf("Don't have any the primes less than n");
				}else{
					for(int i=0;i<count;i++){
					printf("%d  ", array[i]);
					}
				}
				
				break;
			}
		default:{
				printf("\n=============== The program is finished ===============\n");
				printf("                      Goodbye!");
				break;
			}
		}
	}while(choice>=1&&choice<=4);
}

int taxifee(){
	double n;
	double Sum;
	printf("How many km you went?\n");
	
	do{
	printf("Enter a number: ");
	scanf("%lf", &n);
		if(n<=0){
			printf("Please, Enter a positive number!\n");
		}
	}while(n<=0);
	Sum=15000+12000*n-12000;
	
	return Sum;
}

int Sum(int n){
    int digit; 		
	int min,max; 		
	digit = n%10;		
	n=n/10;	
	int S=digit;	
	while (n>0)
	{
		digit=n%10;		
		n=n/10;
		S=S+digit;
	}
	return S;
}

int prime (int n){
	float m = sqrt(n);	
	int i; 
	if (n<2) return 0;
	for (i=2;i<=m;i++)
		{
			if ((n%i)==0) return 0;	
		}
		return 1;
}

int integerString(char array[][100]){
}
