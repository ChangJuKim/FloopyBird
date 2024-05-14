using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Settings
    public const string HIGH_SCORE_KEY = "High Score";
    public const string VOLUME = "Volume";
    public const string FREE_FLIGHT_KEY = "Free Flight";
    
    // Values
    public const string TRUE = "true";
    public const string FALSE = "false";

    // World stats
    public const float DEAD_ZONE_TOP = 21;
    public const float DEAD_ZONE_BOT = -13;
    public const float DEAD_ZONE_LEFT = -25;
    public const float DEAD_ZONE_RIGHT = 25;

    // Classic stats
    public const float CLASSIC_GRAVITY = 4.5f;
    public const float CLASSIC_FLAP_STRENGTH = 20;

    // Free Flight stats
    public const float FF_GRAVITY = 0;
    public const float FF_FLAP_STRENGTH = 0.1f;
    public const float FF_MAX_VELOCITY = 15;

}
