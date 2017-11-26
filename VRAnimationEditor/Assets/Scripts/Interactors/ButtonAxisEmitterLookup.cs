﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAxisEmitterLookup : MonoBehaviour {
    private static Dictionary<int, IButtonAxisEmitter> emitters;

    public static void RegisterEmitter(IButtonAxisEmitter emitter, int id){
        if (emitters == null)
        {
            emitters = new Dictionary<int, IButtonAxisEmitter>();
        }
        emitters.Add(id, emitter);
    }

    public static IButtonAxisEmitter GetEmitter(int id){
        if (emitters == null)
        {
            emitters = new Dictionary<int, IButtonAxisEmitter>();
        }
        return emitters[id];
    }

    public static void RegisterReciever(IButtonAxisReciever reciever, int id){
        if (emitters.ContainsKey(id))
        {
            emitters[id].RegisterButtonAxisReciever(reciever);
        }
    }

    public static void UnregisterReciever(IButtonAxisReciever reciever, int id){
        if (emitters.ContainsKey(id))
        {
            emitters[id].UnregisterButtonAxisReciever(reciever);
        }
    }
}