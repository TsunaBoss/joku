using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
	[Header("General")]
	private Rigidbody2D _rigidbody;
	private Animator _anim;
	private Vector3 change;

	[Header("Movement")]
	public float speed = 6.0f;

    void Start()
	{
	    _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        #region PLAYER_MOVEMENT
        change = Vector3.zero;
		change.x=Input.GetAxisRaw("Horizontal");
		change.y=Input.GetAxisRaw("Vertical");
		UpdateAnimationAndMove();
        #endregion
 
    }

    void UpdateAnimationAndMove()
	{
		if(change != Vector3.zero)
		{
			MoveCharacter();
			_anim.SetFloat("moveX", change.x);
			_anim.SetFloat("moveY", change.y);
			_anim.SetBool("moving", true);
		} else {
			_anim.SetBool("moving",false);
		}
	}

	void MoveCharacter() { 
		_rigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); 
	}
}
