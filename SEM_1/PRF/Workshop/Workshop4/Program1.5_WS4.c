#include <stdio.h>

int main()
{
	int n = 260,  *p=&n;
	printf("n=%d\n",n);
	char *pp=(char*)p;
	*pp=0;
	printf("n=%d\n",n);
	getchar();
}