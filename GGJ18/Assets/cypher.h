#include <string>
#include <map>
#ifndef CYPHER_H
#define CYPHER_H
using namespace std;

const char a = 'a';

typedef map<char, char> cypher;

cypher makeFromWord(string keyword);

cypher ceasar(int key);

string encode(cypher coder, string text);

#endif
