using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Scipt : MonoBehaviour
{
    [SerializeField] GameObject player;
    Player_State state;
    // Start is called before the first frame update
    void Start()
    {
        state = player.GetComponent<Player_State>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            state.is_alive = false;
            state.DeathSequence();
        }
    }
}
