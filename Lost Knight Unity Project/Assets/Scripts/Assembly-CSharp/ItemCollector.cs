using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
	public int skulls;

	[SerializeField]
	private TextMeshProUGUI skullsText;

	[SerializeField]
	private AudioSource CollectSFX;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("cherry"))
		{
			Object.Destroy(collision.gameObject);
			CollectSFX.Play();
			skulls++;
			skullsText.text = "Black Skulls: " + skulls;
			Score.totalSKULLS++;
		}
	}
}
