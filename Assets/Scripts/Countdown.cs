using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdown;
    
    // Start is called before the first frame update
    void Start()
    {
        CountdownEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CountdownEvent()
    {   
        switch (Time.deltaTime)
        {
            case 0.5217f:
                countdown.text = "3";
                break;
            case 2 * 0.5217f:
                countdown.text = "2";
                break;
            case 3 * 0.5217f:
                countdown.text = "1";
                break;
            case 4 * 0.5217f:
                countdown.text = "GO!";
                break;
        }
    }
}
