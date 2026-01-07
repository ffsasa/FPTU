/* 1.3 */
#include <stdio.h>
int main()
{
	double x =3.2, y=5.1;
	double *p1= &x;
	double *p2= &y;
	*p1 += 3 - 2*(*p2);
	*p2 -= 3*(*p1);
	printf("%lf",x+y);
	getchar();
	return 0;
}