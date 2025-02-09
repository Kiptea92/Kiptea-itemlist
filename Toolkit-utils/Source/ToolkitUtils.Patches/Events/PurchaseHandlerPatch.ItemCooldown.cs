﻿// MIT License
// 
// Copyright (c) 2022 SirRandoo
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using SirRandoo.ToolkitUtils.Models;
using TwitchToolkit.Store;

namespace SirRandoo.ToolkitUtils.Patches;

internal partial class PurchaseHandlerPatch
{
    [HarmonyPostfix]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "RedundantAssignment")]
    [HarmonyPatch(typeof(Purchase_Handler), nameof(Purchase_Handler.CheckIfCarePackageIsOnCooldown))]
    private static void CheckIfCarePackageIsOnCooldownPostfix(string username, ref bool __result)
    {
        if (__result)
        {
            return;
        }

        EventItem itemEvent = Data.Events.Find(e => string.Equals(e.DefName, IncidentDefOf.Item.defName));

        __result = itemEvent != null && UsageService.IsOnCooldown(itemEvent, username);
    }
}