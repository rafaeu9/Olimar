using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
	private GameManager game;
	// Start is called before the first frame update
    void Start()
    {
	    game = GameManager.instance;
    }

    // Update is called once per frame
	void OnTriggerEnter2D(Collider2D coll)
    {
	    if(coll.CompareTag("Goal"))
	    {
	    	game.ClearMatch(this.gameObject);
	    }
    }
    
}
