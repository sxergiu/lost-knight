using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
	[SerializeField]
	private GameObject[] waypoints;

	private int currentWaypoint;

	[SerializeField]
	private float speed = 3f;

	private SpriteRenderer sprite;

	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		sprite.flipX = true;
	}

	private void Update()
	{
		if (Vector2.Distance(waypoints[currentWaypoint].transform.position, base.transform.position) < 0.1f)
		{
			currentWaypoint++;
			if (currentWaypoint >= waypoints.Length)
			{
				currentWaypoint = 0;
			}
		}
		base.transform.position = Vector2.MoveTowards(base.transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
	}
}
