using UnityEngine;

public class comp : MonoBehaviour
{
	private enum MovementState
	{
		idle = 0,
		running = 1,
		jumping = 2,
		falling = 3,
		climbing = 4,
		crouching = 5
	}

	private Rigidbody2D rb;

	private BoxCollider2D coll;

	private SpriteRenderer sprite;

	private Animator anim;

	private CircleCollider2D coll2;

	private float dirX;

	private float dirY;

	[SerializeField]
	private float moveSpeed = 7f;

	[SerializeField]
	private float jumpForce = 14f;

	[SerializeField]
	private float crouchSpeed = 4f;

	[SerializeField]
	private LayerMask jumpableground;

	[SerializeField]
	private AudioSource jumpSoundFX;

	private bool isLadder;

	private bool isClimbing;

	private bool isCrouching;

	private float aux;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		coll = GetComponent<BoxCollider2D>();
		coll2 = GetComponent<CircleCollider2D>();
		coll2.enabled = false;
		coll.enabled = true;
	}

	private void Update()
	{
		dirX = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
		if (Input.GetButtonDown("Jump") && IsGrounded() && !isClimbing)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jumpSoundFX.Play();
		}
		if (Input.GetButtonDown("Crouch"))
		{
			isCrouching = true;
			collsw();
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			isCrouching = false;
			collsw();
		}
		dirY = Input.GetAxis("Vertical");
		if (isLadder && Mathf.Abs(dirY) > 0f)
		{
			isClimbing = true;
		}
		UpdateAnimationState();
	}

	private void UpdateAnimationState()
	{
		MovementState value;
		if (isCrouching)
		{
			value = MovementState.crouching;
			if (dirX > 0f)
			{
				sprite.flipX = false;
			}
			else if (dirX < 0f)
			{
				sprite.flipX = true;
			}
		}
		else if (dirX > 0f && !isClimbing)
		{
			value = MovementState.running;
			sprite.flipX = false;
		}
		else if (dirX < 0f && !isClimbing)
		{
			value = MovementState.running;
			sprite.flipX = true;
		}
		else
		{
			value = MovementState.idle;
		}
		if (isClimbing)
		{
			rb.gravityScale = 0f;
			rb.velocity = new Vector2(rb.velocity.x, dirY * moveSpeed);
			value = MovementState.climbing;
		}
		else
		{
			rb.gravityScale = 3f;
		}
		if (rb.velocity.y > 0.1f && !isClimbing)
		{
			value = MovementState.jumping;
		}
		else if (rb.velocity.y < -0.1f && !isClimbing)
		{
			value = MovementState.falling;
		}
		anim.SetInteger("State", (int)value);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
			isLadder = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
			isLadder = false;
			isClimbing = false;
		}
	}

	private void collsw()
	{
		coll.enabled = !coll.enabled;
		coll2.enabled = !coll2.enabled;
		aux = moveSpeed;
		moveSpeed = crouchSpeed;
		crouchSpeed = aux;
	}

	private bool IsGrounded()
	{
		return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableground);
	}
}
