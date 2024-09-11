using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Item slots")]
    public GameObject Weapon1;
    public bool isWeapon1Active = true;//기본 권총

    public GameObject Weapon2;//서브머신건(샷건)
    public bool isWeapon2Active = false;

    public GameObject Weapon3;//바주카
    public bool isWeapon3Active = false;//gun상속

    [Header("Weapons to Use")]
    public GameObject BaseGun;//기본 권총
    public GameObject ShotGun;//샷건 무기2
    public GameObject Bazooka;//바주카 무기3

    [Header("Scripts")]
    public PlayerShooter playershooterScript;//기본무기
    public PlayerShooter2 playershooter2Script;//샷건무기2
    //public PlayerShooter3 playershooter3Script;//바주카무기3

    private void Update()
    {
        if(playershooterScript.gun.state != Gun.State.Reloading &&
            playershooter2Script.gun.state != Gun.State.Reloading
            )
        {
            //기본건 끼고있는 상태에서 재장전 or 샷건 or 바주카 끼고있는 상태에서 재장전 하고있던 경우라면 무기교체 제한
            if (Input.GetKeyDown("1"))
            {
                isWeapon1Active = true;
                isWeapon2Active = false;
                isWeapon3Active = false;
                isRifleActive();
            }else if (Input.GetKeyDown("2"))
            {
                isWeapon1Active = false;
                isWeapon2Active = true;
                isWeapon3Active = false;
                isRifleActive();
            }else if (Input.GetKeyDown("3"))
            {
                isWeapon1Active = false;
                isWeapon2Active = false;
                isWeapon3Active = true;
                isRifleActive();
            }
            else
            {
                isRifleActive();
            }
        }
    }

    void isRifleActive()
    {
        if (isWeapon1Active == true)
        {
            BaseGun.SetActive(true);
            ShotGun.SetActive(false);
           // Bazooka.SetActive(false);

            playershooterScript.enabled = true;
            playershooter2Script.enabled = false;
        }else if(isWeapon2Active == true)
        {
            BaseGun.SetActive(false);
            ShotGun.SetActive(true);
           // Bazooka.SetActive(false);

            playershooterScript.enabled = false;
            playershooter2Script.enabled = true;
        }
        else if (isWeapon3Active == true)
        {
            BaseGun.SetActive(false);
            ShotGun.SetActive(false);
           // Bazooka.SetActive(true);

            /*playershooterScript.enabled = false;
            playershooter2Script.enabled = true;*/
        }
    }
}
