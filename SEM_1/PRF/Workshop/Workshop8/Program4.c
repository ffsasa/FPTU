#include <stdio.h>

void fileToArray(char* fname, int *a, int *pn)
{
	FILE* f = fopen(fname, "r");
	fscanf(f, "%d", pn);
	
	for (int i = 0; i <= *pn; i++)
	{
		fscanf(f, "%d", &a[i]);
	}
		
	fclose(f);
}

void asc_sort(int* a, int n)
{
	int i, j, t;
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = n - 1; j > i; j--)
		{
			if (a[j] < a[j - 1])
			{
				t = a[j];
				a[j] = a[j - 1];
				a[j - 1] = t;
			}
		}
	}
}

int print(int* a, int n)
{
	for (int i = 0; i < n; i++)
	{
		printf("%d ", a[i]);
	}
}

int printToFile(char* fname, int* a, int n)
{
	FILE* f = fopen(fname, "w");
	fprintf(f, "%d ", n);
	
	for (int i = 0; i < n; i++)
	{
		fprintf(f, "%d ", a[i]);
	}
	
	fclose(f);
}

int main(int argc, char* argv[])
{
	int a[200];
	int n = 0;
	
	fileToArray("array1.txt", a, &n);
	
	asc_sort(a, n);
	
	print(a, n);
	
	printToFile("array2.txt", a, n);
	
	getchar();
	
	return 0;
}