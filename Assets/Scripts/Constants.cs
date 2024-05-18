using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Settings
    public const string CLASSIC_HIGH_SCORE_KEY = "Classic High Score";
    public const string FF_HIGH_SCORE_KEY = "Free Flight High Score";
    public const string VOLUME = "Volume";
    public const string IS_FF_KEY = "Is Free Flight";
    
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
    public const float FF_FLAP_STRENGTH = 15f;
    public const float FF_MAX_VELOCITY = 15;

}
