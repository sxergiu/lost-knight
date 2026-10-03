using UnityEngine;

public class CoolCursor : MonoBehaviour
{
	public Texture2D cursorArrow;

	private void Start()
	{
		Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
	}
}
