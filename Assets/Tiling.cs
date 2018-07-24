using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {
	public int offSetX = 2;
	public bool hasARight = false;
	public bool hasALeft = false;
	public bool reverseScale = false; //used if object is not tilable 
	private float spriteWidth = 0f; // width of our element 
	private Camera cam;
	private Transform trans;

	private void Awake()
	{
		cam = Camera.main;
		trans = transform;
	}

	// Use this for initialization
	void Start ()
	{
		SpriteRenderer render = GetComponent<SpriteRenderer>();
		spriteWidth = render.sprite.bounds.size.x;
	}

	// Update is called once per frame
	void Update()
	{
		if (hasARight == false || hasALeft == false)
		{
			//calculatlte the camera extendt
			float camHorizon = cam.orthographicSize * Screen.width / Screen.height;

			//calcaulate the x position where the camera can see the edge of the sprite
			float edgeVisibleR = (trans.position.x + spriteWidth / 2) - camHorizon;
			float edgeVisibleL = (trans.position.x - spriteWidth / 2) + camHorizon;
		} 
	}
}
