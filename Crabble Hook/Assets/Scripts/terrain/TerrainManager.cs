using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public delegate void Ticket();
    public static event Ticket SeaBedTicketCheck;

    public int seabedTicket;
    public int seabedTickeCurrent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
