using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlatform_Script : MonoBehaviour
{
    BoxCollider2D box;
    [SerializeField] GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platform.GetComponent<BoxCollider2D>().enabled = true;
    }
}
