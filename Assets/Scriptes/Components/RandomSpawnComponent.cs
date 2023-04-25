using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomSpawnComponent : MonoBehaviour
{   
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private Points[] points;

    private void FixedUpdate() {
        
        Spawn();
    }
    
    public void Spawn(){
        coolDown = UnityEngine.Random.Range(0.3f , 1f);
        var randomPoint = UnityEngine.Random.Range(0, points.Length);
        var randomCar = UnityEngine.Random.Range(0, prefab.Length);
        var Car=  prefab[randomCar].gameObject.GetComponent<CarBrain>();
        int multiply =0;
        var pointTMP = points[randomPoint];
        if (pointTMP.Invert){
            multiply = -1;
            Car.invert = true;
        }
        else{
            multiply =0;
            Car.invert = false;
        }
        Car.speed = pointTMP.Speed;
        if (pointTMP.canSpawn){
            Instantiate(prefab[randomCar], pointTMP.Point.transform.position, new Quaternion(0 , 180*multiply, 0, 1));
            pointTMP.Wait(coolDown);
            
        }
        
    }

    
}

[Serializable]
public class Points{
    [SerializeField] private Transform point;
    [SerializeField] private bool invert;
    [SerializeField] private int speed;
    public Transform Point => point;
    public bool Invert => invert;
    public int Speed => speed;

    public float timeUp;
    public void Wait(float coolDown){
        timeUp = Time.time + coolDown;
    }

    public bool canSpawn => timeUp <= Time.time;
}