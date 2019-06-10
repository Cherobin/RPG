using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Item : MonoBehaviour
{

    public int id;
    public string nome;
    public string tipo;  
    public int dano;
    public int defesa;

    // Start is called before the first frame update
    void Start()
    {
        // colocando o nome do prefab com o nome do item
        name = nome;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnGUI()
    {
        //Use a Câmera Principal e obtenha a posição do objeto atual
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Cria o label
        GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 100, 50), nome);
    }
}
