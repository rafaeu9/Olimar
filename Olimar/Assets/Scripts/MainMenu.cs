using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject mainScreen;
	public GameObject levelScreen;
    // Start is called before the first frame update
	public void LoadLevel(int levelID)
	{
		SceneManager.LoadScene(levelID);
	}
	
	public void SwapMenu()
	{
		mainScreen.SetActive(!mainScreen.activeSelf);
		levelScreen.SetActive(!levelScreen.activeSelf);
	}
}
