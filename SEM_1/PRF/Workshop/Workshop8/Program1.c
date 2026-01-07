#include <stdio.h>
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
		printf("The file %s existed. Override it Y/N?:", file_name);
		
		if(toupper(getchar()) == 'N')
		{
			return 0;
		}
	}
	
	FILE* f = fopen(file_name, "w");
	fflush(stdin);
	
	char c = -1;
	
	do
	{
		c = getchar();
		
		if (c != -1)
		{
			fputc(c, f);
		}
		
	} while (c != -1);
	
	fclose(f);
	
	return 1;
}

int main(int argc, char* argv[])
{
	if (argc != 2)
	{
		printf("Syntax: Workshop08_Problem_1 filename\n");
	}
	else if (writeFile(argv[1]) == 1)
	{
		printf("Writting the file %s: done\n", argv[1]);
	}
	else
	{
		printf("Can not write the file %s\n", argv[1]);
	}
	
	return 0;
}