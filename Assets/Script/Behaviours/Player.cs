using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    public GameObject[] todos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(rb == null) {
            Debug.LogError("Não tem Rigidbody neste compomente");
        }

        todos = GameObject.FindGameObjectsWithTag("Pick Up");


    }

    public void setColor (Color color) {

        Debug.Log(color);

        GetComponent<MeshRenderer>().material.color = color;
      

    }
    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            if(GetComponent<MeshRenderer>().material.color ==
                other.GetComponent<MeshRenderer>().material.color) { 
                 other.gameObject.SetActive(false);

                mudaCor();
                // other.gameObject
                //Destroy(other.gameObject);
            }
        }
    }

    void mudaCor() {


        foreach (var item in todos)
        {
            if (item.gameObject.activeSelf)
            {
                GetComponent<MeshRenderer>().material.color =
                    item.GetComponent<MeshRenderer>().material.color;
            } else {
                Debug.Log("Você Ganhou ");
            }
        }

    }
}
