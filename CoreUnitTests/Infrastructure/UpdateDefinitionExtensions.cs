using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CoreUnitTests.Infrastructure;

public static class UpdateDefinitionExtensions
{
    public static bool EquivalentTo<TDocument>(this UpdateDefinition<TDocument> update, UpdateDefinition<TDocument> expected)
    {
        var renderArgs = new RenderArgs<TDocument>(BsonSerializer.SerializerRegistry.GetSerializer<TDocument>(),
            BsonSerializer.SerializerRegistry);

        var renderedUpdate = update.Render(renderArgs);

        var renderedExpected = expected.Render(renderArgs);

        return renderedUpdate.Equals(renderedExpected);
    }
}
