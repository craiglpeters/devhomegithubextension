﻿// Copyright (c) Microsoft Corporation and Contributors
// Licensed under the MIT license.

namespace GitHubExtension;
internal static class DeveloperOAuthConfiguration
{
    //// Follow this link https://docs.GitHub.com/en/developers/apps/building-oauth-apps/creating-an-oauth-app
    //// to create a Git Oauth app (with RedirectUri = "devhome://oauth_redirect_uri/").
    //// The following info can be modified by setting the corresponding environment variables.
    //// How to set the environment variables:
    ////
    ////        On an elevated cmd window:
    ////                       setx GitHub_CLIENT_ID "Your OAuth App's ClientId" /m
    ////                       setx GitHub_CLIENT_SECRET "Your OAuth App's ClientSecret" /m

    // GitHub OAuth Client ID and Secret values should not be checked in. Rather than modifying these values,
    // setting the environment variables like shown above will persist across branch switches.
    internal static readonly string? ClientID = Environment.GetEnvironmentVariable("GitHub_CLIENT_ID");

    internal static readonly string? ClientSecret = Environment.GetEnvironmentVariable("GitHub_CLIENT_SECRET");
}