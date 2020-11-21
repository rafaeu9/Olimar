using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private Vector3 startPos;
	private GameManager game;
	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		startPos = transform.position;
		game = GameManager.instance;
	}
	
	public void StartSim()
	{
		startPos = transform.position;
		rb2d.bodyType = RigidbodyType2D.Dynamic;
	}
    
	public void Reset()
	{
		rb2d.velocity = Vector3.zero;
		rb2d.bodyType = RigidbodyType2D.Static;
		transform.position = startPos;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
