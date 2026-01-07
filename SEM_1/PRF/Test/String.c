#include<stdio.h>
#include<string.h>

int main(){
	
//	char string[100];
//	
//	char string1[100]={'H','e','l','l','o',' ','w','o','r','l','d'};
//	printf("the string is: %s\n", string1);


//	char string2[100]="Hello world";
//	printf("the string is: %s\n", string2);


////	printf("please inout a string:");
////	scanf("%s", string);
////	printf("%s", string);


//	printf("please inout a string:");
//	scanf("%[^\n]", string);
//	printf("%s\n", string);


//	getchar();
//	printf("please input a string: ");
//	gets(string);
//	printf("Your input is: %s\n", string);


	printf("the number of the letters in a string: %d\n", strlen(string));
	
	char string3[101]="This is the third test!";
	printf("Your input is: %s\n", string3);
	printf("Your string after using strupr: %s\n", strupr(string3));
	printf("Your string after using strlwe: %s\n", strlwr(string3));

	char string4[101];
	strcpy(string4, string3);
	printf("Copied string is: %s\n", string4);
	
	return 0;
}