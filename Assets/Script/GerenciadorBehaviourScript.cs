using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorBehaviourScript : MonoBehaviour
{


    //cria a ref do prefab do personagem
    public GameObject prefPersonagem;

    //cria a ref do prefab da dungeon
    public GameObject prefDungeon;

    //cria a lista de todos os inimigos
    public List<Inimigo> inimigos = new List<Inimigo>();

    //cria a lista de todas as dungeons
    public List<Dungeon> dungeons = new List<Dungeon>();


    //aqui justamos as informações do inimigo com o prefab. E retornamos
    public GameObject mergeInimigo(Inimigo ini) {
        /*
         * aqui estamos pegando o script do prefab inimigo que é o ini, e 
          estamos colocando os valores especificos para cadas atributo. 
        */       
        prefPersonagem.GetComponent<Inimigo>().id = ini.id;
        prefPersonagem.GetComponent<Inimigo>().nome = ini.nome;
        prefPersonagem.GetComponent<Inimigo>().tipo = ini.tipo;
        prefPersonagem.GetComponent<Inimigo>().familia = ini.familia;
        prefPersonagem.GetComponent<Inimigo>().vida = ini.vida;
        prefPersonagem.GetComponent<Inimigo>().dano = ini.dano;

        return prefPersonagem;

    } 
}
