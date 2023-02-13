using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Controller : MonoBehaviour
{

    public float targetTime = 0;  

    [SerializeField] private float speed;
    private bool tamañoPersonaje = true; 



    void Start()
    {
        targetTime = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
            
        }

        else
        {

            Debug.Log("Tiempo terminado");
            targetTime= 0;
        }

        float horizontalInput = Input.GetAxis ("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0, verticalInput);
        transform.position = transform.position + movementDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entraste en contacto con  " + other.gameObject.name);
        Debug.Log(targetTime);

        if (targetTime == 0)
        {
           
            Debug.Log("Contador activado" + other.gameObject.name);
            timerStart();

            if (tamañoPersonaje)
            {
                transform.localScale = transform.localScale / 2;
                tamañoPersonaje= false;
            }
            else
            {
                transform.localScale = transform.localScale * 2;
                tamañoPersonaje= true;
            }
        }
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
      //  Debug.Log("Entraste en contacto con " + collision.gameObject.name); 
    //}

     void timerEnded()
    {
        Debug.Log("Tiempo cumplido"); 

    }

    void timerStart()
    {
        targetTime = 5;
        Debug.Log("Contador activado");

    }
}
