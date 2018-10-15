using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyFitness : IFitnessFunction
{
    float fCollision;
    float fAngle;
    float fVelocity;
    float fDistance;

    public float DetermineFitness(CarState state)
    {
        //return UnityEngine.Random.value * 1000;

        //state.AngleToGoal         Drehung           0     0.6       0.1
        //state.CurrentVelocity     Geschwindiket     0     0.8       0.3
        //state.DistanceFromGoal    Entfernung        0     0.9       0.2
        //state.NumberOfCollisions  Unfall            0       9         1


        float angle = state.AngleToGoal();
        float velocity = state.CurrentVelocity();
        float distance = state.DistanceFromGoal();
        int collisions = state.NumberOfCollisions();

        if(angle < 0.1){
            fAngle = 0.1F;
        } if(angle >= 0.1){
            fAngle = 0.9F;
        }

        if(velocity < 0.1){
            fVelocity = 0.1F;
        } if (velocity >0.5){
            fVelocity = 0.9F;
        }

        if(distance < 0.5){
            fDistance = 0.1F;
        } if(distance>=0.5){
            fDistance = 0.9F;
        }


        if (collisions == 0)
        {
            fCollision = 0.1F;
        }
        if (collisions > 0 && collisions <= 3)
        {
            fCollision = 0.5F;
        }
        if (collisions > 3)
        {
            fCollision = 0.99F;
        }

        float fitness = 1 - (fAngle * fVelocity * fDistance * fCollision);
        return (distance/100)-5;
    }
}
