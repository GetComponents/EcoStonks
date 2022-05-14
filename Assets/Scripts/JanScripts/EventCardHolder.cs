using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardHolder : MonoBehaviour
{
    public List<EventCards> AllEventCards;
    public List<EventCards> EventCardPool;

    private void Start()
    {
        foreach (EventCards card in AllEventCards)
        {
            if (card.CheckCondition())
            {
                EventCardPool.Add(card);
            }
        }
    }
}
