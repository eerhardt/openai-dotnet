using OpenAI.Embeddings;
using OpenAI.Moderations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI;

[CodeGenModel("OpenAIModelFactory")]
internal static partial class OpenAIModelFactory
{
    /// <summary> Initializes a new instance of <see cref="Embeddings.EmbeddingCollection"/>. </summary>
    /// <param name="data"> The list of embeddings generated by the model. </param>
    /// <param name="model"> The name of the model used to generate the embedding. </param>
    /// <param name="usage"> The usage information for the request. </param>
    /// <returns> A new <see cref="Embeddings.EmbeddingCollection"/> instance for mocking. </returns>
    public static EmbeddingCollection EmbeddingCollection(IEnumerable<Embedding> data = null, EmbeddingTokenUsage usage = null, string model = null)
    {
        data ??= new List<Embedding>();

        return new EmbeddingCollection(data?.ToList(), model, InternalCreateEmbeddingResponseObject.List, usage, serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="Embeddings.Embedding"/>. </summary>
    /// <param name="index"> The index of the embedding in the list of embeddings. </param>
    /// <param name="vector">
    /// The embedding vector, which is a list of floats. The length of vector depends on the model as
    /// listed in the [embedding guide](/docs/guides/embeddings).
    /// </param>
    /// <returns> A new <see cref="Embeddings.Embedding"/> instance for mocking. </returns>
    public static Embedding Embedding(ReadOnlyMemory<float> vector = default, int index = default)
    {
        // TODO: Vector must be converted to base64-encoded string.
        return new Embedding(index, BinaryData.FromObjectAsJson(vector, OpenAIJsonSerializerContext.Default.ReadOnlyMemorySingle), InternalEmbeddingObject.Embedding, serializedAdditionalRawData: null);
    }

}
