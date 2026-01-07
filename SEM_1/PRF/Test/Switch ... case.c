#include<stdio.h>

int main(){
	int x=2;
	// xem link (https://deviot.vn/tutorials/c-co-ban.78025672/cau-lenh-switch-case.50619709) de hieu cach dung case
	// case thuc ra la ma thuc hien cau lenh.
	switch (x){
		case 1:
			printf("Thuc hien cong viec 1\n");
			break;
		case 2:
			printf("Thuc hien cong viec 2\n");
			break;
		case 3: 
		    printf("Thuc hien cong viec 3\n");
		    break;
		default:
			printf("Thuc hien cong viec mac dinh\n");
			break;
	}
    return 0;
}
