using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabList : MonoBehaviour {
	public TabWrapper[] setTabs;
	static TabWrapper[] tabs;
	const string ppname = "Tabs";
	void Awake () {
		tabs = setTabs;
	}
	static public System.Collections.IEnumerable GetTabs() {
		int length = PlayerPrefs.GetInt (ppname, 0);
		if (length == 0) {
			yield return tabs[0].tab;
		} else {
			for (int i = 0; i < length; i++) {
				string name = PlayerPrefs.GetString (ppname + i, "");
				if (name != "")
					yield return GetTab (name);
			}
		}
	}
	static GameObject GetTab(string name) {
		foreach (TabWrapper tab in tabs)
			if (tab.id == name)
				return tab.tab;
		return null;
	}
	static void AddTab(string value) {
		int length = PlayerPrefs.GetInt (ppname, 0);
		for (int i = 0; i < length; i++) {
			string name = PlayerPrefs.GetString (ppname + i, "");
			if (name == "") {
				PlayerPrefs.SetString (ppname + i, value);
				return;
			}
		}
		PlayerPrefs.SetInt (ppname, length + 1);
		PlayerPrefs.SetString (ppname + length, value);
	}
	static void RemoveTab(string value) {
		int length = PlayerPrefs.GetInt (ppname, 0);
		for (int i = 0; i < length; i++) {
			string name = PlayerPrefs.GetString (ppname + i, "");
			if (name == value) {
				PlayerPrefs.SetString (ppname + i, "");
				return;
			}
		}
	}
}

[System.Serializable]
public class TabWrapper {
	public string id;
	public GameObject tab;
}