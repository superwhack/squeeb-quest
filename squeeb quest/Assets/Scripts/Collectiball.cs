using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectiball : MonoBehaviour
{
    [SerializeField]
    private GlobalController globalController;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            globalController.OnCollectiballCollect();
            this.gameObject.SetActive(false);
        }
    }
}
