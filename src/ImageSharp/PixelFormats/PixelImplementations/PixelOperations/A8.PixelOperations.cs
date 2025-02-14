// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats;

namespace SixLabors.ImageSharp.PixelFormats;

/// <content>
/// Provides optimized overrides for bulk operations.
/// </content>
public partial struct A8
{
    /// <summary>
    /// Provides optimized overrides for bulk operations.
    /// </summary>
    internal class PixelOperations : PixelOperations<A8>
    {
        private static readonly Lazy<PixelTypeInfo> LazyInfo =
            new Lazy<PixelTypeInfo>(() => PixelTypeInfo.Create<A8>(PixelAlphaRepresentation.Unassociated), true);

        /// <inheritdoc />
        public override PixelTypeInfo GetPixelTypeInfo() => LazyInfo.Value;
    }
}
