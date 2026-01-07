#include<conio.h>
#include<stdio.h>
#include<string.h>
int xoa(char *a, int q)
{
            int n = strlen(a), i;
            for (i = q; i <= n; i++)
            {
                        a[i] = a[i + 1];
            }
            n--;
            return 0;
}
int xoakhoangtrang(char *a)
{
            int i, n=strlen(a);
            for (i = 0; i < n; i++)
            {
                        if (a[0] == 32)
                        {
                                    xoa(a, 0);
                                    n--;
                        }
                        if (a[n-1] == 32)
                        {
                                    xoa(a, n-1);
                                    n--;
                        }
                        if (a[i] == 32 && a[i + 1] == 32)
                        {
                                    xoa(a, i);
                                    i--;
                                    n--;
                        }
            }
            return 0;
}
int main()
{
            char chuoi[100];
            printf("xin moi ban nhap chuoi : ");
            fflush(stdin);
            gets(chuoi);
            xoakhoangtrang(chuoi);
            printf("%s", chuoi);
            getch();
            return 0;
}