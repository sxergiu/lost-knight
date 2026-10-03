using UnityEngine;

public class SharpText : MonoBehaviour
{
	public float sizeInUnits;

	public TextMesh textMesh;

	public Camera mainCamera;

	private float sharpness;

	private void Start()
	{
		OnCameraSizeChange();
	}

	public void OnCameraSizeChange()
	{
		sharpness = (float)Screen.height / (20f * mainCamera.orthographicSize);
		textMesh.fontSize = Mathf.RoundToInt(sharpness * sizeInUnits);
		textMesh.characterSize = 1f / sharpness;
	}
}
