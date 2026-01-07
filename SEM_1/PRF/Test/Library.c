#include<stdio.h>
#include<stdlib.h>
#include<time.h>

//int main(){
//	int a=-5;
//	int b=abs(a);
	                                          //Ham gia tri tuyet doi abs
//	printf("b = %d", b);

//	return 0;
//}

//int main()
//{   int i; int a=5, b=50;
//    double x=3.5, y= 20.8;
//    printf("10 Hardware random integers:\n");                         Random hardware
//    for (i=0;i<10; i++) printf("%d ", rand());    
//  
//  
//    srand(time(NULL)); 
//    printf("\n\n10 Software random integers:\n");                     Random Software
//    for (i=0;i<10; i++) printf("%d ", rand());
//     
//	printf("\n\n10 random integers between:%d...%d\n", a, b);           Random trong khoang a-b
//    for (i=0;i<10; i++) printf("%d ", a + rand()% (b-a));
//    
//	printf("\n\n5 random double between:%lf...%lf\n", x, y);
//    for (i=0;i<5; i++) printf("%lf ", x + (double)rand()/RAND_MAX*(y-x));         Random so thuc
//    getchar();   
//}


//int main(){
//	
//	int s=0;
//	time_t t1, t2;                           Khai bao bien thoi gian thuc
//	long int detal_t;
//	
//	t1=time(NULL);                
//	for(int i = 1; i<1000000000; i++){
//		s+=i;
//	}
//	t2=time(NULL);
//	detal_t=difftime(t2,t1);                 difftime(time1, time2) ham tinh chenh lech cua t1 va t2
//	printf("detal_t=%ld", detal_t);
//
//	return 0;
//}



int main(){
	char letter1, letter2;
	
	printf("Nhap ky tu vao letter 1: ");
	letter1=getchar();
	printf("Ky tu da nhap vao letter 1 la: %c\n", letter1);
	
	fflush(stdin);
	
	printf("Nhap ky tu vao letter 2: ");
	scanf("%c", &letter2);
	printf("Ky tu da nhap vao letter 2 la: %c\n", letter2);
		
	return 0;
}
	
