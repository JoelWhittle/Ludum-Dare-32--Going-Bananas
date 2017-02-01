using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HighscoresDisplay : MonoBehaviour {

	public	GameManager cGameManager;
	public List<string> sHighUsers = new List<string>();
	public List<int> iHighScores = new List<int> ();

	public GameObject HighscoresWindow;


	public GUISkin cMyGUI;

	void Start()
	{
		HighscoresWindow.SetActive (false);
		cGameManager = GameObject.Find ("_GameManager").GetComponent<GameManager>();
		
	}


	void OnGUI(){

		GUI.skin = cMyGUI;

			GUI.Box (new Rect (cGameManager.scrnw (25), cGameManager.scrnh (30), cGameManager.scrnw (50), cGameManager.scrnh (75)), "High Oooks!");

			
			
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (35), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [0] + " - " + iHighScores [0].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (40), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [1] + " - " + iHighScores [1].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (45), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [2] + " - " + iHighScores [2].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (50), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [3] + " - " + iHighScores [3].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (55), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [4] + " - " + iHighScores [4].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (60), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [5] + " - " + iHighScores [5].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (65), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [6] + " - " + iHighScores [6].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (70), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [7] + " - " + iHighScores [7].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (75), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [8] + " - " + iHighScores [8].ToString ());
		GUI.Label (new Rect (cGameManager.scrnw (40), cGameManager.scrnh (80), cGameManager.scrnw (20), cGameManager.scrnh (10)), sHighUsers [9] + " - " + iHighScores [9].ToString ());


			
			
			
			
			
			
			
			
			if (GUI.Button (new Rect (cGameManager.scrnw (43), cGameManager.scrnh (85), cGameManager.scrnw (15), cGameManager.scrnh (15)), "Retry")) {
				
				cGameManager.ResetGame ();
			cGameManager.bBlockGUI = false;
				gameObject.SetActive (false);
				
			}
		}
		
		
	}

