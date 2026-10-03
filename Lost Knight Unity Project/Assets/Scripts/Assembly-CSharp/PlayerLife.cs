using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
	private Animator anim;

	private Rigidbody2D rb;

	[SerializeField]
	private AudioSource DeathSFX;

	private void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("TRAP"))
		{
			Die();
			Score.totalDEATHS++;
		}
	}

	private void Die()
	{
		DeathSFX.Play();
		anim.SetTrigger("death");
		rb.bodyType = RigidbodyType2D.Static;
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
