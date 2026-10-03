using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	public static int totalSKULLS;

	public static int totalDEATHS;

	[SerializeField]
	private TextMeshProUGUI skullsText;

	[SerializeField]
	private TextMeshProUGUI deathsText;

	private void Start()
	{
		skullsText.text = totalSKULLS + "/13";
		deathsText.text = totalDEATHS.ToString();
	}
}
