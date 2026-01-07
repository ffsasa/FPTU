//write a function calculating sum of a sequence from 1 to n
//where integer n is inputted from keybroad

int Svip(int x){
	int i,S=0;
	for(i=1;i<=x;i++){
		
		S=S+i;
    }
	return S;
	
}

int main(){
	int x;
	printf("Nhap x: ");
	scanf("%d", &x);
	
	int Tong = Svip(x);
	printf("Tong = %d", Tong );
	
}
