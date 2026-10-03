using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Transform player;

	private void Update()
	{
		base.transform.position = new Vector3(player.position.x, player.position.y + 1.32f, base.transform.position.z);
	}
}
