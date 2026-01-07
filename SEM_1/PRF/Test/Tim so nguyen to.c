#include <stdio.h>
#include <math.h>

int prime(int n);

int main(){
    int n;
 
    printf("please input your number: ");
    scanf("%d", &n);
 
    if (prime(n)){
        printf("%d is a prime\n", n);
    } else {
        printf("%d is not a prime\n", n);
    }
 
 getchar();
 return 0;
}

int prime(int n){
    int m = sqrt(n);
    int i;
    int flag = 0, result = 1;
 
    for (i=2; i<=m && flag == 0; i++){
        if (n%i == 0){
            result = 0;
            flag = 1;
        }
    }
 return result;
}
