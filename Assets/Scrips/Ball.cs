using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			LaunchBallAtStart ();
		}
	}

	void LaunchBallAtStart() {
		// Lock the ball relative to the paddle at the start
		this.transform.position = paddle.transform.position + paddleToBallVector;

		// Wait until the left button of the mouse is pressed
		if (Input.GetMouseButtonDown (0)) {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);

			hasStarted = true;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		ChangeVelocity ();
		PlayBounceSound (col);
	}

	void ChangeVelocity () {
		Vector2 tweak = new Vector2 (Random.Range(0f,0.2f), Random.Range(0,0.2f));

		this.GetComponent<Rigidbody2D> ().velocity += tweak;
	}

	void PlayBounceSound (Collision2D col) {
		if (hasStarted && (col.gameObject.name.Equals("Padle")) || (col.gameObject.name.Equals("Wall_Left"))||
			(col.gameObject.name.Equals("Wall_Right"))|| (col.gameObject.name.Equals("Wall_Top"))) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}
}
