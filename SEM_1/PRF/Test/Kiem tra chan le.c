//write a function to check whether a nuber is odd or even
//test the function with the date inputted form keyboard

void chia(int x){
    int a=x%2;
	if(x==0){printf("Day la so 0");
	
	}else if(a==1){printf("Day la so le");
	}else printf("Day la so chan");
}
	
int main(){
	
	int x;
	printf("Nhap so chan kiem tra: ");
	scanf("%d", &x);
	
	chia(x);
	
	
	
}
	
	
	
	
	
