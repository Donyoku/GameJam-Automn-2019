﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour, Interactive
{
    enum State
    {
        EMPTY,
        FILLED
    }

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Empty()
    {
        state = State.EMPTY;
    }

    public void Fill()
    {
        state = State.FILLED;
    }

    public bool isFilled()
    {
        return state == State.FILLED;
    }

    public void Select()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void Deselect()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public Action GetAction(Player player)
    {
        if (!player.HasBucket())
        {
            return new Action("Prendre", Button.A, null, 0, 0, () => { if (player.PickUpBucket(this)) gameObject.SetActive(false); });
        }
        else
        {
            return null;
        }
    }

    // Pose le seau au sol à l'emplacement passé en paramètres
    public void SetOnGround(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

}