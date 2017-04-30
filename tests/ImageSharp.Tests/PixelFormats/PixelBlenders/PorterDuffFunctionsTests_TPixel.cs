﻿// <copyright file="PorterDuffFunctions<TPixel>Tests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests.PixelFormats.PixelBlenders
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    using ImageSharp.PixelFormats;
    using ImageSharp.PixelFormats.PixelBlenders;
    using ImageSharp.Tests.TestUtilities;
    using Xunit;

    public class PorterDuffFunctionsTests_TPixel
    {
        public static TheoryData<object, object, float, object> NormalBlendFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(0.6f, 0.6f, 0.6f, 1) },
        };

        [Theory]
        [MemberData(nameof(NormalBlendFunctionData))]
        public void NormalBlendFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.NormalBlendFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 3);
        }

        public static TheoryData<object, object, float, object> MultiplyFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(0.6f, 0.6f, 0.6f, 1) },
            {
                new TestPixel<Rgba32>(0.9f,0.9f,0.9f,0.9f),
                new TestPixel<Rgba32>(0.4f,0.4f,0.4f,0.4f),
                .5f,
                new TestPixel<Rgba32>(0.7834783f, 0.7834783f, 0.7834783f, 0.92f)
            },
        };

        [Theory]
        [MemberData(nameof(MultiplyFunctionData))]
        public void MultiplyFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.MultiplyFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }

        public static TheoryData<object, object, float, object> AddFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(.6f, .6f, .6f, 1f) },
            {
                new TestPixel<Rgba32>(0.2f,0.2f,0.2f,0.3f),
                new TestPixel<Rgba32>(0.3f,0.3f,0.3f,0.2f),
                .5f,
                new TestPixel<Rgba32>(.2075676f, .2075676f, .2075676f, .37f)
            },
        };

        [Theory]
        [MemberData(nameof(AddFunctionData))]
        public void AddFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.MultiplyFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }

        public static TheoryData<object, object, float, object> SubstractFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(0,0,0,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(1,1,1, 1f) },
            {
                new TestPixel<Rgba32>(0.2f,0.2f,0.2f,0.3f),
                new TestPixel<Rgba32>(0.3f,0.3f,0.3f,0.2f),
                .5f,
                new TestPixel<Rgba32>(.2027027f, .2027027f, .2027027f, .37f)
            },
        };

        [Theory]
        [MemberData(nameof(SubstractFunctionData))]
        public void SubstractFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.SubstractFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }

        public static TheoryData<object, object, float, object> ScreenFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(1,1,1, 1f) },
            {
                new TestPixel<Rgba32>(0.2f,0.2f,0.2f,0.3f),
                new TestPixel<Rgba32>(0.3f,0.3f,0.3f,0.2f),
                .5f,
                new TestPixel<Rgba32>(.2383784f, .2383784f, .2383784f, .37f)
            },
        };

        [Theory]
        [MemberData(nameof(ScreenFunctionData))]
        public void ScreenFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.ScreenFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }

        public static TheoryData<object, object, float, object> DarkenFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(.6f,.6f,.6f, 1f) },
            {
                new TestPixel<Rgba32>(0.2f,0.2f,0.2f,0.3f),
                new TestPixel<Rgba32>(0.3f,0.3f,0.3f,0.2f),
                .5f,
                new TestPixel<Rgba32>(.2189189f, .2189189f, .2189189f, .37f)
            },
        };

        [Theory]
        [MemberData(nameof(DarkenFunctionData))]
        public void DarkenFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.DarkenFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }

        public static TheoryData<object, object, float, object> LightenFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(1,1,1,1f) },
            {
                new TestPixel<Rgba32>(0.2f,0.2f,0.2f,0.3f),
                new TestPixel<Rgba32>(0.3f,0.3f,0.3f,0.2f),
                .5f,
                new TestPixel<Rgba32>(.227027f, .227027f, .227027f, .37f)
            },
        };

        [Theory]
        [MemberData(nameof(LightenFunctionData))]
        public void LightenFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.LightenFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }

        public static TheoryData<object, object, float, object> OverlayFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(1,1,1,1f) },
            {
                new TestPixel<Rgba32>(0.2f,0.2f,0.2f,0.3f),
                new TestPixel<Rgba32>(0.3f,0.3f,0.3f,0.2f),
                .5f,
                new TestPixel<Rgba32>(.2124324f, .2124324f, .2124324f, .37f)
            },
        };

        [Theory]
        [MemberData(nameof(OverlayFunctionData))]
        public void OverlayFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.OverlayFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }

        public static TheoryData<object, object, float, object> HardLightFunctionData = new TheoryData<object, object, float, object>() {
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(1,1,1,1), 1, new TestPixel<Rgba32>(1,1,1,1) },
            { new TestPixel<Rgba32>(1,1,1,1), new TestPixel<Rgba32>(0,0,0,.8f), .5f, new TestPixel<Rgba32>(0.6f,0.6f,0.6f,1f) },
            {
                new TestPixel<Rgba32>(0.2f,0.2f,0.2f,0.3f),
                new TestPixel<Rgba32>(0.3f,0.3f,0.3f,0.2f),
                .5f,
                new TestPixel<Rgba32>(.2124324f, .2124324f, .2124324f, .37f)
            },
        };

        [Theory]
        [MemberData(nameof(HardLightFunctionData))]
        public void HardLightFunction<TPixel>(TestPixel<TPixel> back, TestPixel<TPixel> source, float amount, TestPixel<TPixel> expected)
            where TPixel : struct, IPixel<TPixel>
        {
            TPixel actual = PorterDuffFunctions<TPixel>.HardLightFunction(back, source, amount);
            VectorAssert.Equal(expected, actual, 2);
        }
    }
}
