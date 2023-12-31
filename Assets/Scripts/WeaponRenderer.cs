using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField]
    protected int playerSortingOrder = 0;
    protected SpriteRenderer weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool val)
    {
        /*weaponRenderer.flipY = val;*/ //For Gun
        //weaponRenderer.flipX = val;
        
    }

    public void RenderBehindHead(bool val)
    {
        if (val)
            weaponRenderer.sortingOrder = playerSortingOrder - 1;
        else
            weaponRenderer.sortingOrder = playerSortingOrder + 1;
    }

}
