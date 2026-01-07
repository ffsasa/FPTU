/* 1.1 */
#include <stdio.h>
int main()
{
	int n=7, m=6;
	int*pn = &n;
	int*pm = &m;
	*pn = *pm + 2*m - 3*n;
	*pm -= *pn;
	printf("%d", m+n);		// m=9 ; n=-3
	getchar();
	return 0;
}