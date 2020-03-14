using UnityEngine;

namespace SaveManager {
	public class PlayerPrefsSaveManager : ISaveManager {
		public void SaveInt(string key, int value){
			PlayerPrefs.SetInt(key, value);
			PlayerPrefs.Save();
		}

		public int LoadInt(string key, int defaultValue = 0) => PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) : defaultValue;

		public void SaveString(string key, string value){
			PlayerPrefs.SetString(key, value);
			PlayerPrefs.Save();
		}

		public string LoadString(string key, string defaultValue = "") => PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : defaultValue;
	}
}