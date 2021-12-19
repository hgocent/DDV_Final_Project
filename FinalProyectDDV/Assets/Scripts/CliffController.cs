using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffController : MonoBehaviour
{
    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag.Substring(0, 6) == "Player") //if (other.gameObject.tag == "PlayerL1")
        {
            player_events.OnPlayerCliff();
        }
    }
    
}
