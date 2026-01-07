#include<stdio.h>
#include<stdlib.h>
#include<math.h>
int choice()
{
	int choice ;
  	printf("\n1- Quadratic equation ");
  	printf("\n2- Bank deposit problem");
  	printf("\n3- Quit");
  	printf("\nChoose: ");
  	scanf("%d",&choice);
  	return choice;		
}
void function1()
{ 
	double a,b,c,delta,x1,x2;
   	printf("Enter the coefficients of the quadratic equation: ");
   	scanf("%lf%lf%lf", &a,&b,&c);
   	delta = b*b-4*a*c;
   	x1 = (-b+sqrt(delta))/(2*a);
   	x2 = (-b-sqrt(delta))/(2*a);
   	if (a==0)
   	{
   		if (b==0) 
   			{
   				if (c==0) printf("The equation has many infinitely solutions.\n");
   				else printf("The equation has no solution.\n");
			}
		else printf("The equation has a unique solution is x = %lf",-c/b);	
	}
	else 
	{
	if (delta==0) printf("The equation has a double solution x = %lf",-b/(2*a));
	else if (delta<0) printf("The equation has no solution.\n");
	else printf("The equation has 2 solutions x1 = %lf  ,x2 = %lf",x1,x2);
	}   	
}
void function2()
{
	double x , r ,P;
  	int y;
  	printf("Enter your deposit[a positive number]:  ");scanf("%lf",&x);
  	printf("\nEnter the yearly rate[0.0-1.0]:   "); scanf("%lf",&r);
  	printf("\nHow many years you want to deposit[year>0]:"); scanf("%d",&y);
  	P = x * pow((1+r),y);
  	printf("\nAmount at the %d year is %.0lf ",y,P);
}

int main()
{
	int userChoice;
  	do
 	{
	  userChoice = choice();
   	  switch(userChoice)
 	 { 
  		case 1: function1(); break;
  		case 2: function2(); break;
    	default: printf("Bye!\n");
     }
	}
  while(userChoice > 0 && userChoice < 3);
  fflush(stdin);	// delete excess memory
  getchar();
  return 0;
}
