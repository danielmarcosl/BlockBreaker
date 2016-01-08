using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		//Debug.Log ("Level load requested for: " + name);
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel () {
		//Debug.Log (SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BrickDestroyed () {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

	public void QuitRequest () {
		//Debug.Log ("I want to quit!");
		Application.Quit ();
	}
}
