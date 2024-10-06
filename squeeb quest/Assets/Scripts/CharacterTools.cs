using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterTools : MonoBehaviour
{
    [SerializeField]
    GenericConfettiCreator confettiCreator;

    [SerializeField]
    CircleCollider2D confettiTriggerZone;

    [SerializeField]
    CharacterController characterController;

    bool confettiCollected = false;
    bool flowerCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUseFlower(InputAction.CallbackContext context)
    {

    }

    public void OnUseConfetti(InputAction.CallbackContext context)
    {
        confettiCreator.Confetti();
        confettiTriggerZone.enabled = false;


    }
}
