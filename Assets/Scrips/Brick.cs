﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount += 1;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position);

		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit += 1;

		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			breakableCount -= 1;
			levelManager.BrickDestroyed ();

			puffSmoke ();

			GameObject.Destroy (gameObject, 0.1f);
		} else {
			LoadSprites ();
		}
	}

	void puffSmoke () {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponentInChildren<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;

		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing");
		}
	}
}
