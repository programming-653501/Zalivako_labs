// ConsoleApplication5.cpp: определяет точку входа для консольного приложения.
//
#include "stdafx.h"
#include "cmath"
#include "iostream"
#include "windows.h"

using namespace std;

long double  factorial(double n) {
	if (n > 1)
		return factorial(n - 1)*n;
	else 
    return 1;
}

int main()
{
	double e, x, sum = 0, sinx; 
	double n = 0;

	cout << "x = "; 
	cin >> x;
	sinx = sin(x);

	cout << "e = "; 
	cin >> e;

	do {
		n++;
		sum += pow(-1, n - 1) * pow(x, 2 * n - 1) / factorial(2 * n - 1);
	} while (abs(sinx - sum) > e);
	
	cout << "sin(x) = " << sinx << endl;
	cout << "sin(x) (Taylor) = " << sum << endl << "n = " << n << endl;

	system("pause");

	return 0;
}