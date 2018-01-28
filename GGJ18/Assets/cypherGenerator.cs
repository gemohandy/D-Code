using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class cypherGenerator : MonoBehaviour {

	public TextAsset file;
	public string cypherTarget, testPath;
	public bool isCeasar;
	public int ceasarKey;
	public string subKey;
	public string nextLevelName;

	Text cypher;
	Text test;

	string originalText;

	// Use this for initialization
	void Start () {
		cypher = GameObject.Find (cypherTarget).GetComponent<Text> ();
		test = GameObject.Find (testPath).GetComponent<Text> ();
		string text = file.text;
		originalText = text.ToUpper ();
		if (isCeasar) {
			cypher.text = ceasarShift (ceasarKey, text.ToUpper ());
		} else {
			cypher.text = substitutionShift (subKey, text.ToUpper());
		}
		updateMidline (cypher.text, originalText);
	}

	string substitutionShift(string key, string s){
		for (int i = 0; i < 26; i++) {
			s = s.Replace ((char)(i + 'A'), key.ToLower () [i]);
		}
		return s.ToUpper ();;
				
	}

	string ceasarShift(int i, string s){
		int j;
		for (j = 0; j + i < 26; j++) {
			s = s.Replace ((char)(j + 'A'), (char)(j + i + 'a'));
		}
		i -= 26;
		for (; j < 26; j++) {
			s = s.Replace ((char)(j + 'A'), (char)(j + i + 'a'));
		}
		return s.ToUpper();
	}

	public void testString(){
		test.supportRichText = false;
		string output = test.text;
		test.supportRichText = true;
		output = output.Replace ("<COLOR=BLUE>", "");
		output = output.Replace ("</COLOR>", "");
		if (output == originalText) {
			Object menu = Resources.Load("levelEndMenu");
			menu = Instantiate (menu);
			GameObject men = (GameObject)menu;
			men.GetComponentInChildren<Button>().onClick.AddListener (loadLevel);
		} 
		updateMidline (output, originalText);
	}

	void updateMidline(string s1, string s2){
		int[] output = new int[s1.Length];
		for (int i = 0; i < s1.Length; i++) {
			output [i] = s1 [i] - s2 [i];
		}
		GameObject.FindObjectOfType<midline> ().updateLine (output);
	}

	void loadLevel(){
		GameObject.FindObjectOfType<manager>().loadLevel (nextLevelName);
	}

}
