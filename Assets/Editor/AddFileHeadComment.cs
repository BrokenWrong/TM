
using UnityEngine;
using System.IO;
using UnityEditor;

public class AddFileHeadComment : UnityEditor.AssetModificationProcessor
{

    public static void OnWillCreateAsset(string newFileMeta)
    {
        string newFilePath = newFileMeta.Replace(".meta", "");
        string fileExt = Path.GetExtension(newFilePath);
        if (fileExt != ".cs")
        {
            return;
        }
        //注意，Application.datapath会根据使用平台不同而不同  
        string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
        string scriptContent = File.ReadAllText(realPath);

        //这里实现自定义的一些规则  
        scriptContent = scriptContent.Replace("#SCRIPTFULLNAME#", Path.GetFileName(newFilePath));
        scriptContent = scriptContent.Replace("#COMPANY#", PlayerSettings.companyName);
        scriptContent = scriptContent.Replace("#VERSION#", "1.0");
        scriptContent = scriptContent.Replace("#UNITYVERSION#", Application.unityVersion);
        scriptContent = scriptContent.Replace("#DATE#", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

        File.WriteAllText(realPath, scriptContent);
    }
}
