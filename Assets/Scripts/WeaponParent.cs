using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    protected float desiredAngle;

    [SerializeField]
    protected WeaponRenderer weaponRenderer;
    [SerializeField]
    protected Weapon weapon;
    
    [SerializeField] private Transform m_Player;

    private void Awake()
    {
        AssignWeapon();
    }

    private void AssignWeapon()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPosition)
    {
        var aimDirection = (Vector3)pointerPosition - transform.position;
        desiredAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        //Debug.Log((int) (desiredAngle + 180));
        //180 = east , 270 = north , 360 && 0 = west 90 = south
        AdjustWeaponRendering();
        bool shouldFlip = desiredAngle > 90 || desiredAngle < -90;
        transform.rotation = Quaternion.AngleAxis(shouldFlip?desiredAngle-180:desiredAngle, Vector3.forward);
        Debug.Log(shouldFlip);
        m_Player.localScale = new Vector3(shouldFlip?-1:1,1,1);

    }

    protected void AdjustWeaponRendering()
    {
        if(weaponRenderer != null)
        {
            weaponRenderer.FlipSprite(desiredAngle > 90 || desiredAngle < -90);
            weaponRenderer.RenderBehindHead(desiredAngle < 180 && desiredAngle > 0);
        }
    }

}
