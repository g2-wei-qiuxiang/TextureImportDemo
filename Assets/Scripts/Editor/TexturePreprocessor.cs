using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// テクスチャインポートする際の設定
/// </summary>
public class TexturePreprocessor : AssetPostprocessor
{
    private static readonly string DefaultPlatform = "DefaultTexturePlatform";
    private static readonly string StandalonePlatform = "Standalone";
    private static readonly string IosPlatform = "iPhone";
    private static readonly string AndroidPlatform = "Android";
    
    private static readonly Dictionary<string, TextureImporterFormat> PathFormatDictionary = new Dictionary<string, TextureImporterFormat>
    {
        {"Assets/Texture/InAtlas", TextureImporterFormat.RGBA32},
        {"Assets/Texture/NoInAtlas", TextureImporterFormat.ASTC_6x6}
    };
    
    /// <summary>
    /// OnPreprocessTexture
    /// </summary>
    private void OnPreprocessTexture()
    {
        TextureImporter textureImporter = assetImporter as TextureImporter;
        foreach (var pathFormat in PathFormatDictionary)
        {
            if (!assetPath.StartsWith(pathFormat.Key, StringComparison.Ordinal))
            {
                continue;
            }
        
            // DefaultPreprocess(textureImporter, pathFormat.Value);
            // StandalonePreprocess(textureImporter, pathFormat.Value);
            AndroidPreprocess(textureImporter, pathFormat.Value);
            IosPreprocess(textureImporter, pathFormat.Value);
        }
    }

    /// <summary>
    /// Defaultインポート設定
    /// </summary>
    /// <param name="importer"></param>
    /// <param name="format"></param>
    private void DefaultPreprocess(TextureImporter importer, TextureImporterFormat format)
    {
        importer.ClearPlatformTextureSettings(DefaultPlatform);
    }

    /// <summary>
    /// Standaloneインポート設定
    /// </summary>
    /// <param name="importer"></param>
    /// <param name="format"></param>
    private void StandalonePreprocess(TextureImporter importer, TextureImporterFormat format)
    {
        importer.ClearPlatformTextureSettings(StandalonePlatform);
        var settings = importer.GetPlatformTextureSettings(StandalonePlatform);
        settings.format = TextureImporterFormat.RGBA32;
    }

    /// <summary>
    /// Androidインポート設定
    /// </summary>
    /// <param name="importer"></param>
    /// <param name="format"></param>
    private void AndroidPreprocess(TextureImporter importer ,TextureImporterFormat format)
    {
        var settings = importer.GetPlatformTextureSettings(AndroidPlatform);
        if (settings.overridden && settings.format == format)
        {
            return;
        }
        
        importer.ClearPlatformTextureSettings(AndroidPlatform);
        settings.format = format;
        BasicSetting(settings);
        importer.SetPlatformTextureSettings(settings);
    }

    /// <summary>
    /// IOSインポート設定
    /// </summary>
    /// <param name="importer"></param>
    /// <param name="format"></param>
    private void IosPreprocess(TextureImporter importer ,TextureImporterFormat format)
    {
        var settings = importer.GetPlatformTextureSettings(IosPlatform);
        if (settings.overridden && settings.format == format)
        {
            return;
        }
        
        importer.ClearPlatformTextureSettings(IosPlatform);
        settings.format = format;
        BasicSetting(settings);
        importer.SetPlatformTextureSettings(settings);
    }

    /// <summary>
    /// 基礎設定
    /// </summary>
    /// <param name="settings"></param>
    private void BasicSetting(TextureImporterPlatformSettings settings)
    {
        settings.overridden = true;
        settings.compressionQuality = 50;
        settings.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
    }
}
