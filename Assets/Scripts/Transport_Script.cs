using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Script : MonoBehaviour
{
    [SerializeField] string destination_scene;
    [SerializeField] GameObject player;
    [SerializeField] GameObject visual_prompt;
    Player_State player_state;
    // Start is called before the first frame update
    void Start()
    {
        player_state = player.GetComponent<Player_State>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player_state.can_traverse)
        {
            SceneManager.LoadScene(destination_scene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player_state.can_traverse = true;
        visual_prompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_state.can_traverse = false;
        visual_prompt.SetActive(false);
    }
}
