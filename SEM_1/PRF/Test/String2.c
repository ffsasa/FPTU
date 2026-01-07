#include <stdio.h>
#include <string.h>
#include<ctype.h>
void countword(char string[]);
void Upperword(char string[]);
int main()
{

	// So sanh 2 string --> strcmp
	char string4[101]="helLo woRld Again";
	char string5[101]="hello world agAin";
	int check = strcmp(string4,string5);    //4=5=0; 4<5=-1; 4>5=1;
	printf("check = %d\n",check);
	
	char string6[101]="world";
	printf("find a substring \"world\" in string: %u\n", strstr(string5, string6));    ///Tim dia chi cua string6 trong string5
	printf("address of string5[6]: %u\n", &string5[6]);
	
	strrev(string4);
	printf("Viet nguoc lai:",string4);    //Viet nguoc lai day so
	
	countword(string4);
	
	Upperword(string4);
	
	return 0;	
}

void countword(char string[]){
	int count=0;
	int n=strlen(string);
	for(int i=0;i<n;i++){
		if((string[i]==' ' && string[i-1]!=' ')||(i==0 && string[i]!=' ')){
			count=count+1;
		}
	}
	printf("the number of the words is: %d\n", count);
}
	
void Upperword(char string[]){
	int n=strlen(string);
	for(int i=0;i<n;i++){
		if(string[i-1]==' '&&string[i]!=' '||i==0&&string[i]!=' '){
			string[i]=toupper(string[i]);
		}else{
			string[i]=tolower(string[i]);
		}
	}
	printf("%s\n",string);	
}
