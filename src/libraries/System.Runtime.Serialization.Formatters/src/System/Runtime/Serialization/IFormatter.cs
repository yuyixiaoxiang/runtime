// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;

namespace System.Runtime.Serialization
{
    public interface IFormatter
    {
        [Obsolete(Obsoletions.InsecureSerializationMessage, DiagnosticId = Obsoletions.InsecureSerializationDiagId, UrlFormat = Obsoletions.SharedUrlFormat)]
        object Deserialize(Stream serializationStream);
        [Obsolete(Obsoletions.InsecureSerializationMessage, DiagnosticId = Obsoletions.InsecureSerializationDiagId, UrlFormat = Obsoletions.SharedUrlFormat)]
        void Serialize(Stream serializationStream, object graph);
        ISurrogateSelector? SurrogateSelector { get; set; }
        SerializationBinder? Binder { get; set; }
        StreamingContext Context { get; set; }
    }
}
