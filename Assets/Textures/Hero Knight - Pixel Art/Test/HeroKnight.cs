﻿using UnityEngine;
using System.Collections;

public class HeroKnight : MonoBehaviour {


    public static HeroKnight instance;

    float m_speed = 20f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      m_rollForce = 6.0f;
    [SerializeField] bool       m_noBlood = false;
    public GameObject m_marker;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_HeroKnight   m_groundSensor;
    private Sensor_HeroKnight   m_wallSensorR1;
    private Sensor_HeroKnight   m_wallSensorR2;
    private Sensor_HeroKnight   m_wallSensorL1;
    private Sensor_HeroKnight   m_wallSensorL2;

    private Sensor_HeroKnight m_wallSensorLC;
    private Sensor_HeroKnight m_wallSensorRC;
    private Sensor_HeroKnight m_wallSensorGC;
    private Sensor_HeroKnight m_wallSensorUC;

    private bool                m_isWallSliding = false;
    private bool                m_grounded = false;
    private bool                m_rolling = false;

    private int                 m_facingDirection = 0;

    private int m_facingDirectionY = 0;

    private int                 m_currentAttack = 0;
    private float               m_timeSinceAttack = 0.0f;
    private float               m_delayToIdle = 0.0f;
    private float               m_rollDuration = 8.0f / 14.0f;
    private float               m_rollCurrentTime;


    private float inputX = 0;
    private float inputY = 0;

    void Start ()
    {
        instance = this;
        // gameObject.transform.position = new Vector3(-8.081f, -2.682f, 0);
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
       // m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR1 = transform.Find("WallSensor_R1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR2 = transform.Find("WallSensor_R2").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL1 = transform.Find("WallSensor_L1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL2 = transform.Find("WallSensor_L2").GetComponent<Sensor_HeroKnight>();
        m_wallSensorRC = transform.Find("WallSensor_RC").GetComponent<Sensor_HeroKnight>();
        m_wallSensorLC = transform.Find("WallSensor_LC").GetComponent<Sensor_HeroKnight>();
        m_wallSensorUC = transform.Find("WallSensor_UC").GetComponent<Sensor_HeroKnight>();
        m_wallSensorGC = transform.Find("WallSensor_GC").GetComponent<Sensor_HeroKnight>();

    }



