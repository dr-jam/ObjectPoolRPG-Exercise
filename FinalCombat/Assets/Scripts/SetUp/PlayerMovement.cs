using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody2D PlayerRigidbody;
    private Vector3 Change;
    private Animator PlayerAnimator;

    public bool PlayerIsAllowedToMove = true;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerIsAllowedToMove)
        {
            PlayerRigidbody = GetComponent<Rigidbody2D>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerIsAllowedToMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Change = Vector3.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimatePlayerMovement();
    }

    void UpdateAnimatePlayerMovement()
    {
        if (Change != Vector3.zero && PlayerIsAllowedToMove == true)
        {
            MovePlayer();
            PlayerAnimator.SetFloat("moveX", Change.x);
            PlayerAnimator.SetFloat("moveY", Change.y);
            PlayerAnimator.SetBool("isWalking", true);
        }
        else
        {
            PlayerAnimator.SetBool("isWalking", false);
        }
    }

    void MovePlayer()
    {
        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);

    }
}
