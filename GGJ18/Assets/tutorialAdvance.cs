using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialAdvance : MonoBehaviour {

	struct tutorialBox{
		public int moveLeft, moveUp, width, height;
		public string tutorialText;
	}

	int curState = 0;

	tutorialBox decodedBox, midlineBox, alphaBox, finalBox;

	void Start(){
		decodedBox = makeBox (
			-350, 
			0, 
			180, 
			160, 
			"This box on the right, meanwhile, is the decoded version. You want it to be readable. That's the goal of the game!"
		);	

		midlineBox = makeBox (
			-150,
			0,
			160,
			160,
			"This line down the middle shows your progress. The more wrong letters, the more red. You want it to just be a green line down the middle."
		);

		alphaBox = makeBox (
			200,
			-70, 
			250,
			160,
			"These letters are your main tool. When you type a letter into a white box, the letter above it gets replaced with whatever you typed. Try it out!"
		);

		finalBox = makeBox (
			0,
			50,
			200,
			100,
			"And that's all there is to it! Now try solving this puzzle!"
		);
	}
	// Update is called once per frame
	public void advance(){
		Debug.Log (this.name);
		tutorialBox nextBox = decodedBox;
		switch (curState) {
		case 0:
			nextBox = decodedBox;
			break;
		case 1:
			nextBox = midlineBox;
			break;
		case 2:
			nextBox = alphaBox;
			break;
		case 3:
			nextBox = finalBox;
			break;
		case 4:
			Destroy (this.gameObject);
			break;
		}
		curState++;
		setupBox (nextBox);
	}

	void setupBox(tutorialBox t){
		RectTransform body = this.GetComponent<RectTransform>();
		body.Translate (t.moveLeft, t.moveUp, 0);
		body.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, t.width);
		body.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, t.height);
		this.GetComponentInChildren<Text>().text = t.tutorialText;
	}

	tutorialBox makeBox(int l, int r, int t, int b, string s){
		tutorialBox box;
		box.moveLeft = l;
		box.moveUp = r;
		box.width = t;
		box.height = b;
		box.tutorialText = s;
		return box;
	}

}
