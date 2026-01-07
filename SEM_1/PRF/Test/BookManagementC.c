// Assignment - This program to manage books in a library

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <ctype.h>
#define MAXN 100

int Menu();
void addBook(char nameOfBook[][50], char Author[][20], short Published[], 
			 char Category[][30], char Language[][15], double Price[], int *amount);
int checkLibraryFull(int amount);
int checkLibraryEmpty(int amount);
void swap(char nameOfBook[][50], char Author[][20], short Published[], 
		  char Category[][30], char Language[][15], double Price[], int i, int j);
void displayAllBooks(char nameOfBook[][50], char Author[][20], short Published[], 
				char Category[][30], char Language[][15], double Price[], int *amount);
void searchBook(char nameOfBook[][50], char Author[][20], short Published[], 
				char Category[][30], char Language[][15], double Price[], int *amount);
void deleteBook(char nameOfBook[][50], char Author[][20], short Published[], 
				char Category[][30], char Language[][15], double Price[], int *amount);
void deleteAllBooks(char nameOfBook[][50], char Author[][20], short Published[], 
					char Category[][30], char Language[][15], double Price[], int *amount);
void sortBooks(char nameOfBook[][50], char Author[][20], short Published[], 
			   char Category[][30], char Language[][15], double Price[], int *amount);
void saveDataInText(char nameOfBook[][50], char Author[][20], short Published[], 
				    char Category[][30], char Language[][15], double Price[], int *amount);
				  								
int main(){
	int amount = 0, userChoice;
	char nameOfBook[MAXN][50], Author[MAXN][20], Category[MAXN][30], Language[MAXN][15];
	short Published[MAXN];
	double Price[MAXN];
	printf("------------The program to manage books------------\n");	
	
	do{
		userChoice = Menu();
		switch(userChoice){
			case 1:{
				if(checkLibraryFull(amount) == 1){
					printf("----------------\n");
					printf("The virtual library is full and no space for adding books.\n");
				}else{
					addBook(nameOfBook, Author, Published, Category, Language, Price, &amount);
				}
				break;
			}	
			case 2:{
				if(checkLibraryEmpty(amount) == 1){
					printf("The virtual library is empty!\n");
				}else{
					printf("----------------\n");
					sortBooks(nameOfBook, Author, Published, Category, Language, Price, &amount);
				}				
				break;
			}	
			case 3:{
				if(checkLibraryEmpty(amount) == 1){
					printf("The virtual library is empty!\n");
				}else{
					printf("----------------\n");
					searchBook(nameOfBook, Author, Published, Category, Language, Price, &amount);
				}
				break;
			}
			case 4:{
				if(checkLibraryEmpty(amount) == 1){
					printf("----------------\n");
					printf("The virtual library is empty!\n");
				}else{
					deleteBook(nameOfBook, Author, Published, Category, Language, Price, &amount);
				}
				break;
			}
			case 5:{
				if(checkLibraryEmpty(amount) == 1){
					printf("----------------\n");
					printf("The virtual library is empty!\n");
				}else{
					deleteAllBooks(nameOfBook, Author, Published, Category, Language, Price, &amount);
				}
				break;
			}
			case 6:{
				if(checkLibraryEmpty(amount) == 1){
					printf("----------------\n");
					printf("The virtual library is empty!\n");
				}else{
					displayAllBooks(nameOfBook, Author, Published, Category, Language, Price, &amount);
				}
				break;
			}
			case 7:{
				saveDataInText(nameOfBook, Author, Published, Category, Language, Price, &amount);
				break;
			}
			default:{
				printf("\n=============== The program is finished ===============\n");
				printf("                      Goodbye!");
				break;
			}
			
		}
	}while(userChoice >= 1 && userChoice <= 7);
	return 0;	
}

int Menu(){
	printf("         -------------- == --------------");
	printf("\nSelections for you:\n");
	printf("1 - Add a new book to the virtual library.\n");
	printf("2 - Sort the books in virtual library for each infomation field.\n");
	printf("3 - Looking for a book in virtual library.\n");
	printf("4 - Delete a book in the virtual library.\n");
	printf("5 - Delete all books in the virtual library.\n");
	printf("6 - Displaying all of books in the virtual library.\n");
	printf("7 - Compiled to text file.\n");
	printf("Others - Exit the progam.\n");
	printf("Please enter your choice: ");
	int choice=0;
	scanf("%d", &choice);
	fflush(stdin);	
	return choice;
}

