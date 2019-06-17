using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    public List<int> inventory;

    public int dano;

    public int defesa;

    public int vida;

    GameObject gerenciador;
    // Start is called before the first frame update
    void Start()
    {

        gerenciador = GameObject.Find("Gerenciador");


        if (gerenciador == null) {
            Debug.LogError("Não gerenciador");
        }
        dano = 0;
        defesa = 0;
        vida = 0;

        rb = GetComponent<Rigidbody>();

        if(rb == null) {
            Debug.LogError("Não tem Rigidbody neste compomente");
        }

       

        inventory = new List<int>(5);

        if (PlayerPrefs.HasKey("invetory")) { 
            inventory.AddRange(
                JsonHelper.FromJson<int>(PlayerPrefs.GetString("invetory")));
        }

        for (int i = 0; i < inventory.Count; i++) {
            UpdateStatus(inventory[i]);
        }

    }

  
    void UpdateStatus(int id) {
        Debug.Log("entrou aqui" + gerenciador.GetComponent<GerenciadorScript>().itens.Count);
        foreach (Item item in gerenciador.GetComponent<GerenciadorScript>().itens) {
          
            if (item.id == id) {
                defesa += item.defesa;
                dano += item.dano;
            }
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
             UpdateStatus(other.gameObject.GetComponent<Item>().id);
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
