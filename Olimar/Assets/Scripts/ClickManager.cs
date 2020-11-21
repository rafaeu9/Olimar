using UnityEngine;
using System.Collections;

public class ClickManager : MonoBehaviour {

	public static bool playMode = false;
	public bool mouseDown = false;
	private Vector3 mousePos;
	private Vector2 mousePos2D;
	
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			if(!mouseDown && !playMode)
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePos2D = new Vector2(mousePos.x, mousePos.y);
				mouseDown = true;
				RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
				if (hit.collider != null) 
				{
					if(!hit.collider.gameObject.CompareTag("Match")&&!hit.collider.gameObject.CompareTag("Goal"))
					{
						StartCoroutine(DragObject(hit.collider.gameObject));
					}
				}
			}
		}
		if (Input.GetMouseButtonUp(0)) 
		{
			mouseDown = false;
		}
	}
	
	public IEnumerator DragObject(GameObject item)
	{
		Vector3 offset = item.transform.position - mousePos;
		while(mouseDown && !playMode)
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos2D = new Vector2(mousePos.x, mousePos.y);
			item.transform.position = mousePos + offset;
			yield return new WaitForSeconds(0.01f);
		}
	}
}