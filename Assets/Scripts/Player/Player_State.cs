using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_State : MonoBehaviour
{
    [SerializeField] public bool is_alive;
    [SerializeField] float max_death_time;
    public bool is_grounded;
    public bool calm;
    public bool can_traverse;
    public float check_x;
    public float check_y;
    float death_timer = 0f;

    // Animations
    string PLAYER_IDLE = "Player_Idle";
    string PLAYER_WALK = "Player_Walk";
    string PLAYER_RUN = "Player_Run";
    string PLAYER_JUMP = "Player_Jump";
    string PLAYER_FALL = "Player_Fall";

    
    Player_Controller pC;
    SpriteRenderer sr;
    Rigidbody2D rb2d;
    BoxCollider2D pbox;
    Animator animator;
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        is_alive = true;  
        can_traverse = false;
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        pbox = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        pC = GetComponent<Player_Controller>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_alive)
        {
            PlayAnimation();
        }
        else
        {
            if (death_timer >= max_death_time)
            {
                death_timer = 0f;
                ResetState();
            }
            death_timer += Time.deltaTime;
            animator.Play(PLAYER_IDLE);
        }
    }

    public void DeathSequence()
    {
        sr.color = Color.red;
        rb2d.velocity = new Vector2(0, 20);
        pbox.enabled = false;
            
    }

    public void ResetState()
    {
        sr.color = Color.white;
        pbox.enabled = true;
        is_alive = true;
        tf.position = new Vector3(check_x, check_y, tf.position.z);
        
    }

    void PlayAnimation()
    {
        if (rb2d.velocity.x != 0)
        {
            if (is_grounded)
            {
                GroundMovementAnim();
            }
            sr.flipX = (rb2d.velocity.x < 0);
        }
        else if (rb2d.velocity.x == 0 && is_grounded)
        {
            animator.Play(PLAYER_IDLE);
        }

        if (rb2d.velocity.y != 0 && !is_grounded)
        {
            JumpMovementAnim();
        }


    }

    private void JumpMovementAnim()
    {
        if (rb2d.velocity.y >= 0)
        {
            animator.Play(PLAYER_JUMP);
        }
        else
        {
            animator.Play(PLAYER_FALL);
        }
    }

    private void GroundMovementAnim()
    {
        if (pC.speed == pC.walk_speed)
        {
            animator.Play(PLAYER_WALK);
        }
        else if (pC.speed == pC.sprint_speed)
        {
            animator.Play(PLAYER_RUN);
        }
    }
}
