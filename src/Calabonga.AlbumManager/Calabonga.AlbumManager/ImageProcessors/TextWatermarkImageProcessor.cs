﻿using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;
using SkiaSharp;

namespace Calabonga.AlbumsManager.ImageProcessors;

/// <summary>
/// // Calabonga: update summary (2023-12-09 08:42 DefaultImageView)
/// </summary>
public class TextWatermarkImageProcessor : IImageProcessor
{
    private const string WatermarkText = "ALBUM-MANAGER";

    public Task ProcessAsync(AlbumImage imageInfo)
    {
        if (imageInfo.OriginalBytes is null)
        {
            return Task.CompletedTask;
        }

        var skBitmap1 = SKBitmap.Decode(imageInfo.OriginalBytes);
        var skSurface = SKSurface.Create(new SKImageInfo(skBitmap1.Width, skBitmap1.Height));
        var skCanvas = skSurface.Canvas;

        var skPaintWatermark = new SKPaint();
        skPaintWatermark.Color = new SKColor(255, 255, 255, 75);

        skPaintWatermark.TextSize = 40f;
        skPaintWatermark.Typeface = SKTypeface.FromFamilyName("Arial");
        skPaintWatermark.IsAntialias = true;
        skPaintWatermark.TextAlign = SKTextAlign.Center;

        var skTextRect = new SKRect();
        var textWidth = skPaintWatermark.MeasureText(WatermarkText, ref skTextRect);
        skPaintWatermark.TextSize = 0.9f * skBitmap1.Width * skPaintWatermark.TextSize / textWidth;
        skCanvas.DrawBitmap(skBitmap1, 0, 0);
        skCanvas.DrawText(WatermarkText, (int)(skBitmap1.Width / 2), (int)(skBitmap1.Height / 2) + skTextRect.MidY, skPaintWatermark);

        var skBitmap2 = SKBitmap.FromImage(skSurface.Snapshot());
        var skData = skBitmap2.Encode(SKEncodedImageFormat.Png, 100);

        imageInfo.ProcessedBytes = skData.ToArray();

        skData.Dispose();
        skPaintWatermark.Dispose();
        skData.Dispose();
        skBitmap1.Dispose();
        skBitmap2.Dispose();
        skCanvas.Dispose();
        skSurface.Dispose();

        return Task.CompletedTask;
    }
}