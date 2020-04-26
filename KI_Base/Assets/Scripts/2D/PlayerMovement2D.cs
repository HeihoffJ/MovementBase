using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Rigidbody2D rigidbody;
    private Vector2 movement;

    private bool _facingRight = false;
    private bool _moveAble = true;

    /// <summary>
    /// bool moveable if false player cant move
    /// </summary>
    public bool MoveAble
    {
       // get {return moveAble;}
        set => _moveAble = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
               
        if(movement.x > 0 && !_facingRight) Flip(); //moving right
        if(movement.x < 0 && _facingRight) Flip();  //moving left

    }

    void FixedUpdate()
    {
        if(_moveAble)
        {
            rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    /// <summary>
    /// Flip Sprite on x axes 
    /// </summary>
    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_facingRight = !_facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
