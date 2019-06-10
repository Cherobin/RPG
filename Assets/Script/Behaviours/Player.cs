using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    public List<int> inventory;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(rb == null) {
            Debug.LogError("Não tem Rigidbody neste compomente");
        }


        inventory = new List<int>(5);

        if (PlayerPrefs.HasKey("invetory")) { 
            inventory.AddRange(
                JsonHelper.FromJson<int>(PlayerPrefs.GetString("invetory")));
        }
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
        if (other.gameObject.CompareTag("Item"))
        {
            if(inventory.Count <= 5) {  
             inventory.Add(other.gameObject.GetComponent<Item>().id);
             Destroy(other.gameObject, 0.5f);
                saveInventory();
            }
        }
    }

    void saveInventory() {
        string inv = JsonHelper.ToJson<int>(inventory.ToArray());
        PlayerPrefs.SetString("invetory", inv);
        PlayerPrefs.Save();
    }

}
