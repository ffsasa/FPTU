#include<stdio.h>

int main(){
	
	int n,i,a;
	
	printf("Ban muon xem bang cuu chuong cua:");
	scanf("%d", &n);
	
	switch(n){
		case 2:
			for(i=1;i<=10;i++){
    	        a=n*i;
    	        printf("%d*%d=%d\n", n, i, a);
    	    }
            break;
        case 3:
        	for(i=1;i<=10;i++){
    	        a=n*i;
    	        printf("%d*%d=%d\n", n, i, a);
    	    }
            break;
        case 4:
        	for(i=1;i<=10;i++){
    	        a=n*i;
    	        printf("%d*%d=%d\n", n, i, a);
    	    }
            break;
        }

	
	return 0;
}  		
	
	

