using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cypherManager : MonoBehaviour {

	public string inputName;

	public string outputName;

	public string defaultCharInput;

	InputField[] inputs = new InputField[26];

	char[] cypher = new char[26];

	Text inputObj, outputObj;
	// Use this for initialization
	void Start () {
		inputObj = GameObject.Find (inputName).GetComponent<Text>();
		outputObj = GameObject.Find (outputName).GetComponent<Text>();
		inputs[0] = GameObject.Find (defaultCharInput).GetComponent<InputField>();
		cypher [0] = 'a';
		for (int i = 1; i < 26; i++) {
			inputs [i] = GameObject.Find (defaultCharInput + " (" + i.ToString () + ")").GetComponent<InputField>();
			cypher [i] = (char)('a' + i);
		}
		StartCoroutine(setupText());
	}

	public void updateCypher(int index){
		if (inputs[index].text.Length != 0) {
			cypher [index] = char.ToLower (inputs [index].text [0]);
		} else {
			cypher [index] = (char)(index + 'a');
		}
		updateText();
	}

	IEnumerator setupText(){
		yield return 0;
		updateText();
	}

	public void updateText(){
		string outputText = inputObj.text;
		for (int i = 0; i < 26; i++) {
			if(cypher[i] != (char)(i+'a')){
				outputText = outputText.Replace (""+(char)(i + 'A'), "<color=blue>" + cypher[i] +"</color>");
			}
		}
		outputObj.text = outputText.ToUpper();
	}
}
