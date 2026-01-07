#include<stdio.h>

int gcd( int a, int b)
{ while ( a!=b )
 if (a>b) a-=b;
 else b-=a;
 return a;
}
int lcm ( int a, int b)
{ return a*b/gcd(a,b);
}

int main(){
	int a,b,d,m;
do
{ printf("Nhap 2 so a va b: ");
  scanf("%d%d", &a, &b);
}
while ( a<=0 || b <=0);
d = gcd(a,b);
m = lcm(a,b);
printf("gcd = %d\n", d);
printf("lcm = %d", m);
}