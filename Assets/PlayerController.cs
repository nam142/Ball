using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset idle, like, hurt,sad;

    public GameObject enemy;

    public string currenState;
    public string currentAnimation;
    public float jumpForce;
    public bool isground;
    public float speed;
    private float moventspeed;
    Rigidbody2D rb;

    GameController m_gc;
    private void Awake()
    {
        if(instance == null)
        {
        instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        currenState = "idle";
        SetChangeState(currenState);
        rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        //enmy = FindObjectOfType<EnemyAgro>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isground)
        {
            isground = false;
            rb.AddForce(Vector2.up * jumpForce);
        }
        Move();
    }
    public void Move()
    {
        moventspeed = Input.GetAxisRaw("Horizontal");
       
        rb.velocity = new Vector2(moventspeed * speed, rb.velocity.y);
        
        if (moventspeed != 0)
        {
            SetChangeState("like");
        }
        else
        {
            SetChangeState("idle");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isground = true;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Vector2 diffrence = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + diffrence.x, transform.position.y + diffrence.y);
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            m_gc.ScoreIncrement();
            Destroy(collision.gameObject);
        }
        if(collision.tag == "heartenemy")
        {
            Vector2 diffrence = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + diffrence.x, transform.position.y + diffrence.y);
            Destroy(enemy);
        }

    }    

    private void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("startposition").transform.position;
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        //AnimationReferenceAsset       
        if (animation.name.Equals(currentAnimation))
        {
            return;
        }
        SkeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
        currentAnimation = animation.name;
    }
    public void SetChangeState(string state)
    {
        if (state.Equals("idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        else if (state.Equals("like"))
        {
            SetAnimation(like, true, 1f);
        }
        else if (state.Equals("hurt"))
        {
            SetAnimation(hurt, true, 1f);
        }
        else if (state.Equals("sad"))
        {
            SetAnimation(sad, true, 1f);
        }
    }

   
}
