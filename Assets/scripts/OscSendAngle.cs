/*
* Based on UniOSC sender code
* Copyright © 2018 Alexandre Gomes de Siqueira
* All rights reserved
* TEI Class Sample files - Clemson University
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using OSCsharp.Data;

namespace UniOSC
{

    /// <summary>
    /// Dispatcher button that forces a OSCConnection to send a OSC Message.
    /// Two separate states: Down and Up 
    /// </summary>
    [AddComponentMenu("UniOSC/EventDispatcherButton")]
    [ExecuteInEditMode]
    public class OscSendAngle : UniOSCEventDispatcher
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            ClearData();
            AppendData("");
        }

        public override void OnDisable()
        {
            base.OnDisable();
        }

        void Update()
        {
            
                if (Globals.prevOscAngle != Globals.OscAngle)
                {
                    if(Globals.prevOscAngle < Globals.OscAngle)
                {
                    SendOSCAngle("dial_right");
                } else { SendOSCAngle("dial_left"); }

                    Globals.prevOscAngle = Globals.OscAngle;
                }
        }

        public void SendOSCAngle(string fmsg)
        {
            if (_OSCeArg.Packet is OscMessage)
            {
                ((OscMessage)_OSCeArg.Packet).UpdateDataAt(0, fmsg);
            }
            else if (_OSCeArg.Packet is OscBundle)
            {
                foreach (OscMessage m in ((OscBundle)_OSCeArg.Packet).Messages)
                {
                    m.UpdateDataAt(0, fmsg);
                }
            }

            _SendOSCMessage(_OSCeArg);
        }
    }
}