    void Update ()
    {
        // Increase timer that controls attack combo
        m_timeSinceAttack += Time.deltaTime;

        // Increase timer that checks roll duration
        if(m_rolling)
            m_rollCurrentTime += Time.deltaTime;

        // Disable rolling if timer extends duration
        if(m_rollCurrentTime > m_rollDuration)
            m_rolling = false;

        //Check if character just landed on the ground
       // if (!m_grounded && m_groundSensor.State())
      //  {
      //      m_grounded = true;
       //     m_animator.SetBool("Grounded", m_grounded);
      //  }

        //Check if character just started falling
        //if (m_grounded && !m_groundSensor.State())
        //{
         //   m_grounded = false;
          //  m_animator.SetBool("Grounded", m_grounded);
      //  }

        // -- Handle input and movement 
        
        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
            m_facingDirectionY = 0;
        }
            
        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
            m_facingDirectionY = 0;
        }


        if (inputY > 0)
        {
            m_facingDirectionY = 1;
            m_facingDirection = 0;
        }

        else if (inputY < 0)
        {
            m_facingDirectionY = -1;
            m_facingDirection = 0;
        }


        //Set AirSpeed in animator
        //m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        // -- Handle Animations --
        //Wall Slide
        m_isWallSliding = (m_wallSensorR1.State() && m_wallSensorR2.State()) || (m_wallSensorL1.State() && m_wallSensorL2.State());
        m_animator.SetBool("WallSlide", m_isWallSliding);

        //Death
        if (Input.GetKeyDown("{") && !m_rolling)
        {
            m_animator.SetBool("noBlood", m_noBlood);
            m_animator.SetTrigger("Death");
        }
            
        //Hurt
       // else if (Input.GetKeyDown("q") && !m_rolling)
      //      m_animator.SetTrigger("Hurt");

        //Attack
        //else if(Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.25f && !m_rolling)
       // {
       //     m_currentAttack++;

            // Loop back to one after third attack
       //     if (m_currentAttack > 3)
          //      m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
        //    if (m_timeSinceAttack > 1.0f)
       //         m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
       //     m_animator.SetTrigger("Attack" + m_currentAttack);

            // Reset timer
       //     m_timeSinceAttack = 0.0f;
      //  }

        // Block
        // else if (Input.GetMouseButtonDown(1) && !m_rolling)
        // {
        //     m_animator.SetTrigger("Block");
        //     m_animator.SetBool("IdleBlock", true);
        // }

        // else if (Input.GetMouseButtonUp(1))
        //     m_animator.SetBool("IdleBlock", false);

        // Roll
       // else if (Input.GetKeyDown("left shift") && !m_rolling && !m_isWallSliding)
       // {
       //     m_rolling = true;
       //     m_animator.SetTrigger("Roll");
       //     m_body2d.velocity = new Vector2(m_facingDirection * m_rollForce, m_body2d.velocity.y);
      //  }
            

        //Jump
       // else if (Input.GetKeyDown("space") && m_grounded && !m_rolling)
      //  {
     //       m_animator.SetTrigger("Jump");
     //       m_grounded = false;
     //       m_animator.SetBool("Grounded", m_grounded);
       //     m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
       //     m_groundSensor.Disable(0.2f);
      //  }

        //Run
     //   else if (Mathf.Abs(inputX) > Mathf.Epsilon)
     //   {
            // Reset timer
   //         m_delayToIdle = 0.05f;
   //         m_animator.SetInteger("AnimState", 1);
   //     }

        //Idle
        // else
        // {
        //     // Prevents flickering transitions to idle
        //     m_delayToIdle -= Time.deltaTime;
        //         if(m_delayToIdle < 0)
        //             m_animator.SetInteger("AnimState", 0);
        // }
    }

    // Animation Events
    // Called in slide animation.
    void Marker()
    {
        Vector3 spawnPosition;

        if (m_facingDirection == 1)
            spawnPosition = m_wallSensorLC.transform.position;
        else if(m_facingDirection == -1)
            spawnPosition = m_wallSensorRC.transform.position;
        else if (m_facingDirectionY == 1)
            spawnPosition = m_wallSensorGC.transform.position;
        else
            spawnPosition = m_wallSensorUC.transform.position;

        // Set correct arrow spawn position
        GameObject marker = Instantiate(m_marker, spawnPosition, gameObject.transform.localRotation) as GameObject;
            // Turn arrow in correct direction
            marker.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    public void Move_Right()
    {
        inputX = 10f;
        inputY = 0;
        transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
        // if (!m_rolling)
        // {
        //     Vector3 movement = new Vector3(Mathf.Ceil(inputX * m_speed * Time.deltaTime) - 0.5f, Mathf.Ceil(inputY * m_speed * Time.deltaTime), 0);
        //     transform.position = transform.position + movement;
        //    // Marker();
        //     //m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        //     //Debug.Log("right");  
        // }


    }

    public void Move_Left()
    {
        inputX = -10f;
        inputY = 0;
        transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);

        // if (!m_rolling)
        // {
        //     Vector3 movement = new Vector3(Mathf.Floor(inputX * m_speed * Time.deltaTime) + 0.5f, Mathf.Floor(inputY * m_speed * Time.deltaTime), 0);
        //     transform.position = transform.position + movement;
        //   //  Marker();
        // }
            //m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        //Debug.Log("left");
    }


    public void Move_Up()
    {
        inputX = 0;
        inputY = 10f;
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);

        // if (!m_rolling)
        // {
        //     Vector3 movement = new Vector3(Mathf.Ceil(inputX * m_speed * Time.deltaTime), Mathf.Ceil(inputY * m_speed * Time.deltaTime) - 0.5f, 0);
        //     transform.position = transform.position + movement;
        //    // Marker();
        //     // Debug.Log(gameObject.transform.position.y);
        //     //m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        //     //Debug.Log("right");  
        // }


    }


    public void Move_Down()
    {
        inputX = 0;
        inputY = -10f;
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);

        // if (!m_rolling)
        // {
        //     Vector3 movement = new Vector3(Mathf.Floor(inputX * m_speed * Time.deltaTime), Mathf.Floor(inputY * m_speed * Time.deltaTime) + 0.5f, 0);
        //     transform.position = transform.position + movement;
        //    // Marker();
        //     //m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        //     //Debug.Log("right");  
        // }


    }

}
