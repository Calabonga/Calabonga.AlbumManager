﻿namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Creator processing
/// </summary>
public interface ICreatorConfiguration
{
    /// <summary>
    /// Pattern for files search
    /// </summary>
    string SearchFilePattern { get; }

    /// <summary>
    /// Source where images live
    /// </summary>
    string SourcePath { get; }

    /// <summary>
    /// Should the manager search images
    /// </summary>
    bool SkipFoundImages { get; }
}