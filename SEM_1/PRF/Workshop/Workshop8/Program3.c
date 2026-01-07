#include <stdio.h>
#include <string.h>
#include <ctype.h>

int exist(char* file_name)
{
	int existed = 0;
	
	FILE* f= fopen(file_name, "r");
	
	if (f != NULL)
	{
		existed = 1;
		
		fclose(f);
	}
	
	return existed;
}

int writeFile(char* file_name)
{
	if (exist(file_name) == 1)
	{
		printf("Write file:\n");
		
		printf("The file %s existed. Override it Y/N?:", file_name);
		
		if(toupper(getchar()) == 'N')
		{
			return 0;
		}
	}
		
	char line[201];
	
	int length = 0;
		
	FILE* f = fopen(file_name, "w");
	fflush(stdin);
		
	do
	{
		gets(line);
		length = strlen(line);
		
		if (length > 0)
		{
			fprintf(f, "%s\n", line);
		}
	} while (length > 0);
			
	fclose(f);
			
	return 1;
}

int printFile(char* file_name)
{
	char c = ' ';
	
	if (exist(file_name) == 0)
	{
		printf("The file %s does not exist.\n", file_name);
		
		return 0;
	}
	
	FILE* f = fopen(file_name, "r");
	char line[201];
	
	while (fscanf(f,"%[^\n]%*c", line) > 0)
	{
		puts(line);
	}
	
	fclose(f);
	
	return 1;
}

int main(int argc, char* argv[])
{
	char file_name[81];
	
	printf("Program for writing then reading a file\n");
	printf("Enter a file name: ");
	gets(file_name);
	
	int x = writeFile(file_name);
	
	if (x == 1)
	{
		printf("Data in the filename %s:\n", file_name);
		
		if (printFile(file_name) == 0)
		{
			printf("File error!\n");
		}
	}
	else if (x == 0)
	{
		printf("\nWriting file fail!\n");
	}
	else if (x == -1)
	{
		printf("The file %s does not exist.\n", file_name);
	}
	
	return 0;
}