#include<stdio.h>
#include<math.h>
#include<string.h>
#include<ctype.h>
#include <stdbool.h>

int checkListFull(int amount);
int checkListEmpty(int amount);
void addStudent(char id[][9], char name[][40], int yob[], double point[], int *amount);
void displayList(char id[][9], char name[][40], int yob[], double point[], int *amount);
void searchStudent(char id[][9], char name[][40], int yob[], double point[], int *amount);
void deleteStudent(char id[][9], char name[][40], int yob[], double point[], int *amount);

int main(){
	char id[100][9];
	char name[100][40];
	int yob[100];
	double point[100];
	
	int choice;
	char buffer;
	int amount=0;
do{  // OPTION TRONG MENU
	printf("\n===========================MENU==========================");
	printf("\n1 - Add a student                                Press 1.");
	printf("\n2 - Search a student                             Press 2.");
	printf("\n3 - Remove a student                             Press 3.");
    printf("\n4 - Print the list in ascending order            Press 4.");
    printf("\nOther - Quit");
    printf("\n");
	
	do{ // EP NGUOI DUNG NHAP SO NGUYEN
    	printf("\nPlease choose from 1 to 5: ");
        scanf("%d", &choice);
        scanf("%c", &buffer);
		fflush(stdin);
		if(buffer != 10) printf("\nPlease enter a number.");
	}while(buffer != 10);
	
	switch(choice){
		case 1:{
				if(checkListFull(amount) == 1){
					printf("----------------\n");
					printf("The virtual library is full and no space for adding books.\n");
				}else{
					addStudent(id, name, yob, point, &amount);
				}
				break;
			}	
		case 2:{
				if(checkListEmpty(amount) == 1){
					printf("The virtual library is empty!\n");
				}else{
					printf("----------------\n");
					searchStudent(id, name, yob, point, &amount);
				}
				break;
			}
		case 3:{
				if(checkListEmpty(amount) == 1){
					printf("----------------\n");
					printf("The virtual library is empty!\n");
				}else{
					deleteStudent(id, name, yob, point, &amount);
				}
				break;
			}
		case 4:{
				if(checkListEmpty(amount) == 1){
					printf("----------------\n");
					printf("The virtual library is empty!\n");
				}else{
					displayList(id, name, yob, point, &amount);
				}
				break;
			}
		default:{
				printf("\n=============== The program is finished ===============\n");
				printf("                      Goodbye!");
				break;
			}
		}
	}while(choice>=1&&choice<=4);
}

int checkListFull(int amount){
	return amount == 100? 1 : 0;
}

int checkListEmpty(int amount){
	return amount == 0? 1 : 0;
}

void addStudent(char id[][9], char name[][40], int yob[], double point[], int *amount){
	printf("----------------\n");
	printf("Enter the student's id': ");
	gets(id[*amount]);
	fflush(stdin);
	printf("Enter the student's name': ");
	gets(name[*amount]);
	fflush(stdin);
	printf("Enter the yob of the student: ");
	scanf("%d", &yob[*amount]);
	fflush(stdin);
	printf("Enter the student's point': ");
	scanf("%lf", &point[*amount]);
	fflush(stdin);
	printf("Added!\n");
	(*amount)++;
}

void displayList(char id[][9], char name[][40], int yob[], double point[], int *amount){
	printf("----------------\n");
	printf("STUDENT LIST\n");
	int i;
	for(i = 0; i < *amount; i++){
		printf("----------------\n");
		printf("Name of the book: %s\n", name[i]);
		printf("ID: %s\n", id[i]);
		printf("Yob: %d\n", yob[i]);
		printf("Point: %lf\n", point[i]);
	}
}


void searchStudent(char id[][9], char name[][40], int yob[], double point[], int *amount){
	char searchStudent[50];
	printf("Please enter the NAME of the Student to search: ");
	fflush(stdin);
	gets(searchStudent);
	strupr(searchStudent);
	int i;
	bool check = false;
	for(i = 0; i < *amount; i++){
		char temp[50];
		strcpy(temp, name[i]);
		strupr(temp);
		if(strcmp(searchStudent, temp) == 0) // if searchBook = nameOfBook[i]
		{
			//print the information of the book need to search
			printf("----------------\n");
			printf("Name of the book: %s\n", name[i]);
			printf("ID: %s\n", id[i]);
			printf("Yob: %d\n", yob[i]);
			printf("Point: %lf\n", point[i]);
			// Mark the book was found
			check = true;
			i = *amount;
		}	
	}
	if(check == false){
		printf("----NOT FOUND!---\n");
	}	
}

void deleteStudent(char id[][9], char name[][40], int yob[], double point[], int *amount){
	char studentDelete[50];
	printf("Please enter the NAME of student needs to delete: ");
	gets(studentDelete);
	strupr(studentDelete);
	int i;
	bool check = false;
	for(i = (*amount) - 1 ; i >= 0; i--){
		char temp[50];
		strcpy(temp, name[i]);
		strupr(temp);
		if(strcmp(studentDelete, temp) == 0){
			int j;
			check = true;
			for(j = i; j < *amount; j++){
				strcpy(id[j], id[j + 1]);
				strcpy(name[j], name[j + 1]);
				yob[j] = yob[j + 1];
				point[j] = point[j + 1];
			}
			(*amount)--;
		}
	}
	if(check == false){
		printf("NOT FOUND!\n");
	}else{
		printf("---Deleted!---\n");
	}	
}


