﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace GitHubExtension.Widgets;

public enum WidgetPageState
{
    Unknown,
    SignIn,
    Configure,
    Loading,
    Content,
    CodespacesConfiguration // Added state for Codespaces configuration and selection
}
