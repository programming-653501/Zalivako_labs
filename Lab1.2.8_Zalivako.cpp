// ConsoleApplication2.cpp: определяет точку входа для консольного приложения.

#include <stdafx.h>
#include <conio.h>
#include <iostream>
using namespace std;
/*
int Sum(int n)
{
	int i, total = 0;
	for (i = 0; i < n; i++) {
		total += i;
		if (total > MAX) {
			printf(″Too large!\n″);
			exit(1);
		}
	}
	return total;
}
*/

int main()
{
	int n, first, last;

	printf("Please, enter 4-digit number: ");
	scanf_s("%d", &n);

    first = (int)n / 100;
	last = n % 100;
    end = last * 100 + first;
	printf("number %ld first - %ld, last - %ld", n, first, last);

	_getch();
	return 0;
}