using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/**
 * Trida slouzi pro vypsani stavu pripojen MindwaveNeurosky do prislusneho textoveho pole 
 */
public class ConnectionStatus : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI messages;



	private void Awake()
	{
		if(InputManager1.instance && InputManager1.instance.checkStatus())
			Connected();

	}


	public void Connect()
	{
	
		messages.text = "Neurosky se připojuje";
	}

	public void Connected()
	{
		
		messages.text = "Neurosky připojeno";
		
	}
	
	public void Disconnect()
	{
		
		messages.text = "Neurosky odpojeno";
		
	}
	
	public void ConnectionTimeOut()
	{
		messages.text = "Neurosky nelze připojit";
		
	}

	public void ConnectionException()
	{
		
		messages.text = "Neurosky nalezeno";
	
	}
}
