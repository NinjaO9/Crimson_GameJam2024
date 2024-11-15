using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb2d;
    Transform tf;
    Animator animator;
    AudioSource audioSource;

    [SerializeField] public float walk_speed = 5f;
    [SerializeField] public float sprint_speed = 10f;
    [SerializeField] float jump_force = 1f;
    [SerializeField] float max_fall_speed = 6f;
    //[SerializeField] float gravity = 3f;
    public float speed;
    bool can_play;

    Player_State state;
    // Start is called before the first frame update
    void Start()
    {
        speed = walk_speed;
        rb2d = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        state = GetComponent<Player_State>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = walk_speed;
        if (state.is_alive)
        {
            GetInput();
            if (rb2d.velocity.x == 0 || rb2d.velocity.y != 0)
            {
                audioSource.Stop();
                can_play = true;
            }
            else if (can_play && rb2d.velocity.y == 0)
            {
                can_play = false;
                audioSource.Play();
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.R)) // Debug reset to default pos
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {

        JumpPhysics();

    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (state.is_grounded && !state.calm))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump_force); 
            state.is_grounded = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && !state.calm)
        {
            speed = sprint_speed;
        }
        //Debug.Log($"Speed: {speed}");
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);

    }

    void JumpPhysics()
    {
        if (rb2d.velocity.y <= 0 && !state.is_grounded)
        {
            rb2d.AddForce(new Vector2(0, -rb2d.gravityScale));
        }
        if (rb2d.velocity.y < -max_fall_speed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -max_fall_speed);
        }
    }
}
