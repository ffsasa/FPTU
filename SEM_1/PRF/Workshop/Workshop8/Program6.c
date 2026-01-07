#include <stdio.h>
#include <string.h>
#include <ctype.h>

#define MAX_ARRAY_VALUE	100

void print(char names[][41], char adds[][200], int * marks, int n)
{
	for (int i = 0; i < n; i++)
	{
		printf ("%-40s%-40s%4d\n", names[i], adds[i], marks[i]);
	}
}

void readFile(char *filename, char names[][41], char adds[][200], int *marks, int *pn)
{
	*pn = 0;
	
	FILE* f = fopen(filename, "r");
	
	if (f != NULL)
	{
		while (fscanf(f, "%40[^;];%40[^;];%d%*c", names[*pn], adds[*pn], &marks[*pn]) == 3)
		{
			(*pn)++;
		}
		
		fclose(f);
	}
}

void sort (char names[][41], char adds[][200], int *marks, int n)
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = n - 1; j > i; j--)
		{
			if (marks[j] > marks[j - 1])
			{
				char tName[41];
				strcpy(tName, names[j]);
				strcpy(names[j], names[j - 1]);
				strcpy(names[j - 1], tName);
				
				char tAdd[200];
				strcpy(tAdd, adds[j]);
				strcpy(adds[j], adds[j - 1]);
				strcpy(adds[j - 1], tAdd);
				
				int tMark = marks[j];
				marks[j] = marks[j - 1];
				marks[j - 1] = tMark;
			}
		}
	}
}

void writeFile(char* filename, char names[][41], char adds[][200], int * marks, int n)
{
	FILE* f = fopen(filename, "w");
	
	for (int i = 0; i < n; i++)
	{
		fprintf(f, "%s;%s;%d\n", names[i], adds[i], marks[i]);
	}
	
	fclose(f);
}

int main(int argc, char* argv[])
{
	char names[MAX_ARRAY_VALUE][41];
	char adds[MAX_ARRAY_VALUE][200];
	
	int marks[MAX_ARRAY_VALUE];
	
	int n = 0;
	
	readFile("students.txt", names, adds, marks, &n);
	
	sort(names, adds, marks, n);
	
	printf("Sorted List : \n\n");
	print(names, adds, marks, n);
	
	writeFile("students2.txt", names, adds, marks, n);
	
	printf("\nResult file : %s \n", "students2.txt");
	
	getchar();
	
	return 0;
}