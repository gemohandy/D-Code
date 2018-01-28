#include "cypher.h"
#include <iostream>

cypher ceasar(int key){
  cypher output;
  for(int i = 0, j = key; i < 26; i++){
    output[a + i] = j+a;
    j++;
    if(j == 26){
      j = 0;
    }
  }
  return output;
}

cypher makeFromWord(string keyword){
  cypher output;
  bool isUsed[26]={false};
  int index = 0;
  for(unsigned int i = 0; i < keyword.length(); i++){
    if(!isUsed[keyword[i] - a]){
      isUsed[keyword[i] - a] = true;
      output[a + index] = keyword[i];
      index++;
    }
  }
  for(int i = index, j = 0; i < 26; i++){
    while(isUsed[j]){
      j++;
    }
    output[a + i] = a + j;
    j++;
  }
  return output;
}

string encode(cypher coder, string text){
  for(unsigned int i = 0; i < text.length(); i++){
    if(coder.count(text[i])){
      text[i] = coder[text[i]];
    }
  }
  return text;
}
