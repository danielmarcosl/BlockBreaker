using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public Sprite[] hitSprites;

	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col) {
		timesHit += 1;

		if (timesHit >= maxHits) {
			GameObject.Destroy (gameObject, 0.1f);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
	}

	// TODO remove this when the bricks can be broken
	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}
