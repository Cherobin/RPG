using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDBehaviourScript : MonoBehaviour
{
    public Text dano;
    public Text defesa;
    public Text vida;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) {
            Debug.LogError("Sem Ref player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "" + player.GetComponent<Player>().vida;
        defesa.text = "" + player.GetComponent<Player>().defesa;
        dano.text = "" + player.GetComponent<Player>().dano;
    }
}
