using UnityEngine;

public class Item : MonoBehaviour
{

    [HideInInspector] public int id;
    [HideInInspector] public string nome;
    [HideInInspector] public string tipo;
    [HideInInspector] public int dano;
    [HideInInspector] public int defesa;

    // Start is called before the first frame update
    private void Start()
    {
        // colocando o nome do prefab com o nome do item
        name = nome;
    }

    private void OnGUI()
    {
        //Use a Câmera Principal e obtenha a posição do objeto atual
        var screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Cria o label
        GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 100, 50), nome);
    }
}
