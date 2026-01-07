#include <stdio.h>

int getRelPos ( double x, double y, double r);

int main(){
    double x, y, r;
    int chk;
    
	printf("please input coordinator of the point: ");
    scanf("%lf %lf", &x, &y);
 
    do {
        printf("please input radius of the circle: ");
        scanf("%lf", &r);
    } while (r<0);
 
    chk = getRelPos(x,y,r);
    if (chk == 1){
        printf("the point p is inside the circle\n");
    } else if (chk == 0){
        printf("the point p is on the circle\n");
    } else {
        printf("the point p is out of the circle\n");
    }
 getchar();
 return 0;
}
int getRelPos ( double x, double y, double r){
    int inside;
    double d2=x*x + y*y;
    double r2= r*r;
    if (d2<r2){
        inside = 1;
    } else if (d2==r2){
        inside = 0;
    } else {
        inside = -1;
    }
 return inside;
}
