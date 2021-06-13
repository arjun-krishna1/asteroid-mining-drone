using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public struct AsteroidType
    {
        public string material;
        public Color color;
        public AsteroidType(string newMat, Color newCol)
        {
            this.material = newMat;
            this.color = newCol;
        }
    }

    public Rigidbody asteroidPrefab;
    [Range(1, 100)]
    public int numberOfAsteroids = 10;
    [Range(10, 100)]
    public int maxSpawnDist = 100;
    private Rigidbody[] asteroids;

    AsteroidType[] asteroidTypes;

    void Start()
    {  
        asteroidTypes = new AsteroidType[2];
        asteroidTypes[0] = new AsteroidType("iron", Color.red);
        asteroidTypes[1] = new AsteroidType("ice", Color.blue);

        asteroids = new Rigidbody[numberOfAsteroids];
        for(int i = 0; i <numberOfAsteroids; i++) {
            asteroids[i] = generateRandomAsteroid();
        }
    }

    void OnApplicationQuit() {
        foreach (Rigidbody rb in asteroids)
        {
            Destroy(rb);
        }
    }


    Rigidbody generateRandomAsteroid() {
        Vector3 newLoc = new Vector3(0, 0, 0);
        newLoc.x = Random.Range(-maxSpawnDist, maxSpawnDist);
        newLoc.z = Random.Range(-maxSpawnDist, maxSpawnDist);

        Rigidbody newRb = Instantiate(asteroidPrefab, newLoc, Quaternion.identity) as Rigidbody;
        newRb.gameObject.GetComponent<Renderer> ().material.color = GetRandomColor();

        return newRb;
    }
    Color GetRandomColor() {
        int randomTypeIdx = Random.Range(0, asteroidTypes.Length);
        return asteroidTypes[randomTypeIdx].color;
    }
}
