using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    public int loadRoleIndex = 0;
    public GameObject[] roleGoArray;

    void Awake()
    {
        loadRoleIndex = PlayerPrefs.GetInt("roleIndex");

        if (PlayerPrefs.HasKey("roleIndex"))
        {
            GameObject.Instantiate(roleGoArray[loadRoleIndex], transform.position, transform.rotation);
        }
        else
        {
            print("Please create a role first！");
        }

    }


    private void Update()
    {
      //  print(loadRoleIndex);
        if (Input.GetKeyDown(KeyCode.P) && loadRoleIndex< roleGoArray.Length-1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));

            loadRoleIndex++;
            GameObject.Instantiate(roleGoArray[loadRoleIndex], transform.position, transform.rotation);

            PlayerPrefs.SetInt("roleIndex", loadRoleIndex);
            PlayerPrefs.Save();
        }
        else if(Input.GetKeyDown(KeyCode.P) && loadRoleIndex >=5)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));

            loadRoleIndex = 0;
            GameObject.Instantiate(roleGoArray[loadRoleIndex], transform.position, transform.rotation);

            PlayerPrefs.SetInt("roleIndex", loadRoleIndex);
            PlayerPrefs.Save();
        }
    }

}
