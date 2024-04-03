using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;


public class MultiplayerUI : NetworkBehaviour
{
    [SerializeField] public Button hostButton;
    [SerializeField] public Button clientButton;
    [SerializeField] public TextMeshProUGUI playerCount;

    private NetworkVariable<int> playersNum = new NetworkVariable<int>();

    public void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });

        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }

    public void Update()
    {
        playerCount.text = "Players: " + playersNum.Value.ToString();


        if (!IsServer) return;
        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }
}
