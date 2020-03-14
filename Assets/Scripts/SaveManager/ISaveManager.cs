namespace SaveManager {
	public interface ISaveManager {
		void SaveInt(string key, int value);
		int LoadInt(string key, int defaultValue);

		void SaveString(string key, string value);
		string LoadString(string key, string defaultValue);
	}
}