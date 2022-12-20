using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
using System;

// Output the build size or a failure depending on BuildPlayer.

public class BuildPlayer : MonoBehaviour
{
    public static void JenkinsBuilder()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        string[] scenes = UnityEditor.EditorBuildSettingsScene.GetActiveSceneList(UnityEditor.EditorBuildSettings.scenes);
        buildPlayerOptions.scenes = scenes;
        buildPlayerOptions.locationPathName = "RunRunRunBuild/RunRunRun.exe";
        //buildPlayerOptions.locationPathName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}