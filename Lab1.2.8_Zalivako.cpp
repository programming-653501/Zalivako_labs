// Lab1.2.8_Zalivako.cpp: определяет точку входа для консольного приложения.
#include <stdio.h>
#include "stdafx.h"
#include <conio.h>

int main()
{
	int n, first, last, end;

	printf("Please, enter 4-digit number: ");
	scanf_s("%ld", &n);
	if (n < 1000 || n>9999)
	{
		while (n < 1000 || n>9999)
		{
			printf("Wrong number!!! Please, enter 4-digit number again: ");
			scanf_s("%ld", &n);
		}
	}
	first = (int)n / 100;
	last = n % 100;
	end = last * 100 + first;
	printf("New number: %d ", end);
	_getch();
	return 0;
}