int checkLibraryFull(int amount){
	return amount == MAXN? 1 : 0;
}

int checkLibraryEmpty(int amount){
	return amount == 0? 1 : 0;
}

void addBook(char nameOfBook[][50], char Author[][20], short Published[], 
			 char Category[][30], char Language[][15], double Price[], int *amount){
	printf("----------------\n");
	printf("Enter the name of the book: ");
	gets(nameOfBook[*amount]);
	fflush(stdin);
	printf("Enter the name of the Author: ");
	gets(Author[*amount]);
	fflush(stdin);
	printf("Enter the published year of the book: ");
	scanf("%d", &Published[*amount]);
	fflush(stdin);
	printf("Enter the category: ");
	gets(Category[*amount]);
	fflush(stdin);
	printf("Enter the Language: ");
	gets(Language[*amount]);
	fflush(stdin);
	printf("Enter the price: ");
	scanf("%lf", &Price[*amount]);
	fflush(stdin);
	printf("Added!\n");
	(*amount)++;
}

void displayAllBooks(char nameOfBook[][50], char Author[][20], short Published[], 
					char Category[][30], char Language[][15], double Price[], int *amount){
	printf("----------------\n");
	printf("LIST OF BOOK IN THE VIRTUAL LIBRARY\n");
	int i;
	for(i = 0; i < *amount; i++){
		printf("----------------\n");
		printf("Name of the book: %s\n", nameOfBook[i]);
		printf("Author: %s\n", Author[i]);
		printf("Published: %d\n", Published[i]);
		printf("Category: %s\n", Category[i]);
		printf("Language: %s\n", Language[i]);
		printf("Price: %.3lf\n", Price[i]);
	}
}

void swap(char nameOfBook[][50], char Author[][20], short Published[], 
		  char Category[][30], char Language[][15], double Price[], int i, int j){
	//change the order of books
	char temp[50];
	strcpy(temp, nameOfBook[i]);
	strcpy(nameOfBook[i], nameOfBook[j]);
	strcpy(nameOfBook[j], temp);
	char temp1[20];
	strcpy(temp1, Author[i]);
	strcpy(Author[i], Author[j]);
	strcpy(Author[j], temp1);
	short temp2 = Published[i];
	Published[i] = Published[j];
	Published[j] = temp2;
	char temp3[30];
	strcpy(temp3, Category[i]);
	strcpy(Category[i], Category[j]);
	strcpy(Category[j], temp3);
	char temp4[15];
	strcpy(temp4, Language[i]);
	strcpy(Language[i], Language[j]);
	strcpy(Language[j], temp4);
	double temp5 = Price[i];
	Price[i] = Price[j];
	Price[j] = temp5;	
}

void sortBooks(char nameOfBook[][50], char Author[][20], short Published[], 
			   char Category[][30], char Language[][15], double Price[], int *amount){
	int choice;
	printf("Please select the information field need to sort!\n");
	do{
		printf("1 - Sort name of Books(Follow alphabet)!\n");
		printf("2 - Sort published year!\n");
		printf("3 - Sort price!\n");
		printf("Enter selection:");
		scanf("%d", &choice);
		if(choice < 1 || choice > 3){
			printf("Please choose correctly the selections above!\n");
		}
	}while(choice < 1 || choice > 3);
	int i, j;
	if(choice == 1){
		//Sort the name of the books
		for(i = 0; i < *amount - 1; i++){
			for(j = i + 1; j < *amount; j++){
				//upper character to compare
				if(toupper(nameOfBook[i][0]) > toupper(nameOfBook[j][0])){
					swap(nameOfBook, Author, Published, Category, Language, Price, i, j);
				}
			}
		}
	}
	if(choice == 2){
		//Sort published year
		for(i = 0; i < *amount - 1; i++){
			for(j = i + 1; j < *amount; j++){
				if(Published[i] > Published[j]){
					swap(nameOfBook, Author, Published, Category, Language, Price, i, j);
				}
			}
		}		
	}
	if(choice == 3){
		//Sort books prices in increasing sequence
		for(i = 0; i < *amount - 1; i++){
			for(j = i + 1; j < *amount; j++){
				if(Price[i] > Price[j]){
					swap(nameOfBook, Author, Published, Category, Language, Price, i, j);
				}
			}
		}	
	}
	printf("---Sorted!---\n");
}

