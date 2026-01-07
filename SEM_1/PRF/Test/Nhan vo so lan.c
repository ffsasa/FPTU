#include<stdio.h>
#include<conio.h>

int main(){
	
	char k;
	printf("Nhap vao mot ky tu: ");
	//Neu dung scanf("%c, &k); thi se du ky tu Enter o sau .
	
	k = getch();
	
	while (k=='y'){
		
		int n;
		printf("Nhap vao mot so (duong va nho hon 10):");
		scanf("%d", &n);
		
		int i=1;
		while (i<=10){
			printf("%dx%d=%d\n", n, i, i*n);
			i++;
		}
		
		printf("Nhap vao mot ky tu:");
		k = getch();
}

return 0;
}
