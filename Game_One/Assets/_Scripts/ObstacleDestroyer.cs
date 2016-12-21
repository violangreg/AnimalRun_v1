using UnityEngine;
using System.Collections;

public class ObstacleDestroyer : MonoBehaviour {

	private GameObject destroyerPoint;
	// Use this for initialization
	void Start ()
	{
		destroyerPoint = GameObject.Find ("Destroyer Point");
	}

	void Update()
	{
		if (transform.position.x < destroyerPoint.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
	}

}
