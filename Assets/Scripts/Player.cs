using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]    
    private float move_x;
    public float moveForce = 10f;
    private float jumForce = 10f;

    private bool onGround = true;
    private string isRun = "walk";
    private string GROUND_TAG = "Ground";


    private Animator ani;
    private SpriteRenderer sr;
    private Rigidbody2D rg;



    private void Awake()
    {
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        move();
        animatePlayer();
    }

    private void FixedUpdate()
    {
        jump();
    }

    void move() {
        move_x = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(move_x, 0f, 0f) * Time.deltaTime * moveForce;
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(onGround)
            {
                onGround = false;
                rg.AddForce(new Vector2(0f, jumForce), ForceMode2D.Impulse);
            }
        }
    }

    void animatePlayer()
    {
        if(move_x > 0)
        {
            ani.SetBool(isRun, true);
            sr.flipX = false;

        } else if(move_x < 0) 
        {
            ani.SetBool(isRun, true);
            sr.flipX = true;

        } else
        {
            ani.SetBool(isRun, false);
        } 

    }


    private void OnCollisionEnter2D(Collision2D collistion)
    {
        if(collistion.gameObject.CompareTag(GROUND_TAG))
        {
            onGround = true;
        }
    }

}
