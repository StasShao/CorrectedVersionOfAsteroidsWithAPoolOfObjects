using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public Transform pl;
    public GameObject[] gameOver;
    HpPlayer hp;
    PolygonCollider2D col;
    SpriteRenderer sprite;
    GameObject player;
    
   void Start()
   {
       hp = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpPlayer>();
       startOn();
   }
    public void startOn()
    { 
        if(hp.hpRange <= 0)
        {
        foreach(GameObject game in gameOver)
        {
          game.SetActive(true);
        }
        return;
        }
        StartCoroutine(Spawn());
    }
    
    public IEnumerator Spawn ()
    {
       yield return new WaitForSeconds (2);
       Instantiate (pl, transform.position, Quaternion.identity);
       player = GameObject.FindGameObjectWithTag("Player");
       sprite = player.GetComponent<SpriteRenderer>();
       col = player.GetComponent<PolygonCollider2D>();
       StartCoroutine(swichRenderer());
       col.enabled = false;

       yield return new WaitForSeconds (3);
       col.enabled = true;
      
    }
    IEnumerator swichRenderer()
    {
        if(player)
        {
        yield return new WaitForSeconds (0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds (0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds (0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds (0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds (0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds (0.2f);
        sprite.enabled = true;
        }
    }
}
