#include<stdio.h>
#include<string.h>

void Swap(char str1[],char str2[]);
void sort(char strF[][20], char strL[][30]);
int main(){
	int matrix[10][20];
// 10 La so hang, 20 la so cot

	int matrix2[3][4]={{1,2,3,4},{5,6,7,8},{9,10,11,12}};
	for(int i=0;i<3;i++){
		for(int j=0;j<4;j++){
			printf("%d ",matrix2[i][j]);
		}
		printf("\n");
	}

	
//Mang 2 chieu int
	int matrix3[][4]={{1,2,3,4},{5,6,7,8},{9,10,11,12}};
	printf("%d\n", matrix3[0][0]);
	
//Mang 2 chieu char
	char name[][30]={"Nguyen Van A","Doan Thi B", "Huynh Tan C"};
	for(int i=0;i<3;i++){
		printf("%s\n",name[i]);
	}
	
	printf("=============\n");
	char firstNames[10][20]={"A","B","C"};
	char lastNames[10][30]={"Nguyen Van","Doan Thi", "Huynh Tan"};
	for(int i=0;i<3;i++){
		printf("%s %s\n",firstNames[i],lastNames[i]);
	}
	
//Add phan tu moi vao mang 2 chieu
	printf("=================\n");
	strcpy(firstNames[3],"D");
	strcpy(lastNames[3],"Le Thi");
	
	for(int i=0;i<4;i++){
	printf("%s %s\n",firstNames[i],lastNames[i]);
	}

//Swap 2 mang 2 chieu	
	printf("===================\n");
	char temp[30];
	strcpy(temp,firstNames[1]);
	strcpy(firstNames[1],firstNames[2]);
	strcpy(firstNames[2],temp);
	
	Swap(lastNames[1],lastNames[2]);
	
	for(int i=0;i<4;i++){
	printf("%s %s\n",firstNames[i],lastNames[i]);
	}
	
//Sort mang 2 chieu
	printf("=================\n");
//	for(int i=0;i<4;i++){
//		for(int j=i+1;j<4;j++){
//			if(strcmp(firstNames[j],firstNames[i])<0){
//				Swap(firstNames[i],firstNames[j]);
//				Swap(lastNames[i],lastNames[j]);
//			}
//		}
//	}
	sort (firstNames,lastNames);
	for(int i=0;i<4;i++){
	printf("%s %s\n",firstNames[i],lastNames[i]);
	}


// Nhap du lieu vao mang 2 chieu
	int matr[2][3];
	printf("Please input your matrix:\n");
	for (int i=0;i<2;i++){
			for (int j=0;j<3;j++){
					scanf("%d",&matr[i][j]);
		}
	}		
//In mang 2 chieu
	printf("Your matrix is:\n");
	for (int i=0;i<3;i++){
			for (int j=0;j<4;j++){
					printf("%d \t",matrix2[i][j]);
			}
			printf("\n");	
		}		

// Nhap chuoi ky tu vao mang 2 chieu
	char fullNames[4][50];
	printf("Please input several names:\n");
	for(int i=0;i<4;i++){
			gets(fullNames[i]);
		}	
//In ra chuoi ky tu		
	printf("The names you provided are:\n");
		for(int i=0;i<4;i++){
			printf("%s\n",fullNames[i]);
		}



}



void Swap(char str1[],char str2[]){
	char temp[30];
	strcpy(temp,str1);
	strcpy(str1,str2);
	strcpy(str2,temp);
}

void sort(char strF[][20], char strL[][30]){
	for(int i=0;i<4;i++){
		for(int j=i+1;j<4;j++){
			if(strcmp(strF[j],strF[i])<0){
				Swap(strF[i],strF[j]);
				Swap(strL[i],strL[j]);
			}
		}
	}
}