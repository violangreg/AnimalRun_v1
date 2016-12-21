using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	Vector3 playerStartingPoint, gameManagerStartingPoint, backgroundStartingPoint;
	public PlayerManager player;
	public Transform gameManager, background, ground;
	ArrayList backgroundPositions;
	Transform[] groundChild;

	// Use this for initialization
	void Start () {
		playerStartingPoint = player.transform.position;
		gameManagerStartingPoint = gameManager.position;
		backgroundStartingPoint = background.localPosition;


		for (int i = 0; i < ground.childCount; i++) 
		{
			groundChild [i].position = ground.GetChild (i).position;
		}
		


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame()
	{
		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo()
	{
		yield return new WaitForSeconds (0.5f);
		player.transform.position = playerStartingPoint;

		for(int i = 0; i < gameManager.childCount; i++)
		{
			gameManager.GetChild(i).position = gameManagerStartingPoint;
		}


		for (int i = 0; i < ground.childCount; i++) 
		{
			ground.GetChild (i).position = groundChild [i].position;
		}
	}
}
