/* Write a C program that will execute repetitively using a simple menu */ 
#include <stdio.h> 
#include <math.h>

int prime (int n)
{
	float m = sqrt(n);	// m: square root of n	
	int i; 
	if (n<2) return 0;
	for (i=2;i<=m;i++)
		{
			if ((n%i)==0) return 0;	// i divided by n --> n is not a prime
		}
		return 1;		// n is a prime.	
}

void print_Min_MaxDigits(int n)
{
    int digit; 			// Variable for extracting 1 digit
	int min,max; 		// Result variables
	digit = n%10;		// get the first rightmost digit
	n=n/10;
	min=max=digit;		// intialize results
	while (n>0)
	{
		digit=n%10;		// Get the next digit
		n=n/10;
		if (min>digit) min=digit;		// update results
		if (max<digit) max=digit;
	}
   printf("Max digit: %d\n", max);
   printf("Min digit: %d\n", min);
}
	
int main() 
{ 
	int n, choice ;
	do 
	{ 
		printf(" 1- Process primes\n");
		printf(" 2- Print min, max digit in an integer\n");
		printf(" 3- Quit\n");
		printf(" Select an operation:  ");
		scanf("%d",&choice);
		switch(choice)
		{
			case 1 : 
				do 
				{ 
					printf("Enter a positive integer: ");
			 		scanf("%d",&n);
				} 
				while (n<1);	
				if(prime(n)==0) 
				{
					printf(" %d is not a prime\n",n);
				} 
				else
				{
					printf(" %d is a prime\n", n );
				}
				break;
			case 2 : do
					 {
					  printf ("Enter a positive integer:  ");
					  scanf("%d",&n);	
					 } 
					 while(n<0);
					print_Min_MaxDigits(n);
				break;
		} 
	} 
	while (choice >0 && choice <3);
	return 0;
}
