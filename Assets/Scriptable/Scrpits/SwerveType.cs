using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Swerve Specs",menuName ="Swerve Specs")]
public class SwerveType : ScriptableObject
{
    public float SwerveSpeed;
    public float MaxSwerveAmount;
    public float MaxMove_x;
}
