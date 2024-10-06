using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenericConfettiCreator : MonoBehaviour
{
    [SerializeField]
    int confettiNumber = 10;

    [SerializeField]
    GameObject particle1;

    [SerializeField]
    GameObject particle2;

    [SerializeField]
    GameObject particle3;

    [SerializeField]
    GameObject defaultParticle;

    [SerializeField]
    float frequency1, frequency2, frequency3;

    List<GameObject> confettiList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        defaultParticle.SetActive(false);
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Confetti()
    {
        
        for (int i  = 0; i < confettiList.Count; i++) 
        {
            Destroy(confettiList[i]);
        }
        confettiList.Clear();

        for (int i = 0; i < confettiNumber; i++)
        {
            GameObject confettiPiece = Instantiate(RandomConfettiObject());

            Rigidbody2D rb = confettiPiece.GetComponent<Rigidbody2D>();
            
            confettiPiece.transform.position = transform.position;

            confettiPiece.transform.localScale = RandomScale(8, 13);

            confettiPiece.transform.rotation = RandomRotation(-15, 15);

            Vector2 confettiDirection = new Vector2(Random.Range(-50, 50), Random.Range(30, 100)).normalized;

            confettiList.Add(confettiPiece);

            confettiPiece.SetActive(true);

            rb.AddForce(confettiDirection * Random.Range(20, 40));
        }
    }

    private GameObject RandomConfettiObject()
    {
        float randomConfettiNum = Random.Range(0, 11) / 10f;

        Debug.Log(randomConfettiNum);
        if (randomConfettiNum < frequency3)
        {
            return particle3;
        }
        else if (randomConfettiNum < frequency2)
        {
            return particle2;
        }
        else if (randomConfettiNum < frequency1)
        {
            return particle1;
        }
        else
        {
            return defaultParticle;
        }
    }

    private Quaternion RandomRotation(int min, int max)
    {
        return Quaternion.Euler(new Vector3(0, 0, Random.Range(min, max)));
    }    

    private Vector2 RandomScale(int min, int max)
    {
        float scale = Random.Range(min, max) / 10f;
        return new Vector2(scale, scale);
    }


}
