using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float x_offset = 0f;
    [SerializeField] float x_bound_left = 0f;
    [SerializeField] float x_bound_right = 0f;
    [SerializeField] float y_lock = 0f;
    Transform tf;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>(); 
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (x_bound_left > player.transform.position.x - x_offset)
        {
            tf.position = new Vector3(x_bound_left, y_lock, tf.position.z);

        }
        else if (x_bound_right < player.transform.position.x + x_offset)
        {
            tf.position = new Vector3(x_bound_right, y_lock, tf.position.z);
        }
        else
        {
            tf.position = new Vector3(player.transform.position.x + x_offset, y_lock, tf.position.z);

        }

    }
}
