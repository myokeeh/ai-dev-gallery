﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;
using System;
using System.Diagnostics.Tracing;

namespace AIDevGallery.Telemetry.Events;

[EventData]
internal class DeepLinkActivatedEvent : EventBase
{
    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public string Uri
    {
        get;
    }

    private DeepLinkActivatedEvent(string uri)
    {
        Uri = uri;
    }

    public override void ReplaceSensitiveStrings(Func<string?, string?> replaceSensitiveStrings)
    {
        // No sensitive strings to replace.
    }

    public static void Log(string uri)
    {
        TelemetryFactory.Get<ITelemetry>().Log("DeepLinkActivated_Event", LogLevel.Measure, new DeepLinkActivatedEvent(uri));
    }
}