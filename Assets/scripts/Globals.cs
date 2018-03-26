using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

        ///***************************************************///
        ///OSC trigger variables
        ///***************************************************///
        /// <summary>
        /// OSC message container
        /// </summary>
        public static float OscMessage = 0;
        public static float prevOscMessage = 0;

        public static float OscAngle = 0;
        public static float prevOscAngle = 0;


        /// <summary>
        /// Triggers sending OSC message when true
        /// </summary>
        public static bool OscSendEvent = false;
        public static bool OscSendAngle = false;


    public static bool check_116B = false;
    public static bool block_116B = false;

    public static bool check_116C = false;
    public static bool block_116C = false;

    public static bool check_116 = false;
    public static bool block_116 = false;


    public static bool check_114 = false;
    public static bool block_114 = false;

    public static bool check_112 = false;
    public static bool block_112 = false;


    public static bool check_113 = false;
    public static bool block_113 = false;

    public static bool check_113B = false;
    public static bool block_113B = false;

    public static bool check_113C = false;
    public static bool block_113C = false;

    public static bool check_113D = false;
    public static bool block_113D = false;

    public static bool check_113E = false;
    public static bool block_113E = false;

    public static bool check_113F = false;
    public static bool block_113F = false;

    public static bool check_113G = false;
    public static bool block_113G = false;



    public static bool check_110 = false;
    public static bool block_110 = false;

    public static bool check_110A = false;
    public static bool block_110A = false;

    public static bool check_110B = false;
    public static bool block_110B = false;

    public static bool check_111A = false;
    public static bool block_111A = false;

    public static bool check_111B = false;
    public static bool block_111B = false;


    public static bool check_102 = false;
    public static bool block_102 = false;


    public static bool check_121 = false;
    public static bool block_121 = false;

}