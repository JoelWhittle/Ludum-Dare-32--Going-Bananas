using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;  


public class HighscoresWindow : MonoBehaviour {

	
	public	GameManager cGameManager;
	public string label;
	public string sName;

	public List<string> sHighUsers = new List<string>();
	public List<int> iHighScores = new List<int> ();

	public GameObject HighscoresDisplay;



	void Start()
	{
		cGameManager = GameObject.Find ("_GameManager").GetComponent<GameManager>();

		StartCoroutine (ReadAndDisplayHighscores ());
	}
	

	
	IEnumerator ReadAndDisplayHighscores()
	{
		
		string signupURL = "http://www.willdevforfood.x10host.com/goingbananas/readscores.php";
		WWW signupReader = new WWW (signupURL);
		yield return signupReader;
		Debug.Log (signupReader.text);
		
		if (signupReader.error != null) {
			label = "Error connecting to database server";
		} 
		else 
		{
			label = "Score Submitted, Loading Highscores ...";


			string[] sSubmissions = signupReader.text.Split("@".ToCharArray());


			foreach(string sSubmission in sSubmissions)
       
			{
				if(sSubmission !="")
				{
				string[]	sArgs = sSubmission.Split(",".ToCharArray());

					if(sArgs[1]!= "" & sArgs[0]!="")
					{
					Submission cSubmission = cGameManager.gameObject.AddComponent<Submission>();

					cSubmission.sUser = sArgs[0];
					cSubmission.iScore = int.Parse(sArgs[1]);
					cGameManager.SubmissionsToClean.Add(cSubmission);

					}
				}

			}

			List<Submission> SortedList = cGameManager.SubmissionsToClean.OrderBy(o=>o.iScore).ToList();
			SortedList.Reverse();

			sHighUsers.Clear();
			iHighScores.Clear();

			for(int i = 0; i < 10; i++)
			
			{
				sHighUsers.Add(SortedList[i].sUser);
				iHighScores.Add(SortedList[i].iScore);

			}

		}
		HighscoresDisplay.SetActive (true);
		HighscoresDisplay.GetComponent<HighscoresDisplay> ().iHighScores = iHighScores;
		HighscoresDisplay.GetComponent<HighscoresDisplay> ().sHighUsers = sHighUsers;


	}
	
	
}