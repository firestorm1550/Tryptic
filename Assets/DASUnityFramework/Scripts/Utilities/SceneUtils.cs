namespace DASUnityFramework.Scripts.Utilities
{
	public static class SceneUtils
	{
		public static string[] GetScenePathsInBuild()
		{
			int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
			string[] scenes = new string[sceneCount];
			for( int i = 0; i < sceneCount; i++ )
			{
				scenes[i] = System.IO.Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i ) );
			}

			return scenes;
		}
	}
}
