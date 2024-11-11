using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // Anzahl der Waffen und Index der aktuellen Waffe
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] guns;            // Array der Waffenobjekte
    public GameObject weaponHolder;      // GameObject, das alle Waffen enthält
    public GameObject currentWeapon;     // Aktuelle Waffe

    // Array zur Speicherung der Waffeninformationen
    public Weapon[] weaponStats;

    void Start()
    {
        // Initialisiere die Waffenanzahl und das Waffenarray
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];
        weaponStats = new Weapon[totalWeapons];

        // Durchlaufe alle Waffen im Waffenhalter
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);

            // Erstelle für jede Waffe ein neues Weapon-Objekt mit spezifischen Eigenschaften
            if (i == 0) weaponStats[i] = new Weapon("Pistol", 5, 1200);
            else if (i == 1) weaponStats[i] = new Weapon("SMG", 4, 1500);
            else if (i == 2) weaponStats[i] = new Weapon("Assault Rifle", 3, 1700);
        }

        // Setze die erste Waffe aktiv
        guns[0].SetActive(true);
        currentWeapon = guns[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
        HandleWeaponSwitch();
    }

    private void HandleWeaponSwitch()
    {
        // Wechsel zur nächsten Waffe
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeaponIndex < totalWeapons - 1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex++;
                guns[currentWeaponIndex].SetActive(true);
                currentWeapon = guns[currentWeaponIndex];
                DisplayWeaponStats();
            }
        }

        // Wechsel zur vorherigen Waffe
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex--;
                guns[currentWeaponIndex].SetActive(true);
                currentWeapon = guns[currentWeaponIndex];
                DisplayWeaponStats();
            }
        }
    }

    // Methode zur Anzeige der aktuellen Waffenstatistiken (zum Testen in der Konsole)
    private void DisplayWeaponStats()
    {
        Weapon currentStats = weaponStats[currentWeaponIndex];
        Debug.Log("Current Weapon: " + currentStats.name + 
                  ", Fire Rate: " + currentStats.fireRate + 
                  ", Bullet Speed: " + currentStats.bulletSpeed);
    }
}

// Klasse zur Repräsentation der Eigenschaften einer Waffe
[System.Serializable]
public class Weapon
{
    public string name;
    public int fireRate;
    public int bulletSpeed;

    public Weapon(string name, int fireRate, int bulletSpeed)
    {
        this.name = name;
        this.fireRate = fireRate;
        this.bulletSpeed = bulletSpeed;
    }
}
