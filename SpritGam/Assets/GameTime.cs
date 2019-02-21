using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTime : MonoBehaviour
{

    private DateTime m_current_time;
    private DateTime m_game_base_time;
    private int m_time_multiplier = 1;
    private int m_start_time;

    public static DateTime CurrentTime;
    public static long CurrentTimeUnix;

    void Start()
    {
        string formatString = "yyyy'##'MM'##'dd' 'HH'*'mm'*'ss";
        string sampleData = "2625##05##23 14*20*09";
        DateTime parsed = DateTime.ParseExact(sampleData, formatString, null);
        m_game_base_time = parsed; // add save data time here;
        m_current_time = parsed;
        m_start_time = DateTime.Now.Second;
    }

    private void FixedUpdate()
    {
        float time = (DateTime.Now.Second - m_start_time) * m_time_multiplier;
        int seconds = Mathf.FloorToInt(time);
        int minutes = Mathf.FloorToInt(seconds / 60);
        int hours = Mathf.FloorToInt(minutes / 60);

        TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);
        m_current_time = m_game_base_time.Add(timeSpan);
        long m_unix = (long)(time * 1000 + DateTime.Now.Millisecond);
        GameTime.CurrentTimeUnix = m_unix;
        GameTime.CurrentTime = m_current_time;
    }
}