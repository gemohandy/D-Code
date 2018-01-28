using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class midline : MonoBehaviour {

	Color red = new Color (1, 0, 0),
	green = new Color (0, 1, 0),
	black = new Color (0, 0, 0);

	public Texture2D texture;



	public void updateLine(int[] a){
		Color[] colorArray = new Color[400 * 51 + 1];
		int rowsPerChar = 400 / a.Length;
		for (int i = 0; i/rowsPerChar < a.Length; i++) {
			int lrc = -1;
			if (a [i/rowsPerChar] == 0) {
				lrc = 0;
			} else if (a [i/rowsPerChar] > 0) {
				lrc = 1;
			}
			for(int j = -25; j < 25; j++){
				switch (lrc) {
				case 0:
					if (j == 0)
						colorArray [51 * i + j + 25] = green;
					else
						colorArray [51 * i + j + 25] = black;
					break;
				case -1:
					if (j > a [i/rowsPerChar] && j <= 0)
						colorArray [51 * i + j + 25] = red;
					else
						colorArray [51 * i + j + 25] = black;
					break;
				case 1:
					if (j < a [i/rowsPerChar] && j >= 0)
						colorArray [51 * i + j + 25] = red;
					else
						colorArray [51 * i + j + 25] = black;
					break;
				}
			}
		}
		for (int i = a.Length * 153; i < 400 * 51; i++) {
			colorArray [i] = black;
		}
		texture.SetPixels (colorArray);
		texture.Apply ();
	}
}
