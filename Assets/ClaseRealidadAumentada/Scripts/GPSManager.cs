using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSManager : MonoBehaviour
{
    public Location userLocation;
    static readonly double R = 6371.0; // Radius of the earth in km
    static readonly double pi_sobre_180 = Math.PI / 180.0;

    public GameObject[] objetos;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
            yield break;
        // Start service before querying location
        Input.location.Start(1, 0.1f);
        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }
        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        InvokeRepeating("UpdateLocation", 1, 1);
    }

    public void UpdateLocation()
    {
        userLocation.lat = Input.location.lastData.latitude;
        userLocation.lon = Input.location.lastData.longitude;

        for (int i = 0; i < objetos.Length; i++)
        {
            Vector3 nuevaPosicion = UpdatePosition(userLocation, objetos[i].GetComponent<Location>());
            objetos[i].transform.position = nuevaPosicion;
        }

    }

    public Vector3 UpdatePosition(Location userLocation, Location poiLocation)
    {
        Vector3 newPos;

        Location projectionY = new Location(poiLocation.lat, userLocation.lon);
        Location projectionX = new Location(userLocation.lat, poiLocation.lon);
        double distX = CalculateDistanceKM(userLocation, projectionX);
        double distY = CalculateDistanceKM(userLocation, projectionY);

        if (poiLocation.lat < userLocation.lat)
            distY *= -1.0;

        if (poiLocation.lon < userLocation.lon)
            distX *= -1.0;

        newPos = new Vector3(((float)(distX * 1000.0)), 0, ((float)(distY * 1000.0)));

        return newPos;
    }

    public double CalculateDistanceKM(Location p1, Location p2)
    {
        double dLat = (p2.lat - p1.lat) * pi_sobre_180;  // deg2rad below
        double dLon = (p2.lon - p1.lon) * pi_sobre_180;

        double a =
            Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(p1.lat * pi_sobre_180) * Math.Cos(p2.lat * pi_sobre_180) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        double d = R * c; // Distance in km

        return d;
    }

}
