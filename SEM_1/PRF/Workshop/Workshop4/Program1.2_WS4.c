/* 1.2 */
#include <stdio.h>
int main()
{
	char c1='A', c2='F';
	char *p1= &c1;
	char *p2= &c2;
	*p1 +=3;
	*p2 -=5;
	printf("%d",c1-c2);
	getchar ();
	return 0;
}