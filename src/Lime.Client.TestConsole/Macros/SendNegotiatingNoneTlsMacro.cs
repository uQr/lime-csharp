﻿using System.Linq;
using Lime.Client.TestConsole.ViewModels;
using Lime.Protocol;

namespace Lime.Client.TestConsole.Macros
{
    [Macro(Name = "Send negotiating none/tls", Category = "Session", IsActiveByDefault = false, Order = 1)]
    public class SendNegotiatingNoneTlsMacro : SendTemplateMacroBase
    {
        protected override bool ShouldSendTemplate(EnvelopeViewModel envelopeViewModel)
        {
            var session = envelopeViewModel.Envelope as Session;
            if (session != null &&
                session.State == SessionState.Negotiating &&
                session.CompressionOptions != null &&
                session.CompressionOptions.Contains(SessionCompression.None) &&
                session.EncryptionOptions != null &&
                session.EncryptionOptions.Contains(SessionEncryption.TLS))
            {
                return true;
            }

            return false;
        }

        protected override string TemplateName => "Negotiating none/tls";
    }
}
