#include <stdio.h>

void processFile(char* fname, int* count, double* sum)
{
	FILE* f = fopen(fname, "r");
	
	*count = 0;
	*sum = 0;
	
	double x;
	
	while (fscanf(f, "%lf", &x) == 1)
	{
		(*count)++;
		(*sum) += x;
	}
	
	fclose(f);
}

int main(int argc, char* argv[])
{
	int count = 0;
	double sum = 0;
	
	processFile("array3.txt", &count, &sum);
	
	printf("Number of value in the file: %d\n", count);
	printf("Average of value in the file: %lf\n", sum/count);
	
	getchar();
	
	return 0;
}