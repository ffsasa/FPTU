/* Write a program that will accept a number (>=1 000 000 000) 
then show whether the number is an ISBN or not.*/
#include <stdio.h>
#include <stdlib.h>
int checkISBN(long int n);

int main() 
{
    long int n;
    do 
	{	
		do
			{
        		printf("Enter a number (10 digits) (or O to stop): ");
        		scanf("%ld", &n);
        	}
        while (n<1000000000 && n!=0);	
   	
        if (checkISBN(n) == 1) printf("This is a valid ISBN\n");
        else printf("This is not a valid ISBN\n");
        
    } 
	while (n != 0);
	if (n==0) printf("Have a nice day!\n");

    return 0;
}
int checkISBN(long int n)
{
    int j=0;
    int m[11], c[11];
    int k[9]={10,9,8,7,6,5,4,3,2};
    int i;
    int T;
    if (n>=1000000000)
    	{
    	for (i=10; i>0; i--)
        	{
           	 	m[i] = n%10;
            	n = n/10;
        	}
    	T = 0;
   		T = T + m[10];
    	for (i=1; i<10; i++)
        	{
            	c[i]=k[i-1]*m[i];
            	T = T +c[i];
        	}
    	if (T%11 == 0) j=1;
    	}	
    return j;
}

