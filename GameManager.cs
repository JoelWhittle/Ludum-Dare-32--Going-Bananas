using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public float fWaveTime;
	public int iInitialSpawnCount;
	public int iCurToSpawnCount;
	public int iWaveRamp;
	public List<GameObject> GuardSpawnPoints = new List<GameObject> ();
	public GameObject PlayerSpawnPoint;
	public float fGuardChatterMinTime;
	public float fGuardChatterMaxTime;

	public ApeController cApeController;
	public int iScore;

	public Prefabs cPrefabs;
	public List<GameObject> ObjectsToClean = new List<GameObject>();
	public List<Submission> SubmissionsToClean = new List<Submission>();
	public GameObject goHighscores;
	public bool bBlockGUI;


	public AudioSource[] aGuardChatter;


	public GUISkin cMyGUI;

	void Start()
	{
		iCurToSpawnCount = iInitialSpawnCount;

		foreach(GameObject spawnpoint in GameObject.FindGameObjectsWithTag("EnemySpawnPoint"))
		{
			GuardSpawnPoints.Add(spawnpoint);
		}
		StartCoroutine (WaveManager ());

		StartCoroutine (GuardChatterManagement ());

	}





public bool bGameStillGoing()
	{
		if (cApeController.iHealth > 0) {
			return true;
		}
		else 
		{
			return false;
		}

	}


	void OnGUI()
	{


		GUI.skin = cMyGUI;
		//UI
		GUI.Label (new Rect (scrnw(10),scrnh(10),scrnw(10),scrnh(10)), "Health: " + cApeController.iHealth.ToString());
		GUI.Label (new Rect (scrnw(10),scrnh(20),scrnw(10),scrnh(10)), "Score: " + iScore.ToString());




		//End game
		if(!bGameStillGoing() && !bBlockGUI)
		{
			// Make a background box
			GUI.Box(new Rect(scrnw(30),scrnh(20),scrnw(40),scrnh(60)), "Oook!");

			GUI.Label (new Rect (scrnw(40),scrnh(30),scrnw(20),scrnh(10)), "Congratulations, you brought nana-wrath on " + iScore.ToString()+ " of those dirrty guards!");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(scrnw(35),scrnh(50),scrnw(10),scrnh(10)), "Restart")) {

				ResetGame();
			}

			if(GUI.Button(new Rect(scrnw(55),scrnh(50),scrnw(10),scrnh(10)), "Submit Score")) {
				
			goHighscores.SetActive(true);
				bBlockGUI = true;
			}
			
		
			}
		}



	public IEnumerator WaveManager()
	{

		for(int i = 0; i < iCurToSpawnCount; i++)
		{

		int iSpawnPoint = Random.Range (0, GuardSpawnPoints.Count);

	Instantiate (cPrefabs.goGuard, GuardSpawnPoints[iSpawnPoint].transform.position, Quaternion.identity);

			yield return new WaitForSeconds(0.5f);
		}
		yield return new WaitForSeconds (fWaveTime);
		iCurToSpawnCount = iCurToSpawnCount + iWaveRamp;

		if(bGameStillGoing())
		{
		StartCoroutine (WaveManager ());

		}
	}


	public void ResetGame()
	{
		foreach(GameObject go in ObjectsToClean)
		{
			Destroy(go);



		}

		ObjectsToClean.Clear ();

		foreach(Submission cSubmission in SubmissionsToClean)
		{
			Destroy(cSubmission);
			
			
		}

		SubmissionsToClean.Clear ();

		cApeController.gameObject.transform.position = PlayerSpawnPoint.transform.position;
		cApeController.Speed = cApeController.iMaxSpeed;
		iCurToSpawnCount = iInitialSpawnCount;
		cApeController.iHealth = cApeController.iMaxHealth;
		iScore = 0;
		StartCoroutine(WaveManager());
		StartCoroutine(GuardChatterManagement());

	}


	public IEnumerator GuardChatterManagement()
	{

		Debug.Log ("ReachGuardCHatter");
		if(bGameStillGoing())
		{
			aGuardChatter[Random.Range(0,aGuardChatter.Length)].Play();


			yield return new WaitForSeconds(Random.Range(fGuardChatterMinTime, fGuardChatterMaxTime));

			StartCoroutine(GuardChatterManagement());

		}
	}


	public float scrnw(float fSize)
	{
		return Screen.width / 100 * fSize;
	}
	public float scrnh(float fSize)
	{
		return Screen.height / 100 * fSize;
	}
}
