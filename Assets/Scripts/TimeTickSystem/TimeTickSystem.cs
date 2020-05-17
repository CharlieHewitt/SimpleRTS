using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Note: This source code is heavily inspired by these two videos by "Code Monkey" 
 * source: (https://www.youtube.com/watch?v=NFvmfoRnarY & https://www.youtube.com/watch?v=FNFJ_R9zqXI)
 */

public static class TimeTickSystem
{
    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;
    public static event EventHandler<OnTickEventArgs> OnTick5;

    private static GameObject timeTickSystemGameObject;

    // .2f = 200ms
    public const float TICK_TIMER_MAX = .2f;

    private static int tick;

    public static void Create()
    {
        if (timeTickSystemGameObject == null)
        {
            timeTickSystemGameObject = new GameObject("TimeTickSystem");
            timeTickSystemGameObject.AddComponent<TimeTickSystemObject>();   
        }
    }




    private class TimeTickSystemObject : MonoBehaviour
    {
            private float tickTimer;
            private void Awake()
            {
                tick = 0;
            }

            private void Update()
            {
                tickTimer += Time.deltaTime;

                if (tickTimer >= TICK_TIMER_MAX)
                {
                    tickTimer -= TICK_TIMER_MAX;
                    tick++;

                    // fire off event if there are subscribers
                    if (OnTick != null)
                    {
                        OnTick(this, new OnTickEventArgs { tick = tick });
                    }

                    if (OnTick5 != null && tick % 5 == 0)
                    {
                        OnTick5(this, new OnTickEventArgs { tick = tick });
                    }
                }
            }
        }
    }
