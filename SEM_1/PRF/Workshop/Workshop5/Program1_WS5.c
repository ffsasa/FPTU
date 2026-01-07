#include<stdio.h>
#include<stdlib.h>
#include<math.h>      
int main()
{
 	int total, count , x , y ;
	  printf("             Dice Thrower\n ");
 	  printf("========================================\n ");
  	do
  	{ 
  		printf("Total sought : "); scanf("%d",&total);
  	} 
	while ( total < 2 || total > 12);
  	count = 0;		// initialize count
   	do
  	{ 
     x = (rand() % 6) + 1;	// use rand() function in stdlib.h
     y = (rand() % 6) + 1;
     count ++;	// change count
  	 printf("Result of throw %d: %d + %d\n",count , x , y);
  	} 
	while (x+y != total);
  	if ( x+y == total)
	  {
  		printf ("You got your total in %d throws!",count);
	  }
  return 0;
}
