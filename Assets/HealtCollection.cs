using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtCollection : MonoBehaviour
{
    [SerializeField] private float healthValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Heart>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