void searchBook(char nameOfBook[][50], char Author[][20], short Published[], 
				char Category[][30], char Language[][15], double Price[], int *amount){
	char searchBook[50];
	printf("Please enter the name of the Book to search: ");
	fflush(stdin);
	gets(searchBook);
	strupr(searchBook);
	int i;
	bool check = false;
	for(i = 0; i < *amount; i++){
		char temp[50];
		strcpy(temp, nameOfBook[i]);
		strupr(temp);
		if(strcmp(searchBook, temp) == 0) // if searchBook = nameOfBook[i]
		{
			//print the information of the book need to search
			printf("----------------\n");
			printf("Name of the book: %s\n", nameOfBook[i]);
			printf("Author: %s\n", Author[i]);
			printf("Published: %d\n", Published[i]);
			printf("Category: %s\n", Category[i]);
			printf("Language: %s\n", Language[i]);
			printf("Price: %.3lf\n", Price[i]);
			// Mark the book was found
			check = true;
			i = *amount;
		}	
	}
	if(check == false){
		printf("----NOT FOUND!---\n");
	}	
}

void deleteBook(char nameOfBook[][50], char Author[][20], short Published[], 
				char Category[][30], char Language[][15], double Price[], int *amount){
	char bookDelete[50];
	printf("Please enter the name of the book needs to delete: ");
	gets(bookDelete);
	strupr(bookDelete);
	int i;
	bool check = false;
	for(i = (*amount) - 1 ; i >= 0; i--){
		char temp[50];
		strcpy(temp, nameOfBook[i]);
		strupr(temp);
		if(strcmp(bookDelete, temp) == 0){
			int j;
			check = true;
			for(j = i; j < *amount; j++){
				strcpy(nameOfBook[j], nameOfBook[j + 1]);
				strcpy(Author[j], Author[j + 1]);
				Published[j] = Published[j + 1];
				strcpy(Category[j], Category[j + 1]);
				strcpy(Language[j], Language[j + 1]);
				Price[j] = Price[j + 1];
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

void deleteAllBooks(char nameOfBook[][50], char Author[][20], short Published[], 
					char Category[][30], char Language[][15], double Price[], int *amount){
	int i;
	for(i = 0; i < *amount; i++){
		strcpy(nameOfBook[i], "\0");
		strcpy(Author[i], "\0");
		Published[i] = '\0';
		strcpy(Category[i], "\0");
		strcpy(Language[i], "\0");
		Price[i] = '\0';
	}
	(*amount) = 0;
	printf("---Deleted all book in the virtual library!---\n");
}

//Function to write data into a text file  
void saveDataInText(char nameOfBook[][50], char Author[][20], short Published[], 
				    char Category[][30], char Language[][15], double Price[], int *amount){
	FILE *f;
	f = fopen("DataOfBookManagement.txt", "w+");
	if(f == NULL){
		printf("Error! Can not open file!\n");
		return;
	}
	int i;
	fprintf(f, "LIST OF BOOK IN THE VIRTUAL LIBRARY\n");
	for(i = 0; i < *amount; i++){
		fprintf(f, "----------------\n");
		fprintf(f, "Name of the book: %s\n", nameOfBook[i]);
		fprintf(f, "Author: %s\n", Author[i]);
		fprintf(f, "Published: %d\n", Published[i]);
		fprintf(f, "Category: %s\n", Category[i]);
		fprintf(f, "Language: %s\n", Language[i]);
		fprintf(f, "Price: %.3lf\n", Price[i]);
	}
	printf("---Done!---\n");
	fclose(f);
}
