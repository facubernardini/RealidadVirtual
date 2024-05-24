using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location: MonoBehaviour
{
    public double lat;
    public double lon;

    public Location(double lat, double lon)
    {
        this.lat = lat;
        this.lon = lon;
    }

}
