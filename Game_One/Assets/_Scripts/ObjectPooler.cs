using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour 
{
	public GameObject pooledObject;			// game objects that will be pooled (reused)
	public int pooledAmount;				// amount of game objects to pool
	List<GameObject> pooledObjects;			// list to store all the pooled objects

	// Use this for initialization
	void Start () 
	{
		pooledObjects = new List<GameObject> ();

		// creates the pooled objects and put it in the list where it will be reused in the game over and over
		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = (GameObject) Instantiate (pooledObject);		// instantiates the object that will be pooled
			obj.SetActive (false);											// set active to false (objs will be activated in update)
			pooledObjects.Add (obj);										// add the object to the list
		}
	}

	// gets non-active pooled object in the game hierarchy (scene)
	public GameObject GetPooledObject() 
	{
		
		// find non-active pooled object in the list
		for (int i = 0; i < pooledObjects.Count; i++) 
		{
			if (!pooledObjects [i].activeInHierarchy) 
			{
				return pooledObjects [i];
			}
		}

		// makes sure there is a game object in the list
		GameObject obj = (GameObject) Instantiate (pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);
		return obj;

	}
}
