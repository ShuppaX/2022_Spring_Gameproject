using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LahioWaypoints : Waypoints
{
    
    // TODO enum lähetin tilasta ja yhdistä switch case rakenteeseen.
    // TODO kolmeen vaiheeseen eri tilat switchiin.
    System.Random rnd = new System.Random();
    
    public enum Status
    {
        Arrived,
        Delivered,
        Leaving
    }
    

    public override Transform GetNextWaypoint(Transform currentWaypoint)
    {
        // gives number between 1 and child count
        int housenumber = rnd.Next(1, transform.childCount);
        // marks for lahetti to move to next rail
       



        if (currentWaypoint == null)
        {
            //Move to first waypoint

            return transform.GetChild(0);
        }

        if (currentWaypoint.GetSiblingIndex() == 0 && !delivered)
        {
            delivered = true;

            //pick random house
            //return transform.GetChild(housenumber);



        }
        else if (currentWaypoint.GetSiblingIndex() == 0 && delivered)
        {
            return null;
        }

        if (currentWaypoint.GetSiblingIndex() != 0)
        {
            //change bool to mark delivery done and prepare for next waypoint system
            return transform.GetChild(0);
        }

        return null;
    }

  

    public Transform Delivery(Transform currentWaypoint, Status statuscheck){
        int housenumber = rnd.Next(1, transform.childCount);

        switch (statuscheck)
        {
            case Status.Arrived:
                return transform.GetChild(housenumber);
            

            case Status.Delivered:
                return transform.GetChild(0);
            case Status.Leaving:
                GetNextSystem();
                break;
            
            default:
                return null;
        }

        return null;
    }
}


