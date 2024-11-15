using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class F_Check_Script : MonoBehaviour
{
    Player_State state;
    [SerializeField] GameObject player;
    [SerializeField] float cyote_time = 0.5f;
    float jump_time;
    bool floor_detected;
    // Start is called before the first frame update
    void Start()
    {
        state = player.GetComponent<Player_State>();
        jump_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state.is_grounded == true && floor_detected == false) // Player didn't jump, yet they are airborne (Likely at ledge, falling)
        {
            ApplyCyoteTime();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Peaceful"))
        {
            state.calm = true;
        }
        else
        {
            state.calm = false;
        }
        state.is_grounded = true;
        floor_detected = true;
        jump_time = 0f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            floor_detected = false;
        }
    }

    void ApplyCyoteTime()
    {
        if (jump_time >= cyote_time)
        {
            state.is_grounded = false;
            jump_time = 0f;
        }
        else
        {
            jump_time += Time.deltaTime;
           // Debug.Log($"Jump_Time: {jump_time}  | cyote_time: {cyote_time}");
        }
    }
}
