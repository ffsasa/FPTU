#include<stdio.h>

void printMinMaxDigits(int n)
{ int remainder; 
  int min, max; 
  remainder = n%10; 
  min=max=remainder; 
 while (n>0) 
 { remainder = n%10; 
  n=n/10;
  if (min > remainder) min=remainder; 
  if (max < remainder) max=remainder;
 }
  printf("Min = %d\n", min);
  printf("Max = %d\n", max);
}

int main(){
	int n;
	do{
	printf("Enter a number: ");
	scanf("%d", &n);
	printMinMaxDigits(n);
}while(n<0);
}