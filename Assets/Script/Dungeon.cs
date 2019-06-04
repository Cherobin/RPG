using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    public int id;
    public float posX;
    public float posZ; // no arquivo esta no Y
    public int idPersonagem;
    public int qtdade;
    public int tempoDeSpawn;
    public string nome;
    public int raio = 10;
    public float timer = 0;

    private GerenciadorBehaviourScript gerenciador;


   
    // Start is called before the first frame update
    void Start()
    {

        name = nome;
   

        gerenciador = GameObject.Find("Gerenciador").GetComponent<GerenciadorBehaviourScript>();

        if (gerenciador == null)
        {
            Debug.Log("não gerenciador");
        }

        criaInimigo(); 

    }

    void criaInimigo() {

        for (int i = 0; i < gerenciador.inimigos.Count; i++)
        {
            // Debug.Log(gerenciador.inimigos[i].nome);
            if (idPersonagem == gerenciador.inimigos[i].id)
            {
                for (int e = 0; e < qtdade; e++)
                {
                    int posAux = Random.Range(0, 10);

                    var novoInimigo = Instantiate(
                        gerenciador.mergeInimigo(gerenciador.inimigos[i]),
                        new Vector3(posX + posAux, 0.5f, posZ + posAux),
                     Quaternion.identity);

                    novoInimigo.transform.parent = transform;

                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(posX, 0, posZ);

        //Debug.Log("qtdade: " + qtdade + " - " + transform.childCount);
        if (qtdade > transform.childCount)
        {
            timer += Time.deltaTime;
            // Debug.Log("timer: "+ timer + " - " + tempoDeSpawn);
            if (timer > tempoDeSpawn)
            {
                criaInimigo();
                timer = 0;
                //Debug.Log("Criou Inimigo");
            }
        }

    }
}
