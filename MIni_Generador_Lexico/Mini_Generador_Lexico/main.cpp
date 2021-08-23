#include "Lexico.h"


int main() {
	
	setlocale(LC_ALL, "spanish"); // Cambiar locale - Suficiente para máquinas Linux
	SetConsoleCP(1252); // Cambiar STDIN -  Para máquinas Windows
	SetConsoleOutputCP(1252); // Cambiar STDOUT - Para máquinas Windows

	string chain= " ";
	Lexico myLexico;
	while (chain != "\0") {
		system("cls");
		cout << "Oprime solo Enter para salir." << endl;
		cout << "Ingrese Letras o Numeros enteros o reales:" << endl;
		fflush(stdin);
		getline(cin, chain);
		if (chain != "\0") {
			cout << chain << endl;
			myLexico.setMyChain(chain);
			myLexico.analyze();
		}
		system("pause");
	}

}
