// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using GitHubExtension.Client;
using System.Collections.Generic; // Required for list handling

namespace GitHubExtension.Providers;

// Microsoft.Windows.DevHome.SDK.IRepository Implementation
public class DevHomeRepository : Microsoft.Windows.DevHome.SDK.IRepository
{
    private readonly string name;

    private readonly Uri cloneUrl;

    private readonly bool _isPrivate;

    private readonly DateTimeOffset _lastUpdated;

    string Microsoft.Windows.DevHome.SDK.IRepository.DisplayName => name;

    public string OwningAccountName => Validation.ParseOwnerFromGitHubURL(this.cloneUrl);

    public bool IsPrivate => _isPrivate;

    public DateTimeOffset LastUpdated => _lastUpdated;

    public Uri RepoUri => cloneUrl;

    // Placeholder for Codespaces data
    private List<Codespace> codespaces = new List<Codespace>();

    /// <summary>
    /// Initializes a new instance of the <see cref="DevHomeRepository"/> class.
    /// </summary>
    /// <param name="octokitRepository">The repository received from octokit</param>
    public DevHomeRepository(Octokit.Repository octokitRepository)
    {
        this.name = octokitRepository.Name;
        this.cloneUrl = new Uri(octokitRepository.CloneUrl);

        _lastUpdated = octokitRepository.UpdatedAt;
        _isPrivate = octokitRepository.Private;
    }

    // Method to create a Codespace based on user selection
    public void CreateCodespace(string repository, string devcontainer, string machineType, string region)
    {
        // Placeholder for Codespace creation logic
        var codespace = new Codespace
        {
            Repository = repository,
            DevContainer = devcontainer,
            MachineType = machineType,
            Region = region,
            Status = "Creating"
        };
        codespaces.Add(codespace);
    }

    // Method to list available Codespaces including their status
    public IEnumerable<Codespace> ListCodespaces()
    {
        return codespaces;
    }

    // Method to implement deletion logic for Codespaces
    public void DeleteCodespace(Codespace codespace)
    {
        codespaces.Remove(codespace);
    }
}

// Placeholder class for Codespace details
public class Codespace
{
    public string Repository { get; set; }
    public string DevContainer { get; set; }
    public string MachineType { get; set; }
    public string Region { get; set; }
    public string Status { get; set; }
}
