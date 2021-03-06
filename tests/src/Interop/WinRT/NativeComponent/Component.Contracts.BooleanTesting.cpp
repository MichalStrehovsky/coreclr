﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
#include "pch.h"
#include "Component.Contracts.BooleanTesting.h"

namespace winrt::Component::Contracts::implementation
{
    bool BooleanTesting::And(bool left, bool right)
    {
        return left && right;
    }
}
