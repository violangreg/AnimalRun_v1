﻿using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform [] backgrounds;	// list of all back and fore grounds to be parallaxed
	private float[] parallaxScales;		// proportions of the camera's movement to move the background by
	public float smoothing = 1f;		// how smooth the parallax is going to be, make sure just to set this above 0
										// or the parallax effect wont work
	private Transform cam;				// reference to the main camera transform
	private Vector3 previousCamPos;		// store the precision of the camera in the previous frame
										// used to calculalte parallaxing
	// Is called before Start(), great for references
	void Awake()
	{
		// set up the reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () 
	{
		// the previous frame had the current frame's camera position
		previousCamPos = cam.position;

		// assigning corresponding parallax scales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; ++i) 
		{
			parallaxScales [i] = backgrounds [i].position.z * -1;	
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// for each background
		for (int i = 0; i < backgrounds.Length; i++) 
		{
			// the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create a target position which is the background current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and the target position using lerp;
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// set the previousCamPos to the camera's position at the end of the frame
		previousCamPos = cam.position;

	}
}
