using UnityEngine;
using System.Collections;

public class SubmitScoreForm : MonoBehaviour {

public	GameManager cGameManager;
	public GameObject goHighscores;
	public string label;
	public string sName;

	public GUISkin cmyGUI;

	void Start()
	{
		cGameManager = GameObject.Find ("_GameManager").GetComponent<GameManager>();
	}

	void OnGUI(){
		GUI.skin = cmyGUI;

		
		GUI.Box (new Rect (cGameManager.scrnw (40),cGameManager.scrnh (40),cGameManager.scrnw (45),cGameManager.scrnh (45)), "Submit Oook!" );

		sName = GUI.TextField (new Rect (cGameManager.scrnw (47),cGameManager.scrnh (53),cGameManager.scrnw (30),cGameManager.scrnh (10)), sName);

		if (GUI.Button (new Rect (cGameManager.scrnw (42),cGameManager.scrnh (65),cGameManager.scrnw (15),cGameManager.scrnh (15)), "Submit")) {
		//TO DO SUbmit

			StartCoroutine(SubmitScore());
		}


		if (GUI.Button (new Rect (cGameManager.scrnw (67),cGameManager.scrnh (65),cGameManager.scrnw (15),cGameManager.scrnh (15)), "Close")) {
		
			cGameManager.bBlockGUI = false;
			gameObject.SetActive(false);

		}



	}

	IEnumerator SubmitScore()
	{
		if (sName != "") {
			string submitURL = "http://www.willdevforfood.x10host.com/goingbananas/newscore.php" + "?name=" + sName + "&score=" + cGameManager.iScore.ToString ();
			WWW submitReader = new WWW (submitURL);
			yield return submitReader;
			Debug.Log (submitReader.text);
		
			if (submitReader.error != null) {
				label = "Error connecting to database server";
			} else {
				label = "Score Submitted, Loading Highscores ...";
	
			}
		} else {
			label = "Please enter a name";
		}

		goHighscores.SetActive (true);
		gameObject.SetActive (false);
	}


}
