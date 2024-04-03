using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using TMPro;

public class DisplayIPV4 : MonoBehaviour
{
    public TextMeshProUGUI ipv4Text;

    void Start()
    {
        // Cihazın IPv4 adresini al
        string ipv4Address = GetLocalIPv4();

        // Ekrana IPv4 adresini yazdır
        ipv4Text.text = "IPv4 Address: " + ipv4Address;
    }

    // Cihazın IPv4 adresini almak için yardımcı fonksiyon
    string GetLocalIPv4()
    {
        string localIPv4 = "";
        foreach (IPAddress ipAddress in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                localIPv4 = ipAddress.ToString();
                break;
            }
        }
        return localIPv4;
    }
}
