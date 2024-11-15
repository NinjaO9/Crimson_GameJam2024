using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BG_Script : MonoBehaviour
{
    [SerializeField] float speed;
    Transform camera_tf;
    float start_x;
    float sprite_size = 0f;
    [SerializeField] GameObject target_sprite;
    float bg_distance;
    float camera_distance;
    

    // Start is called before the first frame update
    void Start()
    {
        camera_tf = Camera.main.transform;
        start_x = transform.position.x;
        if (target_sprite == null)
        {
            sprite_size = GetComponent<SpriteRenderer>().bounds.size.x;

        }
        else
        {
            sprite_size = target_sprite.GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bg_distance = camera_tf.position.x * speed;
        transform.position = new Vector3(start_x + bg_distance, transform.position.y, transform.position.z);

        camera_distance = camera_tf.position.x * (1 - speed);
        if (camera_distance > start_x + sprite_size)
        {
            start_x += sprite_size;
        }
        else if (camera_distance < start_x - sprite_size)
        {
            start_x -= sprite_size;
        }
    }
}
