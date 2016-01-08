using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			AutoMove ();
		} else {
			MoveWithMouse ();
		}
	}

	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePositionInBlocks = ((Input.mousePosition.x / Screen.width) * 16) - 8;

		paddlePos.x = Mathf.Clamp (mousePositionInBlocks, -7.5f, 7.5f);
		this.transform.position = paddlePos;
	}

	void AutoMove() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;

		paddlePos.x = Mathf.Clamp (ballPosition.x, -7.5f, 7.5f);
		this.transform.position = paddlePos;
	}
}
