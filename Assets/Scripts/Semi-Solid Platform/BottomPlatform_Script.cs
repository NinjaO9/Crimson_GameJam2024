using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPlatform_Script : MonoBehaviour
{
    BoxCollider2D box;
    [SerializeField]GameObject platform;
    bool col_hit;
    float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col_hit)
        {
            Temporary_Pass();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platform.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Temporary_Pass()
    {
        if (cooldown >= 10f)
        {
            cooldown = 0f;
            platform.GetComponent <BoxCollider2D>().enabled = true;
        }
        else
        {
            cooldown += Time.deltaTime;
        }
    }

}
