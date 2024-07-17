﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor;
using Microsoft.CodeAnalysis.ExternalAccess.Razor;
using Microsoft.CodeAnalysis.Razor.Settings;
using Microsoft.CodeAnalysis.Razor.Workspaces;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.LanguageServer.Protocol;
using Microsoft.VisualStudio.LanguageServices.Razor.LanguageClient.Cohost;
using Microsoft.VisualStudio.Razor.Settings;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.VisualStudio.Razor.LanguageClient.Cohost;

public class CohostSignatureHelpEndpointTest(ITestOutputHelper testOutputHelper) : CohostTestBase(testOutputHelper)
{
    [Fact]
    public async Task CSharpMethod()
    {
        var input = """
                <div></div>

                @{
                    string M1(int i) => throw new NotImplementedException();

                    void Act()
                    {
                        M1($$);
                    }
                }
                """;

        await VerifySignatureHelpAsync(input, "string M1(int i)");
    }

    [Fact]
    public async Task AutoListParamsOff()
    {
        var input = """
                <div></div>

                @{
                    string M1(int i) => throw new NotImplementedException();

                    void Act()
                    {
                        M1($$);
                    }
                }
                """;

        await VerifySignatureHelpAsync(input, "", autoListParams: false);
    }

    [Fact]
    public async Task TriggerKind()
    {
        var input = """
                <div></div>

                @{
                    string M1(int i) => throw new NotImplementedException();

                    void Act()
                    {
                        M1($$);
                    }
                }
                """;

        await VerifySignatureHelpAsync(input, "", triggerKind: SignatureHelpTriggerKind.TriggerCharacter);
    }

    private async Task VerifySignatureHelpAsync(string input, string expected, bool autoListParams = true, SignatureHelpTriggerKind? triggerKind = null)
    {
        TestFileMarkupParser.GetPosition(input, out input, out var cursorPosition);
        var document = CreateProjectAndRazorDocument(input);
        var sourceText = await document.GetTextAsync(DisposalToken);
        sourceText.GetLineAndOffset(cursorPosition, out var lineIndex, out var characterIndex);

        var clientSettingsManager = new ClientSettingsManager([], null, null);
        clientSettingsManager.Update(ClientCompletionSettings.Default with { AutoListParams = autoListParams });

        var endpoint = new CohostSignatureHelpEndpoint(RemoteServiceInvoker, clientSettingsManager, htmlDocumentSynchronizer, requestInvoker, LoggerFactory);

        var signatureHelpContext = new SignatureHelpContext()
        {
            TriggerKind = triggerKind ?? SignatureHelpTriggerKind.Invoked
        };

        var request = new SignatureHelpParams()
        {
            TextDocument = new TextDocumentIdentifier()
            {
                Uri = document.CreateUri()
            },
            Position = new Position()
            {
                Line = lineIndex,
                Character = characterIndex
            },
            Context = signatureHelpContext
        };

        var result = await endpoint.GetTestAccessor().HandleRequestAndGetLabelsAsync(request, document, DisposalToken);

        // Assert
        if (expected.Length == 0)
        {
            Assert.Null(result);
            return;
        }

        var actual = Assert.Single(result.AssumeNotNull());
        Assert.Equal(expected, actual);
    }
}
