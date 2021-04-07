using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class StartButton : MonoBehaviour
{
	public TextMeshProUGUI title;
	public TextMeshProUGUI algoTitle;
	public Button startButton;
	public Button quitButton;
	public Dropdown algoSelect;

        void Start()
        {
        	algoTitle.gameObject.SetActive(false);
        	quitButton.gameObject.SetActive(false);
        }

	public void StartHandle()
	{
		title.gameObject.SetActive(false);
		startButton.gameObject.SetActive(false);
		algoSelect.gameObject.SetActive(false);
		quitButton.gameObject.SetActive(true);
		algoTitle.gameObject.SetActive(true);
	}
}
