#include<stdio.h>
#include<stdlib.h>
int choice()
{ 
	int choice ;
	printf("\n1- Processing date data");
 	printf("\n2- Character data");
  	printf("\n3- Quit");
  	printf("\nChoose: ");
  	scanf("%d",&choice);
  	fflush(stdin);
  	return choice;
}

int validDate (int d, int m, int y)
{
	int maxd=31;
	if(d <1 || d>31 || m<1 || m >12) return 0 ;
	if( m == 4 || m == 6 || m == 9 || m == 11) maxd = 30;
	else if(m==2) 
	{
		if ( y%400==0 || y%4==0 && y%100!=0 ) maxd=29;
		else maxd=28;
	}
return d<=maxd;
}

void function1()
{
 	int d , m , y;
  	printf("Enter the day: " ); scanf("%d", &d);
  	printf("Enter the month:"); scanf("%d", &m);
  	printf("Enter the year: "); scanf("%d", &y);
    if (validDate(d, m, y)==1) 
	{
		printf ("The date of %d/%d/%d is a valid date!\n", d, m ,y);
	}
	else
	{
		printf("The date of %d/%d/%d is not a valid date!\n", d, m ,y);
	}
}
void printAscii(char c1 , char c2)
{ 
	char c;
	printf("Enter 2 characters contiguously: ");
	scanf("%c %c",&c1, &c2);
	if (c1 > c2)
	{ 
	  c=c1 ; 
	  c1=c2 ;
	  c2=c ;
    }
  	for ( c=c1 ; c<= c2; c++)
  	printf("%c: %3d, %3x\n",c,c,c);
}


int main()
{ 	
	char c1,c2;
	int userChoice;
	do
 	{ 
	 userChoice = choice();
 	 switch(userChoice)
 		{
		  	case 1: function1(); break;
   			case 2: printAscii(c1,c2); break;
   			default: printf("Bye!\n");
		}
 	}
 while(userChoice > 0 && userChoice < 3); 
 fflush(stdin);
 getchar();
 return 0;
}
