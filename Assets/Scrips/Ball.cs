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
			// Lock the ball relative to the paddle at the start
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait until the left button of the mouse is pressed
			if (Input.GetMouseButtonDown (0)) {
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);

				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (hasStarted) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}
}
