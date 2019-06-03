using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inimigo : MonoBehaviour

{

    public int id;
    public string nome;
    public string tipo;
    public string familia;
    public int vida;
    public int dano;
    public int[] itens;
   
    private void Start()
    {
        //coloco o nome do inimigo como nome do prefab tbm
        gameObject.name = nome;
    }


    // Update is called once per frame
    void Update()
    {
      //  transform.position = new new Vector3(15, 30, 45);

       transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);

        }
    }
 
}
