using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeitorCSVScript : MonoBehaviour
{
 
    public GameObject prefDungeon;
    public GameObject listaDeDungeon;

    private GerenciadorScript gerenciador;

    void Awake()
    {

        gerenciador = gameObject.GetComponent<GerenciadorScript>();

        if(gerenciador == null) {
            Debug.Log("gerenciador null no Leitor de CSV");
        } else { 
            //se não for nulo, carrega a Dungeon e os Personagens
            carregaDungeon(); 
            carregaPersonagens();
            carregaItens();
        }

    }

    // função que carrega todos os personagens do CSV
    void carregaPersonagens()
    {

        //nome do arquivo dos personagens é Personagens, ele deve estar dentro na pastas
        // Resouces
        TextAsset leArquivo = Resources.Load<TextAsset>("Personagens");

        if (leArquivo == null)
        {
            Debug.Log("não leu arquivo no gerenciador Personagem");
        }
        else
        {
            Debug.Log("leu arquivo de csv Personagem");
        }




        string[] data = leArquivo.text.Split('\n');

        //começa pelo 1 pq ele avisa quais são meus parametros;
        for (int i = 1; i < data.Length; i++)
        {
            //Debug.Log(data[i]);
            string[] valor = data[i].Split(';');

            //cria inimigo (classe) na lista- não temos o prefb dele ainda
            Inimigo inimigo = new Inimigo
            {
                //seta os valores
                id = int.Parse(valor[0]),
                nome = valor[1],
                tipo = valor[2],
                familia = valor[3],
                vida = int.Parse(valor[4]),
                dano = int.Parse(valor[5]),
                //estou utilizando o JsonHelper para converter em array. O normal não tem essa função
                itens = JsonHelper.FromJson<int>(valor[6]),
                dropChance = int.Parse(valor[7])

            };

            //adiciona na lista
            gerenciador.inimigos.Add(inimigo);

        } 

    }

    // função que carrega todos os itens do CSV
    void carregaItens()
    {

        //nome do arquivo dos itens é Itens, ele deve estar dentro na pastas
        // Resouces
        TextAsset leArquivo = Resources.Load<TextAsset>("Itens");

        if (leArquivo == null)
        {
            Debug.Log("não leu arquivo no gerenciador Itens");
        }
        else
        {
            Debug.Log("leu arquivo de csv Itens");
        }
         

        string[] data = leArquivo.text.Split('\n');

        //começa pelo 1 pq ele avisa quais são meus parametros;
        for (int i = 1; i < data.Length; i++)
        {
            //Debug.Log(data[i]);
            string[] valor = data[i].Split(';');

            //cria Itens (classe) na lista- não temos o prefb dele ainda
            Item item = new Item
            {
                //seta os valores
                id = int.Parse(valor[0]),
                nome = valor[1],
                tipo = valor[2],
                dano = int.Parse(valor[3]),
                defesa = int.Parse(valor[4]),
                  
            };

            //adiciona na lista
            gerenciador.itens.Add(item);

        }

    }

    // função que carrega todas as Dungeons do CSV
    void carregaDungeon()
    {
        //nome do arquivo das dungeons é Dungeons, ele deve estar dentro na pastas
        // Resouces
        TextAsset leArquivo = Resources.Load<TextAsset>("Dungeons");

        if (leArquivo == null)
        {
            Debug.Log("não leu arquivo no gerenciador dungeon");
        }
        else
        {
            Debug.Log("leu arquivo de csv da Dungeon");
        }

        if (prefDungeon == null)
        {
            Debug.LogError(" esqueceu de colococar o dungeon como prefab no gerenciador");
        }



        string[] data = leArquivo.text.Split('\n');

        //começa pelo 1 pq ele avisa quais são meus parametros;
        for (int i = 1; i < data.Length; i++)
        {
            //Debug.Log(data[i]);
            string[] valor = data[i].Split(';');

            //seta os valores
            prefDungeon.GetComponent<Dungeon>().id = int.Parse(valor[0]);
            prefDungeon.GetComponent<Dungeon>().posX = float.Parse(valor[1]);
            prefDungeon.GetComponent<Dungeon>().posZ = float.Parse(valor[2]);
            prefDungeon.GetComponent<Dungeon>().idPersonagem = int.Parse(valor[3]);
            prefDungeon.GetComponent<Dungeon>().qtdade = int.Parse(valor[4]);
            prefDungeon.GetComponent<Dungeon>().tempoDeSpawn = int.Parse(valor[5]);
            prefDungeon.GetComponent<Dungeon>().nome = valor[6];
           

            //cria a dungeon
            Instantiate(prefDungeon, listaDeDungeon.transform);  

            //adiciona a dungeon na lista
            gerenciador.dungeons.Add(prefDungeon.GetComponent<Dungeon>());
        }
    }
}
