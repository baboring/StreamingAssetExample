using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class VersionInfo
{
	public int m_LastVersion;
	public string m_LastDate;
}


/// <summary>
/// System info class
/// </summary>
public class SystemInfo : MonoBehaviour {

	private string m_FilePath;

	public VersionInfo Version { get; protected set; }

	// Use this for initialization
	void Start () 
	{
		m_FilePath = Path.Combine(Application.streamingAssetsPath, "Version.json");
		Load();
		Save();
	}

    /// <summary>
    /// Load this instance.
    /// </summary>
    public void Load()
	{
		// check file eixsts
		if (!System.IO.File.Exists(m_FilePath))
			System.IO.File.WriteAllText(m_FilePath, "");

        // read text
		var jsonString = System.IO.File.ReadAllText(m_FilePath);

        // convert to Instance
		if(jsonString.Length > 0)
			Version = (VersionInfo)JsonUtility.FromJson(jsonString, typeof(VersionInfo));

		if (null == Version)
			Version = new VersionInfo();

		Version.m_LastVersion++;
	}

    /// <summary>
    /// Save this instance.
    /// </summary>
	public void Save()
    {
		//Convert to Jason
        string szToJason = JsonUtility.ToJson(Version, true);
		System.IO.File.WriteAllText(m_FilePath, szToJason);
    }

 
}
