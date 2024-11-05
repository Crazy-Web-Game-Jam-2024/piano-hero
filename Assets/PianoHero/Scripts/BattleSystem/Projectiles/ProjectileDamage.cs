using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ProjectileDamage : MonoBehaviour
{
    public int damage;
    [SerializeField] GameObject effectOnDamage;
    public GameCharacterController owner;
    
    
    public void OnCollision(GameCharacterController target)
    {
        target.On
    }
}

