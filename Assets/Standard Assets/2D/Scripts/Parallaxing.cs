using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] scenery; //Array of all the back and fore gorunds to be parallaxed
	private float[] parallaxScales; //The proportion of the camera's movmt to move the background by
	public float smoothing = 1f; //How smooth the paralax is going to be. Make sure to se this above 0


	private Transform cam; //reference to the main cameras transform
	private Vector3 previousCamPosition;  //VECTOR3(means x,y,z positioning), stores the position of the camera in the previous frame

	/// <summary>
	/// Is called before Start(), but after all the game object is set up
	/// great for references 
	/// </summary>
	void Awake()
	{
		//set up the camera reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start ()
	{
		//store teh previous frame had the current frames's camera posiiton 
		previousCamPosition = cam.position;

		//assigning corresponding parallaxScale
		parallaxScales = new float[scenery.Length]; 
		for (int i = 0; i < scenery.Length; i++)
		{
			parallaxScales[i] = scenery[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		//for each scenery
		for (int i = 0; i < scenery.Length; i++)
		{
			// the parallax is the opposite of the camera mvmt because the previous frame multiplued by the scale 
			float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];

			//set a target x position which is the current position + the parallax
			float backgroundTargetPosX = scenery[i].position.x + parallax;

			// create a taraget position which is the background current position with 
			// its target x position 
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, scenery[i].position.y, scenery[i].position.z);

			// fadae between current positon and the target position using lerp
			//DELTATIME -- converts frames to seconds 
			scenery[i].position = Vector3.Lerp(scenery[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

		}

		//set previousCamPos to the camera's position at the end of the frame
		previousCamPosition = cam.position;
	}
}
