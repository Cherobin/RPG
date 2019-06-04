using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorBehaviourScript : MonoBehaviour
{



    //cria a ref da lista de item
    public GameObject prefListaItens;

    //cria a ref do prefab do personagem
    public GameObject prefPersonagem;

    //cria a ref do prefab do item
    public GameObject prefItem;

    //cria a ref do prefab da dungeon
    public GameObject prefDungeon;

    //cria a lista de todos os inimigos
    public List<Inimigo> inimigos = new List<Inimigo>();

    //cria a lista de todas as dungeons
    public List<Dungeon> dungeons = new List<Dungeon>();

    //cria a lista de todos os itens
    public List<Item> itens = new List<Item>();

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
        prefPersonagem.GetComponent<Inimigo>().itens = ini.itens;
        prefPersonagem.GetComponent<Inimigo>().dropChance = ini.dropChance;
        return prefPersonagem;

    }


    //aqui justamos as informações do item com o prefab. E retornamos
    public GameObject mergeItem(Item item)
    {
        /*
         * aqui estamos pegando o script do prefab item que é o item, e 
          estamos colocando os valores especificos para cadas atributo. 
        */
        prefItem.GetComponent<Item>().id = item.id;
        prefItem.GetComponent<Item>().nome = item.nome;
        prefItem.GetComponent<Item>().tipo = item.tipo; 
        prefItem.GetComponent<Item>().dano = item.dano;
        prefItem.GetComponent<Item>().defesa = item.defesa; 
        return prefItem;

    }
}
