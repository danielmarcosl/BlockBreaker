﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}

	void OnCollisionEnter2D (Collision2D col) {
		timesHit += 1;
		//Debug.Log (timesHit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
