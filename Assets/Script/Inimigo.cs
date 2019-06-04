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
    public int dropChance;

    private GerenciadorBehaviourScript gerenciador;

    private void Start()
    {

        gerenciador = GameObject.Find("Gerenciador").GetComponent<GerenciadorBehaviourScript>();

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
            int rnd = UnityEngine.Random.Range(0, 100);
            
             if (rnd <= dropChance)
                {
                //criar um item
                //pegar o valor total de itens e dar um rnd dessa lista
                int rndItem = UnityEngine.Random.Range(0, itens.Length);
                criaItem(itens[rndItem]);
                }

            Destroy(gameObject);

        }
    }
    //tenho que receber um ID
    void criaItem(int auxID)
    {
        //vendo toda a minha lista de itens carregado, e tenho que achar o ID igual.
        for (int i = 0; i < gerenciador.itens.Count; i++)
        {
            // achou o id correto, cria!
            if (auxID == gerenciador.itens[i].id)
            {
               
                    var novoItem = Instantiate(
                        gerenciador.mergeItem(gerenciador.itens[i]),
                        new Vector3(transform.position.x, 0.5f, transform.position.z),
                     Quaternion.identity);

                    //novoInimigo.transform.parent = transform;

                
            }
        }

    }

}
