#include "Lexico.h"


int main() {
	
	setlocale(LC_ALL, "spanish"); // Cambiar locale - Suficiente para máquinas Linux
	SetConsoleCP(1252); // Cambiar STDIN -  Para máquinas Windows
	SetConsoleOutputCP(1252); // Cambiar STDOUT - Para máquinas Windows

	string chain; 
	Lexico myLexico;
	
	cout << "Ingrese Letras o Numeros enteros o reales" << endl;
	
	getline(cin, chain);
	
	cout << chain << endl;
	myLexico.setMyChain(chain);
	myLexico.analyze();


}