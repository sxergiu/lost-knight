using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
	private AudioSource finishSFX;

	private bool finishtouch;

	private void Start()
	{
		finishSFX = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player" && !finishtouch)
		{
			finishtouch = true;
			finishSFX.Play();
			Invoke("CompleteLevel", 2f);
		}
	}

	private void CompleteLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
