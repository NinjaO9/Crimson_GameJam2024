using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Script : MonoBehaviour
{
    [SerializeField] GameObject player;
    Player_State player_state;
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        player_state = player.GetComponent<Player_State>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player_state.check_x = tf.position.x;
        player_state.check_y = tf.position.y;
    }
}
