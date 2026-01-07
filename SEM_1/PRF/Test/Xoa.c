#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <ctype.h>
void chuanhoachuoi(char[]);
void main()
{
    char a[100];
   printf("Nhap vao chuoi:");
   gets(a);
   chuanhoachuoi(a);
   printf("%s",a);
   getch();
}
void chuanhoachuoi(char a[])
{
   int i,j;
   j=strlen(a);
   printf("\nChuan duoc chuan hoa la:");
   for(i=0;i<j;i++)
    if(a[i]>=65&&a[i]<=90)  
        a[i]=a[i]+32;        
   for(i=0;i<j;i++)
    if(a[i]==' '&&a[i+1]==' ')  
        strcpy(&a[i],&a[i+1]);
   for(i=0;i<j;i++)
    if(a[i]==' ')
        a[i+1]=toupper(a[i+1]);  
         a[0]=a[0]-32;           
   for(i=0;i<j;i++)
    if((a[i]<65&&a[i]!=32)||a[i]>122||(a[i]>90&&a[i]<97)) 
        strcpy(&a[i],&a[i+1]);
}