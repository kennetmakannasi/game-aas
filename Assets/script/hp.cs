using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    public Player Player;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: "+ Player.health + "/100";
        if(Player.health < 0){
            hpText.text = "HP: 0/100";
        }
    }
}
