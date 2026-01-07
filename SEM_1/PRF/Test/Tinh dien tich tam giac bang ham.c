//write a function of calculating the area of a triangles
//with given 3 sides
//p = (a+b+c)/2
//S = sqrt(p*(p-a)*(p-b)*(p-c))

#include<stdio.h>
#include<math.h>

float Tinh(float a, float b, float c){
	float p = (a+b+c)/2;
	float s = sqrt(p*(p-a)*(p-b)*(p-c));
	
	return s;
	}
	
int main(){
    
	float a,b,c;
	scanf("%f%f%f", &a, &b, &c); 
	if((a>=b+c) && (b>=a+c) && (c>=a+b)){
		printf("Day khong phai 3 canh cua tam giac");
		}else{
		
	float K = Tinh(a, b, c);
	
	printf("Dien tich cua tam giac la: %f", K);}
	
	return 0;
}
	
