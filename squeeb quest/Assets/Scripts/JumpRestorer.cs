using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRestorer : MonoBehaviour
{
    [SerializeField]
    private CharacterController playerController;

    [SerializeField]
    private float delay = 0f;
    private float timer = 0f;

    bool restored = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (restored)
        {
            timer += Time.deltaTime;

            if (timer > delay)
            {
                timer = 0f;
                restored = false;
            }
        }
    }
     
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (restored == false && collision.gameObject == playerController.gameObject)
        {
            if (!playerController.jumped)
            {
                playerController.Jumps = playerController.MaxJumps;
            }

            restored = true;
         
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
