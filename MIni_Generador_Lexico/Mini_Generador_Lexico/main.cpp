#include "Lexico.h"


int main() {
	
	setlocale(LC_ALL, "spanish"); // Cambiar locale - Suficiente para m�quinas Linux
	SetConsoleCP(1252); // Cambiar STDIN -  Para m�quinas Windows
	SetConsoleOutputCP(1252); // Cambiar STDOUT - Para m�quinas Windows

	string chain; 
	Lexico myLexico;
	
	cout << "Ingrese Letras o Numeros enteros o reales" << endl;
	
	getline(cin, chain);
	
	cout << chain << endl;
	myLexico.setMyChain(chain);
	myLexico.analyze();


}