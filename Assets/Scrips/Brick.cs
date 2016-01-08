using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

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

			GameObject.Destroy (gameObject, 0.1f);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
	}
}
