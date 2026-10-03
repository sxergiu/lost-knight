using UnityEngine;

public class BrokenPortal : MonoBehaviour
{
	[SerializeField]
	private AudioSource bpSFX;

	private void Start()
	{
		bpSFX = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			bpSFX.Play();
		}
	}
}
