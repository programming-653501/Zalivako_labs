// Lab5.1.10_Zalivako.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <stdio.h> 
#include<iostream>
#include <string>
using namespace std;

typedef struct item
{
	int digit;
	struct item *next;
	struct item *prev;
} Item;
typedef struct mnumber
{
	Item *head;
	Item *tail;
	int n;
} MNumber;

void AddDigit(MNumber *number, int digit)
{
	Item *p = (Item *)malloc(sizeof(Item));
	p->digit = digit;
	p->next = p->prev = NULL;
	if (number->head == NULL)
		number->head = number->tail = p;
	else {
		number->tail->next = p;
		p->prev = number->tail;
		number->tail = p;
	}
	number->n++;
}
void PrintMNumber(MNumber number)
{
	cout << endl;
	Item *p = number.tail;
	while (p) {
		cout << p->digit;
		p = p->prev;
	}
	cout << endl;
}
void PrintMNumberReverse(MNumber number)
{
	Item *p = number.head;
	while (p)
	{
		cout << p->digit;
		p = p->next;
	}
	cout << endl;
}
MNumber CreateMNumber(string a)
{
	MNumber number = { NULL, NULL, 0 };
	int n;
	for (n = a.length() - 1; n >= 0; n--)
		AddDigit(&number, a[n] - '0');
	return number;
}
int Equal(MNumber n1, MNumber n2)
{
	int result;
	int x1 = 0, x2 = 0;
	Item *P1 = n1.head;
	Item *P2 = n2.head;
	while (P1)
	{
		x1++;
		P1 = P1->next;
	}
	while (P2)
	{
		x2++;
		P2 = P2->next;
	}
	if (x1 > x2) return 1;
	if (x1 < x2) return -1;
	if (x1 = x2)
	{
		P1 = n1.head;
		P2 = n2.head;
		while (P1 && P2)
		{
			x1 = P1->digit;
			x2 = P2->digit;
			if (x1 > x2) return 1;
			if (x1 < x2) return -1;
			P1 = P1->next;
			P2 = P2->next;
		}
		return 0;
	}

}
void SayEqual(MNumber n1, MNumber n2, int(*f)(MNumber n1, MNumber n2)) {
	switch (Equal(n1, n2))
	{
	case 1: printf("A > B\n");  break;
	case 0: printf("A = B\n"); break;
	default: printf("A < B\n"); break;
	}
}
MNumber LongDModShort(MNumber n1, int del)
{
	MNumber mod = { NULL, NULL, 0 };
	Item *p1 = n1.tail;
	int s1 = 0;
	while (p1)
	{
		s1 += p1->digit; p1 = p1->prev;
		s1 = (s1 % del) * 10;
	}
	AddDigit(&mod, s1 / 10);
	return mod;
}
MNumber LongDivShort(MNumber n1, int del)
{
	MNumber div = { NULL, NULL, 0 };

	Item *p1 = n1.tail;
	int digit, s1 = 0;
	while (p1)
	{
		s1 += p1->digit; p1 = p1->prev;
		digit = s1 / del;
		AddDigit(&div, digit);
		s1 = (s1 % del) * 10;
	}

	return div;
}
MNumber LongMulSHort(MNumber n1, int multy)
{
	MNumber mult = { NULL, NULL, 0 };
	Item *p1 = n1.head;
	int digit, s1 = 0;
	int div = 0;

	while (p1)
	{
		s1 += p1->digit;
		p1 = p1->next;

		digit = (s1 * multy);
		digit += div;
		s1 = (s1 % 10) / 10;
		if (digit > 9) {
			int digit1 = digit;
			digit %= 10;
			div = digit1 / 10;
			AddDigit(&mult, digit);
		}
		else {
			AddDigit(&mult, digit);
			div = 0;
		}
	}
	return mult;
}
void checkForInt(string b) {
	int lineLength = b.length();
	for (int i = 0; i < lineLength; i++) {
		if (!isdigit(b[i])) {
			cout << "Enter posiitive number!!!!!! ";
			system("pause");
			exit(1);
		}
	}
}
void checkForRange(int a, int b, int c) {
	if (a > c || a < b) {
		cout << "Only " << c << " ways!!!";
		system("pause");
		exit(1);
	}
}
void main()
{
	for (;;)
	{
		cout << "1) Enter the first number\n2) Enter the second number\n 3) Equal\n 4) Result of division\n 5) Modulo\n 6) Multiplication result\n 7) Exit\n";
		int choose;
		cin >> choose;

		string schoose1, sdiv, smult, first, second;
		int choose1, div, mult;
		checkForRange(choose, 1, 7);

		switch (choose)
		{
		case 1:
			system("cls");

			cin >> first;
			checkForInt(first);
			MNumber a = CreateMNumber(first);
			break;

		case 2:
			system("cls");

			cin >> second;
			checkForInt(second);
			MNumber b = CreateMNumber(second);
			break;

		case 3:
			system("cls");
			SayEqual(a, b, &Equal);
			system("pause");
			break;

		case 4:
			system("cls");

			cout << "What do we divide the number into?";
			cin >> sdiv;
			checkForInt(sdiv);
			div = stoi(sdiv);
			cout << "What number do we divide?";

			cin >> schoose1;
			checkForInt(schoose1);
			choose1 = stoi(schoose1);
			checkForRange(choose1, 1, 2);

			if (choose1 == 1) PrintMNumberReverse(LongDivShort(a, div));
			else PrintMNumberReverse(LongDivShort(b, div));
			system("pause");
			break;

		case 5:
			system("cls");

			cout << "What do we divide the number into?";
			cin >> sdiv;
			checkForInt(sdiv);
			div = stoi(sdiv);

			cout << "What number do we divide?";
			cin >> schoose1;
			checkForInt(schoose1);
			choose1 = stoi(schoose1);
			checkForRange(choose1, 1, 2);

			if (choose1 == 1) PrintMNumberReverse(LongDModShort(a, div));
			else PrintMNumberReverse(LongDModShort(b, div));
			system("pause");
			break;

		case 6:
			system("cls");

			cout << "What do we multiply the number into?";
			cin >> smult;
			checkForInt(smult);
			mult = stoi(smult);

			cout << "What number do we multiply?";
			cin >> schoose1;
			checkForInt(schoose1);
			choose1 = stoi(schoose1);
			checkForRange(choose1, 1, 2);

			if (choose1 == 1) PrintMNumber(LongMulSHort(a, mult));
			else PrintMNumber(LongMulSHort(b, mult));

			system("pause");
			break;

		case 7:
			system("pause");
			exit(1);

		}
		system("cls");
	}
}
