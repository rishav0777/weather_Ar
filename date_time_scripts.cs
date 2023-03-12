using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class date_time_scripts : MonoBehaviour
{

    [SerializeField] private TMP_Text date_time;
    // Update is called once per frame
    void Update()
    {
        date_time.text = DateTime.Now.ToString("d:MM:yy  hh:mm tt");
    }
}
