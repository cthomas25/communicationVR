using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSCsharp.Data;

namespace UniOSC
{
    public class OscReceiveCheck : UniOSCEventTarget
    {
        private string smessage;
        private Vector3 currPos;


        public override void OnOSCMessageReceived(UniOSCEventArgs args)
        {
            string Room_number = "0";
            string Room_letter = "";
            string state = "";

            OscMessage msg = (OscMessage)args.Packet;

            Debug.Log("OscReceiveCheck::message received");
            Debug.Log(msg.Data[0].ToString());

            string[] arr = msg.Data[0].ToString().Split(';');
            Debug.Log(arr[0]); //Room_number
            Debug.Log(arr[1]); //Room_letter
            Debug.Log(arr[2]); // C1 = checked once, C2 = checked twice, C0 = not checked

            Room_number = arr[0];
            Room_letter = arr[1];
            state = arr[2];


            if (Room_number == "116" && Room_letter == "B")
            {
                Globals.check_116B = true;
            }
            if (Room_number == "116" && Room_letter == "C")
            {
                Globals.check_116C = true;
            }
            if (Room_number == "116" && Room_letter == "")
            {
                Globals.check_116 = true;
            }
            if (Room_number == "114" && Room_letter == "")
            {
                Globals.check_114 = true;
            }
            if (Room_number == "112" && Room_letter == "")
            {
                Globals.check_112 = true;
            }
            if (Room_number == "113" && Room_letter == "")
            {
                Globals.check_113 = true;
            }
            if (Room_number == "113" && Room_letter == "B")
            {
                Globals.check_113B = true;
            }
            if (Room_number == "113" && Room_letter == "C")
            {
                Globals.check_113C = true;
            }
            if (Room_number == "113" && Room_letter == "D")
            {
                Globals.check_113D = true;
            }
            if (Room_number == "113" && Room_letter == "E")
            {
                Globals.check_113E = true;
            }
            if (Room_number == "113" && Room_letter == "F")
            {
                Globals.check_113F = true;
            }
            if (Room_number == "113" && Room_letter == "G")
            {
                Globals.check_113G = true;
            }
            if (Room_number == "110" && Room_letter == "")
            {
                Globals.check_110 = true;
            }
            if (Room_number == "110" && Room_letter == "A")
            {
                Globals.check_110A = true;
            }
            if (Room_number == "110" && Room_letter == "B")
            {
                Globals.check_110B = true;
            }
            if (Room_number == "111" && Room_letter == "A")
            {
                Globals.check_111A = true;
            }
            if (Room_number == "111" && Room_letter == "B")
            {
                Globals.check_111B = true;
            }
            if (Room_number == "102" && Room_letter == "")
            {
                Globals.check_102 = true;
            }
            if (Room_number == "121" && Room_letter == "")
            {
                Globals.check_121 = true;
            }
        }

    }
}

