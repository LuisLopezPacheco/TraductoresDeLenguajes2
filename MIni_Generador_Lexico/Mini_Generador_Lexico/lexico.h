#ifndef _LEXICO
#define _LEXICO

#include <iostream>
#include <string>
#include <conio.h>
#include <cstdio>
#include <cstdlib>
#include <cstdio>
#include <string.h>
#include <locale.h>
#include <windows.h>


using namespace std;



class Lexico {
private:

	class SymbolType {

	public:
		static const int Entire = 1;
		static const int Lyrics = 2;
		static const int Point = 3;
		static const int Real = 4;
		static const int Invalid = -1;
	};

	int state, size,index = 0;
	float number;
	string myChain, result;
	char c;
	bool next;
	

public:

	Lexico();

	void setMyChain(const string& cadena);


	void Type();
	void analyze();

	
	char nextSymbol();

	bool isSpace(const char& c) ;
	bool isNum(const char& c);
	bool isLyrics(const char& c);
	bool isPoint(const char& c);

	string chainResult();
	void behind();
};



#endif