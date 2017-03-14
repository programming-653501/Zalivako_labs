// ConsoleApplication2.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <conio.h>
#include <Windows.h>
#include <iostream>


using namespace std;


struct Tarifs
{
	char *Name;
	int MBInternet;
	int MinInSet;
	float oneMinIn;
	float otherSet;
	float SMS;
	float EgPlata;
	float EmPlata;
	float Avans;

};

Tarifs *tr[4];

void init()
{

	for (int i = 0; i < 4; i++)
	{
		tr[i] = new Tarifs();
	}

	tr[0]->Name = "��� ����� ����";
	tr[0]->MBInternet = 250;
	tr[0]->MinInSet = 250;
	tr[0]->oneMinIn = 0.04f;
	tr[0]->otherSet = 0.10f;
	tr[0]->SMS = 0.05f;
	tr[0]->EgPlata = 1.99f;
	tr[0]->EmPlata = 5.00f;
	tr[0]->Avans = 3.00f;

	tr[1]->Name = "��� ����� mini";
	tr[1]->MBInternet = 500;
	tr[1]->MinInSet = 500;
	tr[1]->oneMinIn = 0.03f;
	tr[1]->otherSet = 0.07f;
	tr[1]->SMS = 0.05f;
	tr[1]->EgPlata = 2.99f;
	tr[1]->EmPlata = 9.90f;
	tr[1]->Avans = 3.00f;

	tr[2]->Name = "������ � ���� ���";
	tr[2]->MBInternet = 1000;
	tr[2]->MinInSet = 1000;
	tr[2]->oneMinIn = 0.004f;
	tr[2]->otherSet = 0.06f;
	tr[2]->SMS = 0.03f;
	tr[2]->EgPlata = 5.99f;
	tr[2]->EmPlata = 14.50f;
	tr[2]->Avans = 3.00f;

	tr[3]->Name = "��� �����+";
	tr[3]->MBInternet = 2000;
	tr[3]->MinInSet = 2000;
	tr[3]->oneMinIn = 0.005f;
	tr[3]->otherSet = 0.07f;
	tr[3]->SMS = 0.05f;
	tr[3]->EgPlata = 9.99f;
	tr[3]->EmPlata = 23.80f;
	tr[3]->Avans = 3.00f;
}


void enterInfo()
{
	int minIn;
	int other;
	int gorod;
	int sms;
	cout << "������� ���������� ����� � ����� ���� : ";
	cin >> minIn;
	cout << endl;
	cout << "������� ���������� ����� � ������ ���� : ";
	cin >> other;
	cout << endl;
	cout << "������� ���������� ����� �� ��������� ������ : ";
	cin >> gorod;
	cout << endl;
	cout << "������� ���������� sms : ";
	cin >> sms;
	cout << endl;
}

void printInfo()
{
	cout << "�������� ��������:\n"<<endl;
	for (int i = 0; i < 4; i++)
	{
		 
		cout << "����� " << tr[i]->Name << endl;
		cout << "���-�� �������: " << tr[i]->MBInternet << " ��" <<endl;
		cout << "����� ������ ����: " << tr[i]->MinInSet <<endl;
		cout << "��������� ������ ������ ����: " << tr[i]->oneMinIn << endl;
		cout << "��������� ������ � ������ ���� � �����: " << tr[i]->otherSet << endl;
		cout << "��������� SMS: " << tr[i]->SMS << endl;
		cout << "���������� �����: " << tr[i]->EgPlata << endl;
		cout << "����������� ������: " << tr[i]->EmPlata << endl;
		cout << "�������������� �����: " << tr[i]->Avans << endl;
		cout << endl;
	}
}

void connection()
{
	cout << "\n���������� �����\n������ ��������� �����\n0890 (��������� � ���� ���)\n8 017 237 - 98 - 98\n�������������\n\n������ ��������� ���������\n0860 (��������� � ���� ���)\n8 017 237 - 98 - 28\n�������������\n\n������������ ������������� ��������\n0990 (��������� � ���� ���)\n8 017 237 - 98 - 95\n\n";
}

float calculation(int minIn, int other, int gorod, int sms)
{
	float mass[4] = { 0,0,0,0};
	float result = 0;

	float inSet = 0;
	float OtherSet = 0;
	float SMS = 0;
	float Gorod = 0;
	int check = 0;

	for (int i = 0; i < 4; i++)
	{
		if (tr[i]->MinInSet < minIn)
		{
			inSet = (minIn - tr[i]->MinInSet)*tr[i]->oneMinIn;
		}
		else
		{
			inSet = 0;
		}


		OtherSet = tr[i]->otherSet*other;
		SMS = tr[i]->SMS*sms;
		Gorod = gorod*tr[i]->otherSet;
		mass[check] = inSet + OtherSet + SMS + Gorod + tr[i]->Avans + tr[i]->EgPlata + tr[i]->EmPlata;
		check++;
	}

	float min = mass[0];
	for (int i = 0; i < 4; i++)
	{
		if (min > mass[i])
		{
			min = mass[i];
			result = (float)i;
		}
	}
	return result;
}



int main()
{
	setlocale(LC_ALL, "Russian");
	
	init();
	int minIn = 0;
	int other = 0;
	int gorod = 0;
	int sms = 0;

	for (;;) 
	{
		int choise;
		cout << "�������� �����:\n";
		cout << "1. ���� ���������� \n2. ������ ������ \n3. ����������� � ������� \n4. ���������� ���������� MTS  \n5. ����� \n��� �����: ";
		cin >> choise;
		cout << endl;
		while (choise != 1 && choise != 2 && choise != 3 && choise != 4 && choise != 5)
		{
			cout << "�������� ����� �����:\n";
			cout << "1. ���� ���������� \n2. ������ ������ \n3. ����������� � ������� \n4. ���������� ���������� MTS  \n5. ����� \n��� �����: ";
			cin >> choise;
			cout << endl;
		}
		switch (choise)
		{
		case 1: enterInfo(); break;
		case 2: {int index = (int)calculation(minIn, other, gorod, sms); 
			cout << "����� " << tr[index]->Name << endl;
			cout << "���-�� �������: " << tr[index]->MBInternet << " ��" << endl;
			cout << "����� ������ ����: " << tr[index]->MinInSet << endl;
			cout << "��������� ������ ������ ����: " << tr[index]->oneMinIn << endl;
			cout << "��������� ������ � ������ ���� � �����: " << tr[index]->otherSet << endl;
			cout << "��������� SMS: " << tr[index]->SMS << endl;
			cout << "���������� �����: " << tr[index]->EgPlata << endl;
			cout << "����������� ������: " << tr[index]->EmPlata << endl;
			cout << "�������������� �����: " << tr[index]->Avans << endl;
			cout << endl;
		} break;
		case 3: printInfo(); break;
		case 4: connection(); break;
		case 5: return 0; break;
		default: break;
		}
	}

	system("pause");
	return 0;
}

