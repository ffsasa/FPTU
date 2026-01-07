#include <stdio.h>
#include <math.h>

    int validDate( int d, int m, int y);

int main(){
 
    int d, m, y;
 
    printf("please input your day: ");
    scanf("%d %d %d", &d, &m, &y);
 
    if (validDate(d,m,y)){
        printf("it is a valid date\n");
    } else {
        printf("it is not a valid date\n");
    }
 
    getchar();
    return 0;
}

int validDate( int d, int m, int y){
    int maxd = 31;
    int val = 1;
 
    if (m==4 || m==6 || m==9 || m==11){
        maxd=30;
    } else if (m==2){
        if ( y%400==0 || ( y%4==0 && y%100!=0)){
            maxd=29;
        } else{
            maxd = 28;
        }
    }  
    if (d<1 || d>maxd || m<1 || m>12) val = 0;
    
	return val;
}
