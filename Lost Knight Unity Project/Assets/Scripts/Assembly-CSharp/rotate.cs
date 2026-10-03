using UnityEngine;

public class rotate : MonoBehaviour
{
	[SerializeField]
	private float speed = 3f;

	private void Update()
	{
		base.transform.Rotate(0f, 0f, 360f * speed * Time.deltaTime);
	}
}
