﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.AspNetCore.Razor.Language;

internal partial class DefaultBoundAttributeDescriptorBuilder
{
    private sealed class Policy : TagHelperPooledObjectPolicy<DefaultBoundAttributeDescriptorBuilder>
    {
        public static Policy Instance = new();

        public override DefaultBoundAttributeDescriptorBuilder Create() => new();

        public override bool Return(DefaultBoundAttributeDescriptorBuilder builder)
        {
            builder._parent = null;
            builder._kind = null;

            builder.Name = null;
            builder.TypeName = null;
            builder.IsEnum = false;
            builder.IsDictionary = false;
            builder.IsEditorRequired = false;
            builder.IndexerAttributeNamePrefix = null;
            builder.IndexerValueTypeName = null;
            builder.Documentation = null;
            builder.DisplayName = null;

            if (builder._attributeParameterBuilders is { } attributeParameterBuilders)
            {
                foreach (var attributeParameterBuilder in attributeParameterBuilders)
                {
                    DefaultBoundAttributeParameterDescriptorBuilder.Return(attributeParameterBuilder);
                }

                ClearList(attributeParameterBuilders);
            }

            ClearDiagnostics(builder._diagnostics);

            builder._metadata?.Clear();

            return true;
        }
    }
}
