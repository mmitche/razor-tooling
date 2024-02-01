﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Razor.Test.Common;
using Microsoft.CodeAnalysis.Razor;
using Microsoft.VisualStudio.Editor.Razor;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using Moq;

namespace Microsoft.VisualStudio.LegacyEditor.Razor.Test;

internal static class VsMocks
{
    public static ITextBuffer CreateTextBuffer(bool core)
        => StrictMock.Of<ITextBuffer>(b =>
            b.ContentType == (core ? ContentTypes.RazorCore : ContentTypes.NonRazorCore) &&
            b.Properties == new PropertyCollection());

    internal static class ContentTypes
    {
        public static readonly IContentType LegacyRazorCore;
        public static readonly IContentType RazorCore;
        public static readonly IContentType NonRazorCore;

        static ContentTypes()
        {
            var legacyRazorCoreMock = new StrictMock<IContentType>();
            legacyRazorCoreMock
                .Setup(x => x.IsOfType(It.IsAny<string>()))
                .Returns((string type) => type == RazorConstants.LegacyCoreContentType);

            LegacyRazorCore = legacyRazorCoreMock.Object;

            var razorCoreMock = new StrictMock<IContentType>();
            razorCoreMock
                .Setup(x => x.IsOfType(It.IsAny<string>()))
                .Returns((string type) => type == RazorLanguage.CoreContentType);

            RazorCore = razorCoreMock.Object;

            var nonRazorCoreMock = new StrictMock<IContentType>();
            nonRazorCoreMock
                .Setup(x => x.IsOfType(It.IsAny<string>()))
                .Returns(false);

            NonRazorCore = nonRazorCoreMock.Object;
        }
    }
}
