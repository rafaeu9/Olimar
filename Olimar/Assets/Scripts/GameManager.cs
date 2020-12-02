using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	private GameObject[] matches;
	private ResetManager[] resetObjects;
	private GameObject startUI;
	private GameObject stopUI;
	private GameObject winUI;
	private GameObject pauseUI;
	
    // Start is called before the first frame update
	void Start()
	{
		instance = this;
		matches = GameObject.FindGameObjectsWithTag("Match");
		resetObjects = Object.FindObjectsOfType<ResetManager>();
		winUI = GameObject.FindGameObjectWithTag("Win UI");
		startUI = GameObject.FindGameObjectWithTag("Start UI");
		stopUI = GameObject.FindGameObjectWithTag("Stop UI");
		pauseUI = GameObject.FindGameObjectWithTag("Pause UI");
		ClickManager.playMode = false;
		if(winUI != null)
		{
			winUI.SetActive(false);
		}
		if(stopUI != null)
		{
			stopUI.SetActive(false);
		}
		if(pauseUI != null)
		{
			pauseUI.SetActive(false);
		}
	}

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetKeyDown(KeyCode.Escape) && pauseUI != null && !winUI.activeSelf) //pause menu
	    {
		    Pause();
	    }   
    }
    
	public void StartSimulation()
	{
		foreach (ResetManager reset in resetObjects)
		{
			reset.StartSim();
		}
		startUI.SetActive(false);
		stopUI.SetActive(true);
		ClickManager.playMode = true;
	}
	
	public void StopSimulation()
	{
		ClickManager.playMode = false; // Alert the Click Manager that we are no longer in play mode, and objects can be moved again 
		startUI.SetActive(true); // Show the Start Simulation UI
		stopUI.SetActive(false); // Hide the Stop Simulation UI
		foreach (ResetManager reset in resetObjects)
		{
			reset.Reset();
		}
		
	}
	public void ClearMatch(GameObject match)
	{
		int counter = 0;
		foreach(GameObject testMatch in matches)
		{
			if (match == testMatch)
			{
				matches[counter] = null;
			}
			counter ++;
		}
		WinCheck();
	}
	
	
	public void WinCheck()
	{
		bool winTest = true;
		foreach(GameObject testMatch in matches)
		{
			if (testMatch != null)
			{
				winTest = false;
			}

		}
		if(winTest)
		{
			winUI.SetActive(true);
			pauseUI.SetActive(false);
			stopUI.SetActive(false);
			startUI.SetActive(false);
		}
	}
	
	public void RestartLevel() // Called by the Restart Button
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload Scene 
	}
	
	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load next Scene in build index (Next Level)
	}
	
	public void MainMenu()
	{
		SceneManager.LoadScene(0); // Load First Scene (Main Menu)
	}
	public void Pause()
	{
		pauseUI.SetActive(!pauseUI.activeSelf);
		Time.timeScale = (Time.timeScale - 1f) * -1f;
	}

}
